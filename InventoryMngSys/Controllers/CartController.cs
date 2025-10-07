using InventoryMngSys.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMngSys.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartServ;

        public CartController(CartService cartServ)
        {
            _cartServ = cartServ;
        }

        public async Task<IActionResult> CartDetails()
        {
            var res = HttpContext.Session.GetString("Userid");
            Console.WriteLine($"Stored: {res}");
            if (res == null)
            {
                return View(); 
            }
            int id = int.Parse(res);
            var cartdto = await _cartServ.CartDetails(id);

            if (cartdto == null)
            {
                Console.WriteLine($"cartdto : {cartdto}");
                return View();
            }

            Console.WriteLine($"cartdto : {cartdto}");
            return View(cartdto);
        }
    }
}