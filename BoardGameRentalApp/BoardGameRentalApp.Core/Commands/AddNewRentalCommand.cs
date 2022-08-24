using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    public class AddNewRentalCommand : CommandBase
    {
        public Action MyAction;
        public Func<bool> CanExecuteEvent;
        public ListOfRentalsViewModel ViewModelBase;


        public AddNewRentalCommand(Action myAction, Func<bool> canExecuteEvent, ListOfRentalsViewModel viewModelBase) : base(myAction)
        {
            MyAction = myAction;
            CanExecuteEvent = canExecuteEvent;
            ViewModelBase = viewModelBase;
            ViewModelBase.PropertyChanged += OnTextBoxChange;

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
            if (e.PropertyName == nameof(ViewModelBase.SelectedBoardGame) || e.PropertyName == nameof(ViewModelBase.SelecteduserViewModel))
            {
                OnCanExecuteChange();
            }
        }
    }
}
