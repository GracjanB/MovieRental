using DatabaseAccess.Entities;
using DatabaseAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public async Task<bool> RechargeBalance(int userId, decimal amount, bool add = true)
        {
            try
            {
                Account account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == userId);
                if (account != null)
                {
                    if (add)
                        account.Balance += amount;
                    else
                        account.Balance -= amount;

                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch(Exception) { return false; }
        }

        public async Task<bool> Update(Account account)
        {
            bool output = false;
            Account existingAccount = null;

            try
            {
                existingAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);
                
                if(existingAccount != null)
                {
                    existingAccount.Username = account.Username;
                    existingAccount.FirstName = account.FirstName;
                    existingAccount.LastName = account.LastName;
                    existingAccount.Email = account.Email;

                    await _context.SaveChangesAsync();
                    output = true;
                }
            }
            catch(Exception) { }

            return output;
        }
    }
}
