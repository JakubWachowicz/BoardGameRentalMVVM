using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.DbContexts
{
    public class BoardGameRentalDbContextFactory
    {
        private readonly string _connectionString;

        public BoardGameRentalDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BoardGameRentalDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new BoardGameRentalDbContext(options);
        }
    }
}
