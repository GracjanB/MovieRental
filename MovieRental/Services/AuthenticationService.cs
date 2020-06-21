using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;

namespace MovieRental.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountRepository _accountRepo;

        public AuthenticationService(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        public async Task<Account> AuthenticateUser(string username, string clearTextPassword)
        {
            Account account = null;
            
            var hashedPassword = CalculateHash(clearTextPassword, username);

            account = await _accountRepo.GetAccount(username);

            if (account != null)
            {
                if (account.Password == hashedPassword)
                    return account;
                else
                    throw new UnauthorizedAccessException("Password doesn't match.");
            }
            else
                throw new UnauthorizedAccessException("Username not found.");
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
