using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
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
    public class LoggedInUser : ILoggedInUser, IHandle<UserCredentialsChangedEvent>
    {
        private readonly IAuthenticationService _authService;

        private readonly IMapper _mapper;

        private readonly IEventAggregator _events;

        private readonly IAccountRepository _accountRepo;

        public UserModel User { get; private set; }

        public bool IsActive { get; set; } = false;


        public LoggedInUser(IAuthenticationService authService, IMapper mapper, IEventAggregator eventAggregator,
            IAccountRepository accountRepo)
        {
            _authService = authService;
            _accountRepo = accountRepo;
            _mapper = mapper;
            _events = eventAggregator;
            _events.Subscribe(this);
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

                IsActive = true;
                output = true;
            }

            return output;
        }

        public void Logout()
        {
            User = null;
            IsActive = false;
            _events.PublishOnUIThread(new UserHasLogoutEvent());
        }

        public string GetUsername()
        {
            var username = User.Username;
            return username;
        }

        public int GetUserId()
        {
            var userId = User.Id;
            return userId;
        }

        public UserModel GetUser()
        {
            return User;
        }

        #region Events

        public async void Handle(UserCredentialsChangedEvent userCredentialsChangedEvent)
        {
            if(User != null)
            {
                var account = await _accountRepo.GetAccount(User.Id);
                User = _mapper.Map<UserModel>(account);
            }
        }

        #endregion
    }
}
