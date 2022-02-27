﻿using CS296N80sGameFansite.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private GameListContext context;

        // constructor
        public ReviewRepository(GameListContext c)
        {
            context = c;
        }

        public IQueryable<Review> Reviews 
        { 
            get 
            { 
                // Get all the Review objects in the Reviews DbSet
                // and include the Reivewer object in each Review.
                return context.Reviews
                    .Include(review => review.Reviewer)
                    .Include(review => review.Comments)
                    .ThenInclude(comment => comment.Commenter);
            }
        }

        public async Task AddReviewAsync(Review review)
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteReviewAsync(Review review)
        {
            var theReview = await context.Reviews.FindAsync(review.ReviewId);
            context.Reviews.Remove(theReview);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            context.Reviews.Update(review);   // Find the review by ReviewId and update it
            await context.SaveChangesAsync();
        }
    }
}
