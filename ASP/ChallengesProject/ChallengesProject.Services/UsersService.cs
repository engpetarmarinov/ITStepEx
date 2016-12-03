using ChallengesProject.Data;
using ChallengesProject.Models;

namespace ChallengesProject.Services
{
    public class UsersService : BaseService<ApplicationUser>
    {
        public UsersService(IChallengesData data) : base(data)
        {
        }        
    }
}