using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBiblio.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aid",
                table: "Libros");

            migrationBuilder.AddColumn<string>(
                name: "Editorial",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_LibroId",
                table: "Autores",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Libros_LibroId",
                table: "Autores",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Libros_LibroId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_LibroId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Editorial",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Autores");

            migrationBuilder.AddColumn<int>(
                name: "Aid",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
