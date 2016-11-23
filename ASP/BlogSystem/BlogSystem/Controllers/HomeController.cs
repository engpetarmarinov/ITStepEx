using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Response.Write("sadsad");
            var posts = Data.Posts.Take(3).ToList();
            return View(posts);
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