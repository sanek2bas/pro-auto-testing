namespace SUT;

public class Order
{
    private readonly List<Product> products = new List<Product>();
    
    public IReadOnlyList<Product> Products => products.ToList();
    
    public void AddProduct(Product product)
    {
        products.Add(product);
    }
}
