using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public AppUser Commenter { get; set; }
        public DateTime CommentDate { get; set; }
        public int ReviewId { get; set; }  // FK, enable cascade delete
    }
}
