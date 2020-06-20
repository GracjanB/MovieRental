using DatabaseAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories.Implementations
{
    public interface IVideoRentalRepository
    {
        Task<bool> AddRental(VideoRental rental);

        Task<List<VideoRental>> GetRentals(int accountId, bool archiveRentals = false);
    }
}