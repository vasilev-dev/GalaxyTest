using Microsoft.EntityFrameworkCore.Migrations;

namespace GalaxyTest.Migrations
{
    public partial class RenameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Information_BirthDate",
                table: "AspNetUsers",
                newName: "Information_Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Information_Birthday",
                table: "AspNetUsers",
                newName: "Information_BirthDate");
        }
    }
}
