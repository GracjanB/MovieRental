using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
using MovieRental.Models;
using MovieRental.User;
using MovieRental.Validators;
using Npgsql.TypeHandlers.CompositeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class AccountSettingsViewModel : Screen
    {
        private readonly IAccountRepository _accountRepo;

        private readonly ILoggedInUser _user;

        private readonly IMapper _mapper;

        public AccountSettingsViewModel(IAccountRepository accountRepo, ILoggedInUser user, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _user = user;
            _mapper = mapper;
            User = _user.GetUser();
        }

        #region Account Data Form

        private UserModel _userModel;

        public UserModel User
        {
            get { return _userModel; }
            set 
            { 
                _userModel = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public async void SaveAccountData()
        {
            var accountValidator = new AccountFormValidator();
            var validationResult = accountValidator.Validate(User);

            if (validationResult.IsValid)
            {
                var account = _mapper.Map<Account>(User);
                var updateResult = await _accountRepo.Update(account);
                string message = updateResult ? "Pomyślnie zmieniono dane konta." : "Wystąpił błąd podczas zapisu.\nSpróbuj ponownie";
                MessageBox.Show(message);
            }
            else MessageBox.Show("Błąd walidacji danych. Spróbuj ponownie");
        }

        #endregion
    }
}
