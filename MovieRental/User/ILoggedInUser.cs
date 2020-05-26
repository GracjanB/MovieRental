﻿using System.Threading.Tasks;

namespace MovieRental.User
{
    public interface ILoggedInUser
    {
        Task<bool> Login(string username, string password);

        bool Logout();
    }
}