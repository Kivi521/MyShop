using System.Collections.Generic;
using OrderManagementSystemNew.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystemNew.Data.Entities;

namespace OrderManagementSystemNew.Data
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