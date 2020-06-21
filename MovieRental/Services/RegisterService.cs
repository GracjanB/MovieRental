using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
using MovieRental.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IAccountRepository _accountRepo;

        public RegisterService(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        public async Task<bool> Register(RegisterFormModel registerForm)
        {
            bool output = false;

            var account = createAccountObject(registerForm);
            output = await _accountRepo.CreateAccount(account);

            return output;
        }

        private Account createAccountObject(RegisterFormModel registerForm)
        {
            var account = new Account
            {
                Username = registerForm.Username,
                Email = registerForm.Email,
                Password = CalculateHash(registerForm.Password, registerForm.Username),
                IsActive = false,
                FirstName = registerForm.FirstName,
                LastName = registerForm.LastName,
                Balance = 0
            };

            return account;
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }
    }
}
