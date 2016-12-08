using AutoMapper.QueryableExtensions;
using ChallengesProject.Services;
using ChallengesProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ChallengesProject.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using PagedList;

namespace ChallengesProject.Controllers
{
    public class ChallengesController : BaseController
    {
        const string ImagesPath = "~/images/challenges/";
        private ChallengesService challengesService;
        private UsersChallengesService userChallengesService;

        public ChallengesController(ChallengesService service, UsersChallengesService userChallengesService) : base()
        {
            challengesService = service;
            this.userChallengesService = userChallengesService;
        }

        // GET: Challenges
        public ActionResult Index(int? page = 1)
        {
            var challenges = GetChallengesPage(page);
            //Pass the action name to the partial view
            ViewBag.ActionName = "Challenges";
            ViewBag.ImagesPath = ImagesPath;
            return View(challenges);
        }

        // GET: Challenges/Challenges - Used for Index Pagination
        public ActionResult Challenges(int? page = 1)
        {
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Index/"+ page);
            }
            var challenges = GetChallengesPage(page);
            //Pass the action name to the partial view
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            ViewBag.ActionName = actionName;
            ViewBag.ImagesPath = ImagesPath;
            return PartialView("_ListChallengesPanelsPartial", challenges);
        }

        public IPagedList<ChallengeViewModel> GetChallengesPage(int? page, int? perPage = 2)
        {
            var challenges = challengesService
                .GetChallengesOrderedByDate()?
                .ProjectTo<ChallengeViewModel>();//ToList(); -- Do not invoke ToList here, ToPagedList will put limit and offset
            int pageSize = perPage ?? 2;
            int pageNumber = (page ?? 1);
            return challenges?.ToPagedList(pageNumber, pageSize);
        }

        // GET: Challenges/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Challenges/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(ChallengeViewModel challengeViewModel)
        {
            if (ModelState.IsValid)
            {
                challengeViewModel.Created = DateTime.Now;
                challengeViewModel.UserId = User.Identity.GetUserId();
                //TODO: resieze uploaded image
                // Save uploaded pic
                if (challengeViewModel.ImageFile != null)
                {
                    var picName = challengesService.GenerateImageName(challengeViewModel.ImageFile.FileName);
                    var subfolder = challengesService.GenerateSubfolderName(User.Identity.GetUserId());
                    string path = Path.Combine(Server.MapPath(ImagesPath), subfolder);
                    // upload file
                    challengesService.SaveFile(challengeViewModel.ImageFile, path, picName);
                    // save file path
                    challengeViewModel.Image = Path.Combine(subfolder, picName);
                }
                var challenge = Mapper.Map<Challenge>(challengeViewModel);
                challengesService.Add(challenge);
                challengesService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(challengeViewModel);
        }

        // GET: Challenges/Details/{id}
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var challenge = challengesService.Find(id);
            if (challenge == null) {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var challengeView = Mapper.Map<ChallengeViewModel>(challenge);

            //get challenged users
            challengeView.UsersChallenged = userChallengesService
                .Get(filter: uc => uc.ChallengeId == id)
                .ProjectTo<UsersChallengesViewModel>()
                .ToList();

            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                challengeView.MyselfChallenged = userChallengesService
                    .Get(filter: uc => uc.ChallengeId == id && uc.ToUserId == userId)
                    .ProjectTo<UsersChallengesViewModel>()
                    .FirstOrDefault();
            }

            return View(challengeView);
        }
                

        // GET: Challenges/My
        [HttpGet]
        [Authorize]
        public ActionResult My(int? page)
        {
            var challenges = GetMyChallenges(page);
            //Pass the action name to the partial view
            ViewBag.ActionName = "MyChallenges";
            return View(challenges);
        }

        // GET: Challenges/MyChallenges - used for AJAX pagination
        [HttpGet]
        [Authorize]        
        public ActionResult MyChallenges(int? page)
        {
            var challenges = GetMyChallenges(page);
            //Pass the action name to the partial view
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            ViewBag.ActionName = actionName;
            return PartialView("_ListChallengesPanelsPartial", challenges);
        }

        private IPagedList<ChallengeViewModel> GetMyChallenges(int? page)
        {
            var challenges = challengesService.GetUserChallenges(User.Identity.GetUserId())
                .ProjectTo<ChallengeViewModel>();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return challenges.ToPagedList(pageNumber, pageSize);
        }
    }
}