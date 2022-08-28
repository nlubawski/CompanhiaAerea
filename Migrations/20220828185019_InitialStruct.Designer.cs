﻿// <auto-generated />
using System;
using CompanhiaAerea.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanhiaAerea.Migrations
{
    [DbContext(typeof(AirlineContext))]
    [Migration("20220828185019_InitialStruct")]
    partial class InitialStruct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CompanhiaAerea.Entities.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes", (string)null);
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Cancellation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeNotification")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlyingId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FlyingId")
                        .IsUnique();

                    b.ToTable("Cancellations", (string)null);
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Flying", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTimeDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTimeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("PilotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("PilotId");

                    b.ToTable("Flyings", (string)null);
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AirlaneId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarriedOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comments")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MaintenanceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlaneId");

                    b.ToTable("Maintenances", (string)null);
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Registration")
                        .IsUnique();

                    b.ToTable("Pilots", (string)null);
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Cancellation", b =>
                {
                    b.HasOne("CompanhiaAerea.Entities.Flying", "Flying")
                        .WithOne("Cancellation")
                        .HasForeignKey("CompanhiaAerea.Entities.Cancellation", "FlyingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flying");
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Flying", b =>
                {
                    b.HasOne("CompanhiaAerea.Entities.Airplane", "Airplane")
                        .WithMany("Flyings")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanhiaAerea.Entities.Pilot", "Pilot")
                        .WithMany("Flyings")
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("Pilot");
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Maintenance", b =>
                {
                    b.HasOne("CompanhiaAerea.Entities.Airplane", "Airplane")
                        .WithMany("Maintenances")
                        .HasForeignKey("AirlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Airplane", b =>
                {
                    b.Navigation("Flyings");

                    b.Navigation("Maintenances");
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Flying", b =>
                {
                    b.Navigation("Cancellation");
                });

            modelBuilder.Entity("CompanhiaAerea.Entities.Pilot", b =>
                {
                    b.Navigation("Flyings");
                });
#pragma warning restore 612, 618
        }
    }
}
