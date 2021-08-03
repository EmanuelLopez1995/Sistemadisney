using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDisney.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Imagen = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUusario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sal = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUusario);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    PeliculaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(nullable: true),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Calificacion = table.Column<int>(nullable: false),
                    GeneroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.PeliculaID);
                    table.ForeignKey(
                        name: "FK_Pelicula_Genero_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Genero",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    PersonajeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Historia = table.Column<string>(type: "varchar(50)", nullable: true),
                    PeliculaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.PersonajeID);
                    table.ForeignKey(
                        name: "FK_Personaje_Pelicula_PeliculaID",
                        column: x => x.PeliculaID,
                        principalTable: "Pelicula",
                        principalColumn: "PeliculaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_GeneroID",
                table: "Pelicula",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_PeliculaID",
                table: "Personaje",
                column: "PeliculaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
