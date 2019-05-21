using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class modify_projects_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ContractWarrantyFile",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarrantyGuaranteeFile",
                table: "Contracts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ContractWarrantyFile",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "WarrantyGuaranteeFile",
                table: "Contracts");
        }
    }
}
