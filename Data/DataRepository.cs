using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EShop.Data.Entities;
using EShop.Data.Entity;

namespace EShop.Data
{
    public class DataRepository: IDataRepository
    {
        
        private readonly EShopContext _ctx;
        

        
        public DataRepository(EShopContext ctx)
        {
            _ctx = ctx;

        }

       

        public IEnumerable<EBook> GetAllEBooks()
        {
            return _ctx.EBooks
                  .OrderBy(p => p.Name)
                  .ToList();

            //return EBooks;
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.EBook)
                  .ToList();
            }
            else
            {
                return _ctx.Orders
                  .ToList();
            }
        }

        

        public IEnumerable<EBook> GetEBooksByName(string name)
        {
            return _ctx.EBooks
                .Where(p => p.Name == name)
                .ToList(); 
        }

        public IEnumerable<Order> GetOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.EBook)
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
             .ThenInclude(i => i.EBook)
             .Where(o => o.Id == id && o.User.UserName == username)
             .FirstOrDefault();//this is going to do the query, find the one that's for the id and return the first result or a null.
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
