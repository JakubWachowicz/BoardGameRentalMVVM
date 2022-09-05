using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
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
        public Guid UserId => _userModel.UserId;
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return   UserName + " "+ UserId.ToString().Substring(0, 4);
        }

        public UserViewModel(UserModel userModel)
        {
            _userModel = userModel;
        }
    }
}
