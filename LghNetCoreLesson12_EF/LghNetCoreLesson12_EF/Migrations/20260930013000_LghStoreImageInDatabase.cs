using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LghNetCoreLesson12_EF.Migrations
{
    public partial class LghStoreImageInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LghImage",
                table: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "LghImage",
                table: "Products",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LghImage",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "LghImage",
                table: "Products",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }
    }
}
