using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactuSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CajaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CajaId = table.Column<int>(type: "int", nullable: false),
                    One = table.Column<int>(type: "int", nullable: false),
                    Five = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<int>(type: "int", nullable: false),
                    TwentyFive = table.Column<int>(type: "int", nullable: false),
                    Fifty = table.Column<int>(type: "int", nullable: false),
                    OneHundred = table.Column<int>(type: "int", nullable: false),
                    TwoHundred = table.Column<int>(type: "int", nullable: false),
                    FiveHundred = table.Column<int>(type: "int", nullable: false),
                    OneThousand = table.Column<int>(type: "int", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CajaDetalles");
        }
    }
}
