using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Entities;
using MyShop.Data.Entity;

namespace MyShop.Data
{
    public class DataRepository: IDataRepository
    {
        
        private readonly ShopContext _ctx;
        

        
        public DataRepository(ShopContext ctx)
        {
            _ctx = ctx;

        }

       

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                  .OrderBy(p => p.Name)
                  .ToList();

            //return products;
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .ToList();
            }
            else
            {
                return _ctx.Orders
                  .ToList();
            }
        }

        

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return _ctx.Products
                .Where(p => p.Name == name)
                .ToList();
        }

        public IEnumerable<Order> GetOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .Where(o => o.User.UserName == username)
                  .ToList();
            }
            else
            {
                return _ctx.Orders
                  .Where(o => o.User.UserName == username)
                  .ToList();
            }
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
             .Include(o => o.Items)
             .ThenInclude(i => i.Product)
             .Where(o => o.Id == id && o.User.UserName == username)
             .FirstOrDefault();
        }

        public void AddEntity(object entity)
        {
            _ctx.Add(entity);
        }

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
