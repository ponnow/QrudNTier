
using QrudNTier.Model;

namespace QrudNTier.BLL.Interfaces;

public interface IProductService
{
    Task AddAsync(Product product);
}
