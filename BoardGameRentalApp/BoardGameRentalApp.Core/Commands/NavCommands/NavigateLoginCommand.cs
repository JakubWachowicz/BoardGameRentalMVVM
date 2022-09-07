using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands.NavCommands
{
    class NavigateLoginCommand: Core.AsyncCommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;
        private readonly BoardGameRentalStore boardGameRentalStore;

        public NavigateLoginCommand(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel, BoardGameRentalStore boardGameRentalStore)
        {
            _navigationStore = navigationStore;
            _boardGameRentalViewModel = boardGameRentalViewModel;
            this.boardGameRentalStore = boardGameRentalStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore, _boardGameRentalViewModel, boardGameRentalStore);
        }

    }
}
