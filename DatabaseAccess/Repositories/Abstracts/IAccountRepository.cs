using DatabaseAccess.Entities;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccount(Account account);

        Task<Account> GetAccount(int id);

        Task<Account> GetAccount(string username);

        Task<bool> RechargeBalance(int userId, decimal amount, bool add = true);

        Task<bool> Update(Account account);

        Task<bool> ChangePassword(int accountId, string newPassword);
    }
}