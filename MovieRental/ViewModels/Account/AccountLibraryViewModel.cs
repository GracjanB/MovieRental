using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Repositories.Implementations;
using MovieRental.Models;
using MovieRental.User;
using MovieRental.ViewModels.Movies;
using MovieRental.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class AccountLibraryViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IWindowManager _windowManager;

        private readonly IVideoRentalRepository _rentalRepo;

        private readonly ILoggedInUser _user;

        private readonly IMapper _mapper;

        public AccountLibraryViewModel(SimpleContainer container, IVideoRentalRepository rentalRepo, IMapper mapper, ILoggedInUser user,
            IWindowManager windowManager)
        {
            _container = container;
            _windowManager = windowManager;
            _rentalRepo = rentalRepo;
            _user = user;
            _mapper = mapper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadRentals();
        }

        private async Task LoadRentals()
        {
            var rentals = await _rentalRepo.GetRentals(_user.GetUserId());
            MovieRentals = new BindableCollection<MovieRentalModel>();

            if(rentals != null && rentals.Count > 0)
            {
                foreach (var rental in rentals)
                {
                    var rentalModel = _mapper.Map<MovieRentalModel>(rental);
                    rentalModel.Movie = _mapper.Map<MovieModel>(rental.Video);
                    MovieRentals.Add(rentalModel);
                }
            }       
        }

        #region Form Controls

        private BindableCollection<MovieRentalModel> _movieRentals;

        public BindableCollection<MovieRentalModel> MovieRentals
        {
            get { return _movieRentals; }
            set
            {
                _movieRentals = value;
                NotifyOfPropertyChange(() => MovieRentals);
            }
        }

        public void PlayVideo()
        {
            var moviePlayerVM = _container.GetInstance<MoviePlayerViewModel>();
            _windowManager.ShowDialog(moviePlayerVM);
        }

        public void MovieDetails(MovieRentalModel movieRentalModel)
        {
            var movieDetailsVM = _container.GetInstance<MovieDetailsViewModel>();
            movieDetailsVM.LoadMovie(movieRentalModel.Movie);

            var conductorObject = _container.GetInstance<MainViewModel>();
            conductorObject.ActivateItem(movieDetailsVM);
        }

        public void MakeReview(MovieRentalModel movieRentalModel)
        {
            // TODO
        }

        #endregion

    }
}
