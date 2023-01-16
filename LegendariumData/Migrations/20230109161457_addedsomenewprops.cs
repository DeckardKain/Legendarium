using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class addedsomenewprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTileMoveable",
                table: "GameMapItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PowerLevel",
                table: "GameMapItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Energy",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTileMoveable",
                table: "GameMapItems");

            migrationBuilder.DropColumn(
                name: "PowerLevel",
                table: "GameMapItems");

            migrationBuilder.DropColumn(
                name: "Energy",
                table: "Character");
        }
    }
}
