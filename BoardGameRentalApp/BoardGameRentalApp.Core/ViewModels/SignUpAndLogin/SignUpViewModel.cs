using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Commands.NavCommands;
using BoardGameRentalApp.Core.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels.SignUpAndLogin
{
    public class SignUpViewModel:ViewModelBase
    {
        private string _userName = "";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertChanged(nameof(UserName)); }
        }

        private string _password = "";

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertChanged(nameof(Password)); }

        }
        private string _confirmPassword = "";

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertChanged(nameof(ConfirmPassword)); }
        }

        public ICommand Login { get; set; }
        public ICommand CreateNewAccount { get; set; }

        private NavigationStore _navigationStore;
        private BoardGameRentalViewModel _boardGameRentalViewModel;
        private BoardGameRentalStore _boardGameRentalStore;

        public SignUpViewModel(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRentalViewModel, BoardGameRentalStore boardGameRentalStore)
        {
            _navigationStore = navigationStore;
            _boardGameRentalViewModel = boardGameRentalViewModel;
            _boardGameRentalStore = boardGameRentalStore;
            Login = new NavigateLoginCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore);
            CreateNewAccount = new CreateNewUserAccountCommand(navigationStore, boardGameRentalViewModel, boardGameRentalStore,this);
            
        }
    }
}
