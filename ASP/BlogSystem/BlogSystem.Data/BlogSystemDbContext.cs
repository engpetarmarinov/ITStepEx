using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;
using System.Web.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        protected static SqlConnection DbConnection;

        public BlogSystemDbContext() : base("BlogSystemConnection", false)
        {
            //Register DB logger
            this.Database.Log += Logger.Log;
        }

        //Try to reuse existing connection to the DB
        public BlogSystemDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection)
        {
            //Register DB logger
            this.Database.Log += Logger.Log;
        }

        public static BlogSystemDbContext Create()
        {
            //Try to reuse the connection
            //if (DbConnection == null)
            //{
            //    //conn
            //    var connStr = WebConfigurationManager.ConnectionStrings["BlogSystemConnection"].ConnectionString;
            //    DbConnection = new SqlConnection(connStr);
            //    DbConnection.Open();
            //}
            //return new BlogSystemDbContext(DbConnection, true);
            return new BlogSystemDbContext();
        }

        public System.Data.Entity.DbSet<BlogSystem.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<BlogSystem.Models.Comment> Comments { get; set; }
        
    }
}
