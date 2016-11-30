using ChallengesProject.Data.Repositories;
using ChallengesProject.Models;

namespace ChallengesProject.Data
{
    public interface IChallengesData
    {
        IRepository<Challenge> Challenges{ get; }
        IRepository<ApplicationUser> Users{ get; }

        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}