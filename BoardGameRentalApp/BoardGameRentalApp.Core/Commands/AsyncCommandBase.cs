using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Commands
{
    public abstract class AsyncCommandBase: Core.AsyncCommandBase
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set 
            {
                _isExecuting = value;
                OnCanExecuteChange();
            }
        }
        public override bool CanExecute(object parametr)
        {
            return !IsExecuting && base.CanExecute(parametr);
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

        public abstract Task ExecuteAsync(object parameter);
    }

}
