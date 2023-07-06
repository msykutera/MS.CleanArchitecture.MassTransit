namespace Domain;

public record Order(int Id, IEnumerable<Product> products, DateTime created);
