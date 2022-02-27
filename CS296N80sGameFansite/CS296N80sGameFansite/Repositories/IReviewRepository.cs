using CS296N80sGameFansite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }  // Read (or retrieve) reviews
        Task AddReviewAsync(Review review);  // Create a review
        Task UpdateReviewAsync(Review review);  // Modify a review
    }
}
