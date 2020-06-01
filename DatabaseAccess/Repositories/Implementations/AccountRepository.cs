using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MovieRentalModel _context;

        public AccountRepository()
        {
            _context = new MovieRentalModel();
        }

        public async Task<bool> CreateAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<Account> GetAccount(int id)
        {
            Account account = null;

            try
            {
                account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch { }

            return account;
        }

        public async Task<Account> GetAccount(string username)
        {
            Account account = null;

            try
            {
                account = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == username);
            }
            catch { }

            return account;
        }
    }
}
