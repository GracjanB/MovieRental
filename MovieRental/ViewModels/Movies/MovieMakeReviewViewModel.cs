using Caliburn.Micro;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories.Implementations;
using MaterialDesignThemes.Wpf;
using MovieRental.EventModels;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels.Movies
{
    public class MovieMakeReviewViewModel : Screen
    {
        private readonly IEventAggregator _events;

        private readonly IReviewsRepository _reviewsRepo;

        private readonly ILoggedInUser _user;

        private int movieId { get; set; }

        public MovieMakeReviewViewModel(IEventAggregator events, IReviewsRepository reviewsRepo, ILoggedInUser user)
        {
            _events = events;
            _reviewsRepo = reviewsRepo;
            _user = user;
        }

        public void SetMovieId(int id) { movieId = id; }

        #region Form Controls

        public int Rating { get; set; }

        public string Comment { get; set; }

        public void RatingValueChanged(RatingBar ratingBar) { Rating = ratingBar.Value; }

        public async Task SaveReview()
        {
            if(Rating != 0 && Comment != null)
            {
                var review = new Review
                {
                    Rating = Rating,
                    Description = Comment,
                    AccountId = _user.GetUserId(),
                    VideoId = movieId
                };

                var result = await _reviewsRepo.AddReview(review);

                if (result)
                {
                    _events.PublishOnUIThread(new NewReviewAddedEvent());
                    this.TryClose();
                }
                else MessageBox.Show("Coś poszło nie tak.\nSpróbuj ponownie");
            }
        }

        #endregion
    }
}
