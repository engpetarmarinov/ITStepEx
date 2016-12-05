using ChallengesProject.Data;
using ChallengesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChallengesProject.Services
{
    public class UsersChallengesService : BaseService<UsersChallenges>
    {
        public UsersChallengesService(IChallengesData data) : base(data)
        {
        }

        public UsersChallenges AddChallengeMyself(string userId, Challenge challenge)
        {
            var userChallenge = new UsersChallenges()
            {
                ChallengeId = challenge.Id,
                FromUserId = userId,
                ToUserId = userId,
                StartedOn = DateTime.Now,
                Status = UsersChallenges.StatusType.Accepted
            };

            base.Add(userChallenge);
            base.SaveChanges();
            return userChallenge;
        }

        public UsersChallenges AddChallengeUser(string fromUserId, string toUserId, Challenge challenge)
        {
            var userChallenge = new UsersChallenges()
            {
                ChallengeId = challenge.Id,
                FromUserId = fromUserId,
                ToUserId = toUserId,
                StartedOn = DateTime.Now,
                Status = UsersChallenges.StatusType.Pending
            };

            base.Add(userChallenge);
            base.SaveChanges();
            return userChallenge;
        }
    }
}
