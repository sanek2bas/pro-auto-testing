public class CustomerController2
{
    private readonly StatisticsCalculator2 calculator;
    private readonly IDeliveryGateway gateway;

    public CustomerController2(
        StatisticsCalculator2 calculator,
        IDeliveryGateway gateway)
    {
        this.calculator = calculator;
        this.gateway = gateway;
    }

    public CustomerController2(int customerId)
    {
        var records = gateway.GetDeliveries(customerId);
        (double totalWeight, double totalCost) 
            = calculator.Calculate(records);
    }
}