namespace Application;

public record CreateOrderCommand(IEnumerable<int> ProductIds);