using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class SeedUsers
    {
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
    }
}
