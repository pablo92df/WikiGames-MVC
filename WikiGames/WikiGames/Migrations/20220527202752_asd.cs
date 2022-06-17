using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desarrolladores",
                columns: table => new
                {
                    DesarrolladorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesarrolladorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Creacion = table.Column<DateTime>(type: "date", nullable: false),
                    Cierre = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladores", x => x.DesarrolladorId);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "ImgConsolas",
                columns: table => new
                {
                    ImgConsolasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgConsolas", x => x.ImgConsolasId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "ModosDeJuegos",
                columns: table => new
                {
                    ModosDeJuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModosDeJuegoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModosDeJuegos", x => x.ModosDeJuegoId);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProtagonista = table.Column<bool>(type: "bit", nullable: false),
                    IsVillano = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.PersonajeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Consolas",
                columns: table => new
                {
                    ConsolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsolaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(type: "date", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ImgConsolasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolas", x => x.ConsolaId);
                    table.ForeignKey(
                        name: "FK_Consolas_ImgConsolas_ImgConsolasId",
                        column: x => x.ImgConsolasId,
                        principalTable: "ImgConsolas",
                        principalColumn: "ImgConsolasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consolas_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuegoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JuegoDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    FechaLanzamientoOficial = table.Column<DateTime>(type: "date", nullable: false),
                    DesarrolladoraId = table.Column<int>(type: "int", nullable: false),
                    PublicadoraId = table.Column<int>(type: "int", nullable: false),
                    Argumento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.JuegoId);
                    table.ForeignKey(
                        name: "FK_Juegos_Desarrolladores_DesarrolladoraId",
                        column: x => x.DesarrolladoraId,
                        principalTable: "Desarrolladores",
                        principalColumn: "DesarrolladorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Juegos_Publicadoras_PublicadoraId",
                        column: x => x.PublicadoraId,
                        principalTable: "Publicadoras",
                        principalColumn: "PublicadoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroJuego",
                columns: table => new
                {
                    GenerosGeneroId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroJuego", x => new { x.GenerosGeneroId, x.JuegoId });
                    table.ForeignKey(
                        name: "FK_GeneroJuego_Generos_GenerosGeneroId",
                        column: x => x.GenerosGeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroJuego_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegoModosDeJuego",
                columns: table => new
                {
                    JuegosJuegoId = table.Column<int>(type: "int", nullable: false),
                    ModosDeJuegosModosDeJuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegoModosDeJuego", x => new { x.JuegosJuegoId, x.ModosDeJuegosModosDeJuegoId });
                    table.ForeignKey(
                        name: "FK_JuegoModosDeJuego_Juegos_JuegosJuegoId",
                        column: x => x.JuegosJuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegoModosDeJuego_ModosDeJuegos_ModosDeJuegosModosDeJuegoId",
                        column: x => x.ModosDeJuegosModosDeJuegoId,
                        principalTable: "ModosDeJuegos",
                        principalColumn: "ModosDeJuegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuegoPersonaje",
                columns: table => new
                {
                    JuegoListJuegoId = table.Column<int>(type: "int", nullable: false),
                    PersonajesPersonajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegoPersonaje", x => new { x.JuegoListJuegoId, x.PersonajesPersonajeId });
                    table.ForeignKey(
                        name: "FK_JuegoPersonaje_Juegos_JuegoListJuegoId",
                        column: x => x.JuegoListJuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuegoPersonaje_Personaje_PersonajesPersonajeId",
                        column: x => x.PersonajesPersonajeId,
                        principalTable: "Personaje",
                        principalColumn: "PersonajeId",
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
                name: "IX_Consolas_ImgConsolasId",
                table: "Consolas",
                column: "ImgConsolasId");

            migrationBuilder.CreateIndex(
                name: "IX_Consolas_MarcaId",
                table: "Consolas",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroJuego_JuegoId",
                table: "GeneroJuego",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoModosDeJuego_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego",
                column: "ModosDeJuegosModosDeJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPersonaje_PersonajesPersonajeId",
                table: "JuegoPersonaje",
                column: "PersonajesPersonajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_DesarrolladoraId",
                table: "Juegos",
                column: "DesarrolladoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_PublicadoraId",
                table: "Juegos",
                column: "PublicadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegosConsolas_ConsolaId",
                table: "JuegosConsolas",
                column: "ConsolaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroJuego");

            migrationBuilder.DropTable(
                name: "JuegoModosDeJuego");

            migrationBuilder.DropTable(
                name: "JuegoPersonaje");

            migrationBuilder.DropTable(
                name: "JuegosConsolas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "ModosDeJuegos");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Consolas");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "ImgConsolas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Desarrolladores");

            migrationBuilder.DropTable(
                name: "Publicadoras");
        }
    }
}
