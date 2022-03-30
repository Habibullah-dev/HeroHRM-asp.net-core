using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class updateemployeelicenseexpirydate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expiryDate",
                table: "EmployeeLicenses",
                newName: "ExpiryDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "EmployeeLicenses",
                newName: "expiryDate");
        }
    }
}
