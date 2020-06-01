using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly MovieRentalModel _context;

        public VideoRepository()
        {
            _context = new MovieRentalModel();
        }

        public async Task<List<Video>> GetVideos()
        {
            List<Video> videos = null;

            videos = await _context.Videos.Include("Reviews").AsNoTracking().ToListAsync();

            return videos;
        }
    }
}
