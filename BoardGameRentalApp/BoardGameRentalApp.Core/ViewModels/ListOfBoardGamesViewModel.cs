using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentallApp.Core.Commands;
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
    public class ListOfBoardGamesViewModel:ViewModelBase
    {

        public ObservableCollection<BoardGameViewModel> BoardGameList => _boardGameRentalViewModel.boardGamesList;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;
        private string _boardGameName = "";
        private string _genre = "";

        public string BoardGameName
        {
            get
            {
                return _boardGameName;
            }
            set
            {
                _boardGameName = value;
                OnPropertChanged(nameof(BoardGameName));
            }
        }
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertChanged(nameof(Genre));
            }
        }




        public ICommand AddNewBoardGame { get; set; }

        public ICommand DeleteSelectedBoardGames { get; set; }


        public ICommand ChangeToUsersView { get; set; }
        public ICommand ChangeToRentalsView{ get; set; }
        



        public ListOfBoardGamesViewModel(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRentalViewModel)
        {
            AddNewBoardGame = new AddNewBoardGameCommand(AddBoardGame, AddNewBoardGameCanExecute, this);
            DeleteSelectedBoardGames = new CommandBase(DeleteBoardGames);
            _boardGameRentalViewModel = boardGameRentalViewModel;
            ChangeToUsersView = new NavigateUserListCommand(navigationStore, _boardGameRentalViewModel);
            ChangeToRentalsView = new NavigateRentalListCommand(navigationStore, _boardGameRentalViewModel);



        }

        public void DeleteBoardGames()
        {
            var newList = BoardGameList.Where(x => x.IsSelected).ToList();
            var l = new System.Collections.ObjectModel.ObservableCollection<BoardGameViewModel>(newList);
            foreach (var item in l)
            {
                BoardGameList.Remove(item);
            }


        }


        public bool AddNewBoardGameCanExecute()
        {
            return !(BoardGameName.Trim() == string.Empty || Genre.Trim() == string.Empty);
        }

        public void AddBoardGame()
        {
            BoardGameViewModel NewBoardGame = new BoardGameViewModel(new BoardGameModel(Genre, BoardGameName));
            BoardGameList.Add(NewBoardGame);


            BoardGameName = string.Empty;
            Genre = string.Empty;
            OnPropertChanged(nameof(BoardGameName));
            OnPropertChanged(nameof(Genre));
        }
    }
}

