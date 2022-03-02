using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CS296N80sGameFansite.Models
{
    public class AdminVM
    {
        public IEnumerable<AppUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
