using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGameRentalApp.Core.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "listOfUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "listOfUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "listOfUsers");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "listOfUsers");
        }
    }
}
