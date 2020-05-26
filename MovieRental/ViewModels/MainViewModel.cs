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
    public class MainViewModel : Conductor<object>
    {
        private readonly SimpleContainer _container;

        public MainViewModel(SimpleContainer container)
        {
            _container = container;
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
    }
}
