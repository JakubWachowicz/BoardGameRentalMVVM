using BoardGameRentalApp.Core.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BoardGameRentalApp.Core.ViewModels;
using BoardGameRentallApp.Core.ViewModels;
using BoardGameRentalApp.Core.Models;

namespace BoardGameRentalApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly BoardGameRentalMainControl _boardGameRental;
        public App()
        {
            //_boardGameRental = new BoardGameRentalMainControl("Bone'n'roll");
            
           

        }

        protected override void OnStartup(StartupEventArgs e)
        {
              BoardGameRentalViewModel boardGameRentalViewModel = new BoardGameRentalViewModel(new BoardGameRentalModel());
             var _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new ListOfBoardGamesViewModel(_navigationStore, boardGameRentalViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, boardGameRentalViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
