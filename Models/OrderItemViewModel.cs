using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int EBookId { get; set; }
        public string EBookName { get; set; }
        public string EBookPrice { get; set; }
        public string EBookSize { get; set; }
        public string EBookImgId { get; set; }
        public string EBookColor { get; set; }
        //public string EBookDeliveryType { get; set; }
        //public string EBookDescription { get; set; }
    }
}