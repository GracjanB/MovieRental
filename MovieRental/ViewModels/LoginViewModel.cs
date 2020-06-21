using Caliburn.Micro;
using MovieRental.EventModels;
using MovieRental.User;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly ILoggedInUser _userService;

        private readonly IEventAggregator _events;

        public LoginViewModel(ILoggedInUser userService, IEventAggregator eventAggregator)
        {
            _userService = userService;
            _events = eventAggregator;
        }

        #region Form Controls

        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                bool output = false;

                if (Username?.Length > 0 && Password?.Length > 0)
                    output = true;

                return output;
            }
        }

        public async Task Login()
        {
            try
            {
                if(await _userService.Login(Username, Password))
                {
                    _events.PublishOnUIThread(new UserHasLoggedInEvent());
                    this.TryClose();
                }
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
