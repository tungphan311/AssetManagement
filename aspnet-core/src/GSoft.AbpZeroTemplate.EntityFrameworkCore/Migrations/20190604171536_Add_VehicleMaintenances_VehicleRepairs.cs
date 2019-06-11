using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_VehicleMaintenances_VehicleRepairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMaintenances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    PlateNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NextMaintenanceDate = table.Column<DateTime>(nullable: false),
                    MoneyAmount = table.Column<int>(nullable: false),
                    NumberMaintenanceTimes = table.Column<int>(nullable: false),
                    MaintenanceCategories = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MaintenanceUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMaintenances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetId = table.Column<string>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(nullable: false),
                    ExpectedRepairUnit = table.Column<string>(nullable: true),
                    ProposedUnit = table.Column<string>(nullable: true),
                    ExpectedRepairCost = table.Column<int>(nullable: false),
                    Proposer = table.Column<string>(nullable: true),
                    StaffInCharge = table.Column<string>(nullable: true),
                    ExpectedRepairContent = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Note1 = table.Column<string>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    RepairUnit = table.Column<string>(nullable: true),
                    RepairCosts = table.Column<int>(nullable: false),
                    RepairContent = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRepairs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMaintenances");

            migrationBuilder.DropTable(
                name: "VehicleRepairs");
        }
    }
}
