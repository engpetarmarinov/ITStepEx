using AutoMapper.QueryableExtensions;
using ChallengesProject.Services;
using ChallengesProject.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChallengesProject.Controllers
{
    public class UsersController : BaseController
    {

        private UsersService usersService;

        public UsersController(UsersService service) : base()
        {
            usersService = service;
        }

        // GET: Users
        public ActionResult Index(int? page)
        {
            var users = usersService.Get(orderBy: us => us.OrderBy(u => u.UserName))
                .ProjectTo<UserViewModel>()
                .ToList();
            var pageSize = 10;
            var pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }
    }
}