using Microsoft.EntityFrameworkCore;
using QrudNTier.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrudNTier.DAL.Core;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;
    protected readonly QrudNTierDBContext _context;

    public UnitOfWork(QrudNTierDBContext context)
    {
        _context = context;
    }
    public bool SaveChanges()
    {
        return _context?.SaveChanges() > 0;
    }
    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Rollback()
    {
        _context.ChangeTracker.Entries()
            .ToList()
            .ForEach(entry => entry.State = EntityState.Unchanged);

        //_context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
    }

    #region Dispose
    ~UnitOfWork()
    {
        Dispose(false);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            _disposed = true;
        }
    }

    #endregion

}
