
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projects.Models;
namespace projects.Data;
public class PetrolStationContext : DbContext
{
    public DbSet<Station> Stations { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<FuelPrice> FuelPrices { get; set; }

    public string DbPath { get; }
    public PetrolStationContext() : base()
    {
        var folder = "/home/chefnoid/Desktop/learning/projects/"
        ;
        // var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(folder, "stations.db");
        // Database.SetInitializer<PetrolStationContext>(new CreateDatabaseIfNotExists<PetrolStationContext>());
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var id = 1;
        modelBuilder.Entity<Station>().HasMany(e => e.FuelPrices);
        modelBuilder.Entity<FuelPrice>();
        //     .Property(e => e.Id)
        // .ValueGeneratedOnAdd();
        Models.Station station = new()
        {
            StationId = 30092081,
            LocationType = "node",
            Lat = -1.2990005,
            Lon = 36.7597173,

            TagId = 30092081,
            // FuelPriceId = id
        };
        Models.Tag tag = new()
        {
            TagId = 30092081,
            City = "Nairobi",
            Street = "Ngong Road",
            Amenity = "fuel",
            Brand = "Total",
            Name = "Total",
            Operator = "Total",
        };

        FuelPrice fuelPrice = new FuelPrice
        {
            FuelPriceId = 30092081,
            Id = id,
            StationId = 30092081,
            Diesel = 200,
            Kerosene = 200,
            Petrol = 200,
            CreatedAt = DateTime.UtcNow,
        };
        Models.Station station1 = new()
        {
            StationId = 30092222,
            LocationType = "node",
            Lat = -1.3195401,
            Lon = 36.8371639,

            TagId = 30092222,
            // FuelPriceId = id
        };
        Models.Tag tag1 = new()
        {
            TagId = 30092222,
            City = "Nairobi",
            Street = "Popo Rd/Mombasa Rd",
            Amenity = "fuel",

            Name = "OLA Energy",

        };

        FuelPrice fuelPrice1 = new FuelPrice
        {
            FuelPriceId = 30092222,
            Id = id + 1,
            StationId = 30092222,
            Diesel = 2020,
            Kerosene = 2200,
            Petrol = 2020,
            CreatedAt = DateTime.UtcNow,
        };
        modelBuilder.Entity<Station>().HasData(station, station1);
        modelBuilder.Entity<Tag>().HasData(tag, tag1);
        modelBuilder.Entity<FuelPrice>().HasData(fuelPrice, fuelPrice1);
    }


}
