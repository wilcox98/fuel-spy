using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projects.Data;
using projects.Models;
namespace projects.Controllers;

[ApiController]
[Route("prices")]
public class PricesController : ControllerBase
{
    private readonly ILogger<PricesController> _logger;

    public PricesController(ILogger<PricesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<StationResponse> Get()
    {
        List<Station> stations = new List<Station>();
        List<StationResponse> newStations = new List<StationResponse>();
        using (var context = new PetrolStationContext())
        {
            stations = context.Stations.Include(i => i.Tag).Include(i => i.FuelPrices).ToList();



            foreach (var station in stations)
            {
                // convert it to a response model
                var latest = station.FuelPrices.Where(x => x.CreatedAt.HasValue).Max(r => r.CreatedAt)!.Value;
                var res = new StationResponse
                {

                    Lat = station.Lat,
                    Lon = station.Lon,
                    StationId = station.StationId,
                    Tags = station.Tag,
                    FuelPrice = station.FuelPrices.Where(x => x.CreatedAt == latest).FirstOrDefault(),
                };
                newStations.Add(res);


            }
        }
        return newStations;
    }
    [HttpGet("station/{stationId}")]
    public FuelPrice GetStationPrices(int stationId)
    {
        FuelPrice fuelPrice = new FuelPrice();

        using (var context = new PetrolStationContext())
        {
            fuelPrice = context.FuelPrices.Where(e => e.StationId == stationId).First();

        }
        return fuelPrice;
    }
    [HttpPost]
    public FuelPrice Post([FromBody] dynamic jsonData)
    {
        Console.WriteLine(jsonData);
        FuelPrice fuelPrice = JsonSerializer.Deserialize<FuelPrice>(jsonData)!;
        fuelPrice.CreatedAt = DateTime.UtcNow;
        // fuelPrice.FuelPriceId = Guid.NewGuid().ToString();

        using (var context = new PetrolStationContext())
        {
            context.FuelPrices.Add(fuelPrice);
            context.SaveChanges();
        }
        return fuelPrice;
    }
}