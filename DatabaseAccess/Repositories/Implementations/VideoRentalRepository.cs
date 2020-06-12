using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
