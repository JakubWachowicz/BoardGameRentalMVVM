
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        private ViewModelBase _currentVieModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentVieModel;
            set { 
                _currentVieModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
