﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendariumData.Migrations
{
    /// <inheritdoc />
    public partial class imadechangesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Creature_GameMapItems_GameMapItemZ_GameMapItemX_GameMapItemY",
                table: "Creature");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
