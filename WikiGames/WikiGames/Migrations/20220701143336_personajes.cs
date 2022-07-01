using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class personajes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPersonaje_Personaje_PersonajesPersonajeId",
                table: "JuegoPersonaje");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonajeJuegos_Personaje_PersonajeId",
                table: "PersonajeJuegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personaje",
                table: "Personaje");

            migrationBuilder.RenameTable(
                name: "Personaje",
                newName: "Personajes");

            migrationBuilder.AddColumn<int>(
                name: "ImgJuegosId",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadesVendidas",
                table: "Consolas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personajes",
                table: "Personajes",
                column: "PersonajeId");

            migrationBuilder.CreateTable(
                name: "ImgJuegos",
                columns: table => new
                {
                    ImgJuegosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgJuegos", x => x.ImgJuegosId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_ImgJuegosId",
                table: "Juegos",
                column: "ImgJuegosId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPersonaje_Personajes_PersonajesPersonajeId",
                table: "JuegoPersonaje",
                column: "PersonajesPersonajeId",
                principalTable: "Personajes",
                principalColumn: "PersonajeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_ImgJuegos_ImgJuegosId",
                table: "Juegos",
                column: "ImgJuegosId",
                principalTable: "ImgJuegos",
                principalColumn: "ImgJuegosId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajeJuegos_Personajes_PersonajeId",
                table: "PersonajeJuegos",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "PersonajeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPersonaje_Personajes_PersonajesPersonajeId",
                table: "JuegoPersonaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_ImgJuegos_ImgJuegosId",
                table: "Juegos");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonajeJuegos_Personajes_PersonajeId",
                table: "PersonajeJuegos");

            migrationBuilder.DropTable(
                name: "ImgJuegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_ImgJuegosId",
                table: "Juegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personajes",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "ImgJuegosId",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "UnidadesVendidas",
                table: "Consolas");

            migrationBuilder.RenameTable(
                name: "Personajes",
                newName: "Personaje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personaje",
                table: "Personaje",
                column: "PersonajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPersonaje_Personaje_PersonajesPersonajeId",
                table: "JuegoPersonaje",
                column: "PersonajesPersonajeId",
                principalTable: "Personaje",
                principalColumn: "PersonajeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajeJuegos_Personaje_PersonajeId",
                table: "PersonajeJuegos",
                column: "PersonajeId",
                principalTable: "Personaje",
                principalColumn: "PersonajeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
