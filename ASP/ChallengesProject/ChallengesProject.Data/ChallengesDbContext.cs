using Microsoft.AspNet.Identity.EntityFramework;
using ChallengesProject.Models;

namespace ChallengesProject.Data
{
    public class ChallengesDbContext : IdentityDbContext
    {
        public System.Data.Entity.DbSet<Challenge> Challenges { get; set; }

        public ChallengesDbContext() : this(new DebugLogger())
        {

        }

        public ChallengesDbContext(ILogger logger) : base("ChallengesDbConnection")
        {
            //Add custom logger
            this.Database.Log += logger.Log;
        }

        public static ChallengesDbContext Create()
        {
            return new ChallengesDbContext();
        }
    }
}
