using BoardGameRentalApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Service.UserCreator
{
    interface IUserCreator
    {
        Task CreateUser(UserModel userModel);
    }
}
