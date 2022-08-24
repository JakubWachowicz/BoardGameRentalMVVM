using BoardGameRentalApp.Core.Services;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentallApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentallApp.Core.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public BoardGameRentalViewModel boardGameRental;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRental)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.boardGameRental = boardGameRental;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertChanged(nameof(CurrentViewModel));
        }
    }
}
