using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGameRentalApp.Core.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "listOfBoardGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_listOfBoardGames",
                table: "listOfBoardGames",
                column: "BoardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_listOfBoardGames",
                table: "listOfBoardGames");

            migrationBuilder.RenameTable(
                name: "listOfBoardGames",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "BoardGameId");
        }
    }
}
