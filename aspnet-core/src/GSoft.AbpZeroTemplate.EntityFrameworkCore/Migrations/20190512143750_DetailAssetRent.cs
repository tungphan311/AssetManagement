using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class DetailAssetRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "assetRentID",
                table: "AsssetRents",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "valueAsset",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "DetailAssetRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    detailId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameAsset = table.Column<string>(nullable: true),
                    rentBy = table.Column<string>(nullable: true),
                    assetRentId = table.Column<int>(nullable: false),
                    rate = table.Column<float>(nullable: false),
                    dayPay = table.Column<DateTime>(nullable: true),
                    money = table.Column<decimal>(nullable: false),
                    describe = table.Column<string>(nullable: true),
                    isPay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailAssetRents", x => x.detailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailAssetRents");

            migrationBuilder.DropColumn(
                name: "assetRentID",
                table: "AsssetRents");

            migrationBuilder.AlterColumn<int>(
                name: "valueAsset",
                table: "Assets",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
