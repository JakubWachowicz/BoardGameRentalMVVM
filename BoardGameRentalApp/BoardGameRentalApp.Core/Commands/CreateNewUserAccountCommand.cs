using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentalApp.Core.ViewModels.SignUpAndLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class CreateNewUserAccountCommand : AsyncCommandBase
    {
        
        private readonly NavigationStore _navigationStore;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;
        private readonly BoardGameRentalStore _boardGameRentalStore;
        private readonly SignUpViewModel _signUpViewModel;

        public CreateNewUserAccountCommand(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel, BoardGameRentalStore boardGameRentalStore, SignUpViewModel signUpViewModel)
        {
            _navigationStore = navigationStore;
            _boardGameRentalViewModel = boardGameRentalViewModel;
            _boardGameRentalStore = boardGameRentalStore;
            _signUpViewModel = signUpViewModel;
            _signUpViewModel.PropertyChanged += OnTextBoxChange;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            
            Guid g = Guid.NewGuid();
            UserModel NewBoardGame = new UserModel(g, _signUpViewModel.UserName, _signUpViewModel.Password);
           

            await _boardGameRentalStore.AddUser(NewBoardGame);
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore, _boardGameRentalViewModel, _boardGameRentalStore);

        }
        public override bool CanExecute(object parameter)
        {
            return Validation();
        }

        public bool Validation()
        {
            if(_signUpViewModel.Password.Trim().Length >=6 && _signUpViewModel.Password.Trim() == _signUpViewModel.ConfirmPassword.Trim())
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
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }

        }


        private void OnTextBoxChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_signUpViewModel.Password) || e.PropertyName == nameof(_signUpViewModel.ConfirmPassword) || e.PropertyName == nameof(_signUpViewModel.UserName))
            {
                OnCanExecuteChange();
            }
        }
    }
}
