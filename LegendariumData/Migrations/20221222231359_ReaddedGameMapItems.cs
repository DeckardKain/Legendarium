using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class ReaddedGameMapItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameMapItemX",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemY",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemZ",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemX",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemY",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemZ",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameMapItems",
                columns: table => new
                {
                    Z = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerrainSpeedPenalty = table.Column<int>(type: "int", nullable: false),
                    Stones = table.Column<int>(type: "int", nullable: false),
                    Wood = table.Column<int>(type: "int", nullable: false),
                    Minerals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMapItems", x => new { x.Z, x.X, x.Y });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Creature",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" });

            migrationBuilder.CreateIndex(
                name: "IX_Character_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Character",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Character_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Character",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" },
                principalTable: "GameMapItems",
                principalColumns: new[] { "Z", "X", "Y" });

            migrationBuilder.AddForeignKey(
                name: "FK_Creature_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Creature",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" },
                principalTable: "GameMapItems",
                principalColumns: new[] { "Z", "X", "Y" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Creature");

            migrationBuilder.DropTable(
                name: "GameMapItems");

            migrationBuilder.DropIndex(
                name: "IX_Creature_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Creature");

            migrationBuilder.DropIndex(
                name: "IX_Character_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "GameMapItemX",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "GameMapItemY",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "GameMapItemZ",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "GameMapItemX",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "GameMapItemY",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "GameMapItemZ",
                table: "Character");
        }
    }
}
