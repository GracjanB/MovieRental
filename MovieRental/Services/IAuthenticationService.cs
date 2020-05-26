using DatabaseAccess.Entities;
using System.Threading.Tasks;

namespace MovieRental.Services
{
    public interface IAuthenticationService
    {
        Task<Account> AuthenticateUser(string username, string clearTextPassword);
    }
}