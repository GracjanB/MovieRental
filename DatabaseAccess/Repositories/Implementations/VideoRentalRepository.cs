﻿using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<List<VideoRental>> GetRentals(int accountId, bool archiveRentals = false)
        {
            List<VideoRental> rentals = null;

            try
            {
                if(archiveRentals)
                    rentals = await _context.VideoRentals
                        .Include(x => x.Video)
                        .Where(x => x.DateEnd < DateTime.Now)
                        .ToListAsync();
                else
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
