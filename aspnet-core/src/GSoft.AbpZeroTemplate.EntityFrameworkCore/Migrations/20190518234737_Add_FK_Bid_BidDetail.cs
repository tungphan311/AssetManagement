using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_FK_Bid_BidDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BidId",
                table: "BidDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BidDetails_BidId",
                table: "BidDetails",
                column: "BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_BidDetails_Bids_BidId",
                table: "BidDetails",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDetails_Bids_BidId",
                table: "BidDetails");

            migrationBuilder.DropIndex(
                name: "IX_BidDetails_BidId",
                table: "BidDetails");

            migrationBuilder.DropColumn(
                name: "BidId",
                table: "BidDetails");
        }
    }
}
