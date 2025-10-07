using InventoryMngSys.Data;
using InventoryMngSys.Models;
using InventoryMngSys.Repository;
using InventoryMngSys.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryMngSys.Services
{
    public class CartService
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepo<CartItem> _cartItemRepo;
        private readonly IGenericRepo<Cart> _cartRepo;

        public CartService(IGenericRepo<CartItem> cartItemRepo,
                           IGenericRepo<Cart> cartRepo,
                           AppDbContext context)
        {
            _context = context;
            _cartItemRepo = cartItemRepo;
            _cartRepo = cartRepo;
        }

        public async Task<int> CartItemCount(int id)
        {
            bool exist = await _cartRepo.IsExists(id);

            if (!exist)
            {
                Console.WriteLine("ID Doesn't Exists");
                return 0;
            }

            var result = await _context.Carts
                        .Join(_context.CartItems,
                               cart => cart.CartId,
                               item => item.CartId,
                               (cart, item) => new { 
                                    Cart = cart,
                                    CartItem = item
                               })
                        .Where(item => item.Cart.UserId == id)
                        .ToListAsync();

            int count = result.Count;

            return count;
        }

        public async Task<List<CartProductVM>> CartDetails(int id)
        {
            bool exists = await _cartRepo.IsExists(id);

            if (!exists)
            {
                Console.WriteLine("ID Doesn't Exists");
                throw new ArgumentException("ID Doesn't Exists");
            }

            var cartresult = _context.Carts
                        .Join(_context.CartItems,
                              cart => cart.CartId,
                              item => item.CartId,
                              (cart, item) => new
                              {
                                  Cart = cart,
                                  CartItem = item
                              });
            var prodResult = await _context.Products
                            .Join(cartresult,
                                  p => p.ProductId,
                                  cr => cr.CartItem.ProductId,
                                  (p,cr) => new CartProductVM
                                  {
                                      Products = p,
                                      CartItems = cr.CartItem,
                                      Cart = cr.Cart
                                  })
                            .Where(i => i.Cart.UserId == id).ToListAsync();

            if (prodResult != null)
            {
                return prodResult;
            }
            return null;

        }

    }
}
