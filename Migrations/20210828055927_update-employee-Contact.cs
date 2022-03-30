using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class updateemployeeContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EmployeeContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fax",
                table: "EmployeeContactDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EmployeeContactDetails");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "EmployeeContactDetails");
        }
    }
}
