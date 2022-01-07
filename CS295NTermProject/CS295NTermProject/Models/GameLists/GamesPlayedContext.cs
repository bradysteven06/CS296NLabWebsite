using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295NTermProject.Models
{
    public class GamesPlayedContext : DbContext
    {
        public GamesPlayedContext(DbContextOptions<GamesPlayedContext> options) : base(options) { }

        public DbSet<GameInfoModel> GameInfo { get; set; }

        // Adds initial value to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameInfoModel>().HasData(
                new GameInfoModel { GameID = 1, Name = "Asteroids", ReleaseDate = "11/1979", Platform = "Arcade" }
                );
        }
    }
}
