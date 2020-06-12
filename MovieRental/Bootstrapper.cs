using Caliburn.Micro;
using DatabaseAccess.Repositories;
using MovieRental.Services;
using MovieRental.User;
using MovieRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using DatabaseAccess.Entities;
using MovieRental.Models;
using MovieRental.Helpers;
using System.Windows.Controls;
using DatabaseAccess.Repositories.Implementations;

namespace MovieRental
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            MapperConfiguration mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Account, UserModel>();
                config.CreateMap<Video, MovieModel>();
            });

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IRegisterService, RegisterService>()
                .Singleton<ILoggedInUser, LoggedInUser>()
                .Singleton<IAccountRepository, AccountRepository>()
                .Singleton<IVideoRepository, VideoRepository>()
                .Singleton<IVideoRentalRepository, VideoRentalRepository>();

            _container
                .RegisterInstance(typeof(IMapper), "automapper", mapperConfig.CreateMapper());

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
