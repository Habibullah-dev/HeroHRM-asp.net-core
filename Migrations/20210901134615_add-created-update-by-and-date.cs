using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroHRM.Migrations
{
    public partial class addcreatedupdatebyanddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Resigns",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Resigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Resigns",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Resigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Leaves",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Leaves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Leaves",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Leaves",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Holidays",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Holidays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Holidays",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Holidays",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Resigns");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Resigns");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Resigns");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Resigns");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Holidays");
        }
    }
}
