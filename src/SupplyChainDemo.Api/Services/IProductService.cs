using SupplyChainDemo.Api.Models;

namespace SupplyChainDemo.Api.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? Get(Guid id);
    Product Add(Product p);
    bool Update(Guid id, Product p);
    bool Delete(Guid id);
    Order? CreateOrder(Guid productId, int quantity);
    IEnumerable<Order> GetOrders();
}
