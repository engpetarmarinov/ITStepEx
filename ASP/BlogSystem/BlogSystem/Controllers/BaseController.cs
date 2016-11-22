using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;

namespace BlogSystem.Controllers
{
    public class BaseController : Controller
    {
        protected BlogSystemDbContext Data { get; set; }

        public BaseController() : this(new BlogSystemDbContext()) //Poor man injection
        {
            
        }

        public BaseController(BlogSystemDbContext context)
        {
            Data = context;
        }
    }
}