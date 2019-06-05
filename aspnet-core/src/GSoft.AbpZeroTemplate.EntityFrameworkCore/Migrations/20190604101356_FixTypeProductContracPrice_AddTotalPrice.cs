using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixTypeProductContracPrice_AddTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductContracts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ProductContracts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ProductContracts");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ProductContracts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
