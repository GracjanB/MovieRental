using Caliburn.Micro;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Username { get; set; }

        public string Password { get; set; }


        public void Login()
        {
            // TODO: Make login function
        }

        #endregion
    }
}
