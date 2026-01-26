namespace SUT.UnitTests;

public class OrderTests
{
    [Fact]
    public void Adding_A_Product_To_An_Order()
    {
        var product = new Product("Hand wash");
        var sut = new Order();

        sut.AddProduct(product);

        Assert.Single(sut.Products);
        Assert.Equal(product, sut.Products[0]);
    }
}
