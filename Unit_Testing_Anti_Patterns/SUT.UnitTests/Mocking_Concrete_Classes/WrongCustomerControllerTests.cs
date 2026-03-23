using Moq;

namespace SUT.UnitTests.Unit_Testing_Anti_Patterns;

public class WrongCustomerControllerTests
{
    [Fact]
    public void Customer_With_No_Deliveries()
    {
        // Arrange
        var stub = new Mock<StatisticsCalculator> { CallBase = true };
        stub.Setup(x => x.GetDeliveries(1))
            .Returns(new List<DeliveryRecord>());
        var sut = new CustomerController(stub.Object);
        
        // Act
        string result = sut.GetStatistics(1);
        
        // Assert
        Assert.Equal("Total weight delivered: 0. Total cost: 0", result);
    }
}