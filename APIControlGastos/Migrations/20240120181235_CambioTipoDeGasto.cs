using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControlGastos.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoDeGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoGasto",
                table: "Gastos");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Gastos");

            migrationBuilder.AddColumn<string>(
                name: "TipoGasto",
                table: "Gastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
