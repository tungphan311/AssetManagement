using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Contract_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Merchandises",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ContractID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DeliveryTime = table.Column<DateTime>(nullable: false),
                    BriefcaseID = table.Column<int>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    ContractWarrantyTypeID = table.Column<int>(nullable: false),
                    ContractWarrantyID = table.Column<int>(nullable: false),
                    ContractWarrantyExpireDate = table.Column<DateTime>(nullable: false),
                    ContractWarrantyPercent = table.Column<int>(nullable: false),
                    ContractWarrantyAmount = table.Column<int>(nullable: false),
                    WarrantyGuaranteeTypeID = table.Column<int>(nullable: false),
                    WarrantyGuaranteeID = table.Column<int>(nullable: false),
                    WarrantyGuaranteeExpireDate = table.Column<DateTime>(nullable: false),
                    WarrantyGuaranteePercent = table.Column<int>(nullable: false),
                    WarrantyGuaranteeAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchandises_ContractId",
                table: "Merchandises",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchandises_Purchase_ContractId",
                table: "Merchandises",
                column: "ContractId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchandises_Purchase_ContractId",
                table: "Merchandises");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Merchandises_ContractId",
                table: "Merchandises");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Merchandises");
        }
    }
}