public class WrongCalculatorTests
{
    [Theory]
    [InlineData(1, 3)]
    [InlineData(11, 33)]
    [InlineData(100, 500)]
    public void Adding_Two_Numbers(int value1, int value2)
    {
        int expected = value1 + value2;
        int actual = Calculator.Add(value1, value2);
        
        Assert.Equal(expected, actual);
    }
}