namespace Domain;

public class Order
{
    public int Id { get; set; }

    public IEnumerable<Product> Products { get; set; }

    public DateTime Created { get; set; }

}
