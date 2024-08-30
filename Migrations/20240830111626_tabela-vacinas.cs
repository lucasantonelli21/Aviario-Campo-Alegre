using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aviario_Campo_Alegre.Migrations
{
    /// <inheritdoc />
    public partial class tabelavacinas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataProxAplicao",
                table: "Vacinas",
                newName: "DataProxAplicacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataProxAplicacao",
                table: "Vacinas",
                newName: "DataProxAplicao");
        }
    }
}
