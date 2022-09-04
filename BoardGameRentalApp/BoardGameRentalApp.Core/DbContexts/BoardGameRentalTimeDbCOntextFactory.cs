using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.DbContexts
{
    class BoardGameRentalTimeDbCOntextFactory : IDesignTimeDbContextFactory<BoardGameRentalDbContext>
    {
        public BoardGameRentalDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source = boardgameRental.db").Options;
            return new BoardGameRentalDbContext(options);
        }
    }
}
