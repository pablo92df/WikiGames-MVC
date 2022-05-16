using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class juegosDesarrollador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesarrolladorJuego");

            migrationBuilder.AddColumn<int>(
                name: "DesarrolladoraDesarrolladorId",
                table: "Juegos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_DesarrolladoraDesarrolladorId",
                table: "Juegos",
                column: "DesarrolladoraDesarrolladorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Desarrolladores_DesarrolladoraDesarrolladorId",
                table: "Juegos",
                column: "DesarrolladoraDesarrolladorId",
                principalTable: "Desarrolladores",
                principalColumn: "DesarrolladorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Desarrolladores_DesarrolladoraDesarrolladorId",
                table: "Juegos");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_DesarrolladoraDesarrolladorId",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "DesarrolladoraDesarrolladorId",
                table: "Juegos");

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

            migrationBuilder.CreateIndex(
                name: "IX_DesarrolladorJuego_JuegosJuegoId",
                table: "DesarrolladorJuego",
                column: "JuegosJuegoId");
        }
    }
}
