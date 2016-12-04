using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengesProject.ViewModels
{
    public class UsersChallengesViewModel
    {

        public int Id { get; set; }

        public int ChallengeId { get; set; }

        public virtual ChallengeViewModel Challenge { get; set; }
        
        public virtual UserViewModel FromUser { get; set; }
        
        public virtual UserViewModel ToUser { get; set; }

        public int Status { get; set; }

        public DateTime? StartedOn { get; set; }
    }
}