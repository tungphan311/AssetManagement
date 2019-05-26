using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Edit3_TaiSan_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PbDonVi");

            migrationBuilder.DropColumn(
                name: "DonViId",
                table: "PbTaiSan");

            migrationBuilder.AlterColumn<long>(
                name: "UnitId",
                table: "PbTaiSan",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "PbTaiSan",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "DonViId",
                table: "PbTaiSan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PbDonVi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    DonViChinhId = table.Column<int>(nullable: false),
                    TenDonVi = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbDonVi", x => x.Id);
                });
        }
    }
}
