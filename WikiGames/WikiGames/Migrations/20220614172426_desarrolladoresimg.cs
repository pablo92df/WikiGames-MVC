using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class desarrolladoresimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProtagonista",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "IsVillano",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "ImgDesarrolladorId",
                table: "Desarrolladores");

            migrationBuilder.CreateTable(
                name: "PersonajeJuegos",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPersonaje = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Secundario")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajeJuegos", x => new { x.JuegoId, x.PersonajeId });
                    table.ForeignKey(
                        name: "FK_PersonajeJuegos_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "JuegoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonajeJuegos_Personaje_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personaje",
                        principalColumn: "PersonajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonajeJuegos_PersonajeId",
                table: "PersonajeJuegos",
                column: "PersonajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonajeJuegos");

            migrationBuilder.AddColumn<bool>(
                name: "IsProtagonista",
                table: "Personaje",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVillano",
                table: "Personaje",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ImgDesarrolladorId",
                table: "Desarrolladores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
