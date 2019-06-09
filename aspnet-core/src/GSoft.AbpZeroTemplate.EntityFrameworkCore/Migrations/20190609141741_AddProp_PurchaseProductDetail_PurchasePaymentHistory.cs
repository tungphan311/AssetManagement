using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddProp_PurchaseProductDetail_PurchasePaymentHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "PurchaseProductDetails",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "PurchaseProductDetails",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNumber",
                table: "PurchaseProductDetails",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchaseProductDetails",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchasePaymentHistories",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentNumber",
                table: "PurchasePaymentHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "PurchasePaymentHistories",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percent",
                table: "PurchasePaymentHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PurchasePaymentHistories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproval",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "PurchaseProductDetails");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "PurchaseProductDetails");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNumber",
                table: "PurchaseProductDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchaseProductDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchasePaymentHistories");

            migrationBuilder.DropColumn(
                name: "InstallmentNumber",
                table: "PurchasePaymentHistories");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "PurchasePaymentHistories");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "PurchasePaymentHistories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PurchasePaymentHistories");

            migrationBuilder.DropColumn(
                name: "IsApproval",
                table: "PurchaseOrders");
        }
    }
}
