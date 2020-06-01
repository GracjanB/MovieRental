using DatabaseAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IVideoRepository
    {
        Task<List<Video>> GetVideos();
    }
}