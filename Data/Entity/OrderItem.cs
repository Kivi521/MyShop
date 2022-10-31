using System;
using OrderManagementSystemNew.Data.Entities;
using OrderManagementSystemNew.Data.Entity;

namespace OrderManagementSystemNew.Data.Entity
{
    public class OrderItem
    {
        //for now
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
        //till here
        public string Description { get; set; }
        public int OrderHeaderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int StockItemId { get; set; }
        public int StockGap { get; set; }
        public string Name { get; set; }
        public decimal Total
        {
            get
            {
                return Price * Quantity;
            }
            set
            {

            }
        }

        public string OrderHeader { get; set; }
    }
}
