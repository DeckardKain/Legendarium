using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCoordinateToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "YCoordinate",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "XCoordinate",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateY2",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateY1",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateX2",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateX1",
                table: "Location",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HP",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Intellect = table.Column<int>(type: "int", nullable: false),
                    Dialect = table.Column<int>(type: "int", nullable: false),
                    Discernement = table.Column<int>(type: "int", nullable: false),
                    Stamina = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "HP",
                table: "Character");

            migrationBuilder.AlterColumn<double>(
                name: "YCoordinate",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "XCoordinate",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Size",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateY2",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateY1",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateX2",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CoordinateX1",
                table: "Location",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
