using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public static class SeedData
    {
        private const string ID1 = "A";
        private const string ID2 = "B";
        private const string ID3 = "C";
        private const string ID4 = "D";

        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            // TODO: Remove the user name and password from source code
            const string USER_NAME = "admin";
            const string SCREEN_NAME = "Admin";
            const string PASS_WORD = "Secret!123";
            const string ROLE_NAME = "Admin";

            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(ROLE_NAME) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ROLE_NAME));
            }
            // if username doesn't exist, create it and add it to role if (await userManager.FindByNameAsync(username) == null) { User user = new User { UserName = username }; var result = await userManager.CreateAsync(user, password); if (result.Succeeded) {
            if (await userManager.FindByNameAsync(USER_NAME) == null)
            {
                var user = new AppUser { UserName = USER_NAME, Name = SCREEN_NAME };
                var result = await userManager.CreateAsync(user, PASS_WORD);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ROLE_NAME);
                }
            }
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Create four AppUsers who will be reviewers
            var user1 = new AppUser()
            {
                Id = ID1,
                Name = "Steven Brady",
                UserName = "StevenB"
            };
            var user2 = new AppUser()
            {
                Id = ID2,
                Name = "Emma Watson",
                UserName = "EmmaW"
            };
            var user3 = new AppUser
            {
                Id = ID3,
                Name = "Daniel Radcliffe",
                UserName = "DanielR"
            };
            var user4 = new AppUser
            {
                Id = ID4,
                Name = "Scarlett Johansson",
                UserName = "ScarlettJ"
            };

            // Add the three AppUsers to the database
            modelBuilder.Entity<AppUser>().HasData(
                user1, user2, user3, user4
            );

            // Create and add four reviews to the database
            modelBuilder.Entity<Review>().HasData(
                new
                {
                    ReviewId = 1,
                    ReviewerId = ID1,      // Shadow FK
                    GameName = "Tetris",
                    Genre = "Puzzle",
                    ReviewText = "Great game, a must play!",
                    ReviewDate = DateTime.Parse("11/1/2020"),
                    Rating = 5
                },
                new
                {
                    ReviewId = 2,
                    ReviewerId = ID3,      // Shadow FK
                    GameName = "Pacman",
                    Genre = "Platform",
                    ReviewText = "Great game, a must play!",
                    ReviewDate = DateTime.Parse("11/1/2020"),
                    Rating = 5
                },
                new
                {
                    ReviewId = 3,
                    ReviewerId = ID4,      // Shadow FK
                    GameName = "Tetris",
                    Genre = "Puzzle",
                    ReviewText = "Great game, a must play!",
                    ReviewDate = DateTime.Parse("11/1/2020"),
                    Rating = 5
                },
                new
                {
                    ReviewId = 4,
                    ReviewerId = ID2,      // Shadow FK
                    GameName = "Donkey Kong",
                    Genre = "Platformer",
                    ReviewText = "Great game, a must play!",
                    ReviewDate = DateTime.Parse("11/1/2020"),
                    Rating = 4
                }
            );

            // Create and add comments to the database.

            // These must be untyped objects because they use "shadow" FK preoperties
            // which are in the tables created by EF but not in the domain model.

            modelBuilder.Entity<Comment>().HasData(
                new
                {
                    CommentId = 1,
                    CommentText = "I loved that game too!",
                    CommentDate = DateTime.Parse("11/5/2020"),
                    CommenterId = ID1,     // "shadow" FK 
                    ReviewId = 3
                },

                new
                {
                    CommentId = 2,
                    CommentText = "Great game.",
                    CommentDate = DateTime.Parse("12/3/2020"),
                    CommenterId = ID3,
                    ReviewId = 2
                },

                new
                {
                    CommentId = 3,
                    CommentText = "So nostalgic",
                    CommentDate = DateTime.Parse("1/15/2021"),
                    CommenterId = ID2,
                    ReviewId = 1
                },

                 new
                 {
                     CommentId = 4,
                     CommentText = "Lots of fun.",
                     CommentDate = DateTime.Parse("10/15/2021"),
                     CommenterId = ID2,
                     ReviewId = 4
                 },

                new
                {
                    CommentId = 5,
                    CommentText = "Can't stop playing.",
                    CommentDate = DateTime.Parse("2/1/2021"),
                    CommenterId = ID1,
                    ReviewId = 2
                }
             );
        }
    }
}
