
using QrudNTier.DAL.Context;
using QrudNTier.DAL.Core;
using QrudNTier.Model;

namespace QrudNTier.DAL.Interfaces;

public  interface IProductRepository : IRepository<Product, int, QrudNTierDBContext>
{
    int CountProduct();
}
