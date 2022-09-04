using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.Models
{
    public class BoardGameModel
    {
        public string BoardGameName;
        public string IAvailable { get; set; } = "Yes";
        public string Genre;
        public bool IsSelected;
        public Guid BoardGameId { get; }

        public BoardGameModel(Guid boardGameId, string genre, string boardGameName)
        {
            BoardGameName = boardGameName;
            Genre = genre;
            BoardGameId = boardGameId;
        }
    }
}
