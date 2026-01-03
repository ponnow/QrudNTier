
using QrudNTier.DAL.Context;
using QrudNTier.DAL.Core;
using QrudNTier.DAL.Interfaces;
using QrudNTier.Model;

namespace QrudNTier.DAL.Implementation;

public class ProductRepository : Repository<Product, int, QrudNTierDBContext>, IProductRepository
{
    public ProductRepository(QrudNTierDBContext context) : base(context)
    {
    }

    public int CountProduct()
    {
        return _dbSet.Count();
    }
}
