
using QrudNTier.BLL.Interfaces;
using QrudNTier.DAL.Interfaces;
using QrudNTier.Model;

namespace QrudNTier.BLL.Implementations;

public class ProductService : IProductService
{
    private readonly IProductUnitOfWork _productUnitOfWork;
    public ProductService(IProductUnitOfWork productUnitOfWork)
    {
        _productUnitOfWork = productUnitOfWork;
    }
    public async Task AddAsync(Product product)
    {
        await _productUnitOfWork.ProductRepository.AddAsync(product);
    }
}
