using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChallengesProject.Services;
using ChallengesProject.Data;
using AutoMapper.QueryableExtensions;
using ChallengesProject.ViewModels;

namespace ChallengesProject.Controllers
{
    public class HomeController : BaseController
    {
        private ChallengesService challengesService;
                
        public HomeController(ChallengesService service) : base()
        {
            challengesService = service;
        }

        public ActionResult Index()
        {
            var challenges = challengesService.GetAll()?.ProjectTo<ChallengeViewModel>().ToList();
            var challengesFiltered = challengesService.Get(
                    orderBy: cs => cs.OrderByDescending(c => c.Created),
                    includeProperties: "Name"
                )?.ProjectTo<ChallengeViewModel>().ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}