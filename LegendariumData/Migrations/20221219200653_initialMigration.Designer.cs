﻿// <auto-generated />
using System;
using LegendariumData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LegendariumData.Migrations
{
    [DbContext(typeof(LegendariumDbContext))]
    [Migration("20221219200653_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LegendariumAdventure.AdventureOfLegend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdventureType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Path")
                        .HasColumnType("float");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<double>("X1Start")
                        .HasColumnType("float");

                    b.Property<double>("X2End")
                        .HasColumnType("float");

                    b.Property<double>("Y1Start")
                        .HasColumnType("float");

                    b.Property<double>("Y2End")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Adventure");
                });

            modelBuilder.Entity("LegendariumAdventure.ItemOfLegend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplyId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SupplyId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("LegendariumAdventure.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdventureOfLegendId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Supply");
                });

            modelBuilder.Entity("LegendariumLife.CardOfLegend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bonuses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("CardOfLegend");
                });

            modelBuilder.Entity("LegendariumLife.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdventureOfLegendId")
                        .HasColumnType("int");

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Dialect")
                        .HasColumnType("int");

                    b.Property<int>("Discernement")
                        .HasColumnType("int");

                    b.Property<int?>("DiscoveryId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Intellect")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdventureOfLegendId");

                    b.HasIndex("DiscoveryId");

                    b.ToTable("Character");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LegendariumLife.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Deck");
                });

            modelBuilder.Entity("LegendariumLife.Relationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Relationship");
                });

            modelBuilder.Entity("LegendariumWorld.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LandType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Coordinate");
                });

            modelBuilder.Entity("LegendariumWorld.Discovery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discovery");
                });

            modelBuilder.Entity("LegendariumWorld.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CoordinateX1")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateX2")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateY1")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateY2")
                        .HasColumnType("float");

                    b.Property<int?>("DiscoveryId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnSurface")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentLocationId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("XCoordinate")
                        .HasColumnType("float");

                    b.Property<double>("YCoordinate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DiscoveryId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("LegendariumWorld.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Planet");
                });

            modelBuilder.Entity("LegendariumWorld.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vision")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("LegendariumWorld.Player_Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlayerLocations");
                });

            modelBuilder.Entity("LegendariumLife.Creature", b =>
                {
                    b.HasBaseType("LegendariumLife.Character");

                    b.HasDiscriminator().HasValue("Creature");
                });

            modelBuilder.Entity("LegendariumAdventure.ItemOfLegend", b =>
                {
                    b.HasOne("LegendariumAdventure.Supply", null)
                        .WithMany("Supplies")
                        .HasForeignKey("SupplyId");
                });

            modelBuilder.Entity("LegendariumLife.CardOfLegend", b =>
                {
                    b.HasOne("LegendariumLife.Deck", null)
                        .WithMany("Cards")
                        .HasForeignKey("DeckId");
                });

            modelBuilder.Entity("LegendariumLife.Character", b =>
                {
                    b.HasOne("LegendariumAdventure.AdventureOfLegend", null)
                        .WithMany("Characters")
                        .HasForeignKey("AdventureOfLegendId");

                    b.HasOne("LegendariumWorld.Discovery", null)
                        .WithMany("Characters")
                        .HasForeignKey("DiscoveryId");
                });

            modelBuilder.Entity("LegendariumLife.Deck", b =>
                {
                    b.HasOne("LegendariumLife.Character", null)
                        .WithOne("Deck")
                        .HasForeignKey("LegendariumLife.Deck", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LegendariumLife.Relationship", b =>
                {
                    b.HasOne("LegendariumLife.Character", null)
                        .WithMany("Relationships")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("LegendariumWorld.Coordinate", b =>
                {
                    b.HasOne("LegendariumWorld.Planet", null)
                        .WithMany("Coordinates")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("LegendariumWorld.Location", b =>
                {
                    b.HasOne("LegendariumWorld.Discovery", null)
                        .WithMany("Locations")
                        .HasForeignKey("DiscoveryId");
                });

            modelBuilder.Entity("LegendariumAdventure.AdventureOfLegend", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("LegendariumAdventure.Supply", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("LegendariumLife.Character", b =>
                {
                    b.Navigation("Deck")
                        .IsRequired();

                    b.Navigation("Relationships");
                });

            modelBuilder.Entity("LegendariumLife.Deck", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("LegendariumWorld.Discovery", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("LegendariumWorld.Planet", b =>
                {
                    b.Navigation("Coordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
