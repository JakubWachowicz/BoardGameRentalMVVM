using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public Guid UserId { get; }
        public bool IsSelected { get; set; }


        public UserModel(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }


    }
}
