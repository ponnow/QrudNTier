
using QrudNTier.DAL.Context;
using QrudNTier.DAL.Core;
using QrudNTier.DAL.Interfaces;
using QrudNTier.Model;

namespace QrudNTier.DAL.Implementation;

public class ProductRepository 
    : Repository<Product, int, QrudNTierDBContext>, 
    IProductRepository
{
    public ProductRepository(QrudNTierDBContext dBContext) : base(dBContext)
    {
    }

    public int CountProduct()
    {
        return _dbSet.Count();
    }

    public override async Task AddAsync(Product entity)
    {
        await _dbSet.AddAsync(entity);
    }
}
