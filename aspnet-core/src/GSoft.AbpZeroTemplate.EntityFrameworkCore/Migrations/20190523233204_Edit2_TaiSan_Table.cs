using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Edit2_TaiSan_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DangTrongKho",
                table: "PbTaiSan",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "DangSuDung",
                table: "PbTaiSan",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "BiHuHong",
                table: "PbTaiSan",
                newName: "DonViId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "PbTaiSan",
                newName: "DangTrongKho");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "PbTaiSan",
                newName: "DangSuDung");

            migrationBuilder.RenameColumn(
                name: "DonViId",
                table: "PbTaiSan",
                newName: "BiHuHong");
        }
    }
}
