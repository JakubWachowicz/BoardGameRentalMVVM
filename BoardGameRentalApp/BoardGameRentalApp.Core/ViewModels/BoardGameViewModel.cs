using BoardGameRentalApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.ViewModels
{
    public class BoardGameViewModel
    {
        private readonly BoardGameModel _boardGameModel;

        public string BoardGameName => _boardGameModel.BoardGameName;
        public string Genre => _boardGameModel.Genre;


        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return BoardGameName;
        }

        public BoardGameViewModel(BoardGameModel boardGameModel)
        {
            _boardGameModel = boardGameModel;
        }
    }
}
