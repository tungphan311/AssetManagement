using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class DeleteFKInDB_Bid_BidDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDetails_Bids_BidId",
                table: "BidDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BidDetails_Providers_ProviderId",
                table: "BidDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Projects_ProjectId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_ProjectId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_BidDetails_BidId",
                table: "BidDetails");

            migrationBuilder.DropIndex(
                name: "IX_BidDetails_ProviderId",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Bids");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "Bids",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ProjectId",
                table: "Bids",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDetails_BidId",
                table: "BidDetails",
                column: "BidId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDetails_ProviderId",
                table: "BidDetails",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BidDetails_Bids_BidId",
                table: "BidDetails",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BidDetails_Providers_ProviderId",
                table: "BidDetails",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Projects_ProjectId",
                table: "Bids",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
