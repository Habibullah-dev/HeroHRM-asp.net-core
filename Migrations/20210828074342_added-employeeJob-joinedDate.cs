using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class addedemployeeJobjoinedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedDate",
                table: "EmployeeJobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "EmployeeJobs");
        }
    }
}
