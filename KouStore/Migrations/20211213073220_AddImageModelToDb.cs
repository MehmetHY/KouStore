using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KouStore.Migrations
{
    public partial class AddImageModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviewImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageModel_Products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PreviewImageId",
                table: "Products",
                column: "PreviewImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageModel_ProductModelId",
                table: "ImageModel",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageModel_PreviewImageId",
                table: "Products",
                column: "PreviewImageId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageModel_PreviewImageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_PreviewImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreviewImageId",
                table: "Products");
        }
    }
}
