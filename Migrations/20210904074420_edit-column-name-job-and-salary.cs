using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class editcolumnnamejobandsalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobs_JobCategories_jobCategoriesId",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_PayGrades_payGradesId",
                table: "EmployeeSalaries");

            migrationBuilder.RenameColumn(
                name: "payGradesId",
                table: "EmployeeSalaries",
                newName: "PayGradesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_payGradesId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_PayGradesId");

            migrationBuilder.RenameColumn(
                name: "jobCategoriesId",
                table: "EmployeeJobs",
                newName: "JobCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobs_jobCategoriesId",
                table: "EmployeeJobs",
                newName: "IX_EmployeeJobs_JobCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobs_JobCategories_JobCategoriesId",
                table: "EmployeeJobs",
                column: "JobCategoriesId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_PayGrades_PayGradesId",
                table: "EmployeeSalaries",
                column: "PayGradesId",
                principalTable: "PayGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobs_JobCategories_JobCategoriesId",
                table: "EmployeeJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_PayGrades_PayGradesId",
                table: "EmployeeSalaries");

            migrationBuilder.RenameColumn(
                name: "PayGradesId",
                table: "EmployeeSalaries",
                newName: "payGradesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_PayGradesId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_payGradesId");

            migrationBuilder.RenameColumn(
                name: "JobCategoriesId",
                table: "EmployeeJobs",
                newName: "jobCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobs_JobCategoriesId",
                table: "EmployeeJobs",
                newName: "IX_EmployeeJobs_jobCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobs_JobCategories_jobCategoriesId",
                table: "EmployeeJobs",
                column: "jobCategoriesId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_PayGrades_payGradesId",
                table: "EmployeeSalaries",
                column: "payGradesId",
                principalTable: "PayGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
