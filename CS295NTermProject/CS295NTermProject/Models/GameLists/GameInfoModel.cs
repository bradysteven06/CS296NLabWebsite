using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS295NTermProject.Models
{
    public class GameInfoModel
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
