using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Merchandise_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Merchandise",
                table: "Merchandise");

            migrationBuilder.RenameTable(
                name: "Merchandise",
                newName: "Merchandises");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchandises",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Merchandises",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merchandises",
                table: "Merchandises",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Merchandises",
                table: "Merchandises");

            migrationBuilder.RenameTable(
                name: "Merchandises",
                newName: "Merchandise");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchandise",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Merchandise",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Merchandise",
                table: "Merchandise",
                column: "Id");
        }
    }
}
