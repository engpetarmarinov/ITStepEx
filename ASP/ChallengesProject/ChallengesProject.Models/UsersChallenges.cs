using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesProject.Models
{
    public class UsersChallenges
    {
        public int Id { get; set; }

        [Index("UQ_UsersChallenges_FromToUserId", 1, IsUnique = true)]
        public int ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }

        [Index("UQ_UsersChallenges_FromToUserId", 2, IsUnique = true)]
        public string FromUserId { get; set; }
        public virtual ApplicationUser FromUser { get; set; }

        [Index("UQ_UsersChallenges_FromToUserId", 3, IsUnique = true)]
        public string ToUserId { get; set; }
        public virtual ApplicationUser ToUser { get; set; }

        public StatusType Status { get; set; }

        public enum StatusType {
            Pending,
            Accepted,
            Declined
        }

        public DateTime? StartedOn { get; set; }
    }
}
