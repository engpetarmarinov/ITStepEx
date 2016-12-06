using System.ComponentModel.DataAnnotations;
using ChallengesProject.Attributes;

namespace ChallengesProject.ViewModels
{
    public class FacebookFriendViewModel
    {
        [Required]
        [FacebookMapping("id")]
        public string TaggingId { get; set; }

        [Required]
        [Display(Name = "Friend's Name")]
        [FacebookMapping("name")]
        public string Name { get; set; }

        [FacebookMapping("url", parent = "picture")]
        public string ImageURL { get; set; }
    }
}