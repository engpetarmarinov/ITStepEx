using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChallengesProject.Data
{
    public class ChallengesDbContext : IdentityDbContext
    {
        public ChallengesDbContext() : base("ChallengesDbConnection")
        {
            //Add custom logger
            //this.Database.Log += Logger.Log;
        }

        public static ChallengesDbContext Create()
        {
            return new ChallengesDbContext();
        }
    }
}
