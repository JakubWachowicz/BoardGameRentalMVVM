using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels.Controls;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class BoardGameRentalViewModel:ViewModelBase
    {
        public ObservableCollection<UserViewModel> userViewList => boardGameRental.userViewList;
        public ObservableCollection<BoardGameViewModel> boardGamesList => boardGameRental.BoardGamesList;
        public ObservableCollection<RentalViewModel> rentalList => boardGameRental.RentalList;

        public BoardGameRentalModel boardGameRental;
       

        public BoardGameRentalViewModel(BoardGameRentalModel boardGameRental)
        {
            this.boardGameRental = boardGameRental;
        }
    }
}
