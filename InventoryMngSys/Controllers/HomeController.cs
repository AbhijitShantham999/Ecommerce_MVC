using System.Diagnostics;
using InventoryMngSys.Models;
using InventoryMngSys.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMngSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CartService _cartServ;
        public HomeController(ILogger<HomeController> logger, CartService cartServ)
        {
            _logger = logger;
            _cartServ = cartServ;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                var userid = HttpContext.Session.GetString("UserId");
                Console.WriteLine($"Home Controller - Index - userid : {userid}");
                int id = int.Parse(userid);
                Console.WriteLine($"Home Controller - Index - Parsed(userid) : {id}");
                int count = await _cartServ.CartItemCount(id);
                Console.WriteLine($"Cart Count : {count}");
                ViewBag.cartCount = count;
                return View();
            }
            TempData["SessionTimeout"] = "Please Login to Continue";
            return RedirectToAction("Login","UserAuth");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","UserAuth");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
