﻿using DatabaseAccess.Entities;
using System.Threading.Tasks;

namespace DatabaseAccess.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccount(Account account);

        Task<Account> GetAccount(int id);

        Task<Account> GetAccount(string username);
    }
}