using System.Text.Json.Serialization;
namespace projects.Models;
public class Station
{
    [JsonPropertyName("id")]
    public int StationId { get; set; }
    [JsonPropertyName("type")]
    public string? LocationType { get; set; }
    [JsonPropertyName("lon")]
    public double Lat { get; set; }
    [JsonPropertyName("lat")]
    public double Lon { get; set; }
    [JsonPropertyName("tags")]
    public Tag? Tag { get; set; }
    // [JsonPropertyName("id")]
    public required int TagId { get; set; }
}
public class Tag
{
    public int? TagId { get; set; }
    [JsonPropertyName("addr:city")]
    public string? City { get; set; }
    [JsonPropertyName("addr:street")]
    public string? Street { get; set; }
    [JsonPropertyName("amenity")]
    public string? Amenity { get; set; }
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

}
public class FuelPrice
{
    public string? FuelPriceId { get; set; }
    [JsonPropertyName("stationId")]
    public int? StationId { get; set; }
    [JsonPropertyName("diesel")]
    public double? Diesel { get; set; }
    [JsonPropertyName("kerosene")]
    public double? Kerosene { get; set; }
    [JsonPropertyName("petrol")]
    public double? Petrol { get; set; }
    public DateTime? CreatedAt { get; set; }

}