using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactuSystem.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Abonado",
                table: "CuadrarCajas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VentaContado",
                table: "CuadrarCajas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abonado",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "VentaContado",
                table: "CuadrarCajas");
        }
    }
}
