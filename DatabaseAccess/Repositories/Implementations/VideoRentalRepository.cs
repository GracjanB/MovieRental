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
    public class VideoRentalRepository : IVideoRentalRepository
    {
        private readonly MovieRentalModel _context;

        public VideoRentalRepository()
        {
            _context = new MovieRentalModel();
        }

        public async Task<bool> AddRental(VideoRental rental)
        {
            bool output = false;

            try
            {
                _context.VideoRentals.Add(rental);
                await _context.SaveChangesAsync();
                output = true;
            }
            catch (Exception) { }

            return output;
        }

        public async Task<List<VideoRental>> GetRentals(int accountId)
        {
            List<VideoRental> rentals = null;

            try
            {
                rentals = await _context.VideoRentals
                    .Include(x => x.Video)
                    .Where(x => x.DateEnd >= DateTime.Now)
                    .ToListAsync();
            }
            catch(Exception) { }

            return rentals;
        }
    }
}
