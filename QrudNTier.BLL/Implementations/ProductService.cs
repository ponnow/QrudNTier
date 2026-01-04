
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
        try 
        {
            await _productUnitOfWork.ProductRepository.AddAsync(product);
            await _productUnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productUnitOfWork.ProductRepository.GetByIdAsync(id);
        if(product is not null)
        {
            await _productUnitOfWork.ProductRepository.DeleteAsync(product);
        }
    }

    public Task<IList<Product>> GetAllAsync()
    {
        var products =  _productUnitOfWork.ProductRepository.GetAsync(x => x,null, x => x.OrderByDescending(x => x.Id),null,true);
        //return products; 44:48 PM
        return products.ContinueWith(t => (IList<Product>)t.Result);
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
