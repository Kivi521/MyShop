using System;
using OrderManagementSystemNew.Data.Entities;
using OrderManagementSystemNew.Data.Entity;

namespace OrderManagementSystemNew.Data.Entity
{
    public class OrderItem
    {
      

        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
     
       
    }
}
