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
    public IEnumerable<Station> Get()
    {
        List<Station> stations = new List<Station>();
        List<Station> newStations = new List<Station>();
        using (var context = new PetrolStationContext())
        {
            stations = context.Stations.ToList();



            foreach (var station in stations)
            {
                // get fuel price
                var fuelPrice = context.FuelPrices.Where(i => i.StationId == station.StationId).OrderByDescending(p => p.CreatedAt)
                       .FirstOrDefault();


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
        fuelPrice.FuelPriceId = Guid.NewGuid().ToString();

        using (var context = new PetrolStationContext())
        {
            context.FuelPrices.Add(fuelPrice);
            context.SaveChanges();
        }
        return fuelPrice;
    }
}