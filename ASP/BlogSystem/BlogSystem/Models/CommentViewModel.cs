using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Коментар")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        public int PostId { get; set; }
    }
}