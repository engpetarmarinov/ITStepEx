using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using ChallengesProject.Services;
using ChallengesProject.Controllers;
using System;

namespace ChallengesProject.Attributes
{
    public class FacebookAccessTokenAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var accountController = filterContext.Controller as AccountController;

            if (accountController == null)
            {
                throw new InvalidOperationException("This attribute is not used on AccountController!");
            }

            ApplicationUserManager _userManager = accountController.UserManager;

            if (_userManager != null)
            {
                var claimsforUser = _userManager.GetClaimsAsync(filterContext.HttpContext.User.Identity.GetUserId());
                var access_token = claimsforUser.Result.FirstOrDefault(x => x.Type == "FacebookAccessToken").Value;

                if (filterContext.HttpContext.Items.Contains("access_token"))
                    filterContext.HttpContext.Items["access_token"] = access_token;
                else
                    filterContext.HttpContext.Items.Add("access_token", access_token);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}