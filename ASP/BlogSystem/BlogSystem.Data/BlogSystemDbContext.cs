using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogSystemDbContext() : base("BlogSystemConnection")
        {
            
        }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }

        public System.Data.Entity.DbSet<BlogSystem.Models.Post> Posts { get; set; }
    }
}
