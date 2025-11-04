namespace SupplyChainDemo.Api.Models;

public record Order
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
