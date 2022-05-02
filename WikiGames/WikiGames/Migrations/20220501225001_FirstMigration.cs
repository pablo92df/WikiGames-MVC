using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desarrolladores",
                columns: table => new
                {
                    DesarrolladorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesarrolladorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Creacion = table.Column<DateTime>(type: "date", nullable: false),
                    Cierre = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladores", x => x.DesarrolladorId);
                });

            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuegoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JuegoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.JuegoId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "DesarrolladorJuego",
                columns: table => new
                {
                    DesarrolladoraDesarrolladorId = table.Column<int>(type: "int", nullable: false),
                    JuegosJuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesarrolladorJuego", x => new { x.DesarrolladoraDesarrolladorId, x.JuegosJuegoId });
                    table.ForeignKey(
                        name: "FK_DesarrolladorJuego_Desarrolladores_DesarrolladoraDesarrolladorId",
                        column: x => x.DesarrolladoraDesarrolladorId,
                        principalTable: "Desarrolladores",
                        principalColumn: "DesarrolladorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesarrolladorJuego_Juegos_JuegosJuegoId",
                        column: x => x.JuegosJuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JuegoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                    table.ForeignKey(
                        name: "FK_Generos_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId");
                });

            migrationBuilder.CreateTable(
                name: "Consolas",
                columns: table => new
                {
                    ConsolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsolaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaLanzamiento = table.Column<DateTime>(type: "date", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolas", x => x.ConsolaId);
                    table.ForeignKey(
                        name: "FK_Consolas_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegosConsolas",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    ConsolaId = table.Column<int>(type: "int", nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "date", nullable: false),
                    CopiasVendidas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegosConsolas", x => new { x.JuegoId, x.ConsolaId });
                    table.ForeignKey(
                        name: "FK_JuegosConsolas_Consolas_ConsolaId",
                        column: x => x.ConsolaId,
                        principalTable: "Consolas",
                        principalColumn: "ConsolaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegosConsolas_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consolas_MarcaId",
                table: "Consolas",
                column: "MarcaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DesarrolladorJuego_JuegosJuegoId",
                table: "DesarrolladorJuego",
                column: "JuegosJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_JuegoId",
                table: "Generos",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegosConsolas_ConsolaId",
                table: "JuegosConsolas",
                column: "ConsolaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesarrolladorJuego");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "JuegosConsolas");

            migrationBuilder.DropTable(
                name: "Desarrolladores");

            migrationBuilder.DropTable(
                name: "Consolas");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
