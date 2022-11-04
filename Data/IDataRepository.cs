using System.Collections.Generic;
using MyShop.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Entities;

namespace MyShop.Data
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByName(string name);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);

        void AddEntity(object entity);
        bool SaveAll();
    }
}