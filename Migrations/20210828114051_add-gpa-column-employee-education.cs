using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class addgpacolumnemployeeeducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Supervisor",
                table: "EmployeeSupervisors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subordinate",
                table: "EmployeeSubordinates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gpa",
                table: "EmployeeEducations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supervisor",
                table: "EmployeeSupervisors");

            migrationBuilder.DropColumn(
                name: "Subordinate",
                table: "EmployeeSubordinates");

            migrationBuilder.DropColumn(
                name: "Gpa",
                table: "EmployeeEducations");
        }
    }
}
