using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("prices")]
public class PricesController : ControllerBase
{
    private readonly ILogger<PricesController> _logger;
    private readonly PetrolStationContext _context;
    private readonly IConfiguration Configuration;
    public PricesController(ILogger<PricesController> logger, PetrolStationContext context, IConfiguration configuration)
    {
        _logger = logger;
        _context = context;
        Configuration = configuration;
    }
    /// <summary>
    /// Gets list of all stations
    /// </summary>
    /// <returns>All fuel stations</returns>
    [HttpGet]
    public IEnumerable<StationResponse> Get()
    {
        List<Station> stations = new List<Station>();
        List<StationResponse> newStations = new List<StationResponse>();

        using (var context = new PetrolStationContext(Configuration))
        {
            stations = context.Stations.Include(i => i.Tag).Include(i => i.FuelPrices).ToList();



            foreach (var station in stations)
            {
                // convert it to a response model
                DateTime? latest = station.FuelPrices.Where(x => x.CreatedAt.HasValue).Max(r => r.CreatedAt);
                var res = new StationResponse
                {

                    Lat = station.Lat,
                    Lon = station.Lon,
                    StationId = station.Id,
                    Tags = station.Tag,
                    FuelPrice = latest != null ? station.FuelPrices.Where(x => x.CreatedAt == latest).FirstOrDefault() : null,
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

        try
        {
            using (var context = new PetrolStationContext(Configuration))
            {
                fuelPrice = context.FuelPrices.Where(e => e.StationId == stationId).First();

            }
            return fuelPrice;
        }
        catch (Exception e)
        {
            // _logger.LogError(e);
            return fuelPrice;
        }
    }
    /// <summary>
    /// Update the price of a fuels station
    /// </summary>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    ///  <remarks>
    /// Sample request:
    ///
    ///     POST /prices/
    ///     {
    ///     "stationId":30092081,
    ///     "diesel":198.0,
    ///     "petrol":333.3,
    ///     "kerosene":100.1
    /// }
    ///
    /// </remarks>
    [HttpPost]
    public FuelPrice Post([FromBody] FuelPrice jsonData)
    {

        FuelPrice fuelPrice = new FuelPrice
        {
            StationId = jsonData.StationId,
            Petrol = jsonData.Petrol,
            Diesel = jsonData.Diesel,
            Kerosene = jsonData.Kerosene,
            CreatedAt = DateTime.UtcNow
        };
        // fuelPrice.FuelPriceId = Guid.NewGuid().ToString();

        using (var context = new PetrolStationContext(Configuration))
        {
            context.FuelPrices.Add(fuelPrice);
            context.SaveChanges();
        }
        return fuelPrice;
    }
}