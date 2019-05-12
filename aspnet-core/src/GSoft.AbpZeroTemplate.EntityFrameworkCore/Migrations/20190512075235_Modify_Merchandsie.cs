using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Modify_Merchandsie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Info",
                table: "MerchandiseTypes",
                newName: "TypeID");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MerchandiseTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MerchandiseTypes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Merchandises",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Merchandises",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Merchandises",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Merchandises",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeVender",
                table: "Merchandises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Merchandises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MerchandiseTypes");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "MerchandiseTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Merchandises");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Merchandises");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Merchandises");

            migrationBuilder.DropColumn(
                name: "TypeVender",
                table: "Merchandises");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Merchandises");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "MerchandiseTypes",
                newName: "Info");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Merchandises",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
