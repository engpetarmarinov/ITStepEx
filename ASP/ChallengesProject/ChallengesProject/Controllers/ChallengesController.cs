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
        private ChallengesService challengesService;

        public ChallengesController(ChallengesService service) : base()
        {
            challengesService = service;
        }

        // GET: Challenges
        public ActionResult Index(int? page = 1)
        {
            var challenges = challengesService.Get(
                    orderBy: cs => cs.OrderByDescending(c => c.Created),
                    includeProperties: "Name"
                )?.ProjectTo<ChallengeViewModel>().ToList();


            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //return View(challenges.ToPagedList(pageNumber, pageSize));
            return View(challenges);
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
                // Use your file here
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    challengeViewModel.ImageFIle?.InputStream.CopyTo(memoryStream);
                }
                challengeViewModel.Created = DateTime.Now;
                challengeViewModel.UserId = User.Identity.GetUserId();
                //TODO: resieze, save image, get patt, save to DB
                //challengeViewModel.Image = "path to the image"
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