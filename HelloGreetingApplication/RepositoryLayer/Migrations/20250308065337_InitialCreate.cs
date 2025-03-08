using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Greetings");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Greetings",
                newName: "GreetingMessage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings");

            migrationBuilder.RenameTable(
                name: "Greetings",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "GreetingMessage",
                table: "Users",
                newName: "message");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
