using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Edit_DonVi_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbDonVi_PbDonVi_DonViChinhId",
                table: "PbDonVi");

            migrationBuilder.DropIndex(
                name: "IX_PbDonVi_DonViChinhId",
                table: "PbDonVi");

            migrationBuilder.AlterColumn<int>(
                name: "DonViChinhId",
                table: "PbDonVi",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DonViChinhId",
                table: "PbDonVi",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PbDonVi_DonViChinhId",
                table: "PbDonVi",
                column: "DonViChinhId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbDonVi_PbDonVi_DonViChinhId",
                table: "PbDonVi",
                column: "DonViChinhId",
                principalTable: "PbDonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
