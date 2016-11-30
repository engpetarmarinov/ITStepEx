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
        public ActionResult Index()
        {
            //just test services
            var challenges = challengesService.GetAll()?.ProjectTo<ChallengeViewModel>().ToList();
            var challengesFiltered = challengesService.Get(
                    orderBy: cs => cs.OrderByDescending(c => c.Created),
                    includeProperties: "Name"
                )?.ProjectTo<ChallengeViewModel>().ToList();

            return View(challenges);
        }

        // GET: Challenges/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

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
    }
}