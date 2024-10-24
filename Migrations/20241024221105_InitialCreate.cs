using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasDefeito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasDefeito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N_Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabrica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defeitos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defeitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defeitos_CategoriasDefeito_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasDefeito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defeitos_CategoriaId",
                table: "Defeitos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defeitos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "CategoriasDefeito");
        }
    }
}
