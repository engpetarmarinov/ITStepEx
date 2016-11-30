using ChallengesProject.Data;
using ChallengesProject.Models;

namespace ChallengesProject.Services
{
    public class ChallengesService : BaseService<Challenge>
    {
        public ChallengesService(IChallengesData data) : base(data)
        {
        }
    }

}