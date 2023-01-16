using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGameMapItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameMapItems_GameMapItemId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_GameMapItems_GameMapItemId",
                table: "Creature");

            migrationBuilder.DropTable(
                name: "GameMapItems");

            migrationBuilder.DropIndex(
                name: "IX_Creature_GameMapItemId",
                table: "Creature");

            migrationBuilder.DropIndex(
                name: "IX_Character_GameMapItemId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "GameMapItemId",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "GameMapItemId",
                table: "Character");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameMapItemId",
                table: "Creature",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemId",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameMapItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minerals = table.Column<int>(type: "int", nullable: false),
                    Stones = table.Column<int>(type: "int", nullable: false),
                    TerrainSpeedPenalty = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wood = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Z = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMapItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_GameMapItemId",
                table: "Creature",
                column: "GameMapItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_GameMapItemId",
                table: "Character",
                column: "GameMapItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_GameMapItems_GameMapItemId",
                table: "Character",
                column: "GameMapItemId",
                principalTable: "GameMapItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Creature_GameMapItems_GameMapItemId",
                table: "Creature",
                column: "GameMapItemId",
                principalTable: "GameMapItems",
                principalColumn: "Id");
        }
    }
}
