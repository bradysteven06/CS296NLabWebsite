﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS296N80sGameFansite.Controllers
{
    public class ReviewController : Controller
    {
        IReviewRepository repo;
        UserManager<AppUser> userManager;

        public ReviewController(IReviewRepository r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }

        // Show the view that has a form for entering a review
        [Authorize]
        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Review(Review model)
        {
            // Store the model in the database if it is valid
            if (ModelState.IsValid)
            {
                model.ReviewDate = DateTime.Today;
                // Get the AppUser object for the current user
                model.Reviewer = await userManager.GetUserAsync(User);
                await repo.AddReviewAsync(model);
            }
            return RedirectToAction("FilterReviews", new { gameTitle = model.GameName, reviewerName = model.Reviewer.Name });
        }

        public async Task<IActionResult> Index()
        {
            // Get all reviews in the database
            List<Review> reviews = await repo.Reviews.ToListAsync<Review>(); // Use ToList to convert the IQueryable to a list
            return View(reviews);
        }

        public async Task<IActionResult> FilterReviews(string gameTitle, string reviewerName)
        {
            List<Review> reviews = null;

            // We can filter by title, reviewer, or both
            if (!string.IsNullOrEmpty(gameTitle))
            {
                await Task.Run(() =>
                    reviews = (from r in repo.Reviews
                                   where r.GameName == gameTitle
                               select r).ToList()
                    );
            }
            if (!string.IsNullOrEmpty(reviewerName))
            {
                await Task.Run(() =>
                    reviews = (from r in repo.Reviews
                               where r.Reviewer.Name == reviewerName
                               select r).ToList()
                 );
            }
            return View("Index", reviews);
        }

        [Authorize]
        public IActionResult Comment(int reviewId)
        {
            var commentVM = new CommentVM { ReviewId = reviewId };
            return View(commentVM);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Comment(CommentVM commentVM)
        {
            // Comment is the domain model
            var comment = new Comment { CommentText = commentVM.CommentText };
            comment.Commenter = userManager.GetUserAsync(User).Result;
            comment.CommentDate = DateTime.Now;

            // Retrieve the review that this comment is for
            var review = (from r in repo.Reviews.Include(r => r.Comments)
                          where r.ReviewId == commentVM.ReviewId
                          select r).First<Review>();

            // Store the review with the comment in the database
            review.Comments.Add(comment);
            await repo.UpdateReviewAsync(review);

            return RedirectToAction("FilterReviews", new { gameTitle = review.GameName, reviewerName = review.Reviewer.Name });
        }


    }
};
