using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class EditProviderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Providers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Providers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                nullable: true);
        }
    }
}
