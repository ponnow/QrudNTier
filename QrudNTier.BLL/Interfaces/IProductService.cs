
using QrudNTier.BLL.Model;
using QrudNTier.Model;

namespace QrudNTier.BLL.Interfaces;

public interface IProductService
{
    //Task<Result<IList<Product>>> GetAllAsync();
    Task <IList<Product>> GetAllAsync();
    Task<Result<Product>> GetByIdAsync(int id);
    Task<Result<int>> AddAsync(Product product);
    Task<Result<int>> UpdateAsync(Product product);
    Task<Result<bool>> DeleteAsync(int id);
}
