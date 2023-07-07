namespace Domain;

public class Order
{
    public int Id { get; set; }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public DateTime Created { get; set; }

}
