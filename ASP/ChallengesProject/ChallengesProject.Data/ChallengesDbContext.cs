using Microsoft.AspNet.Identity.EntityFramework;
using ChallengesProject.Models;

namespace ChallengesProject.Data
{
    public class ChallengesDbContext : IdentityDbContext
    {
        public System.Data.Entity.DbSet<Challenge> Challenges { get; set; }

        public System.Data.Entity.DbSet<UsersChallenges> UsersChallenges { get; set; }

        //Default constructor for migrations       
        public ChallengesDbContext() : base("ChallengesDbConnection") 
        {
        }

        public ChallengesDbContext(ILogger logger) : base("ChallengesDbConnection")
        {
            //Add custom logger
            this.Database.Log += logger.Log;
        }
    }
}
