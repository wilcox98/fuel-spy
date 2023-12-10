using Api.Controllers;
using Api.Data;
using Microsoft.Extensions.Logging;
using Moq;
namespace Tests;
public class TestPriceController
{
    [Fact]
    public async void Test_GetAllStations()
    {

        var station = new Mock<PetrolStationContext>();
        var logger = new Mock<ILogger<PricesController>>(MockBehavior.Strict);
        var controller = new PricesController(logger.Object, station.Object);
        // act
        var result = controller.Get();
        Assert.Equal(1, 1);
    }


}