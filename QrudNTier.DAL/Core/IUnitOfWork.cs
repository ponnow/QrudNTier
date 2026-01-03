using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrudNTier.DAL.Core;

public interface IUnitOfWork : IDisposable
{
    bool SaveChanges();
    void Rollback();
    Task<bool> SaveChangesAsync();
}
