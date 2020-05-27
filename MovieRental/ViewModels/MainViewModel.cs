using Caliburn.Micro;
using DatabaseAccess.Model;
using MaterialDesignThemes.Wpf;
using MovieRental.EventModels;
using MovieRental.Models;
using MovieRental.Services;
using MovieRental.User;
using MovieRental.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<UserHasLoggedInEvent>, IHandle<UserHasLogoutEvent>, IHandle<UserHasRegisteredEvent>
    {
        private readonly SimpleContainer _container;

        private readonly IWindowManager _windowManager;

        private readonly IEventAggregator _events;

        private readonly ILoggedInUser _userService;

        private string _username = "";

        public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public MainViewModel(SimpleContainer container, IWindowManager windowManager, IEventAggregator eventAggregator, ILoggedInUser userService)
        {
            _container = container;
            _windowManager = windowManager;
            _userService = userService;
            _events = eventAggregator;
            _events.Subscribe(this);
        }

        public void MovieRentalLibraryShow()
        {
            // TODO: Show Movie Rental Library
        }

        public void UserMovieLibraryShow()
        {
            // TODO: Show User Movie Library
        }

        public void AccountShow()
        {
            // TODO: Show Account Screen
        }

        public void GitHubRepositoryRedirect()
        {
            // TODO: Open GitHub repo in browser
        }

        #region PopUp Menu

        private Visibility _loginButtonVisibility = Visibility.Visible;
        private Visibility _logoutButtonVisibility = Visibility.Collapsed;
        private Visibility _registerButtonVisibility = Visibility.Visible;
        private Visibility _accountButtonVisibility = Visibility.Collapsed;

        public Visibility LoginButtonVisibility
        {
            get { return _loginButtonVisibility; }
            set
            {
                _loginButtonVisibility = value;
                NotifyOfPropertyChange(() => LoginButtonVisibility);
            }
        }

        public Visibility LogoutButtonVisibility
        {
            get { return _logoutButtonVisibility; }
            set
            {
                _logoutButtonVisibility = value;
                NotifyOfPropertyChange(() => LogoutButtonVisibility);
            }
        }

        public Visibility RegisterButtonVisibility
        {
            get { return _registerButtonVisibility; }
            set 
            { 
                _registerButtonVisibility = value;
                NotifyOfPropertyChange(() => RegisterButtonVisibility);
            }
        }

        public Visibility AccountButtonVisibility
        {
            get { return _accountButtonVisibility; }
            set 
            {
                _accountButtonVisibility = value;
                NotifyOfPropertyChange(() => AccountButtonVisibility);
            }
        }

        private void SetButtonsVisibility_UserLogin()
        {
            LoginButtonVisibility = Visibility.Collapsed;
            LogoutButtonVisibility = Visibility.Visible;
            RegisterButtonVisibility = Visibility.Collapsed;
            AccountButtonVisibility = Visibility.Visible;
        }

        private void SetButtonsVisibility_UserLogout()
        {
            LoginButtonVisibility = Visibility.Visible;
            LogoutButtonVisibility = Visibility.Collapsed;
            RegisterButtonVisibility = Visibility.Visible;
            AccountButtonVisibility = Visibility.Collapsed;
        }

        public void LoginWindowShow()
        {
            var loginVM = _container.GetInstance<LoginViewModel>();
            _windowManager.ShowDialog(loginVM);
        }

        public void RegisterWindowShow()
        {
            var registerVM = _container.GetInstance<RegisterViewModel>();
            _windowManager.ShowDialog(registerVM);
        }

        public void Logout()
        {
            _userService.Logout();
        }

        #endregion


        #region Snackbar PopUp Notification

        private Snackbar _snackbarNotification;

        public Snackbar SnackbarNotification
        {
            get { return _snackbarNotification; }
            set 
            { 
                _snackbarNotification = value;
                NotifyOfPropertyChange(() => SnackbarNotification);
            }
        }

        public void SnackbarLoaded(object sender)
        {
            SnackbarNotification = (Snackbar)sender;
        }

        private void SnackbarShowMessage(string message)
        {
            SnackbarNotification.MessageQueue = new SnackbarMessageQueue();
            SnackbarNotification.MessageQueue.Enqueue(message);
        }

        #endregion


        #region Events

        public void Handle(UserHasLoggedInEvent userHasLoggedInEvent)
        {
            Username = _userService.GetUsername();
            SetButtonsVisibility_UserLogin();

            string message = "Zalogowano. Witaj " + Username;
            SnackbarShowMessage(message);
        }

        public void Handle(UserHasLogoutEvent userHasLogoutEvent)
        {
            string message = "Wylogowano. Zapraszamy ponownie " + Username;
            Username = "";
            SetButtonsVisibility_UserLogout();

            SnackbarShowMessage(message);
        }

        public void Handle(UserHasRegisteredEvent userHasRegisteredEvent)
        {
            SnackbarShowMessage("Zarejestrowano! Możesz się teraz zalogować");
        }

        #endregion
    }
}
