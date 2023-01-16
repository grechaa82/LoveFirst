﻿// <auto-generated />
using System;
using LoveFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoveFirst.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoveFirst.Models.Counters", b =>
                {
                    b.Property<int>("CounterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("TotalScores")
                        .HasColumnType("int");

                    b.HasKey("CounterId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Counters");

                    b.HasData(
                        new
                        {
                            CounterId = 1,
                            ProfileId = 1,
                            TotalScores = 3
                        });
                });

            modelBuilder.Entity("LoveFirst.Models.Operations", b =>
                {
                    b.Property<int>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CounterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOperation")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("OperationId");

                    b.HasIndex("CounterId");

                    b.ToTable("Operations");

                    b.HasData(
                        new
                        {
                            OperationId = 1,
                            CounterId = 1,
                            DateOperation = new DateTime(2022, 10, 11, 21, 11, 27, 601, DateTimeKind.Local).AddTicks(5238),
                            ParticipantId = 1,
                            Score = 1
                        },
                        new
                        {
                            OperationId = 2,
                            CounterId = 1,
                            DateOperation = new DateTime(2022, 10, 11, 21, 11, 27, 602, DateTimeKind.Local).AddTicks(4817),
                            ParticipantId = 2,
                            Score = 1
                        },
                        new
                        {
                            OperationId = 3,
                            CounterId = 1,
                            DateOperation = new DateTime(2022, 10, 11, 21, 11, 27, 602, DateTimeKind.Local).AddTicks(4864),
                            ParticipantId = 1,
                            Score = 1
                        });
                });

            modelBuilder.Entity("LoveFirst.Models.Participants", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CounterId")
                        .HasColumnType("int");

                    b.Property<string>("NameParticipant")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<int>("NumberScore")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId");

                    b.HasIndex("CounterId");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            ParticipantId = 1,
                            CounterId = 1,
                            NameParticipant = "Danila",
                            NumberScore = 2
                        },
                        new
                        {
                            ParticipantId = 2,
                            CounterId = 1,
                            NameParticipant = "An",
                            NumberScore = 1
                        });
                });

            modelBuilder.Entity("LoveFirst.Models.Profiles", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            Login = "test",
                            PasswordHash = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08"
                        });
                });

            modelBuilder.Entity("LoveFirst.Models.Counters", b =>
                {
                    b.HasOne("LoveFirst.Models.Profiles", "Profiles")
                        .WithMany("Counters")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("LoveFirst.Models.Operations", b =>
                {
                    b.HasOne("LoveFirst.Models.Counters", "Counters")
                        .WithMany("Operations")
                        .HasForeignKey("CounterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Counters");
                });

            modelBuilder.Entity("LoveFirst.Models.Participants", b =>
                {
                    b.HasOne("LoveFirst.Models.Counters", "Counters")
                        .WithMany("Participants")
                        .HasForeignKey("CounterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Counters");
                });

            modelBuilder.Entity("LoveFirst.Models.Counters", b =>
                {
                    b.Navigation("Operations");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("LoveFirst.Models.Profiles", b =>
                {
                    b.Navigation("Counters");
                });
#pragma warning restore 612, 618
        }
    }
}