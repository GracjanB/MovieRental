using Caliburn.Micro;
using MovieRental.Models;
using MovieRental.ViewModels.Movies;

namespace MovieRental.ViewModels
{
    public class MovieDetailsViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IWindowManager _windowManager;

        public MovieDetailsViewModel(SimpleContainer container, IWindowManager windowManager)
        {
            _container = container;
            _windowManager = windowManager;
        }

        public void LoadMovie(MovieModel movie)
        {
            Movie = movie;
        }

        #region Form Controls

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

        public void MakeReview()
        {
            var movieMakeReviewVM = _container.GetInstance<MovieMakeReviewViewModel>();
            movieMakeReviewVM.SetMovieId(Movie.Id);
            _windowManager.ShowDialog(movieMakeReviewVM);
        }

        public void RentMovie()
        {
            var movieRentVM = _container.GetInstance<MovieRentViewModel>();
            movieRentVM.LoadMovie(Movie);
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(movieRentVM);
        }

        public void MoveBack()
        {
            var moviesVM = _container.GetInstance<MoviesViewModel>();
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(moviesVM);
        }

        #endregion
    }
}
