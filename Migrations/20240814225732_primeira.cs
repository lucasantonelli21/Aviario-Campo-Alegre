using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aviario_Campo_Alegre.Migrations
{
    /// <inheritdoc />
    public partial class primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Perfil = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateOnly>(type: "date", nullable: false),
                    QuantidadeAnimais = table.Column<long>(type: "bigint", nullable: false),
                    Linhagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AviarioOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeVendas = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeConsumo = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeMortos = table.Column<long>(type: "bigint", nullable: false),
                    PrecoLote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoVendaAnimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVenda = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDaRacao = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeDiasAplicacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLote = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAplicacao = table.Column<DateOnly>(type: "date", nullable: false),
                    DataProxAplicao = table.Column<DateOnly>(type: "date", nullable: false),
                    NumeroNota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Validade = table.Column<DateOnly>(type: "date", nullable: false),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refeicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRacao = table.Column<int>(type: "int", nullable: false),
                    RacaoId = table.Column<int>(type: "int", nullable: false),
                    NumeroLote = table.Column<int>(type: "int", nullable: false),
                    QuantidadeRacao = table.Column<double>(type: "float", nullable: false),
                    DataAdministracao = table.Column<DateOnly>(type: "date", nullable: false),
                    PrecoAplicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicoes_Racoes_RacaoId",
                        column: x => x.RacaoId,
                        principalTable: "Racoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refeicoes_RacaoId",
                table: "Refeicoes",
                column: "RacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Refeicoes");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Racoes");
        }
    }
}
