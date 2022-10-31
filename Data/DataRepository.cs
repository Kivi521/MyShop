using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystemNew.Data.Entities;
using OrderManagementSystemNew.Data.Entity;

namespace OrderManagementSystemNew.Data
{
    public class DataRepository: IDataRepository
    {
        private List<TestData> products = new List<TestData>();
        private readonly ShopContext _ctx;
        

        
        public DataRepository(ShopContext ctx)
        {
            _ctx = ctx;


            TestData productA = new TestData();
            productA.id = 1;
            productA.name = "bookcase";
            productA.price = 999.9M;
            productA.description = "this is a very good bookcase";

            TestData productB = new TestData();
            productB.id = 2;
            productB.name = "sofa";
            productB.price = 576.9M;
            productB.description = "this is a very good sofa";

            products.Add(productA);
            products.Add(productB);
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
