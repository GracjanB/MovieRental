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
    public class MoviesViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly ILoggedInUser _userService;

        public MoviesViewModel(SimpleContainer container, ILoggedInUser userService)
        {
            _container = container;
            _userService = userService;
        }


        #region Searching Menu

        public string MovieNameSearch { get; set; }

        public BindableCollection<string> CategorySearch { get; set; }

        public string SelectedCategory { get; set; }

        public int ProductionYearFrom { get; set; }

        public int ProductionYearTo { get; set; }

        public void Search()
        {
            // TODO
        }

        #endregion

        #region Movies List

        public BindableCollection<MovieModel> Movies { get; set; }

        public void MovieDetails(MovieModel movie)
        {
            // TODO
        }

        public void MakeRent(MovieModel movie)
        {
            // TODO
        }

        #endregion
    }
}
