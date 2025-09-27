using InventoryMngSys.Repository;
using InventoryMngSys.Models;


namespace InventoryMngSys.Services
{
    public class ProductServices
    {
        private readonly IGenericRepo<Product> _productRepo;

        public ProductServices(IGenericRepo<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var prod = await _productRepo.GetAllAsync();
            return prod;
        }
    }
}
