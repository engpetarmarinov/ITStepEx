using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengesProject.ViewModels
{
    public class ChallengeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Duration { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }
    }
}