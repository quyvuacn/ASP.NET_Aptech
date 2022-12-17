using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EX_Shop.Models;

namespace EX_Shop.Data
{
    public class EX_ShopContext : DbContext
    {
        public EX_ShopContext (DbContextOptions<EX_ShopContext> options)
            : base(options)
        {
        }

        public DbSet<EX_Shop.Models.Customer> Customer { get; set; } = default!;
		public DbSet<EX_Shop.Models.Category> Category { get; set; } = default!;
		public DbSet<EX_Shop.Models.Product> Product { get; set; } = default!;
		public DbSet<EX_Shop.Models.Order> Order { get; set; } = default!;
		public DbSet<EX_Shop.Models.OrderDetail> OrderDetail { get; set; } = default!;



	}
}
