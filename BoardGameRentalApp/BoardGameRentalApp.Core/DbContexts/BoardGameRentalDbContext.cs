using BoardGameRentalApp.Core.DTOs;
using BoardGameRentalApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace BoardGameRentalApp.Core.DbContexts
{
    public class BoardGameRentalDbContext : DbContext
    {
        public BoardGameRentalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BoardGameDTO> listOfBoardGames { get; set; }
        public DbSet<UserDTO> listOfUsers { get; set; }


    }
}
