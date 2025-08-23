using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sooqak.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "Icon");

            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "categories",
                newName: "Name");
        }
    }
}
