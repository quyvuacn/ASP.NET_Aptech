using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EX_MVC.Models;

namespace EX_MVC.Data
{
    public class EX_MVCContext : DbContext
    {
        public EX_MVCContext (DbContextOptions<EX_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<EX_MVC.Models.Employee> Employee { get; set; } = default!;
    }
}
