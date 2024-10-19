using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MUSICA_TRFINAL.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    CancionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NombreCancion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cantante = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Vistos = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Canciones", x => x.CancionID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Vistos = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC07051DEF7D", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_Link",
                table: "Canciones",
                column: "Link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__6B0F5AE0458A70F2",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
