using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public HttpPostedFileBase ImageFIle { get; set; }

        public string Image { get; set; }

        public int Duration { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }
    }
}