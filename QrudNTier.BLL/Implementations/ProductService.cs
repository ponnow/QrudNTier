
using QrudNTier.BLL.Interfaces;
using QrudNTier.BLL.Model;
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
    public async Task<Result<int>> AddAsync(Product product)
    {
        if ( product is null)
        {
            return Result<int>.FailureResult("Product cannot be Blank!");
        }
        try 
        {
            await _productUnitOfWork.ProductRepository.AddAsync(product);
            var saved = await _productUnitOfWork.SaveChangesAsync();
            if(!saved)
            {
                return Result<int>.FailureResult("Failed to add Product!");
            }
                return Result<int>.SuccessResult(product.Id);
        }
        catch (Exception)
        {
            return Result<int>.FailureResult("An error occurred while adding the Product.");
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var product = await _productUnitOfWork.ProductRepository.GetByIdAsync(id);
        if (product is null)
        {
            return Result<bool>.FailureResult("Product not found!");
        }
        await _productUnitOfWork.ProductRepository.DeleteAsync(product);
        var saved = await _productUnitOfWork.SaveChangesAsync();
        if (!saved)
        {
            return Result<bool>.FailureResult("Failed to delete Product!");
        }
        return Result<bool>.SuccessResult(true);
    }

    //public async Task<Result<IList<Product>>> GetAllAsync()
    //{
    //    var products = await _productUnitOfWork.ProductRepository.GetAsync(
    //    x => x,
    //    null,
    //    x => x.OrderByDescending(x => x.Id),null,true);
    //    return Result<IList<Product>>.SuccessResult(products);
    //}
    public async Task<Result<IList<Product>>> GetAllAsync()
    {
        var products = await _productUnitOfWork.ProductRepository.GetAsync(
            x => x,
            null,
            x => x.OrderByDescending(x => x.Id),
            null,
            true
        );
        return Result<IList<Product>>.SuccessResult(products);
    }

    public async Task<Result<Product>> GetByIdAsync(int id)
    {
        var product = await _productUnitOfWork.ProductRepository.GetByIdAsync(id);
        if (product is null)
        {
            return Result<Product>.FailureResult("Product not found!");
        }
        return Result<Product>.SuccessResult(product);
    }

    public async Task<Result<int>> UpdateAsync(Product product)
    {
        if (product is null)
        {
            return Result<int>.FailureResult("Product cannot be Blank!");
        }
        var existingProduct = await _productUnitOfWork.ProductRepository.GetByIdAsync(product.Id);
        if (existingProduct is null)
        {
            return Result<int>.FailureResult($"Product {product.Id} not found!");
        }
        await _productUnitOfWork.ProductRepository.UpdateAsync(product);
        var saved = await _productUnitOfWork.SaveChangesAsync();
        if (!saved)
        {
            return Result<int>.FailureResult("Failed to update Product!");
        }
        return Result<int>.SuccessResult(product.Id);
    }
}
