using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class NavigateRentalListCommand:CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;


        public NavigateRentalListCommand(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel)
        {
            _navigationStore = navigationStore;
            _boardGameRentalViewModel = boardGameRentalViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListOfRentalsViewModel(_navigationStore, _boardGameRentalViewModel);
        }


    }
}
