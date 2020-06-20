using Caliburn.Micro;
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

        private readonly IEventAggregator _events;

        public AccountViewModel(SimpleContainer simpleContainer, ILoggedInUser userService, IWindowManager windowManager,
            IEventAggregator events)
        {
            _container = simpleContainer;
            _userService = userService;
            _windowManager = windowManager;
            _events = events;
            _events.Subscribe(this);
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            LoadUserInfo();
        }

        #region User Info Card

        private UserModel _user;

        public UserModel User
        {
            get { return _user; }
            set 
            { 
                _user = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public void RechargeAccount()
        {
            var accountRechargeVM = _container.GetInstance<AccountRechargeViewModel>();
            _windowManager.ShowDialog(accountRechargeVM);
        }

        private void LoadUserInfo()
        {
            User = _userService.GetUser();
        }

        #endregion


        #region Navigation Menu

        public void UserLibraryShow()
        {
            var accountLibraryVM = _container.GetInstance<AccountLibraryViewModel>();
            ChangeActiveItem(accountLibraryVM, true);
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
            _events.PublishOnUIThread(new UserCredentialsChangedEvent());
            LoadUserInfo();
        }

        #endregion
    }
}
