using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Implementations
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly MovieRentalModel _context;

        public ReviewsRepository()
        {
            _context = new MovieRentalModel();
        }

        public async Task<bool> AddReview(Review review)
        {
            bool output = false;
            Review existingReview = null;

            try
            {
                existingReview = await _context.Reviews
                    .Where(x => x.AccountId == review.AccountId && x.VideoId == review.VideoId)
                    .FirstOrDefaultAsync();

                if(existingReview != null)
                {
                    existingReview.Description = review.Description;
                    existingReview.Rating = review.Rating;
                }
                else _context.Reviews.Add(review);

                await _context.SaveChangesAsync();
                output = true;
            }
            catch (Exception) { }

            return output;
        }
    }
}
