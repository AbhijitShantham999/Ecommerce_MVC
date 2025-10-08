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
            var res = HttpContext.Session.GetString("UserId");
            Console.WriteLine($"CartController - CartDetails - res(userid): {res}");
            if (res == null)
            {
                return View(); 
            }
            int id = int.Parse(res);
            Console.WriteLine($"Id in Cart Controller : {id}");
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