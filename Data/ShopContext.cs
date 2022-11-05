using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyShop.Data.Entities;
using MyShop.Data.Entity;

namespace MyShop.Data
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

            //bldr.UseSqlServer("Server=PETER-PC; Database=myShopDataBase; User Id=hello;Password=123456;");
            bldr.UseSqlite("Data Source =shop.db");
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
