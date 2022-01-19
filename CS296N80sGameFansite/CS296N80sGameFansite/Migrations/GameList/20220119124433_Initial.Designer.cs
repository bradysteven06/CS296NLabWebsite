﻿// <auto-generated />
using System;
using CS296N80sGameFansite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS296N80sGameFansite.Migrations.GameList
{
    [DbContext(typeof(GameListContext))]
    [Migration("20220119124433_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS296N80sGameFansite.Models.Played", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("GameID");

                    b.ToTable("PlayedInfo");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            Name = "Tetris",
                            Platform = "Nintendo",
                            Year = 1989
                        },
                        new
                        {
                            GameID = 2,
                            Name = "Donkey Kong",
                            Platform = "Arcade",
                            Year = 1981
                        });
                });

            modelBuilder.Entity("CS296N80sGameFansite.Models.WantToPlay", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("GameID");

                    b.ToTable("WantToPlayInfo");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            Name = "Tetris",
                            Platform = "Nintendo",
                            Year = 1989
                        },
                        new
                        {
                            GameID = 2,
                            Name = "Test",
                            Platform = "Testrix",
                            Year = 1981
                        });
                });
#pragma warning restore 612, 618
        }
    }
}