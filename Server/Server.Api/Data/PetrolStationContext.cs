using Api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Api.Data;
public class PetrolStationContext : DbContext
{

    protected readonly IConfiguration Configuration;

    public PetrolStationContext(IConfiguration configuration) : base()
    {
        Configuration = configuration;

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase")); ;
        options.EnableSensitiveDataLogging();
    }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<FuelPrice> FuelPrices { get; set; }


    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("interpreter.json"))
        {
            string json = r.ReadToEnd();
            List<Station>? items = JsonConvert.DeserializeObject<List<Station>>(json);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        List<Station> items = new List<Station>();
        using (StreamReader r = new StreamReader("interpreter.json"))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<Station>>(json) ?? items;
        }

        modelBuilder.Entity<Station>().Property(e => e.Id)
        .HasConversion<int>();
        modelBuilder.Entity<Station>().HasMany(e => e.FuelPrices);

        modelBuilder.Entity<Station>().HasKey(e => e.Id);
        modelBuilder.Entity<Station>().OwnsOne(
                station => station.Tag, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToTable("Tags");
                });
        modelBuilder.Entity<FuelPrice>();
        //     .Property(e => e.Id)
        // .ValueGeneratedOnAdd();

        // modelBuilder.Entity<Station>().HasData(station, station1);
        // modelBuilder.Entity<Tag>().HasData(tag, tag1);
        // modelBuilder.Entity<FuelPrice>().HasData(fuelPrice, fuelPrice1);
        Random rnd = new Random();
        foreach (var item in items)
        {

            Station s = new();
            s = item;
            int id = Math.Abs((int)s.Id);
            Tag? tag = new();
            tag = s.Tag;
            s.TagId = id;
            s.Id = id;
            s.Tag = null;
            if (s.LocationType == "node")
            {
                modelBuilder.Entity<Station>(b =>
                   {
                       b.HasData(s);
                   });
                if (tag != null)
                {
                    tag.Id = id;
                    tag.StationId = id;
                    modelBuilder.Entity<Station>().OwnsOne(p => p.Tag).HasData(tag);
                }
            }

            // modelBuilder.Entity<Tag>(b =>
            //     {
            //         // int id = rnd.Next(Math.Abs((int)item.StationId));
            //         item.TagId = Math.Abs((int)item.StationId);

            //         b.HasData(item);
            //     });


        }
    }


}
// Models.Station station = new()
//         {
//             StationId = 30092081,
//             LocationType = "node",
//             Lat = -1.2990005,
//             Lon = 36.7597173,

//             TagId = 30092081,
//             // FuelPriceId = id
//         };
//         Models.Tag tag = new()
//         {
//             TagId = 30092081,
//             City = "Nairobi",
//             Street = "Ngong Road",
//             Amenity = "fuel",
//             Brand = "Total",
//             Name = "Total",
//             Operator = "Total",
//         };

//         FuelPrice fuelPrice = new FuelPrice
//         {

//             Id = id,
//             StationId = 30092081,
//             Diesel = 200,
//             Kerosene = 200,
//             Petrol = 200,
//             CreatedAt = DateTime.UtcNow,
//         };
//         Models.Station station1 = new()
//         {
//             StationId = 30092222,
//             LocationType = "node",
//             Lat = -1.3195401,
//             Lon = 36.8371639,

//             TagId = 30092222,
//             // FuelPriceId = id
//         };
//         Models.Tag tag1 = new()
//         {
//             TagId = 30092222,
//             City = "Nairobi",
//             Street = "Popo Rd/Mombasa Rd",
//             Amenity = "fuel",

//             Name = "OLA Energy",

//         };

//         FuelPrice fuelPrice1 = new FuelPrice
//         {

//             Id = id + 1,
//             StationId = 30092222,
//             Diesel = 2020,
//             Kerosene = 2200,
//             Petrol = 2020,
//             CreatedAt = DateTime.UtcNow,
//         };