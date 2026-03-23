public class CustomerController
{
    private readonly StatisticsCalculator calculator;

    public CustomerController(StatisticsCalculator calculator)
    {
        this.calculator = calculator;
    }

    public string GetStatistics(int customerId)
    {
        (double totalWeight, double totalCost) = 
            calculator.Calculate(customerId);
            
        return $"Total weight delivered: {totalWeight}. " 
             + $"Total cost: {totalCost}";
    }
}