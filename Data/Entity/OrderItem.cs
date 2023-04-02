using System;
using EShop.Data.Entities;
using EShop.Data.Entity;

namespace EShop.Data.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public EBook EBook { get; set; }
        public int EBookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }       
    }
}
