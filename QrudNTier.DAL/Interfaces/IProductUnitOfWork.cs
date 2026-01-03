
using QrudNTier.DAL.Core;

namespace QrudNTier.DAL.Interfaces;

public interface IProductUnitOfWork : IUnitOfWork
{
    IProductRepository ProductRepository { get; }
}
