namespace LogAn.UnitTests
{
    public class MemCalculatorTests
    {
        [Fact]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calc = MakeCalc();
            int lastSum = calc.Sum();
            Assert.Equal(0, lastSum);
        }

        [Fact]
        public void Add_WhenCalled_ChangeSum()
        {
            MemCalculator calc = MakeCalc();

            calc.Add(1);
            int sum = calc.Sum();

            Assert.Equal(1, sum);
        }

        private MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
