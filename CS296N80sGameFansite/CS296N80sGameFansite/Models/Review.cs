using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CS296N80sGameFansite.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public String GameName { get; set; }
        public String Genre { get; set; }
        public AppUser Reviewer { get; set; }

        [StringLength(500, MinimumLength = 10)]
        [Required]
        public String ReviewText { get; set; }
        
        [Range(1,5)]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReviewDate { get; set; }
        public ICollection<Comment> Comments {get;}
    }
}
