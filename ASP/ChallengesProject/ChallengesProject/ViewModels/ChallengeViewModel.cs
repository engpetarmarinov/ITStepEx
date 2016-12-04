using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ChallengesProject.Helpers;

namespace ChallengesProject.ViewModels
{
    public class ChallengeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name of the challenge")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [ValidateImage(maxSize: 2, errorMessage: "The image file must be jpg or png and not larger than {0} MB.")]
        public HttpPostedFileBase ImageFile { get; set; }

        public string Image { get; set; }

        public int Duration { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}