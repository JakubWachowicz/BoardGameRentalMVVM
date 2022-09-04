using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.DTOs;
using BoardGameRentalApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.UserProvider
{
    class DbUserProvider
    {
        private readonly BoardGameRentalDbContextFactory _boardGameRentalDbContextFactory;

        public DbUserProvider(BoardGameRentalDbContextFactory boardGameRentalDbContext)
        {
            _boardGameRentalDbContextFactory = boardGameRentalDbContext;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> users = await context.listOfUsers.ToListAsync();
                return users.Select(r => new UserModel(r.UserId,r.UserName));
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
