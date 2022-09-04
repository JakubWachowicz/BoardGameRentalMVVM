using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.BoardGamesProvider
{
    public interface IBoardGamesProvider
    {
        Task<IEnumerable<BoardGameModel>> GetAllBoardGames();
        Task DeleteBoardGame(BoardGameModel boardGameModel);

        Task<IEnumerable<UserModel>> GetAllUsers();
        Task DeleteUser(UserModel userModel);
    }
}
