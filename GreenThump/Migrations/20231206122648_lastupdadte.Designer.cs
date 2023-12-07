﻿// <auto-generated />
using GreenThump.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GreenThumbDb))]
    [Migration("20231206122648_lastupdadte")]
    partial class lastupdadte
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenThump.Models.Instruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("InstructionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("instructions");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("instructions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InstructionText = "Well-drained soil.",
                            PlantId = 1
                        },
                        new
                        {
                            Id = 2,
                            InstructionText = "Sunlight.",
                            PlantId = 1
                        },
                        new
                        {
                            Id = 3,
                            InstructionText = "Keep soil moist.",
                            PlantId = 2
                        },
                        new
                        {
                            Id = 4,
                            InstructionText = "Shade.",
                            PlantId = 2
                        },
                        new
                        {
                            Id = 5,
                            InstructionText = "Full sun.",
                            PlantId = 3
                        },
                        new
                        {
                            Id = 6,
                            InstructionText = "Regular water.",
                            PlantId = 3
                        },
                        new
                        {
                            Id = 7,
                            InstructionText = " Full sun",
                            PlantId = 4
                        },
                        new
                        {
                            Id = 8,
                            InstructionText = "Well-drained soil.",
                            PlantId = 4
                        },
                        new
                        {
                            Id = 9,
                            InstructionText = "Low light.",
                            PlantId = 5
                        },
                        new
                        {
                            Id = 10,
                            InstructionText = "Infrequent water",
                            PlantId = 5
                        },
                        new
                        {
                            Id = 11,
                            InstructionText = "Full Sun",
                            PlantId = 6
                        },
                        new
                        {
                            Id = 12,
                            InstructionText = "Acidic soil.",
                            PlantId = 6
                        },
                        new
                        {
                            Id = 13,
                            InstructionText = "Full Sun.",
                            PlantId = 7
                        },
                        new
                        {
                            Id = 14,
                            InstructionText = "Sparse water.",
                            PlantId = 7
                        },
                        new
                        {
                            Id = 15,
                            InstructionText = "Full Sun.",
                            PlantId = 8
                        },
                        new
                        {
                            Id = 16,
                            InstructionText = "Minimal Water.",
                            PlantId = 8
                        });
                });

            modelBuilder.Entity("GreenThump.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Known for its beautiful and fragrant flowers.",
                            Name = "Rose"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Known for its large, yellow flowers.",
                            Name = "Sunflower."
                        },
                        new
                        {
                            Id = 3,
                            Description = " A fragrant herb with purple flowers.",
                            Name = "Lavender. "
                        },
                        new
                        {
                            Id = 4,
                            Description = "known as Mother in law's Tongue.",
                            Name = "Snake Plant. "
                        },
                        new
                        {
                            Id = 5,
                            Description = "These deciduous trees are well-known for their distinctive.",
                            Name = "Maple Tree."
                        },
                        new
                        {
                            Id = 6,
                            Description = "A bulbous plant with vibrant, cup-shaped flowers.",
                            Name = "Tulip."
                        },
                        new
                        {
                            Id = 7,
                            Description = "A fast-growing grass that forms tall, woody stems.",
                            Name = "Bamboo."
                        },
                        new
                        {
                            Id = 8,
                            Description = "Adapted to arid environments, cacti are known for their water-storing capabilities and unique.",
                            Name = "Cactus. "
                        });
                });

            modelBuilder.Entity("GreenThump.Models.Instruction", b =>
                {
                    b.HasOne("GreenThump.Models.Plant", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThump.Models.Plant", b =>
                {
                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}