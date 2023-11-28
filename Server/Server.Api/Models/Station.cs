using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace Server.Api.Models;
public class Station
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("type")]
    public string? LocationType { get; set; }
    [JsonProperty("lat")]
    public double Lat { get; set; }
    [JsonProperty("lon")]
    public double Lon { get; set; }

    public int? TagId { get; set; }
    [JsonProperty("tags")]
    public virtual Tag? Tag { get; set; }


    public IList<FuelPrice> FuelPrices { get; } = new List<FuelPrice>();
}
public class Tag
{

    public long? StationId { get; set; }
    [Key]
    [ForeignKey("TagId")]
    public int? Id { get; set; }
    [JsonProperty("addr:city")]
    public string? City { get; set; }
    [JsonProperty("addr:street")]
    public string? Street { get; set; }
    [JsonProperty("amenity")]
    public string? Amenity { get; set; }
    [JsonProperty("brand")]
    public string? Brand { get; set; }
    [JsonProperty("name")]
    public string? Name { get; set; }
    [JsonProperty("operator")]
    public string? Operator { get; set; }

}
public class FuelPrice
{
    [Key]
    public int? Id { get; set; }
    [JsonProperty("stationId")]
    public long StationId { get; set; }
    [JsonProperty("diesel")]
    public double? Diesel { get; set; }
    [JsonProperty("kerosene")]
    public double? Kerosene { get; set; }
    [JsonProperty("petrol")]
    public double? Petrol { get; set; }
    public DateTime? CreatedAt { get; set; }

}