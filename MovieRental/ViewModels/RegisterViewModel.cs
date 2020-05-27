using Caliburn.Micro;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly IAccountRepository _accountRepo;

        public RegisterViewModel(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }


        #region Form Controls

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Register()
        {
            // TODO: Add posibility to register new user
            // TODO: Add validator to form
        }

        #endregion
    }
}
