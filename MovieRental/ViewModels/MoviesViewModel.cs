using AutoMapper;
using Caliburn.Micro;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
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

        private readonly IVideoRepository _videoRepo;

        private readonly IMapper _mapper;

        public MoviesViewModel(SimpleContainer container, ILoggedInUser userService, IVideoRepository videoRepo, IMapper mapper)
        {
            _container = container;
            _userService = userService;
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadVideos();
        }

        private async Task LoadVideos()
        {
            var videos = await _videoRepo.GetVideos();
            Movies = new BindableCollection<MovieModel>();

            foreach(var video in videos)
               Movies.Add(_mapper.Map<MovieModel>(video));
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

        private BindableCollection<MovieModel> _movies;

        public BindableCollection<MovieModel> Movies
        {
            get { return _movies; }
            set 
            { 
                _movies = value;
                NotifyOfPropertyChange(() => Movies);
            }
        }

        public void MovieDetails(MovieModel movie)
        {
            var movieDetailsVM = _container.GetInstance<MovieDetailsViewModel>();
            movieDetailsVM.LoadMovie(movie);

            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(movieDetailsVM);
        }

        public void MakeRent(MovieModel movie)
        {
            // TODO
        }

        #endregion
    }
}
