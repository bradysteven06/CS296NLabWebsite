using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class WantToPlayContext : DbContext
    {
        public WantToPlayContext(DbContextOptions<WantToPlayContext> options) : base(options) { }

        public DbSet<GameInfoModel> GameInfo { get; set; }

        // Adds initial value to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameInfoModel>().HasData(
                new GameInfoModel { GameID = 1, Name = "Tetris", Year = 1989, Platform = "Nintendo" },
                new GameInfoModel { GameID = 2, Name = "Donkey Kong", Year = 1981, Platform = "Arcade" }
                );
        }
    }
}
