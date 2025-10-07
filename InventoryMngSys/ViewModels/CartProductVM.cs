using InventoryMngSys.Models;

namespace InventoryMngSys.ViewModels
{
    public class CartProductVM
    {
            public Cart Cart { get; set; }
            public CartItem CartItems { get; set; }
            public Product Products { get; set; }
    }
}
