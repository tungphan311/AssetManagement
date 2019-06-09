using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixPropertyName_PurchaseOrder_TransactionOfficeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transactionffices",
                table: "PurchaseOrders",
                newName: "TransactionOfficeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionOfficeName",
                table: "PurchaseOrders",
                newName: "Transactionffices");
        }
    }
}
