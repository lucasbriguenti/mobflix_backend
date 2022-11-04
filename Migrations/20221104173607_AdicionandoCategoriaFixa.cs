using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mobflix_backend.Migrations
{
    public partial class AdicionandoCategoriaFixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (Titulo, Color) VALUES('Livre', '#ff0000');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
