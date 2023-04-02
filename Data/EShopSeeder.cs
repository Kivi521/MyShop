using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EShop.Data.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using EShop.Data;

namespace EShop.Data
{
    public class EShopSeeder
    {
        private readonly EShopContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public EShopSeeder(EShopContext ctx,
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

            StoreUser user = await _userManager.FindByEmailAsync("visitor@EShop.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "visitor",
                    LastName = "visitor",
                    Email = "visitor@EShop.com",
                    UserName = "visitor"
                };

                var result = await _userManager.CreateAsync(user, "Hel!oW0rld");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }

            if (!_ctx.EBooks.Any())
            {
                // Need to create the Sample Data
                var file = Path.Combine(_hosting.ContentRootPath, "Data/data.json");
                var json = File.ReadAllText(file);
                var EBooks = JsonSerializer.Deserialize<IEnumerable<EBook>>(json); 
                //add EBooks to the contex

                _ctx.EBooks.AddRange(EBooks);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
              {
                new OrderItem()
                {
                  EBook = EBooks.First(), 
                      Quantity = 5,
                  UnitPrice = EBooks.First().Price
                }
              };
                }
                //this doesn't get saved untile this sytax
                _ctx.SaveChanges();
            }
        }
    }
}
