using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGames.Migrations
{
    public partial class imgDesarrolladores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImgDesarrolladorId",
                table: "Desarrolladores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImgDesarrolladoresId",
                table: "Desarrolladores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImgDesarrolladores",
                columns: table => new
                {
                    ImgDesarrolladoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imgext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgDesarrolladores", x => x.ImgDesarrolladoresId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desarrolladores_ImgDesarrolladoresId",
                table: "Desarrolladores",
                column: "ImgDesarrolladoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desarrolladores_ImgDesarrolladores_ImgDesarrolladoresId",
                table: "Desarrolladores",
                column: "ImgDesarrolladoresId",
                principalTable: "ImgDesarrolladores",
                principalColumn: "ImgDesarrolladoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desarrolladores_ImgDesarrolladores_ImgDesarrolladoresId",
                table: "Desarrolladores");

            migrationBuilder.DropTable(
                name: "ImgDesarrolladores");

            migrationBuilder.DropIndex(
                name: "IX_Desarrolladores_ImgDesarrolladoresId",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "ImgDesarrolladorId",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "ImgDesarrolladoresId",
                table: "Desarrolladores");
        }
    }
}
