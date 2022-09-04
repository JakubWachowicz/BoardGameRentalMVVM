using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.Service.BoardGamesCreator;
using BoardGameRentalApp.Core.Service.BoardGamesProvider;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Models
{
    public class BoardGameRentalModel
    {
       public ObservableCollection<UserViewModel> userViewList { get; set; } = new ObservableCollection<UserViewModel>();
       private ObservableCollection<BoardGameViewModel> _boardGamesList;
       public ObservableCollection<BoardGameViewModel> BoardGamesList = new ObservableCollection<BoardGameViewModel>();
        public BoardGameRentalDbContext boardGameRentalDbContext;
        public ObservableCollection<RentalViewModel> RentalList{ get; set; } = new ObservableCollection<RentalViewModel>();

        private readonly IBoardGamesProvider _boardGamesProvider;
        private readonly IBoardGameCreator _boardGameCreator;

       



        public BoardGameRentalModel(IBoardGamesProvider boardGamesProvider, IBoardGameCreator boardGameCreator)
        {
            _boardGamesProvider = boardGamesProvider;
            _boardGameCreator = boardGameCreator;
            
        }
     
        public async Task<IEnumerable<BoardGameModel>> GetAllBoardGames()
        {
            return await _boardGamesProvider.GetAllBoardGames();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _boardGamesProvider.GetAllUsers();
        }

        public async Task AddBoardGameAsync(BoardGameModel boardGameModel)
        {
            await _boardGameCreator.CreateBoardGame(boardGameModel);
        }
        public async Task DeleteBoardGame(BoardGameModel boardGameModel)
        {
            await _boardGamesProvider.DeleteBoardGame(boardGameModel);
        }
        public async Task DeleteUser(UserModel userModel)
        {
            await _boardGamesProvider.DeleteUser(userModel);
        }
        public async Task AddUserAsync(UserModel userModel)
        {
            await _boardGameCreator.CreateUser(userModel);
        }
        //ObservableCollection<UserViewModel> userViewModels = new ObservableCollection<UserViewModel>();
    }
}
