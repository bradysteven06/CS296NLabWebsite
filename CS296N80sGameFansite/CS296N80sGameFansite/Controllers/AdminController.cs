﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CS296N80sGameFansite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IPlayedRepository playedRepo;
        private IWantToPlayRepository wantToPlayRepo;

        public AdminController(UserManager<AppUser> userMngr,
                                RoleManager<IdentityRole> roleMngr,
                                IPlayedRepository pRepo, IWantToPlayRepository wRepo)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            playedRepo = pRepo;
            wantToPlayRepo = wRepo;
        }

        /// <summary>
        /// Get a list of all users. Each user will have a list of their
        /// roles in the AppUser.RoleNames property
        /// </summary>
        /// <returns>ViewResult</returns>
        public async Task<IActionResult> Index()
        {
            // Modified this loop from the version in Murach to prevent "data reader already open" errors
            List<AppUser> users = userManager.Users.ToList();
            foreach (AppUser user in users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
            }

            AdminVM model = new AdminVM
            {
                Users = users, // List of AppUsers
                Roles = roleManager.Roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            /*IdentityResult result = null;*/
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Check to see if the user has posted a review
                /*if (0 == (from r in reviewRepo.Reviews
                            where r.Reviewer.Name == user.Name
                            select r).Count<Review>())
                {

                    result = await userManager.DeleteAsync(user);
                }
                else
                {
                    result = IdentityResult.Failed(new IdentityError()
                    { Description = "User's reviews must be deleted first" });
                }

                if (!result.Succeeded)
                {
                    // if failed 
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += errorMessage != "" ? " | " : "";   // put a separator between messages
                        errorMessage += error.Description;
                    }
                    TempData["message"] = errorMessage;
                }
                else
                {
                    TempData["message"] = "";  // No errors, clear the message
                }*/
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. "
                    + "Click 'Create Admin Role' button to create it.";
            }
            else
            {
                AppUser user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded) { }
            return RedirectToAction("Index");
        }


        /****************  Role management *******************/

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterVM model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username, Name = model.Name };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
