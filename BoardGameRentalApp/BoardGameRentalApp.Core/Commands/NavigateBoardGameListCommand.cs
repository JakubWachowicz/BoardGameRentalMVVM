using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.Commands
{
    class NavigateBoardGameListCommand:CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly BoardGameRentalViewModel _boardGameRental;

        public NavigateBoardGameListCommand(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRental)
        {
            _navigationStore = navigationStore;
            _boardGameRental = boardGameRental;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListOfBoardGamesViewModel(_navigationStore, _boardGameRental);
        }
    }
}
