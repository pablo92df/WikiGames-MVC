using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class Nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Argumento",
                table: "Juegos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicadoraId",
                table: "Juegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModosDeJuego",
                columns: table => new
                {
                    ModosDeJuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModosDeJuegoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModosDeJuego", x => x.ModosDeJuegoId);
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
                        name: "FK_JuegoModosDeJuego_ModosDeJuego_ModosDeJuegosModosDeJuegoId",
                        column: x => x.ModosDeJuegosModosDeJuegoId,
                        principalTable: "ModosDeJuego",
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

            migrationBuilder.CreateIndex(
                name: "IX_JuegoModosDeJuego_ModosDeJuegosModosDeJuegoId",
                table: "JuegoModosDeJuego",
                column: "ModosDeJuegosModosDeJuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPersonaje_PersonajesPersonajeId",
                table: "JuegoPersonaje",
                column: "PersonajesPersonajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuegoModosDeJuego");

            migrationBuilder.DropTable(
                name: "JuegoPersonaje");

            migrationBuilder.DropTable(
                name: "ModosDeJuego");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropColumn(
                name: "Argumento",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "PublicadoraId",
                table: "Juegos");
        }
    }
}
