using BoardGameRentalApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Stores
{
    public class BoardGameRentalStore
    {
       
        public readonly List<BoardGameModel> _boardGames = new List<BoardGameModel>();
        public readonly List<UserModel> _users = new List<UserModel>();
        public event Action<BoardGameModel> BoardGameAdded;
        public event Action<BoardGameModel> BoardGameDeleted;


        public void ResetSubscriptions() => UserAdded = null;

        public event Action<UserModel> UserAdded;
       

        public event Action<UserModel> UserDeleted;
        private readonly BoardGameRentalModel _boardGameRental;
        private Lazy<Task> _initializeLazy;


        public BoardGameRentalStore(BoardGameRentalModel boardGameRental)
        {
            _boardGameRental = boardGameRental;
            _initializeLazy = new Lazy<Task>(Initialize);
        }

        public async Task AddBoardGame(BoardGameModel reservation)
        {

            await _boardGameRental.AddBoardGameAsync(reservation);

            _boardGames.Add(reservation);

            //BoardGameAdded(reservation);
            OnBoardGameAdded(reservation);
        }
        public async Task AddUser(UserModel reservation)
        {

            await _boardGameRental.AddUserAsync(reservation);

            _users.Add(reservation);

            //BoardGameAdded(reservation);
            OnUserAdded(reservation);
        }

        public async Task DeleteBoardGame(BoardGameModel reservation)
        {

            await _boardGameRental.DeleteBoardGame(reservation);
            //BoardGameAdded(reservation);
            OnBoardGameDeleted(reservation);
        }
        public async Task DeleteUser(UserModel reservation)
        {

            await _boardGameRental.DeleteUser(reservation);
            //BoardGameAdded(reservation);
            OnUserDeleted(reservation);
        }


        private void OnBoardGameAdded(BoardGameModel reservation)
        {
            BoardGameAdded?.Invoke(reservation);
        }
        private void OnUserAdded(UserModel reservation)
        {
            UserAdded?.Invoke(reservation);
        }

        private void OnBoardGameDeleted(BoardGameModel reservation)
        {
            BoardGameDeleted?.Invoke(reservation);
        }
        private void OnUserDeleted(UserModel  reservation)
        {
            UserDeleted?.Invoke(reservation);
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }
        public async Task Initialize()
        {
            IEnumerable<BoardGameModel> games = await _boardGameRental.GetAllBoardGames();
            IEnumerable<UserModel> users = await _boardGameRental.GetAllUsers();


            _boardGames.Clear();
            _boardGames.AddRange(games);
            _users.Clear();
            _users.AddRange(users);
        }
    }
}
