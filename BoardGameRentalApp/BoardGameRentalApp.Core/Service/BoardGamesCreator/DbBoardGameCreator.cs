using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.DTOs;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.BoardGamesCreator
{
    public class DbBoardGameCreator : IBoardGameCreator
    {
        private readonly BoardGameRentalDbContextFactory _boardGameRentalDbContextFactory;

        public DbBoardGameCreator(BoardGameRentalDbContextFactory boardGameRentalDbContextFactory)
        {
            _boardGameRentalDbContextFactory = boardGameRentalDbContextFactory;
        }

        public async Task CreateBoardGame(BoardGameModel boardGameModel)
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                BoardGameDTO boardGameDTO = ToBoardGameDTO(boardGameModel);
                context.listOfBoardGames.Add(boardGameDTO);
                await context.SaveChangesAsync();

            }
        }

      

        public async Task CreateUser(UserModel userModel)
        {
             using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = ToUserDTO(userModel);
                context.listOfUsers.Add(userDTO);
                await context.SaveChangesAsync();

            }
        }

        private UserDTO ToUserDTO(UserModel userModel)
        {
            return new UserDTO()
            {
                UserId = userModel.UserId,
                UserName = userModel.UserName
            };
        }


        private BoardGameDTO ToBoardGameDTO(BoardGameModel boardGameModel)
        {
            return new BoardGameDTO()
            {
                BoardGameId = boardGameModel.BoardGameId,
                Genre = boardGameModel.Genre,
                Name = boardGameModel.BoardGameName
            };
        }

    }
}
