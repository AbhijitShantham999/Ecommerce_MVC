using System.ComponentModel.DataAnnotations;

namespace InventoryMngSys.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is Required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 100 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Password cannot exceed 50 characters")]
        public string Password { get; set; }
    }
}
