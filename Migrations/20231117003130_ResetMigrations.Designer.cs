﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projects.Data;

#nullable disable

namespace projects.Migrations
{
    [DbContext(typeof(PetrolStationContext))]
    [Migration("20231117003130_ResetMigrations")]
    partial class ResetMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("projects.Models.FuelPrice", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Diesel")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "diesel");

                    b.Property<int>("FuelPriceId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Kerosene")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "kerosene");

                    b.Property<double?>("Petrol")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "petrol");

                    b.Property<int?>("StationId")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "stationId");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("FuelPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 11, 17, 0, 31, 30, 422, DateTimeKind.Utc).AddTicks(7640),
                            Diesel = 200.0,
                            FuelPriceId = 30092081,
                            Kerosene = 200.0,
                            Petrol = 200.0,
                            StationId = 30092081
                        });
                });

            modelBuilder.Entity("projects.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<double>("Lat")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "lon");

                    b.Property<string>("LocationType")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.Property<double>("Lon")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "lat");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StationId");

                    b.HasIndex("TagId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            StationId = 30092081,
                            Lat = -1.2990005,
                            LocationType = "node",
                            Lon = 36.759717299999998,
                            TagId = 30092081
                        });
                });

            modelBuilder.Entity("projects.Models.Tag", b =>
                {
                    b.Property<int?>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amenity")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "amenity");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "brand");

                    b.Property<string>("City")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "addr:city");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Operator")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "operator");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "addr:street");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasAnnotation("Relational:JsonPropertyName", "tags");

                    b.HasData(
                        new
                        {
                            TagId = 30092081,
                            Amenity = "fuel",
                            Brand = "Total",
                            City = "Nairobi",
                            Name = "Total",
                            Operator = "Total",
                            Street = "Ngong Road"
                        });
                });

            modelBuilder.Entity("projects.Models.FuelPrice", b =>
                {
                    b.HasOne("projects.Models.Station", null)
                        .WithMany("FuelPrices")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("projects.Models.Station", b =>
                {
                    b.HasOne("projects.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("projects.Models.Station", b =>
                {
                    b.Navigation("FuelPrices");
                });
#pragma warning restore 612, 618
        }
    }
}