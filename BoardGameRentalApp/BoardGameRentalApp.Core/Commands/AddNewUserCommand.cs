using BoardGameRentalApp.Core;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class AddNewUserCommand: AsyncCommandBase
    {
       
        public Func<bool> CanExecuteEvent;
        public ListOfUsersViewModel AddNewUserPageViewModel;
        public BoardGameRentalStore boardGameRentalStore;


        public AddNewUserCommand(Func<bool> canExecuteEvent, BoardGameRentalStore boardGameRentalStore, ListOfUsersViewModel addNewUserPageViewModel) 
        {
            this.boardGameRentalStore = boardGameRentalStore;
            CanExecuteEvent = canExecuteEvent;
            AddNewUserPageViewModel = addNewUserPageViewModel;
            AddNewUserPageViewModel.PropertyChanged += OnTextBoxChange;

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

        public override async Task ExecuteAsync(object parameter)
        {
            Guid g = Guid.NewGuid();
            UserModel NewBoardGame = new UserModel(g, AddNewUserPageViewModel.UserName);
            //BoardGameList.Add(NewBoardGame);
            // await ViewModelBase._boardGameRentalViewModel.boardGameRental.AddBoardGameAsync(new BoardGameModel(ViewModelBase.Genre, ViewModelBase.BoardGameName));
            await boardGameRentalStore.AddUser(NewBoardGame);
            AddNewUserPageViewModel.OnPropertChanged(nameof(AddNewUserPageViewModel.usersList));

            AddNewUserPageViewModel.UserName = string.Empty;
            AddNewUserPageViewModel.OnPropertChanged(nameof(AddNewUserPageViewModel.UserName));
            
        }
      
        public override bool CanExecute(object parameter)
        {
            return CanExecuteEvent.Invoke();
        }
        private void OnTextBoxChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ListOfUsersViewModel.UserId) || e.PropertyName == nameof(ListOfUsersViewModel.UserName))
            {
                OnCanExecuteChange();
            }
        }
    }
}
