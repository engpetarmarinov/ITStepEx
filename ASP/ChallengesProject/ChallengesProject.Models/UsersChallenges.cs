using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesProject.Models
{
    public class UsersChallenges
    {
        public int Id { get; set; }

        public int ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }

        public string FromUserId { get; set; }
        public virtual ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }
        public virtual ApplicationUser ToUser { get; set; }

        public int Status { get; set; }

        public DateTime? StartedOn { get; set; }
    }
}
