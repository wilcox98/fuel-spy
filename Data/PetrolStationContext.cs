
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
        var folder = "/home/chefnoid/Desktop"
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

        modelBuilder.Entity<Station>();
        Models.Station station = new()
        {
            StationId = 30092081,
            LocationType = "node",
            Lat = -1.2990005,
            Lon = 36.7597173,

            TagId = 30092081,
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
            FuelPriceId = Guid.NewGuid().ToString(),
            StationId = 30092081,
            Diesel = 200,
            Kerosene = 200,
            Petrol = 200,
            CreatedAt = DateTime.UtcNow,
        };
        modelBuilder.Entity<Station>().HasData(station);
        modelBuilder.Entity<Tag>().HasData(tag);
        modelBuilder.Entity<FuelPrice>().HasData(fuelPrice);
    }


}
