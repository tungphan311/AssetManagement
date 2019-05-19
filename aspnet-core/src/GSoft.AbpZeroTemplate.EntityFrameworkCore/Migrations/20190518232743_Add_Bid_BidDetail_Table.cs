using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Bid_BidDetail_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityType",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Projects",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BidDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAccepted = table.Column<bool>(nullable: false),
                    BiddingCreatedDate = table.Column<DateTime>(nullable: true),
                    AttachmentFile = table.Column<string>(nullable: true),
                    BidPrice = table.Column<decimal>(nullable: false),
                    GuaranteeForm = table.Column<int>(nullable: false),
                    GuaranteeEndDate = table.Column<DateTime>(nullable: true),
                    CertificateNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDetails_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    BidStatus = table.Column<int>(nullable: false),
                    BiddingForm = table.Column<int>(nullable: false),
                    ProjectCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    CautionMoney = table.Column<decimal>(nullable: false),
                    AttachmentFile = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidDetails_ProviderId",
                table: "BidDetails",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectId",
                table: "Bids",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDetails");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Projects");
        }
    }
}
