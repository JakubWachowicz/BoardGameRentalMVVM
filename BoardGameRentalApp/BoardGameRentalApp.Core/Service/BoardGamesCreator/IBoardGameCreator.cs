using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.BoardGamesCreator
{
    public interface IBoardGameCreator
    {
        Task CreateBoardGame(BoardGameModel boardGameModel);
        Task CreateUser(UserModel userModel);

    }
}
