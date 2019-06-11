using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddProp_IsInProject_To_PurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInProject",
                table: "PurchaseProductDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsInProject",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInProject",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<bool>(
                name: "IsInProject",
                table: "PurchaseProductDetails",
                nullable: false,
                defaultValue: false);
        }
    }
}
