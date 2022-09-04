using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class ListOfBoardGamesViewModel:ViewModelBase
    {
        private readonly ObservableCollection<BoardGameViewModel> _boardgamesList = new ObservableCollection<BoardGameViewModel>();
        public ObservableCollection<BoardGameViewModel> BoardGameList => _boardgamesList;
        public BoardGameRentalViewModel _boardGameRentalViewModel;
        private string _boardGameName = "";
        private string _genre = "";
        public NavigationBarViewModel NavigationBarViewModel;
        private BoardGameRentalStore _boardGameRentalStore;

        
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
        public ICommand ChangeToBoardGamesView { get; set; }
        public BoardGameRentalStore BoardGameRentalStore { get; }

        public ListOfBoardGamesViewModel(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRentalViewModel , BoardGameRentalStore boardGameRentalStore)
        {
            _boardGameRentalStore = boardGameRentalStore;
            

           

            AddNewBoardGame = new AddNewBoardGameCommand(this, _boardGameRentalStore,CanExecute);

             DeleteSelectedBoardGames = new DeleteSelectedObjectsFormDbCommand(this, boardGameRentalStore);
            _boardGameRentalViewModel = boardGameRentalViewModel;
            BoardGameRentalStore = boardGameRentalStore;
            ChangeToUsersView = new NavigateUserListCommand(navigationStore, _boardGameRentalViewModel, _boardGameRentalStore);
            ChangeToRentalsView = new NavigateBoardGamesCommand(navigationStore, _boardGameRentalViewModel, _boardGameRentalStore);

            NavigationBarViewModel = new NavigationBarViewModel(navigationStore, boardGameRentalViewModel, _boardGameRentalStore);
            boardGameRentalStore.BoardGameAdded += OnBoardGameAdded;
            boardGameRentalStore.BoardGameDeleted += OnBoardGameDeleted;

            LoadDb = Load;
            LoadDb.Invoke();
            UpdateListOfBoardGames(_boardGameRentalStore._boardGames);


        }
        private bool CanExecute()
        {
            return BoardGameName.Trim() != String.Empty && Genre.Trim() != String.Empty;
        }
        public void DeleteBoardGames()
        {
            var newList = BoardGameList.Where(x => x.IsSelected).ToList();
            var l = new ObservableCollection<BoardGameViewModel>(newList);
            foreach (var item in l)
            {
                BoardGameList.Remove(item);
            }


        }


        public bool AddNewBoardGameCanExecute()
        {
            return !(BoardGameName.Trim() == string.Empty || Genre.Trim() == string.Empty);
        }

        //public async Task AddBoardGame()
        //{
        //    //BoardGameViewModel NewBoardGame = new BoardGameViewModel();
        //    //BoardGameList.Add(NewBoardGame);
        //    await _boardGameRentalViewModel.boardGameRental.AddBoardGameAsync(new BoardGameModel(int 4,Genre, BoardGameName));
        //    OnPropertChanged(nameof(BoardGameList));

        //    BoardGameName = string.Empty;
        //    Genre = string.Empty;
        //    OnPropertChanged(nameof(BoardGameName));
        //    OnPropertChanged(nameof(Genre));

        //}

        public Func<Task> LoadDb;

        public async Task Load()
        {
            await _boardGameRentalStore.Initialize();
        }

        private void OnBoardGameAdded(BoardGameModel reservation)
        {
            BoardGameViewModel reservationViewModel = new BoardGameViewModel(reservation);
            BoardGameList.Add(reservationViewModel);
        }

        private void OnBoardGameDeleted(BoardGameModel reservation)
        {
            BoardGameViewModel reservationViewModel = new BoardGameViewModel(reservation);
            BoardGameList.Remove(reservationViewModel);
        }




        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public void UpdateListOfBoardGames(IEnumerable<BoardGameModel> boardgames)
        {
            _boardgamesList.Clear();

            foreach (BoardGameModel boardgame in boardgames)
            {
                BoardGameViewModel newBoardGame = new BoardGameViewModel(boardgame);
                _boardgamesList.Add(newBoardGame);
            }
        }
       

    }
}

