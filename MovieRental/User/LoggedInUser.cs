using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Entities;
using MovieRental.EventModels;
using MovieRental.Models;
using MovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.User
{
    public class LoggedInUser : ILoggedInUser
    {
        private readonly IAuthenticationService _authService;

        private readonly IMapper _mapper;

        private readonly IEventAggregator _events;

        public UserModel User { get; private set; }


        public LoggedInUser(IAuthenticationService authService, IMapper mapper, IEventAggregator eventAggregator)
        {
            _authService = authService;
            _mapper = mapper;
            _events = eventAggregator;
        }

        public async Task<bool> Login(string username, string password)
        {
            bool output = false;
            Account account = null;

            try
            {
                account = await _authService.AuthenticateUser(username, password);
            }
            catch(UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }

            if (account != null)
            {
                User = _mapper.Map<UserModel>(account);

                output = true;
            }

            return output;
        }

        public void Logout()
        {
            User = null;
            _events.PublishOnUIThread(new UserHasLogoutEvent());
        }

        public string GetUsername()
        {
            var username = User.Username;
            return username;
        }
    }
}
