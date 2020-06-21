using Caliburn.Micro;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
using DatabaseAccess.Repositories.Implementations;
using MovieRental.Models;
using MovieRental.User;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class MovieRentViewModel : Screen
    {
        private readonly ILoggedInUser _user;

        private readonly IVideoRentalRepository _rentalRepo;

        private readonly IAccountRepository _accountRepo;

        public MovieRentViewModel(ILoggedInUser user, IVideoRentalRepository rentalRepo,
            IAccountRepository accountRepo)
        {
            _user = user;
            _rentalRepo = rentalRepo;
            _accountRepo = accountRepo;
        }

        public void LoadMovie(MovieModel movie) { Movie = movie; }


        #region Form Controls

        private MovieModel _movie;
        private decimal _calculatedCost;
        private bool _canMakeRent;

        public MovieModel Movie
        {
            get { return _movie; }
            set 
            { 
                _movie = value;
                NotifyOfPropertyChange(() => Movie);
            }
        }

        public decimal CalculatedCost
        {
            get { return _calculatedCost; }
            set 
            { 
                _calculatedCost = value;
                NotifyOfPropertyChange(() => CalculatedCost);
            }
        }

        public bool CanMakeRent
        {
            get { return _canMakeRent; }
            set 
            { 
                _canMakeRent = value;
                NotifyOfPropertyChange(() => CanMakeRent);
            }
        }

        public DateTime SelectedDateFrom { get; set; } = DateTime.Now;

        public DateTime SelectedDateTo { get; set; } = DateTime.Now;

        public void CalculateCost()
        {
            var days = (SelectedDateTo - SelectedDateFrom).TotalDays;
            if (days > 0)
            {
                CalculatedCost = Movie.PricePerDay * Convert.ToDecimal(days);
                CanMakeRent = true;
            }
            else CanMakeRent = false;
        }

        public async Task MakeRent()
        {
            var user = _user.GetUser();

            if(CalculatedCost > user.Balance)
            {
                MessageBox.Show("Nie masz wystarczających środków na koncie.");
            }
            else
            {
                var rental = new VideoRental
                {
                    DateCreated = DateTime.UtcNow,
                    DateStart = SelectedDateFrom,
                    DateEnd = SelectedDateTo,
                    Price = CalculatedCost,
                    VideoId = Movie.Id,
                    AccountId = user.Id
                };

                var addRentalResult = await _rentalRepo.AddRental(rental);
                var rechargeBalanceResult = await _accountRepo.RechargeBalance(user.Id, CalculatedCost, false);

                string message = addRentalResult && rechargeBalanceResult ? "Pomyślnie dodano wypożyczenie." : "Wystąpił błąd.\nSpróbuj ponownie";
                MessageBox.Show(message);
            }
        }

        #endregion
    }
}
