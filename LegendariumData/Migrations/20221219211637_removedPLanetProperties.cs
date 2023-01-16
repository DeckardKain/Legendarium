using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class removedPLanetProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinate_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinate_PlanetId",
                table: "Coordinate",
                column: "PlanetId");
        }
    }
}
