using BoardGameRentalApp.Core.Models;
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        private readonly UserModel _userModel;
        public string UserName => _userModel.UserName;
        public string UserId => _userModel.UserId;
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return UserId +" "+ UserName;
        }

        public UserViewModel(UserModel userModel)
        {
            _userModel = userModel;
        }
    }
}
