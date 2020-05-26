using Caliburn.Micro;
using DatabaseAccess.Model;
using MovieRental.Models;
using MovieRental.Services;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IRegisterService _registerService;

        private readonly ILoggedInUser _userService;

        public MainViewModel(IRegisterService registerService, ILoggedInUser userService)
        {
            _registerService = registerService;
            _userService = userService;
        }

        public async Task Login()
        {
            //var registerForm = new RegisterFormModel()
            //{
            //    Username = "testUsername",
            //    Email = "test@test.com",
            //    Password = "passwordtest",
            //    ConfirmPassword = "passwordtest",
            //    FirstName = "testName",
            //    LastName = "testLast"
            //};

            //var result = await _userService.Login("testUsername", "passwordtest");

            //if (result)
            //    MessageBox.Show("HURA");
            //else
            //    MessageBox.Show("NOPE");
        }
    }
}
