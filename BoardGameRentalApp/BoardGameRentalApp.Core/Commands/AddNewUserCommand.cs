using BoardGameRentalApp.Core;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentallApp.Core.Commands
{
    class AddNewUserCommand:CommandBase
    {
        public Action MyAction;
        public Func<bool> CanExecuteEvent;
        public ListOfUsersViewModel AddNewUserPageViewModel;


        public AddNewUserCommand(Action myAction, Func<bool> canExecuteEvent, ListOfUsersViewModel addNewUserPageViewModel) : base(myAction)
        {
            MyAction = myAction;
            CanExecuteEvent = canExecuteEvent;
            AddNewUserPageViewModel = addNewUserPageViewModel;
            AddNewUserPageViewModel.PropertyChanged += OnTextBoxChange;

        }

        public override void Execute(object parameter)
        {
            MyAction.Invoke();
        }
        public override bool CanExecute(object parameter)
        {
            return CanExecuteEvent.Invoke();
        }
        private void OnTextBoxChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ListOfUsersViewModel.UserId) || e.PropertyName == nameof(ListOfUsersViewModel.UserName))
            {
                OnCanExecuteChange();
            }
        }
    }
}
