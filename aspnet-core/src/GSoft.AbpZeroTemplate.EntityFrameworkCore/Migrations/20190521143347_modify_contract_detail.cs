using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class modify_contract_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "Bidders");

            migrationBuilder.AddColumn<string>(
                name: "MerName",
                table: "ContractDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ContractDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerName",
                table: "ContractDetails");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ContractDetails");

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorID",
                table: "Bidders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
