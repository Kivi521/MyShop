using System.Collections.Generic;
using EShop.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using EShop.Data.Entities;

namespace EShop.Data
{
    public interface IDataRepository
    {
        IEnumerable<EBook> GetAllEBooks();
        IEnumerable<EBook> GetEBooksByName(string name);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);

        void AddEntity(object entity);
        bool SaveAll();
    }
}