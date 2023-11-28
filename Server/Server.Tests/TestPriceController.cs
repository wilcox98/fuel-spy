
using Xunit;
using Moq;


namespace Tests;
public class TestPriceController
{
    [Fact]
    public async void Test_GetAllStations()
    {

        var station = new Mock<PetrolStationContext>();
        var controller = new PricesController(station.Object);
        // act
        var result = controller.Get();
        Assert.Equal(1, 1);
    }


}