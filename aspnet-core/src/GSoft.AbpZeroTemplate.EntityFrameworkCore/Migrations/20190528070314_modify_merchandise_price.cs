using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class modify_merchandise_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Merchandises",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractDetails_ContractID",
                table: "ContractDetails",
                column: "ContractID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractDetails_Contracts_ContractID",
                table: "ContractDetails",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractDetails_Contracts_ContractID",
                table: "ContractDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContractDetails_ContractID",
                table: "ContractDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Merchandises",
                nullable: true,
                oldClrType: typeof(float));
        }
    }
}
