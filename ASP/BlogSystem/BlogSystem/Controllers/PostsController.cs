using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;
using Microsoft.AspNet.Identity;
using AutoMapper.QueryableExtensions;

namespace BlogSystem.Controllers
{
    public class PostsController : BaseController
    {

        // GET: Posts
        public ActionResult Index()
        {
            //Use AutoMapper to map Post -> PostViewModel
            var posts = Data.Posts.ProjectTo<PostViewModel>().ToList();
            return View(posts);
            //Use manual mapping Post -> PostViewModel
            //return View(Data.Posts.Select(p => new PostViewModel()
            //{
            //    Id = p.Id,
            //    Content = p.Content,
            //    Name = p.Name,
            //    UserName = p.User.UserName
            //}).ToList());

        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Get the post
            Post post = Data.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            //Get comments
            //var comments = Data.Comments
            //    .Where(c => c.PostId == post.Id)
            //    .Select(c => new CommentViewModel()
            //    {
            //        Id = c.Id,
            //        Content = c.Content,
            //        Date = c.Date,
            //        UserName = (c.UserId)
            //    }).ToList();

            var comments = (from c in Data.Comments
                join u in Data.Users on c.UserId equals u.Id
                where c.PostId == post.Id
                orderby c.Date descending
                select new CommentViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    Date = c.Date,
                    UserName = u.UserName
                }).Take(10).ToList();

            //Create the view model
            PostViewModel viewPost = new PostViewModel()
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                UserName = User.Identity.GetUserName(),
                Comments = comments
            };

            return View(viewPost);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Date = DateTime.Now;
                post.UserId = User.Identity.GetUserId();
                Data.Posts.Add(post);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Post post = Data.Posts.Select(p => new PostViewModel()
            //{
            //    Name = p.Name,
            //    Content = p.Content,
            //    UserName = p.User.UserName
            //}).Find(id);

            Post post = Data.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Name,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                //Chain syntax
                var oldPost = Data.Posts.FirstOrDefault(p => p.Id == post.Id);
                //SQL like syntax
                //var oldPost = (from p in Data.Posts
                //    where p.Id == post.Id
                //    select new Post()).Take(1);

                oldPost.Name = post.Name;
                oldPost.Content = post.Content;
                Data.Entry(oldPost).State = EntityState.Modified;
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = Data.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = Data.Posts.Find(id);
            Data.Posts.Remove(post);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Data.Dispose();
            }
            base.Dispose(disposing);
        }


        // POST: Posts/Details
        [HttpPost]
        [ActionName("Details")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CreateComment([Bind(Include = "PostId,Content")] CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment()
                {
                    PostId = comment.PostId,
                    Content = comment.Content,
                    Date = DateTime.Now,
                    UserId = User.Identity.GetUserId(),

                };
                Data.Comments.Add(newComment);
                Data.SaveChanges();
                return RedirectToAction("Details", new { id = comment.PostId });
            }

            return Details(comment.PostId);
        }
    }
}
