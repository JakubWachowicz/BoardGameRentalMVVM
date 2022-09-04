using BoardGameRentalApp.Core.Services;
using BoardGameRentalApp.Core.Stores;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentalApp.Core.ViewModels.Controls;
using BoardGameRentalApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public BoardGameRentalViewModel boardGameRental;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        
        public MainViewModel(NavigationStore navigationStore, BoardGameRentalViewModel boardGameRental,BoardGameRentalStore boardGameRentalStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.boardGameRental = boardGameRental;
            NavigationBarViewModel navigationBarViewModel = new NavigationBarViewModel(_navigationStore, boardGameRental, boardGameRentalStore);


    }

    private void OnCurrentViewModelChanged()
        {
            OnPropertChanged(nameof(CurrentViewModel));
        }
    }
}
