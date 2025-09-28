using InventoryMngSys.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryMngSys.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductServices _prodServ;

        public ProductsController(ProductServices prodServ)
        {
            _prodServ = prodServ;
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var allProducts = await _prodServ.GetAllProduct();

            return View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var prod = await _prodServ.GetProdByID(id);

            if (prod == null)
            {
                TempData["Invalid"] = "Id Not Found";
                return View();
            }

            return View(prod);
        }


    }
}
