using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Modify_Vendor_VendorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "VendorTypes",
                newName: "Note");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "VendorTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VendorTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vendors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TIN",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "VendorTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VendorTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TIN",
                table: "Vendors");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "VendorTypes",
                newName: "Info");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Vendor",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vendor",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Vendor",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Vendor",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");
        }
    }
}
