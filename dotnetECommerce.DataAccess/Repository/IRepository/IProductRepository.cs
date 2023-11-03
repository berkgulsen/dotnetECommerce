using dotnetECommerce.Models;

namespace dotnetECommerce.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}