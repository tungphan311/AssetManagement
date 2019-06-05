using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Delete_BlankField_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlankField0",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField10",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField6",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField7",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField8",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField9",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlankField0",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlankField1",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BlankField10",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlankField2",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField3",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField4",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField5",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BlankField6",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField7",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField8",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField9",
                table: "Products",
                nullable: true);
        }
    }
}
