using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_PO_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    PurchaseOrderDate = table.Column<DateTime>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    Area = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true),
                    UnitCode = table.Column<string>(maxLength: 50, nullable: true),
                    Transactionffices = table.Column<string>(maxLength: 256, nullable: true),
                    IsIndependentUnit = table.Column<bool>(nullable: true),
                    ReportCode = table.Column<string>(maxLength: 50, nullable: true),
                    ReportRecievedDate = table.Column<DateTime>(nullable: true),
                    ReportApprovalDate = table.Column<DateTime>(nullable: true),
                    AttachmentFile = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    PaymentMoney = table.Column<decimal>(nullable: true),
                    PaidMoney = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCategory = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    VAT_Percent = table.Column<decimal>(nullable: true),
                    VAT = table.Column<decimal>(nullable: true),
                    IsInProject = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProductDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchasePaymentHistories");

            migrationBuilder.DropTable(
                name: "PurchaseProductDetails");
        }
    }
}
