using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class update_bids_bidders_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment1",
                table: "Bids",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment2",
                table: "Bids",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment3",
                table: "Bids",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment4",
                table: "Bids",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Percent",
                table: "Bids",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Bidders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeBank",
                table: "Bidders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment1",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Attachment2",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Attachment3",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Attachment4",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "GuaranteeBank",
                table: "Bidders");
        }
    }
}
