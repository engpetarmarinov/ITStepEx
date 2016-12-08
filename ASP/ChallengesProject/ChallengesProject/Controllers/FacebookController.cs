using System;
using System.Web.Mvc;
using ChallengesProject.Attributes;
using System.Configuration;
using Facebook;
using System.Threading.Tasks;
using ChallengesProject.Extensions;
using System.Web;
using ChallengesProject.ViewModels;
using System.Collections.Generic;
using ChallengesProject.Services;

namespace ChallengesProject.Controllers
{
    [Authorize]
    [FacebookAccessToken]
    public class FacebookController : AccountController
    {

        public FacebookController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) : base(userManager, signInManager)
        {
        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("ExternalCallBack", "Facebook");
                return uriBuilder.Uri;
            }
        }

        private RedirectResult GetFacebookLoginURL()
        {

            if (Session["AccessTokenRetryCount"] == null ||
                (Session["AccessTokenRetryCount"] != null &&
                 Session["AccessTokenRetryCount"].ToString() == "0"))
            {
                Session.Add("AccessTokenRetryCount", "1");

                FacebookClient fb = new FacebookClient();
                fb.AppId = ConfigurationManager.AppSettings["Facebook_AppId"];
                return Redirect(fb.GetLoginUrl(new
                {
                    scope = ConfigurationManager.AppSettings["Facebook_Scope"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    response_type = "code"
                }).ToString());
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to obtain a valid Facebook Token, contact support";
                return Redirect(Url.Action("Index", "Error"));
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is FacebookApiLimitException)
            {
                //Status message banner notifying user to try again later
                filterContext.ExceptionHandled = true;
                ViewBag.GlobalStatusMessage = "Facebook Graph API limit reached, Please try again later...";
            }
            else if (filterContext.Exception is FacebookOAuthException)
            {
                FacebookOAuthException OAuth_ex = (FacebookOAuthException)filterContext.Exception;
                if (OAuth_ex.ErrorCode == 190 || OAuth_ex.ErrorSubcode > 0)
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = GetFacebookLoginURL();
                }
                else
                {
                    //redirect to Facebook Custom Error Page
                    ViewBag.ErrorMessage = filterContext.Exception.Message;
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = RedirectToAction("Index", "Error");
                }

            }
            else if (filterContext.Exception is FacebookApiException)
            {
                //redirect to Facebook Custom Error Page
                ViewBag.ErrorMessage = filterContext.Exception.Message;
                filterContext.ExceptionHandled = true;
                filterContext.Result = RedirectToAction("Index", "Error");
            }
            else
                base.OnException(filterContext);
        }

        public async Task<ActionResult> FB_TaggableFriends()
        {
            //get the access token
            var accessToken = HttpContext.Items["access_token"]?.ToString();
            if (accessToken != null)
            {
                //generate app secret prrof
                var appsecretProof = accessToken.GenerateAppSecretProof();

                var fb = new FacebookClient(accessToken);
                //make the graph call
                dynamic myInfo = await fb.GetTaskAsync("me/taggable_friends".GraphAPICall(appsecretProof));
                var friendsList = new List<FacebookFriendViewModel>();
                foreach (dynamic friend in myInfo.data)
                {
                    //Mapping with the dynamic extension
                    friendsList.Add(DynamicExtension.ToStatic<FacebookFriendViewModel>(friend));
                }

                return PartialView(friendsList);
            }
            else
            {
                return PartialView("_ExternalLoginsListPartial", new ExternalLoginListViewModel());
            }
        }


    }
}