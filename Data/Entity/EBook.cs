using System;
namespace EShop.Data.Entity
{
    public class EBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public string ImgId { get; set; }
        public string Author { get; set; }
        public string DateOfPublish { get; set; }
        public string Introduction { get; set; }
    }
}
