using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoCorrida.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Distancia = table.Column<decimal>(nullable: false),
                    Percurso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    NumeroCamisa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
