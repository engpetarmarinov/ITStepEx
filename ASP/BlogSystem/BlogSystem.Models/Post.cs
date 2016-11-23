using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
