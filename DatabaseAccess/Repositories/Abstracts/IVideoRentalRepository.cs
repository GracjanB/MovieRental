using DatabaseAccess.Entities;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Implementations
{
    public interface IVideoRentalRepository
    {
        Task<bool> AddRental(VideoRental rental);
    }
}