using MovieRental.Models;
using System.Threading.Tasks;

namespace MovieRental.Services
{
    public interface IRegisterService
    {
        Task<bool> Register(RegisterFormModel registerForm);
    }
}