using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class REmoveForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractDetails_Contracts_ContractID",
                table: "ContractDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContractDetails_ContractID",
                table: "ContractDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
