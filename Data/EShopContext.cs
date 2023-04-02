using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EShop.Data.Entities;
using EShop.Data.Entity;

namespace EShop.Data
{
    public class EShopContext : IdentityDbContext<StoreUser>
    {
        private readonly IConfiguration _config;

        public EShopContext(IConfiguration config)
        {
            _config = config;
        }


        public DbSet<EBook> EBooks { get; set; }
        public DbSet<Order> Orders { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            //bldr.UseSqlServer("Server=PETER-PC; Database=EShopDataBase; User Id=hello;Password=123456;");
            bldr.UseSqlite("Data Source =EShop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EBook>()
              .Property(p => p.Price)
              .HasColumnType("money");
        }
    }

}
