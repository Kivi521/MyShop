using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystemNew.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductSize { get; set; }
        public string ProductImgId { get; set; }
        public string ProductColor { get; set; }
        //public string ProductDeliveryType { get; set; }
        //public string ProductDescription { get; set; }
    }
}