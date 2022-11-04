using System;
namespace MyShop.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ImgId { get; set; }
        public string Color { get; set; }
        public string DeliveryType { get; set; }
        public string Description { get; set; }
    }
}
