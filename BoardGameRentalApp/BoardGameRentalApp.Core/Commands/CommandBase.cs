using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoardGameRentalApp.Core
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public event Action MyAction;
        public CommandBase()
        {

        }
        public  CommandBase(Action myAction)
        {
            MyAction = myAction;
        }


        
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
        

        public virtual void Execute(object parameter)
        {
            MyAction.Invoke();
        }
       
       
        protected void OnCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
