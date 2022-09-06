using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get{return _userName;}
            set {_userName = value;OnPropertChanged(nameof(UserName));}    
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertChanged(nameof(Password));}
        }



        public ICommand Login { get; set; }
        private NavigationStore _navigationStore;
        private BoardGameRentalViewModel _boardGameRentalViewModel;
        private BoardGameRentalStore _boardGameRentalStore;

        public LoginViewModel(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel, BoardGameRentalStore boardGameRentalStore)
        {
            _navigationStore = navigationStore;
            _boardGameRentalViewModel = boardGameRentalViewModel;
            _boardGameRentalStore = boardGameRentalStore;
            Login = new NavigateBoardGameListCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore);
        }
    }
}
