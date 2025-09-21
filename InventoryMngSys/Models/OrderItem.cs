using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryMngSys.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [ForeignKey("Product")]
        public int Product_id { get; set; }

        [ForeignKey("Order")]
        public int Order_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Price Requried")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater tha 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public Product Product { get; set; }
        public Order Order { get; set; }


    }
}
