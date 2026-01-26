namespace SUT.UnitTests;

public class PriceEngineTests
{
    [Fact]
    public void Discount_Of_Two_Products()
    {
        var product1 = new Product("Hand wash");
        var product2 = new Product("Shampoo");
        var sut = new PriceEngine();
        decimal discount = sut.CalculateDiscount(product1, product2);
        Assert.Equal(0.02m, discount);
    }
}