using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.DTOs;
using BoardGameRentalApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.UserCreator
{
    class DbUserCreator:IUserCreator
    {
        private readonly BoardGameRentalDbContextFactory _boardGameRentalDbContextFactory;

        public DbUserCreator(BoardGameRentalDbContextFactory boardGameRentalDbContextFactory)
        {
            _boardGameRentalDbContextFactory = boardGameRentalDbContextFactory;
        }

        public async Task CreateBoardGame(UserModel userModel)
        {
            using (BoardGameRentalDbContext context = _boardGameRentalDbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = ToUserDTO(userModel);
                context.listOfUsers.Add(userDTO);
                await context.SaveChangesAsync();

            }
        }

        public Task CreateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        private UserDTO ToUserDTO(UserModel userModel)
        {
            return new UserDTO()
            {
               UserId = userModel.UserId,
               UserName = userModel.UserName
            };
        }
    }
}
