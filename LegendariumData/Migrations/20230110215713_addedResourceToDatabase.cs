using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class addedResourceToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_Resource_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "GameMapItemX",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "GameMapItemY",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "GameMapItemZ",
                table: "Resource");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameMapItemX",
                table: "Resource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemY",
                table: "Resource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameMapItemZ",
                table: "Resource",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Resource",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" });

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Resource",
                columns: new[] { "GameMapItemZ", "GameMapItemX", "GameMapItemY" },
                principalTable: "GameMapItems",
                principalColumns: new[] { "Z", "X", "Y" });
        }
    }
}
