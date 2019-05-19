using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Edit_TaiSan_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbTaiSan_PbDonVi_DonViId",
                table: "PbTaiSan");

            migrationBuilder.DropForeignKey(
                name: "FK_PbTaiSan_PbDonVi_DonViId1",
                table: "PbTaiSan");

            migrationBuilder.DropIndex(
                name: "IX_PbTaiSan_DonViId",
                table: "PbTaiSan");

            migrationBuilder.DropIndex(
                name: "IX_PbTaiSan_DonViId1",
                table: "PbTaiSan");

            migrationBuilder.DropColumn(
                name: "DonViId",
                table: "PbTaiSan");

            migrationBuilder.DropColumn(
                name: "DonViId1",
                table: "PbTaiSan");

            migrationBuilder.AddColumn<int>(
                name: "BiHuHong",
                table: "PbTaiSan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DangSuDung",
                table: "PbTaiSan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DangTrongKho",
                table: "PbTaiSan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiHuHong",
                table: "PbTaiSan");

            migrationBuilder.DropColumn(
                name: "DangSuDung",
                table: "PbTaiSan");

            migrationBuilder.DropColumn(
                name: "DangTrongKho",
                table: "PbTaiSan");

            migrationBuilder.AddColumn<int>(
                name: "DonViId",
                table: "PbTaiSan",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonViId1",
                table: "PbTaiSan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PbTaiSan_DonViId",
                table: "PbTaiSan",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_PbTaiSan_DonViId1",
                table: "PbTaiSan",
                column: "DonViId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PbTaiSan_PbDonVi_DonViId",
                table: "PbTaiSan",
                column: "DonViId",
                principalTable: "PbDonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PbTaiSan_PbDonVi_DonViId1",
                table: "PbTaiSan",
                column: "DonViId1",
                principalTable: "PbDonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
