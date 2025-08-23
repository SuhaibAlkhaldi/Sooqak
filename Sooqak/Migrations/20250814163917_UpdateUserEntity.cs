using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sooqak.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerfied",
                table: "users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTry",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OTPCode",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OTPExpiry",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedLanguage",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsVerfied",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NumberOfTry",
                table: "users");

            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "OTPExpiry",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SelectedLanguage",
                table: "users");
        }
    }
}
