using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    class DeleteUserCommand: AsyncCommandBase
    {
        public ListOfUsersViewModel ViewModelBase;
        private readonly BoardGameRentalStore boardGameRentalStore;

        public DeleteUserCommand(ListOfUsersViewModel viewModelBase, BoardGameRentalStore boardGameRentalStore)
        {
            ViewModelBase = viewModelBase;
            this.boardGameRentalStore = boardGameRentalStore;

        }

        public async override Task ExecuteAsync(object parameter)
        {

            var newList = ViewModelBase.usersList.Where(x => x.IsSelected).ToList();
            var l = new ObservableCollection<UserViewModel>(newList);
            foreach (var item in l)
            {
                ViewModelBase.usersList.Remove(item);
                ViewModelBase.OnPropertChanged(nameof(ViewModelBase.usersList));


                var itemToRemove = boardGameRentalStore._users.SingleOrDefault(x => x.UserId == item.UserId);
                if (itemToRemove != null)
                {
                     await boardGameRentalStore.DeleteUser(itemToRemove);


                }



            }

        }

        public override async void Execute(object parameter)
        {
            try
            {
                IsExecuting = true;
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }

        }
    }
}

