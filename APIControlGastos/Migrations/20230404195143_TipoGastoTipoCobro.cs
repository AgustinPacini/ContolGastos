using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControlGastos.Migrations
{
    /// <inheritdoc />
    public partial class TipoGastoTipoCobro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoGasto",
                table: "Gastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeCobro",
                table: "Cobros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoGasto",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "TipoDeCobro",
                table: "Cobros");
        }
    }
}
