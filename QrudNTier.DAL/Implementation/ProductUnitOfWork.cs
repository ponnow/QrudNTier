

using Microsoft.EntityFrameworkCore;
using QrudNTier.DAL.Context;
using QrudNTier.DAL.Core;
using QrudNTier.DAL.Interfaces;

namespace QrudNTier.DAL.Implementation;

public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
{
    public ProductUnitOfWork(
        QrudNTierDBContext context,
        IProductRepository productRepository) : base(context)
    {
        ProductRepository = productRepository;
    }

    public IProductRepository ProductRepository { get; }
}
