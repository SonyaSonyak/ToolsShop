using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Models;
using Microsoft.EntityFrameworkCore;

namespace TS.Data
{
    public class TSContext : DbContext
    {
        public TSContext(DbContextOptions<TSContext> options) : base(options) { }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Providers> Providers { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shops> Shops { get; set; }
    }
}
