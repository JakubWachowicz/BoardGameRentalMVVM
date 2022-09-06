using BoardGameRentalApp.Core.Stores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BoardGameRentalApp.Core.ViewModels;

using BoardGameRentalApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using BoardGameRentalApp.Core.DbContexts;
using BoardGameRentalApp.Core.Service.BoardGamesProvider;
using BoardGameRentalApp.Core.Service.BoardGamesCreator;

namespace BoardGameRentalApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private BoardGameRentalViewModel boardGameRentalViewModel;
        private const string CONNECTION_STRING = "Data Source = boardgameRental.db";

        //private readonly BoardGameRentalMainControl _boardGameRental;
        public App()
        {
            //_boardGameRental = new BoardGameRentalMainControl("Bone'n'roll");
            
           

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (BoardGameRentalDbContext boardGameRentalDbContext = new BoardGameRentalDbContext(options))
            {
                boardGameRentalDbContext.Database.Migrate();
            }
       


            BoardGameRentalDbContextFactory boardGameDbContextFactory = new BoardGameRentalDbContextFactory(CONNECTION_STRING);  
            DbBoardgamesProvider dbBoardgamesProvider = new DbBoardgamesProvider(boardGameDbContextFactory);
            DbBoardGameCreator boardGameCreator = new DbBoardGameCreator(boardGameDbContextFactory);



            BoardGameRentalViewModel boardGameRentalViewModel = new BoardGameRentalViewModel(new BoardGameRentalModel( dbBoardgamesProvider,boardGameCreator));

             var _navigationStore = new NavigationStore();
            BoardGameRentalStore boardGameRentalStore = new BoardGameRentalStore(boardGameRentalViewModel.boardGameRental);
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore, boardGameRentalViewModel,boardGameRentalStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, boardGameRentalViewModel, boardGameRentalStore)
            };
            MainWindow.Show();
            base.OnStartup(e);

        }
       
    }

}
