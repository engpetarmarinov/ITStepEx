using System;

namespace BlogSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
