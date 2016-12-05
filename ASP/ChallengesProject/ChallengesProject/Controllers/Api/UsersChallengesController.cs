using ChallengesProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChallengesProject.Controllers.Api
{
    public class UsersChallengesController : ApiController
    {
        private UsersChallengesService userChallengesService;
        private ChallengesService challengesService;
        
        public UsersChallengesController(UsersChallengesService userChallengesService, ChallengesService challengeService) : base()
        {
            this.userChallengesService = userChallengesService;
            this.challengesService = challengeService;
        }

        // POST: UsersChallenges/MyChallenges
        [HttpPost]
        [Authorize]
        public HttpResponseMessage MyChallenges(int id)
        {
            var challenge = challengesService.Find(id);
            if (challenge == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                var userChallenge = userChallengesService.AddChallengeMyself(User.Identity.GetUserId(), challenge);                
                return Request.CreateResponse(
                    HttpStatusCode.OK, 
                    new
                    {
                        ChallengeId = userChallenge.ChallengeId,
                        Status = userChallenge.Status,
                        StartedOn = userChallenge.StartedOn
                    }
                );
            }
            catch {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred! Have you already challenged yourself?");
            }
        }
    }
}
