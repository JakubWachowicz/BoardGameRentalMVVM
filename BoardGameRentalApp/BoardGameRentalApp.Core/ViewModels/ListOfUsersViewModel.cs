using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentallApp.Core.Commands;
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core.ViewModels
{
   public class ListOfUsersViewModel:ViewModelBase
    {
        public ObservableCollection<UserViewModel> usersList => _boardGameRentalViewModel.userViewList;
        private readonly BoardGameRentalViewModel _boardGameRentalViewModel;
        private string _userName = "";
        private string _userId = "";

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertChanged(nameof(UserName));
            }
        }
        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                OnPropertChanged(nameof(UserId));
            }
        }
        public ICommand AddNewUser { get; set; }

        public ICommand DeleteUser { get; set; }
        public ICommand ChangeToBoardGamesView { get; set; }
        public ICommand ChangeToUsersView { get; set; }
        public ICommand ChangeToRentalsView { get; set; }
        public ListOfUsersViewModel(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRental)
        {
            _boardGameRentalViewModel = boardGameRental;
            AddNewUser = new AddNewUserCommand(AddNewUse, AddNewUserCanExecute, this);
            DeleteUser = new CommandBase(DeleteSelectedUsers);
            ChangeToBoardGamesView = new NavigateBoardGameListCommand(navigationStore, boardGameRental);
            ChangeToRentalsView = new NavigateRentalListCommand(navigationStore, _boardGameRentalViewModel);


        }

        public void DeleteSelectedUsers()
        {
            var newList = usersList.Where(x => x.IsSelected).ToList();
            var l = new ObservableCollection<UserViewModel>(newList);
            foreach (var item in l)
            {
                usersList.Remove(item);
            }


        }


        public bool AddNewUserCanExecute()
        {
            return !(UserName.Trim() == string.Empty || UserId.Trim() == string.Empty);
        }

        public void AddNewUse()
        {
            UserViewModel NewUser = new UserViewModel(new UserModel(UserId, UserName));
            usersList.Add(NewUser);


            UserId = string.Empty;
            UserName = string.Empty;
            OnPropertChanged(nameof(UserName));
            OnPropertChanged(nameof(UserId));
        }
    }

}
