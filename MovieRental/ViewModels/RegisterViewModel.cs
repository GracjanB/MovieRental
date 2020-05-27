using Caliburn.Micro;
using DatabaseAccess.Repositories;
using MovieRental.EventModels;
using MovieRental.Models;
using MovieRental.Services;
using MovieRental.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly IRegisterService _registerService;

        private readonly IEventAggregator _events;

        private RegisterFormValidator _registerValidator;

        public RegisterViewModel(IRegisterService registerService, IEventAggregator eventAggregator)
        {
            _registerService = registerService;
            _events = eventAggregator;
            _registerValidator = new RegisterFormValidator();
        }


        #region Form Controls

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public async void Register()
        {
            var registerModel = new RegisterFormModel
            {
                Username = Username,
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                FirstName = FirstName,
                LastName = LastName
            };

            var result = _registerValidator.Validate(registerModel);

            if (result.IsValid)
            {
                if (await _registerService.Register(registerModel))
                {
                    _events.PublishOnUIThread(new UserHasRegisteredEvent());
                    this.TryClose();
                }
                else MessageBox.Show("Wystąpił błąd. Spróbuj ponownie");
            }
            else MessageBox.Show("Błąd walidacji danych.");
        }

        #endregion
    }
}
