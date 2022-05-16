using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class juegosPublicadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoModosDeJuego_ModosDeJuego_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModosDeJuego",
                table: "ModosDeJuego");

            migrationBuilder.RenameTable(
                name: "ModosDeJuego",
                newName: "ModosDeJuegos");

            migrationBuilder.AlterColumn<int>(
                name: "PublicadoraId",
                table: "Juegos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModosDeJuegos",
                table: "ModosDeJuegos",
                column: "ModosDeJuegoId");

            migrationBuilder.CreateTable(
                name: "Publicadoras",
                columns: table => new
                {
                    PublicadoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicadoraNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fundacion = table.Column<DateTime>(type: "date", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicadoras", x => x.PublicadoraId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_PublicadoraId",
                table: "Juegos",
                column: "PublicadoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoModosDeJuego_ModosDeJuegos_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego",
                column: "ModosDeJuegosModosDeJuegoId",
                principalTable: "ModosDeJuegos",
                principalColumn: "ModosDeJuegoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Publicadoras_PublicadoraId",
                table: "Juegos",
                column: "PublicadoraId",
                principalTable: "Publicadoras",
                principalColumn: "PublicadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoModosDeJuego_ModosDeJuegos_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Publicadoras_PublicadoraId",
                table: "Juegos");

            migrationBuilder.DropTable(
                name: "Publicadoras");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_PublicadoraId",
                table: "Juegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModosDeJuegos",
                table: "ModosDeJuegos");

            migrationBuilder.RenameTable(
                name: "ModosDeJuegos",
                newName: "ModosDeJuego");

            migrationBuilder.AlterColumn<int>(
                name: "PublicadoraId",
                table: "Juegos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModosDeJuego",
                table: "ModosDeJuego",
                column: "ModosDeJuegoId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoModosDeJuego_ModosDeJuego_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego",
                column: "ModosDeJuegosModosDeJuegoId",
                principalTable: "ModosDeJuego",
                principalColumn: "ModosDeJuegoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
