using BoardGameRentalApp.Core;
using BoardGameRentalApp.Core.Models;
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
    public class AddNewBoardGameCommand : AsyncCommandBase
    {
        public Action MyAction;
        public Func<bool> CanExecuteEvent;
        public ListOfBoardGamesViewModel ViewModelBase;
        private readonly BoardGameRentalStore boardGameRentalStore;

        public AddNewBoardGameCommand(ListOfBoardGamesViewModel viewModelBase,BoardGameRentalStore boardGameRentalStore,Func<bool> canExecuteEvent)
        {

            CanExecuteEvent = canExecuteEvent;
            ViewModelBase = viewModelBase;
            this.boardGameRentalStore = boardGameRentalStore;
            ViewModelBase.PropertyChanged += OnTextBoxChange;
            
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
            BoardGameModel NewBoardGame =new BoardGameModel(g,ViewModelBase.Genre, ViewModelBase.BoardGameName);
            //BoardGameList.Add(NewBoardGame);
            // await ViewModelBase._boardGameRentalViewModel.boardGameRental.AddBoardGameAsync(new BoardGameModel(ViewModelBase.Genre, ViewModelBase.BoardGameName));
            await boardGameRentalStore.AddBoardGame(NewBoardGame);
            ViewModelBase.OnPropertChanged(nameof(ViewModelBase.BoardGameList));

            ViewModelBase.BoardGameName = string.Empty;
            ViewModelBase.Genre = string.Empty;
            ViewModelBase.OnPropertChanged(nameof(ViewModelBase.BoardGameName));
            ViewModelBase.OnPropertChanged(nameof(ViewModelBase.Genre));
        }
        public override bool CanExecute(object parameter)
        {
            return CanExecuteEvent.Invoke();
        }
        private void OnTextBoxChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ViewModelBase.Genre) || e.PropertyName == nameof(ViewModelBase.BoardGameName))
            {
                OnCanExecuteChange();
            }
        }

       
    }
}
