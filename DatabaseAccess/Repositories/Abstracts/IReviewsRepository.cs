using DatabaseAccess.Entities;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Implementations
{
    public interface IReviewsRepository
    {
        Task<bool> AddReview(Review review);
    }
}