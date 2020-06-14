using MovieRental.Models;
using System.Threading.Tasks;

namespace MovieRental.User
{
    public interface ILoggedInUser
    {
        bool IsActive { get; set; }

        Task<bool> Login(string username, string password);

        void Logout();

        string GetUsername();

        UserModel GetUser();
    }
}