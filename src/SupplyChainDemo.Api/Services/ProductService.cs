using SupplyChainDemo.Api.Models;

namespace SupplyChainDemo.Api.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product { Name = "Widget A", Sku = "WIDGET-A", Quantity = 100 },
        new Product { Name = "Widget B", Sku = "WIDGET-B", Quantity = 50 }
    };

    private readonly List<Order> _orders = new();

    public IEnumerable<Product> GetAll() => _products;

    public Product? Get(Guid id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Add(Product p)
    {
        var newP = p with { Id = Guid.NewGuid() };
        _products.Add(newP);
        return newP;
    }

    public bool Update(Guid id, Product p)
    {
        var idx = _products.FindIndex(x => x.Id == id);
        if (idx < 0) return false;
        _products[idx] = p with { Id = id };
        return true;
    }

    public bool Delete(Guid id)
    {
        var removed = _products.RemoveAll(p => p.Id == id);
        return removed > 0;
    }

    public Order? CreateOrder(Guid productId, int quantity)
    {
        var prod = Get(productId);
        if (prod == null || prod.Quantity < quantity) return null;
        prod.Quantity -= quantity;
        var order = new Order { ProductId = productId, Quantity = quantity };
        _orders.Add(order);
        return order;
    }

    public IEnumerable<Order> GetOrders() => _orders;
}
