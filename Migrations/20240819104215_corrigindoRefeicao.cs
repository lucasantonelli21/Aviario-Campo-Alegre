using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aviario_Campo_Alegre.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoRefeicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRacao",
                table: "Refeicoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRacao",
                table: "Refeicoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
