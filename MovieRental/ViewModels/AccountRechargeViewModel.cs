using Caliburn.Micro;
using DatabaseAccess.Repositories;
using MovieRental.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.ViewModels
{
    public class AccountRechargeViewModel : Screen
    {
        private readonly IEventAggregator _events;

        private readonly IAccountRepository _accountRepo;

        public AccountRechargeViewModel(IEventAggregator events, IAccountRepository accountRepo)
        {
            _events = events;
            _accountRepo = accountRepo;
        }

        #region Forms Control

        public int Amount { get; set; }

        public void Save()
        {
            // TODO: Add Validator
            // TODO: Update account balance

            _events.PublishOnUIThread(new AccountBalanceRechargedEvent());
            this.TryClose();
        }

        #endregion
    }
}
