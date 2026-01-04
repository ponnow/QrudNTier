
using QrudNTier.Model;

namespace QrudNTier.BLL.Interfaces;

public interface IProductService
{
    Task<IList<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
