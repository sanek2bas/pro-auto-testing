public interface  IDeliveryGateway
{
    List<DeliveryRecord> GetDeliveries(int customerId);
}

public class DeliveryGateway : IDeliveryGateway
{
    public List<DeliveryRecord> GetDeliveries(int customerId)
    {
        /* Calling an out-of-process dependency to get a list of deliveries */
        return new List<DeliveryRecord>();
    }
}