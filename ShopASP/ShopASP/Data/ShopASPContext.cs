using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopASP.Models;

namespace ShopASP.Data
{
    public class ShopASPContext : DbContext
    {
        public ShopASPContext (DbContextOptions<ShopASPContext> options)
            : base(options)
        {
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    Console.WriteLine(entityEntry.Entity.ToString());
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
        }

        public DbSet<ShopASP.Models.User> User { get; set; } = default!;
        public DbSet<ShopASP.Models.UserAddress> UserAddresses { get; set; } = default!;
        public DbSet<ShopASP.Models.Category> Category { get; set; } = default!;
        public DbSet<ShopASP.Models.Brand> Brand { get; set; } = default!;
        public DbSet<ShopASP.Models.Product> Product { get; set; } = default!;
        public DbSet<ShopASP.Models.ProductComment> ProductComment { get; set; } = default!;
        public DbSet<ShopASP.Models.ProductDetail> ProductDetail { get; set; } = default!;
        public DbSet<ShopASP.Models.ProductImage> ProductImage { get; set; } = default!;
        public DbSet<ShopASP.Models.ProductTag> ProductTag { get; set; } = default!;
        public DbSet<ShopASP.Models.Order> Order { get; set; } = default!;
        public DbSet<ShopASP.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<ShopASP.Models.Blog> Blog { get; set; } = default!;
        public DbSet<ShopASP.Models.BlogComment> BlogComment { get; set; } = default!;
    }   
}
