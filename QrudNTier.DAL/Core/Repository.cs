using Microsoft.EntityFrameworkCore;
namespace QrudNTier.DAL.Core;

public class Repository<TEntity, Tkey, TContext> : IRepository<TEntity, Tkey, TContext>
     where TEntity : class
     where TContext : DbContext
{
    private readonly TContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public Repository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }
}
