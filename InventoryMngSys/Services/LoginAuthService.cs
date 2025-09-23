using InventoryMngSys.Repository;
using InventoryMngSys.Models;
using InventoryMngSys.ViewModels;

namespace InventoryMngSys.Services
{
    public class LoginAuthService
    {
        private readonly IGenericRepo<User> _userRepo;

        public LoginAuthService(IGenericRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> Login(LoginVM loginuser)
        {
            var allUsers = await _userRepo.GetAllAsync();

            var user = allUsers.FirstOrDefault(item => item.Username == loginuser.Username 
            && item.Password == loginuser.Password);

            return user;
        }
    }
}
