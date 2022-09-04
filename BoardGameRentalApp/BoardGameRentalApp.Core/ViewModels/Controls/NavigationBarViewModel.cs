using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels.Controls
{
    public class NavigationBarViewModel:ViewModelBase
    {
        public ICommand ChangeToBoardGamesView { get; set; }
        public ICommand ChangeToUsersView { get; set; }
        public ICommand ChangeToRentalsView { get; set; }

        public NavigationBarViewModel(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel,BoardGameRentalStore boardGameRentalStore)
        {
            ChangeToUsersView = new NavigateUserListCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore);
            ChangeToRentalsView = new NavigateBoardGamesCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore);
            ChangeToBoardGamesView = new NavigateBoardGamesCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore);
        }
    }
}
