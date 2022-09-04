using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class RentalViewModel:ViewModelBase
    {


        public Guid UserId => _rentalModel.UserId;
        public string BoardGameName => _rentalModel.BoardGameName;
        public string UserName => _rentalModel.UserName;
        public DateTime rentalDate => _rentalModel.rentalDate;
        private readonly RentalModel _rentalModel;
        public bool IsSelected { get; set; }

        public RentalViewModel(RentalModel rentalModel)
        {
            _rentalModel = rentalModel;
        }
    }
}
