using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class add_contacts_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DeliveryTime = table.Column<DateTime>(nullable: false),
                    BriefcaseID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ContractWarrantyType = table.Column<string>(nullable: true),
                    ContractWarrantyID = table.Column<string>(nullable: true),
                    ContractWarrantyExpireDate = table.Column<DateTime>(nullable: false),
                    ContractWarrantyPercent = table.Column<float>(nullable: false),
                    ContractWarrantyAmount = table.Column<float>(nullable: false),
                    ContractWarrantyBank = table.Column<string>(nullable: true),
                    WarrantyGuaranteeTypeID = table.Column<int>(nullable: false),
                    WarrantyGuaranteeID = table.Column<int>(nullable: false),
                    WarrantyGuaranteeExpireDate = table.Column<DateTime>(nullable: false),
                    WarrantyGuaranteePercent = table.Column<int>(nullable: false),
                    WarrantyGuaranteeAmount = table.Column<int>(nullable: false),
                    WarrantyGuaranteeBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
