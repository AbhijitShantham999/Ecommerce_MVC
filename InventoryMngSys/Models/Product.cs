using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryMngSys.Models
{
    public class Product
    {
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Product Name Requried")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is Required")]
        public string Image {  get; set; }

        [Required(ErrorMessage = "Product Price Requried")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater tha 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Price Requried")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Stock Quantity Requried")]
        public int StockQuantity { get; set; }

        [ForeignKey("User")]
        public int Created_by { get; set; } //Admin id
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        //Refernce Navigation Property
        public User User { get; set; }

        //Relationship
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
