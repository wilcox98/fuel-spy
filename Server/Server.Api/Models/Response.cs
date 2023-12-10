namespace Api.Models;
public class StationResponse
{
    // public Station? Station { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public double StationId { get; set; }
    public Tag? Tags { get; set; }
    public FuelPrice? FuelPrice { get; set; }
}