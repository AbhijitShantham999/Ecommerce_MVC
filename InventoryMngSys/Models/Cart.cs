﻿namespace InventoryMngSys.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;

        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}
