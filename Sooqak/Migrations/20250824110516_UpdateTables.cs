using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sooqak.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "carDetails");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "apartmentDetails");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "advertisements");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "carDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "apartmentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
