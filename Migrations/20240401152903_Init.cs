using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactuSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CajaDetalles");

            migrationBuilder.AddColumn<int>(
                name: "Fifty",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Five",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiveHundred",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "One",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OneHundred",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OneThousand",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ten",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwentyFive",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoHundred",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoThousand",
                table: "CuadrarCajas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fifty",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "Five",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "FiveHundred",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "One",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "OneHundred",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "OneThousand",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "TwentyFive",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "TwoHundred",
                table: "CuadrarCajas");

            migrationBuilder.DropColumn(
                name: "TwoThousand",
                table: "CuadrarCajas");

            migrationBuilder.CreateTable(
                name: "CajaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CajaId = table.Column<int>(type: "int", nullable: false),
                    Fifty = table.Column<int>(type: "int", nullable: false),
                    Five = table.Column<int>(type: "int", nullable: false),
                    FiveHundred = table.Column<int>(type: "int", nullable: false),
                    One = table.Column<int>(type: "int", nullable: false),
                    OneHundred = table.Column<int>(type: "int", nullable: false),
                    OneThousand = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<int>(type: "int", nullable: false),
                    TwentyFive = table.Column<int>(type: "int", nullable: false),
                    TwoHundred = table.Column<int>(type: "int", nullable: false),
                    TwoThousand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CajaDetalles_CuadrarCajas_CajaId",
                        column: x => x.CajaId,
                        principalTable: "CuadrarCajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CajaDetalles_CajaId",
                table: "CajaDetalles",
                column: "CajaId");
        }
    }
}
