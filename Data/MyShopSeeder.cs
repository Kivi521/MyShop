using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyShop.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using MyShop.Data;

namespace MyShop.Data
{
    public class MyShopSeeder
    {
        private readonly ShopContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public MyShopSeeder(ShopContext ctx,
          IWebHostEnvironment hosting,
          UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("visitor@myshop.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "visitor",
                    LastName = "visitor",
                    Email = "visitor@myshop.com",
                    UserName = "visitor"
                };

                var result = await _userManager.CreateAsync(user, "Hel!oW0rld");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }

            if (!_ctx.Products.Any())
            {
                // Need to create the Sample Data
                var file = Path.Combine(_hosting.ContentRootPath, "Data/data.json");
                var json = File.ReadAllText(file);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
              {
                new OrderItem()
                {
                  Product = products.First(), 
                      Quantity = 5,
                  UnitPrice = products.First().Price
                }
              };
                }

                _ctx.SaveChanges();
            }
        }
    }
}
