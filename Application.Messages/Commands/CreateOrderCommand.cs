namespace Application.Messages;

public record CreateOrderCommand(IEnumerable<int> ProductIds);