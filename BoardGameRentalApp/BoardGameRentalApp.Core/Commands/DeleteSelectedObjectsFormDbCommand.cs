using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class DeleteSelectedObjectsFormDbCommand : AsyncCommandBase
    {
        public ListOfBoardGamesViewModel ViewModelBase;
        private readonly BoardGameRentalStore boardGameRentalStore;

        public DeleteSelectedObjectsFormDbCommand(ListOfBoardGamesViewModel viewModelBase, BoardGameRentalStore boardGameRentalStore)
        {
            ViewModelBase = viewModelBase;
            this.boardGameRentalStore = boardGameRentalStore;
           
        }

        public override Task ExecuteAsync(object parameter)
        { 

            var newList = ViewModelBase.BoardGameList.Where(x => x.IsSelected).ToList();
            var l = new ObservableCollection<BoardGameViewModel>(newList);
            foreach (var item in l)
            {
                ViewModelBase.BoardGameList.Remove(item);
                ViewModelBase.OnPropertChanged(nameof(ViewModelBase.BoardGameList));

                
                var itemToRemove = boardGameRentalStore._boardGames.SingleOrDefault(x => x.BoardGameName == item.BoardGameName);
                if(itemToRemove != null)
                {
                    return boardGameRentalStore.DeleteBoardGame(itemToRemove);
                    

                }
                


            }
            return null;

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
    }
}
