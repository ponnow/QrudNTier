using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Linq.Expressions;
namespace QrudNTier.DAL.Core;

public abstract class Repository<TEntity, Tkey, TContext> : IRepository<TEntity, Tkey, TContext>
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

    
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task<IList> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if (include != null)
        {
            query = include(query);
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        var result = await query.Select(selector).ToListAsync();
        return result;
    }

    public virtual async Task<TResult> GetFirstorDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if (include != null)
        {
            query = include(query);
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        var result = await query.Select(selector).FirstOrDefaultAsync();
        return result;
    }

    public virtual async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var query = _dbSet.AsQueryable();
        return await query.AnyAsync(predicate);
    }

    public virtual async Task UpdateAsync(TEntity entity, params string[] updateProperties)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

        if (updateProperties != null && updateProperties.Any())
        {
            updateProperty(updateProperties);
        }
    }

    private void updateProperty(string[] updateProperties)
    {
        var entry = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
        if (updateProperties.Any())
        {             
            foreach (var entity in entry)
            {
                entity.Properties.ToList().ForEach(y => y.IsModified = false);
                foreach (var property in updateProperties)
                {
                    entity.Property(property).IsModified = typeof(TEntity).GetProperty(property) != null;
                }
            }
        }
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }
}
