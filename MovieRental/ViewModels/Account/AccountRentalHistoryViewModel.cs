using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Repositories.Implementations;
using MovieRental.Models;
using MovieRental.User;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class AccountRentalHistoryViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IVideoRentalRepository _rentalsRepo;

        private readonly IMapper _mapper;

        private readonly ILoggedInUser _user;

        public AccountRentalHistoryViewModel(SimpleContainer container, IMapper mapper,
            IVideoRentalRepository rentalsRepo, ILoggedInUser user)
        {
            _container = container;
            _rentalsRepo = rentalsRepo;
            _mapper = mapper;
            _user = user;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadRentals();
        }

        private async Task LoadRentals()
        {
            var rentals = await _rentalsRepo.GetRentals(_user.GetUserId(), true);
            MovieRentals = new BindableCollection<MovieRentalModel>();

            if (rentals != null && rentals.Count > 0)
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

        public void MakeRent(MovieRentalModel movieRentalModel)
        {
            var movieRentVM = _container.GetInstance<MovieRentViewModel>();
            movieRentVM.LoadMovie(movieRentalModel.Movie);

            var conductor = (AccountViewModel)this.Parent;
            var mainConductor = (MainViewModel)conductor.Parent;
            mainConductor.ActivateItem(movieRentVM);
        }

        public void MovieDetails(MovieRentalModel movieRentalModel)
        {
            var movieDetailsVM = _container.GetInstance<MovieDetailsViewModel>();
            movieDetailsVM.LoadMovie(movieRentalModel.Movie);

            var conductor = (AccountViewModel)this.Parent;
            var mainConductor = (MainViewModel)conductor.Parent;
            mainConductor.ActivateItem(movieDetailsVM);
        }

        #endregion
    }
}
