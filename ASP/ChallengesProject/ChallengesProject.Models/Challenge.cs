using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesProject.Models
{
    public class Challenge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Path to the cover image of the challenge
        /// </summary>
        public string Image { get; set; }

        public int Duration { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
