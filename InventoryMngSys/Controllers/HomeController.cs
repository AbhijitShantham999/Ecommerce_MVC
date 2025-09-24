using System.Diagnostics;
using InventoryMngSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMngSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.UserId = HttpContext.Session.GetString("UserId");
                return View();
            }
            TempData["SessionTimeout"] = "Please Login to Continue";
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
