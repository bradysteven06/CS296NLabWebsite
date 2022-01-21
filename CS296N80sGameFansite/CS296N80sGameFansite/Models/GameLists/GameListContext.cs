﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class GameListContext : IdentityDbContext
    {
        public GameListContext(DbContextOptions<GameListContext> options) : base(options) { }

        public DbSet<Played> PlayedInfo { get; set; }
        public DbSet<WantToPlay> WantToPlayInfo { get; set; }

        // Adds initial values to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set primary keys
            modelBuilder.Entity<Played>().HasKey(played => new { played.GameID });
            modelBuilder.Entity<WantToPlay>().HasKey(wantToPlay => new { wantToPlay.GameID });

            // Seed initial data
            modelBuilder.ApplyConfiguration(new SeedPlayed());
            modelBuilder.ApplyConfiguration(new SeedWantToPlay());

            /*modelBuilder.Entity<Played>().HasData(
                new Played { GameID = 1, Name = "Tetris", Year = 1989, Platform = "Nintendo" },
                new Played { GameID = 2, Name = "Donkey Kong", Year = 1981, Platform = "Arcade" }
                );

            modelBuilder.Entity<WantToPlay>().HasData(
                new WantToPlay { GameID = 1, Name = "Tetris", Year = 1989, Platform = "Nintendo" },
                new WantToPlay { GameID = 2, Name = "Test", Year = 1981, Platform = "Testrix" }
                );*/
        }
    }
}
