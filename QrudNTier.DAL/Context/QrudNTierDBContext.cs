using Microsoft.EntityFrameworkCore;
using QrudNTier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrudNTier.DAL.Context
{
    public class QrudNTierDBContext : DbContext
    {
        public QrudNTierDBContext(DbContextOptions<QrudNTierDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
