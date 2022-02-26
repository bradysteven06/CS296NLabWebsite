using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class Played
    {
        [Key]
        public int GameID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")] // validation check with error message
        [StringLength(40, ErrorMessage = "Please enter a shorter name. I can't remember one that long.")] // validation check with error message
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter year released.")] // validation check with error message
        [Range(1980, 1989, ErrorMessage = "Please enter a year from 1980 to 1989.")] // validation check with error message
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter platform of game.")] // validation check with error message
        public string Platform { get; set; }
    }
}
