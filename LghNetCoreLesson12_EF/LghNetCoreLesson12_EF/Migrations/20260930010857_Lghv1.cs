using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LghNetCoreLesson12_EF.Migrations
{
    /// <inheritdoc />
    public partial class Lghv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LghName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LghStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LghName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LghImage = table.Column<string>(type: "varchar(150)", nullable: false),
                    LghPrice = table.Column<float>(type: "real", nullable: false),
                    LghSalePrice = table.Column<float>(type: "real", nullable: false),
                    LghStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    LghDescription = table.Column<string>(type: "ntext", maxLength: 1000, nullable: false),
                    LghCategoryId = table.Column<int>(type: "int", nullable: false),
                    LghCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_LghCategoryId",
                        column: x => x.LghCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_LghCategoryId",
                table: "Products",
                column: "LghCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
