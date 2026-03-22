public class Customer2
{
    private CustomerStatus status =
        CustomerStatus.Regular;
    public void Promote()
    {
        status = CustomerStatus.Preferred;
    }
        
    public decimal GetDiscount()
    {
        return status == CustomerStatus.Preferred 
            ? 0.05m 
            : 0m;
    }
}