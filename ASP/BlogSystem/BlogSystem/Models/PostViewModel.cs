using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set;  }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        public string UserName { get; set; }
    }
}