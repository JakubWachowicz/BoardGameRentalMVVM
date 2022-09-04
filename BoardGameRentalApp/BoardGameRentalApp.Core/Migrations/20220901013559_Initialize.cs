using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGameRentalApp.Core.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoardGameId",
                table: "listOfBoardGames",
                newName: "BoardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BoardGameId",
                table: "listOfBoardGames",
                newName: "BoardGameId");
        }
    }
}
