using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixType_PurchasePaymentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PurchasePaymentHistories",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "PurchasePaymentHistories",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "InstallmentNumber",
                table: "PurchasePaymentHistories",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PurchasePaymentHistories",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "PurchasePaymentHistories",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstallmentNumber",
                table: "PurchasePaymentHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
