using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedSocial.Data.Migrations
{
    public partial class nombreFechaIngreso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIngre",
                table: "usuarios");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "usuarios");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngre",
                table: "usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
