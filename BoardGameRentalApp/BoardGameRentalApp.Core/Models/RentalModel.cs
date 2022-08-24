using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Models
{
    public class RentalModel
    {
      
        private BoardGameViewModel _boardGameModel;
        private UserViewModel _userModel;

        public RentalModel(BoardGameViewModel boardGameModel, UserViewModel userModel, DateTime rentalDate)
        {
            _boardGameModel = boardGameModel;
            _userModel = userModel;
            this.rentalDate = rentalDate;
        }

        public string UserId  => _userModel.UserId;
        public string UserName => _userModel.UserName;
        public string BoardGameName => _boardGameModel.BoardGameName;


        public DateTime rentalDate { get; set; }


    }
}
