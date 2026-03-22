public class PriceCalculator
{
    public decimal Calculate(Customer customer, List<Product> products)
    {
        decimal basePrice = 0; /* Calculation based on products */
        decimal discounts = 0; /* Calculation based on customer */
        decimal taxes = 0;/* Calculation based on products */
        return basePrice - discounts + taxes;
    }
}