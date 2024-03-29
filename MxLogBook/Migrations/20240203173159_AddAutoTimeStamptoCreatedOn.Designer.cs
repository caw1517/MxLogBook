﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(MxLogBookDbContext))]
    [Migration("20240203173159_AddAutoTimeStamptoCreatedOn")]
    partial class AddAutoTimeStamptoCreatedOn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.LogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Closed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discrepency")
                        .HasColumnType("text");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("log_items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Closed = false,
                            CreatedOn = new DateTime(2024, 2, 3, 17, 31, 59, 127, DateTimeKind.Utc).AddTicks(3551),
                            Discrepency = "Rear right hand tire has slow leak.",
                            VehicleId = 1
                        });
                });

            modelBuilder.Entity("Backend.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Hours")
                        .HasColumnType("integer");

                    b.Property<string>("Make")
                        .HasColumnType("text");

                    b.Property<int?>("Mileage")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 2, 3, 17, 31, 59, 127, DateTimeKind.Utc).AddTicks(3453),
                            Make = "Ford",
                            Mileage = 61000,
                            Model = "F-150",
                            Year = 2018
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 2, 3, 17, 31, 59, 127, DateTimeKind.Utc).AddTicks(3455),
                            Hours = 20,
                            Make = "Honda",
                            Model = "CRF250R",
                            Year = 2023
                        });
                });

            modelBuilder.Entity("Backend.Models.LogItem", b =>
                {
                    b.HasOne("Backend.Models.Vehicle", "Vehicle")
                        .WithMany("LogItems")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Backend.Models.Vehicle", b =>
                {
                    b.Navigation("LogItems");
                });
#pragma warning restore 612, 618
        }
    }
}
