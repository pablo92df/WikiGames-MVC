using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class DateTimeJuegos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLanzamientoOficial",
                table: "Juegos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaLanzamientoOficial",
                table: "Juegos");
        }
    }
}
