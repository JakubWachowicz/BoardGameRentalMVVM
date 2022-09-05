using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.Models;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels.Controls;
using BoardGameRentalApp.Core.Commands;
using BoardGameRentalApp.Core.ViewModels;
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
        public NavigationBarViewModel NavigationBarViewModel;
        private BoardGameRentalStore _boardGameRentalStore;
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
        public ListOfUsersViewModel(NavigationStore navigationStore,BoardGameRentalViewModel boardGameRental,BoardGameRentalStore boardGameRentalStore)
        {

           
            _boardGameRentalViewModel = boardGameRental;
            AddNewUser = new AddNewUserCommand(AddNewUserCanExecute, boardGameRentalStore,this);
            DeleteUser = new DeleteUserCommand(this, boardGameRentalStore);
            //foreach (var d in boardGameRentalStore.UserAdded.G)
            //{
            //    FindClicked -= (FindClickedHandler)d;
            //}
            boardGameRentalStore.ResetSubscriptions();
            
            boardGameRentalStore.UserAdded += OnUserAdded;
            ChangeToBoardGamesView = new NavigateBoardGameListCommand(navigationStore, boardGameRental,boardGameRentalStore);
            ChangeToRentalsView = new NavigateBoardGamesCommand(navigationStore, boardGameRental,boardGameRentalStore);
            NavigationBarViewModel = new NavigationBarViewModel(navigationStore, boardGameRental,boardGameRentalStore);
            _boardGameRentalStore = boardGameRentalStore;
            UpdateListOfUsers(boardGameRentalStore._users);

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

        private void OnUserAdded(UserModel reservation)
        {
            var reservationViewModel = new UserViewModel(reservation);
            usersList.Add(reservationViewModel);
        }



        public bool AddNewUserCanExecute()
        {
            return !(UserName.Trim() == string.Empty);
        }

        
        public void UpdateListOfUsers(IEnumerable<UserModel> users)
        {
            usersList.Clear();

            foreach (UserModel user in users)
            {
                UserViewModel newUser = new UserViewModel(user);
                usersList.Add(newUser);
            }
        }
        
    }

}
