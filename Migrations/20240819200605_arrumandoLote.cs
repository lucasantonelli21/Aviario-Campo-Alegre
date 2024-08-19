using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aviario_Campo_Alegre.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoLote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Lotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Lotes");
        }
    }
}
