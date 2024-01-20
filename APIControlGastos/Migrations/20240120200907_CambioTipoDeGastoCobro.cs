using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControlGastos.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoDeGastoCobro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDeCobro",
                table: "Cobros");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Cobros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Cobros");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeCobro",
                table: "Cobros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
