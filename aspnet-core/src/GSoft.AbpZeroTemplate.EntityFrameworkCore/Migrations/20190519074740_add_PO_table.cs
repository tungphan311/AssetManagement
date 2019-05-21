using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class add_PO_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BidID",
                table: "Bidders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "POs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ReportID = table.Column<int>(nullable: false),
                    ReceiveReportDay = table.Column<DateTime>(nullable: false),
                    ApproveReportDay = table.Column<DateTime>(nullable: false),
                    POID = table.Column<int>(nullable: false),
                    CreateDay = table.Column<DateTime>(nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    ContractID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POs");

            migrationBuilder.DropColumn(
                name: "BidID",
                table: "Bidders");
        }
    }
}
