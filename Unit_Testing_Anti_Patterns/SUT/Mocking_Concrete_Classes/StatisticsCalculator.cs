public class StatisticsCalculator
{
    public (double totalWeight, double totalCost) Calculate(int customerId)
    {
        List<DeliveryRecord> records = GetDeliveries(customerId);
        double totalWeight = records.Sum(x => x.Weight);
        double totalCost = records.Sum(x => x.Cost);
        return (totalWeight, totalCost);
    }

    public virtual List<DeliveryRecord> GetDeliveries(int customerId)
    {
        /* Calling an out-of-process dependency to get a list of deliveries */
        return new List<DeliveryRecord>();
    }
}