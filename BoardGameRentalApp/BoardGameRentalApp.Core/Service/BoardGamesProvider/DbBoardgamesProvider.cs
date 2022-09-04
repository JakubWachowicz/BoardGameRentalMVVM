using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.DTOs;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.BoardGamesProvider
{
    public class DbBoardgamesProvider : IBoardGamesProvider
    {
        private readonly BoardGameRentalDbContextFactory _boardGameRentalDbContextFactory;

        public DbBoardgamesProvider(BoardGameRentalDbContextFactory boardGameRentalDbContext)
        {
            _boardGameRentalDbContextFactory = boardGameRentalDbContext;
        }

        public async Task<IEnumerable<BoardGameModel>> GetAllBoardGames()
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                IEnumerable<BoardGameDTO> boardGames = await context.listOfBoardGames.ToListAsync();
                return boardGames.Select(r => new BoardGameModel(r.BoardGameId, r.Genre, r.Name));
            }
        }


        public async Task DeleteBoardGame(BoardGameModel boardGameModel)
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {

                var item = new BoardGameDTO()
                {
                    BoardGameId = boardGameModel.BoardGameId,
                    Genre = boardGameModel.Genre,
                    Name = boardGameModel.BoardGameName
                };

                var itemToRemove = context.listOfBoardGames.SingleOrDefault(x => x.BoardGameId == item.BoardGameId);
                context.listOfBoardGames.Remove(itemToRemove);
                //context.listOfBoardGames.RemoveRange(context.listOfBoardGames);

                context.SaveChanges();

            }
        }
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> users = await context.listOfUsers.ToListAsync();
                return users.Select(r => new UserModel(r.UserId, r.UserName));
            }
        }


        public async Task DeleteUser(UserModel userModel)
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {

                var item = new UserDTO()
                {
                    UserId = userModel.UserId,
                    UserName = userModel.UserName
                };

                var itemToRemove = context.listOfUsers.SingleOrDefault(x => x.UserId == item.UserId);
                context.listOfUsers.Remove(itemToRemove);
                //context.listOfBoardGames.RemoveRange(context.listOfBoardGames);

                context.SaveChanges();

            }
        }
    }
}
