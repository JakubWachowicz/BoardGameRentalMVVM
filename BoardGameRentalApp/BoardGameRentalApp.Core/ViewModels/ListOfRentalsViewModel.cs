using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class ListOfRentalsViewModel : ViewModelBase
    {
        public ObservableCollection<RentalViewModel> rentalList => _boardGameRentalViewModel.rentalList;
        public ObservableCollection<BoardGameViewModel> boardGameList => _boardGameRentalViewModel.boardGamesList;
        public ObservableCollection<UserViewModel> userList => _boardGameRentalViewModel.userViewList;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;

        public ICommand ChangeToBoardGamesView { get; set; }
        public ICommand ChangeToUsersView { get; set; }
        public ICommand ChangeToRentalsView { get; set; }
        private  BoardGameViewModel _selectedBoardGame;
        public BoardGameViewModel SelectedBoardGame
        {
            get
            {
                return _selectedBoardGame;
            }
            set
            {
                _selectedBoardGame = value;
                OnPropertChanged(nameof(SelectedBoardGame));
            }
        }
        private UserViewModel _userViewModel;
        public UserViewModel SelecteduserViewModel
        {
            get
            {
                return _userViewModel;
            }
            set
            {
                _userViewModel = value;
                OnPropertChanged(nameof(SelecteduserViewModel));
            }
        }

        public ICommand AddNewRental { get; set; }
        public ListOfRentalsViewModel(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRentalViewModel)
        {
            _boardGameRentalViewModel = boardGameRentalViewModel;
            ChangeToBoardGamesView = new NavigateBoardGameListCommand(navigationStore, boardGameRentalViewModel);
            ChangeToUsersView = new NavigateUserListCommand(navigationStore, boardGameRentalViewModel);
            AddNewRental = new AddNewRentalCommand(AddRental, AddNewRentalCanExecute,this);


        }
        public bool AddNewRentalCanExecute()
        {
            return !(SelectedBoardGame == null || SelecteduserViewModel == null);
        }
        public void AddRental()
        {
            RentalViewModel NewUser = new RentalViewModel(new RentalModel(SelectedBoardGame, SelecteduserViewModel, DateTime.Now));
            rentalList.Add(NewUser);


            SelectedBoardGame = default;
            SelecteduserViewModel = default;
            OnPropertChanged(nameof(SelectedBoardGame));
            OnPropertChanged(nameof(SelecteduserViewModel));
        }
    }
}
