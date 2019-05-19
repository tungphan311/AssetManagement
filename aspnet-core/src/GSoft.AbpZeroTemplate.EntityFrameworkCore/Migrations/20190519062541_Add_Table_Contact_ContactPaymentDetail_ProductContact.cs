using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Table_Contact_ContactPaymentDetail_ProductContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidStatus",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    ContractCreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    ContractGuaranteeForm = table.Column<int>(nullable: false),
                    ContractCertificateNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ContractCertificateEndDate = table.Column<DateTime>(nullable: false),
                    ContractCertificatePrice = table.Column<DateTime>(nullable: false),
                    ContractCertificatePricePercent = table.Column<DateTime>(nullable: false),
                    ContractGuaranteeBankName = table.Column<string>(maxLength: 200, nullable: true),
                    ContractGuaranteeAttachmentFile = table.Column<string>(nullable: true),
                    WarrantyGuaranteeForm = table.Column<int>(nullable: false),
                    WarrantyCertificateNumber = table.Column<string>(maxLength: 50, nullable: true),
                    WarrantyCertificateEndDate = table.Column<DateTime>(nullable: false),
                    WarrantyCertificatePrice = table.Column<DateTime>(nullable: false),
                    WarrantyCertificatePricePercent = table.Column<DateTime>(nullable: false),
                    WarrantyGuaranteeBankName = table.Column<string>(maxLength: 200, nullable: true),
                    WarrantyGuaranteeAttachmentFile = table.Column<string>(nullable: true),
                    TotalProductPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    BidId = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Bids_BidId",
                        column: x => x.BidId,
                        principalTable: "Bids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    InstallmentNumber = table.Column<int>(nullable: false),
                    ExpectedDate = table.Column<DateTime>(nullable: true),
                    Percent = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractPaymentDetails_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductContracts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractPaymentDetails_ContractId",
                table: "ContractPaymentDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BidId",
                table: "Contracts",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ProviderId",
                table: "Contracts",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductContracts_ContractId",
                table: "ProductContracts",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductContracts_ProductId",
                table: "ProductContracts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractPaymentDetails");

            migrationBuilder.DropTable(
                name: "ProductContracts");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "BidStatus",
                table: "Bids",
                nullable: false,
                defaultValue: 0);
        }
    }
}
