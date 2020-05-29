using Caliburn.Micro;
using MovieRental.Models;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class AccountViewModel : Conductor<object>
    {
        private readonly SimpleContainer _container;

        private readonly ILoggedInUser _userService;

        public AccountViewModel(SimpleContainer simpleContainer, ILoggedInUser userService)
        {
            _container = simpleContainer;
            _userService = userService;
        }


        #region User Info Card

        public UserModel User { get; set; } = new UserModel();

        public void RechargeAccount()
        {
            // TODO
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
    }
}
