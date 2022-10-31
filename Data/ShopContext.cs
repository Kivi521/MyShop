using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagementSystemNew.Data.Entities;
using OrderManagementSystemNew.Data.Entity;

namespace OrderManagementSystemNew.Data
{
    public class ShopContext : IdentityDbContext<StoreUser>
    {
        private readonly IConfiguration _config;

        public ShopContext(IConfiguration config)
        {
            _config = config;
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlite("Data Source=shop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");
        }
    }

}
