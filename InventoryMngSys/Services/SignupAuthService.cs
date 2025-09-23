using InventoryMngSys.Data;
using InventoryMngSys.Models;
using InventoryMngSys.Repository;

namespace InventoryMngSys.Services
{
    public class SignupAuthService
    {
        private readonly IGenericRepo<User> _userRepo;

        public SignupAuthService(IGenericRepo<User> userRepo) {
            _userRepo = userRepo;
        }

        public async Task<bool> SignUp(User user)
        {
            var allUsers = await _userRepo.GetAllAsync();

            bool duplicate = allUsers.Any(item => item.Username == user.Username || item.Email == user.Email);

            if (!duplicate)
            {
                await _userRepo.AddAsync(user);
                return true;
            }

            return false;
        }
    }
}
