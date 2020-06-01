﻿using Caliburn.Micro;
using MovieRental.EventModels;
using MovieRental.Models;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class AccountViewModel : Conductor<object>, IHandle<AccountBalanceRechargedEvent>
    {
        private readonly SimpleContainer _container;

        private readonly ILoggedInUser _userService;

        private readonly IWindowManager _windowManager;

        public AccountViewModel(SimpleContainer simpleContainer, ILoggedInUser userService, IWindowManager windowManager)
        {
            _container = simpleContainer;
            _userService = userService;
            _windowManager = windowManager;
        }


        #region User Info Card

        public UserModel User { get; set; } = new UserModel();

        public void RechargeAccount()
        {
            var accountRechargeVM = _container.GetInstance<AccountRechargeViewModel>();
            _windowManager.ShowDialog(accountRechargeVM);
        }

        #endregion


        #region Navigation Menu

        public void UserLibraryShow()
        {
            var accountLibraryVM = _container.GetInstance<AccountLibraryViewModel>();
            ChangeActiveItem(accountLibraryVM, true);
        }

        public void UserReviewsShow()
        {
            var accountReviewsVM = _container.GetInstance<AccountReviewsViewModel>();
            ChangeActiveItem(accountReviewsVM, true);
        }

        public void UserMoviesRentalHistory()
        {
            var accountRentalHistoryVM = _container.GetInstance<AccountRentalHistoryViewModel>();
            ChangeActiveItem(accountRentalHistoryVM, true);
        }

        public void AccountSettingsShow()
        {
            var accountSettingsVM = _container.GetInstance<AccountSettingsViewModel>();
            ChangeActiveItem(accountSettingsVM, true);
        }

        #endregion

        #region Events

        public void Handle(AccountBalanceRechargedEvent accountBalanceRechargedEvent)
        {
            // TODO: Refresh account info
        }

        #endregion
    }
}
