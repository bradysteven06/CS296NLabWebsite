using System;


namespace CS296N80sGameFansite.Models
{
    public class CommentVM
    {
        public int ReviewId { get; set; }    // This identifies the reivew being commented on
        public int GameName { get; set; }
        public String CommentText { get; set; }
    }
}
