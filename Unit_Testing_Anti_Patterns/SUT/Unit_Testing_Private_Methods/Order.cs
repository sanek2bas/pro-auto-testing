public class Order
{
    private Customer customer;
    private List<Product> products;

    public string GenerateDescription()
    {
        var calc = new PriceCalculator();
        return $"Customer name: {customer.Name}, " 
             + $"total number of products: {products.Count}, " 
             + $"total price: {calc.Calculate(customer, products)}";
    }

    private decimal GetPrice() 
    {
        decimal basePrice = 0; /* Calculation based on products */
        decimal discounts = 0; /* Calculation based on customer */
        decimal taxes = 0; /* Calculation based on products */
        return basePrice - discounts + taxes;
    }
}

public record Customer(string Name);
public record Product();