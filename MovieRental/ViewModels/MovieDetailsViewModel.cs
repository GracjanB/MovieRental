using Caliburn.Micro;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class MovieDetailsViewModel : Screen
    {
        private readonly SimpleContainer _container;

        public MovieDetailsViewModel(SimpleContainer container)
        {
            _container = container;
        }

        public void LoadMovie(MovieModel movie)
        {
            Movie = movie;
        }


        private MovieModel _movie;

        public MovieModel Movie
        {
            get { return _movie; }
            set 
            {
                _movie = value;
                NotifyOfPropertyChange(() => Movie);
            }
        }

        public void RentMovie()
        {
            // TODO
        }

        public void MoveBack()
        {
            var moviesVM = _container.GetInstance<MoviesViewModel>();
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(moviesVM);
        }
    }
}
