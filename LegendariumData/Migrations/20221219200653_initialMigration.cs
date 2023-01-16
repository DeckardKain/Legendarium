using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AdventureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X1Start = table.Column<double>(type: "float", nullable: false),
                    X2End = table.Column<double>(type: "float", nullable: false),
                    Y1Start = table.Column<double>(type: "float", nullable: false),
                    Y2End = table.Column<double>(type: "float", nullable: false),
                    Path = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discovery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discovery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Vision = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureOfLegendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Intellect = table.Column<int>(type: "int", nullable: false),
                    Dialect = table.Column<int>(type: "int", nullable: false),
                    Discernement = table.Column<int>(type: "int", nullable: false),
                    Stamina = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdventureOfLegendId = table.Column<int>(type: "int", nullable: true),
                    DiscoveryId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Adventure_AdventureOfLegendId",
                        column: x => x.AdventureOfLegendId,
                        principalTable: "Adventure",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Character_Discovery_DiscoveryId",
                        column: x => x.DiscoveryId,
                        principalTable: "Discovery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(type: "int", nullable: false),
                    ParentLocationId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnSurface = table.Column<bool>(type: "bit", nullable: false),
                    Biome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    CoordinateX1 = table.Column<double>(type: "float", nullable: false),
                    CoordinateX2 = table.Column<double>(type: "float", nullable: false),
                    CoordinateY1 = table.Column<double>(type: "float", nullable: false),
                    CoordinateY2 = table.Column<double>(type: "float", nullable: false),
                    XCoordinate = table.Column<double>(type: "float", nullable: false),
                    YCoordinate = table.Column<double>(type: "float", nullable: false),
                    DiscoveryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Discovery_DiscoveryId",
                        column: x => x.DiscoveryId,
                        principalTable: "Discovery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    LandType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deck_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationship_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardOfLegend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bonuses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardOfLegend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardOfLegend_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardOfLegend_DeckId",
                table: "CardOfLegend",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_AdventureOfLegendId",
                table: "Character",
                column: "AdventureOfLegendId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_DiscoveryId",
                table: "Character",
                column: "DiscoveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinate_PlanetId",
                table: "Coordinate",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Deck_CharacterId",
                table: "Deck",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_SupplyId",
                table: "Item",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DiscoveryId",
                table: "Location",
                column: "DiscoveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_CharacterId",
                table: "Relationship",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardOfLegend");

            migrationBuilder.DropTable(
                name: "Coordinate");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PlayerLocations");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Adventure");

            migrationBuilder.DropTable(
                name: "Discovery");
        }
    }
}
