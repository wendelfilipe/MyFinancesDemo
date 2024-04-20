using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Wallet>? Wallet { get; set; }
        public DbSet<Stocks>? Stocks { get; set; }
        public DbSet<Fiis>? Fiis { get; set; }
        public DbSet<Fixed>? Fixed { get; set; }
        public DbSet<InternationalAssets>? InternationalAssets { get; set; }
        
    }
}