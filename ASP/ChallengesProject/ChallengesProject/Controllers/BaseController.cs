﻿using ChallengesProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChallengesProject.Controllers
{
    public class BaseController : Controller
    {
        public IChallengesData Data { get; set; }

        public BaseController()
        {

        }
    }
}