namespace SupplyChainDemo.Api.Models;

public record Product
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public string Sku { get; init; } = string.Empty;
    public int Quantity { get; set; }
}
