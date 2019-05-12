using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "WholePrice",
                table: "Products",
                newName: "ExpectedPrice");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Products",
                newName: "ProductDetailId");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "BlankField2");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "CurrentPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                newName: "IX_Products_ProductDetailId");

            migrationBuilder.AddColumn<string>(
                name: "BlankField",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField1",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField2",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField3",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Providers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Providers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlankField0",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlankField1",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BlankField10",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField3",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField4",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField5",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BlankField6",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField7",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField8",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField9",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCategoryCode",
                table: "ProductCategories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlankField0",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlankField1",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BlankField10",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlankField2",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField3",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField4",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BlankField5",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BlankField6",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField7",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField8",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankField9",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductCategoryId",
                table: "ProductDetails",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProviderId",
                table: "ProductDetails",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "BlankField",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "BlankField1",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "BlankField2",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "BlankField3",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "BlankField0",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField10",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField6",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField7",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField8",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField9",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BlankField0",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField1",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField10",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField2",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField3",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField4",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField5",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField6",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField7",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField8",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "BlankField9",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ProductDetailId",
                table: "Products",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "ExpectedPrice",
                table: "Products",
                newName: "WholePrice");

            migrationBuilder.RenameColumn(
                name: "CurrentPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "BlankField2",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                newName: "IX_Products_ProviderId");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Products",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCategoryCode",
                table: "ProductCategories",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "ProductCategories",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
