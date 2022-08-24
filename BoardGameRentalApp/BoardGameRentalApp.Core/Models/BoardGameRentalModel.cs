using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Models
{
    public class BoardGameRentalModel
    {
        public ObservableCollection<UserViewModel> userViewList { get; set; } = new ObservableCollection<UserViewModel>();
        public ObservableCollection<BoardGameViewModel> BoardGamesList { get; set; } = new ObservableCollection<BoardGameViewModel>();
        public ObservableCollection<RentalViewModel> RentalList{ get; set; } = new ObservableCollection<RentalViewModel>();
        //ObservableCollection<UserViewModel> userViewModels = new ObservableCollection<UserViewModel>();
    }
}
