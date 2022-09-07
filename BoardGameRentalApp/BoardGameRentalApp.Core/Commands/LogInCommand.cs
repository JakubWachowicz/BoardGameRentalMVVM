using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class LogInCommand: Core.AsyncCommandBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly BoardGameRentalViewModel _boardGameRental;
        private readonly BoardGameRentalStore _boardGameRentalStore;
        private readonly LoginViewModel _loginViewModel;
        private Action _errorMessages;

        public bool IsExecuting { get; private set; }

        public LogInCommand(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRental, BoardGameRentalStore boardGameRentalStore, LoginViewModel loginViewModel)
        {
            _navigationStore = navigationStore;
            _boardGameRental = boardGameRental;
            _boardGameRentalStore = boardGameRentalStore;
            _loginViewModel = loginViewModel;
            _loginViewModel.PropertyChanged += OnTextBoxChange;
            _errorMessages += _loginViewModel.ErrorOccured;
        }

        private void _loginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async  void ExecuteAsync(object parameter)
        {

               SearchForUser();

        }
        public  async void SearchForUser()
        {
            var list =await _boardGameRental.boardGameRental.GetAllUsers();
            foreach (var item in list)
            {
                if (_loginViewModel.Password.Trim() == item.Password && _loginViewModel.UserName == item.UserName)
                {
                    _navigationStore.CurrentViewModel = new ListOfBoardGamesViewModel(_navigationStore, _boardGameRental, _boardGameRentalStore);
                    break;
                }
            }
            _errorMessages.Invoke();
        }
        public override bool CanExecute(object parameter)
        {
            return Validation();
        }

        public bool Validation()
        {
            if(_loginViewModel.UserName.Trim() != string.Empty && _loginViewModel.Password.Trim() != string.Empty)
            {
                 return true;
            }
            return false;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                IsExecuting = true;
                ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }

        }
        private void OnTextBoxChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginViewModel.Password) || e.PropertyName == nameof(_loginViewModel.UserName))
            {
                OnCanExecuteChange();
            }
        }
    }

}
