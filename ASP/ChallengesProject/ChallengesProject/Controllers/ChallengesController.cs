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

        public ChallengesController(ChallengesService service) : base()
        {
            challengesService = service;
        }

        // GET: Challenges
        public ActionResult Index(int? page = 1)
        {
            ViewBag.ImagesPath = ImagesPath;
            //TODO: add limit
            var challenges = challengesService.Get(
                    //filter:
                    orderBy: cs => cs.OrderByDescending(c => c.Created),
                    includeProperties: "Name"
                )?.ProjectTo<ChallengeViewModel>().ToList();
            
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(challenges.ToPagedList(pageNumber, pageSize));            
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
            return View(challengeView);
        }
    }
}