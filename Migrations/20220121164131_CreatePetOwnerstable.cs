using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class CreatePetOwnerstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "petOwnerId",
                table: "Pets",
                newName: "petOwnerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pets",
                newName: "petOwnerId");
        }
    }
}
