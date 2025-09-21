using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryMngSys.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public string OrderStatus { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
