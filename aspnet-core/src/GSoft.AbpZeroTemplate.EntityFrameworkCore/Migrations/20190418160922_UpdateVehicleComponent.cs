using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class UpdateVehicleComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vehicles",
                newName: "UsePurpose");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Vehicles",
                newName: "UnitUsed");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfManufacture",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EngineVolume",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FuelNorms",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearboxSize",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HorizontalLength",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Length",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberPlate",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RibNumber",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialVehicle",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TireSize",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfManufacture",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CountryOfManufacture",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineVolume",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelNorms",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "GearboxSize",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "HorizontalLength",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NumberPlate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RibNumber",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SpecialVehicle",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TireSize",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "YearOfManufacture",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "UsePurpose",
                table: "Vehicles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UnitUsed",
                table: "Vehicles",
                newName: "Info");
        }
    }
}
