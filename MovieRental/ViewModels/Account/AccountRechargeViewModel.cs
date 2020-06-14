using Caliburn.Micro;
using DatabaseAccess.Repositories;
using MovieRental.EventModels;
using MovieRental.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieRental.ViewModels
{
    public class AccountRechargeViewModel : Screen
    {
        private readonly IEventAggregator _events;

        private readonly IAccountRepository _accountRepo;

        private readonly ILoggedInUser _user;

        public AccountRechargeViewModel(IEventAggregator events, IAccountRepository accountRepo, ILoggedInUser user)
        {
            _events = events;
            _accountRepo = accountRepo;
            _user = user;
        }

        #region Forms Control

        public int Amount { get; set; }

        public async void Save()
        {
            if(Amount > 0)
            {
                var user = _user.GetUser();
                var result = await _accountRepo.RechargeBalance(user.Id, Convert.ToDecimal(Amount));

                if (result)
                {
                    _events.PublishOnUIThread(new AccountBalanceRechargedEvent());
                    this.TryClose();
                }
                else
                    MessageBox.Show("Wystąpił błąd, spróbuj ponownie.");
            }
        }

        #endregion
    }
}
