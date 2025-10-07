using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace InventoryMngSys.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50,ErrorMessage = "Full Name Cannot Exceed 100 characters")]
        public string FullName { get; set; }    

        [Required(ErrorMessage = "Username is Required")]
        [StringLength(50,ErrorMessage = "Username cannot exceed 100 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50,MinimumLength=4, ErrorMessage = "Password cannot exceed 50 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        [StringLength(50, ErrorMessage = "Password cannot exceed 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        [RegularExpression("^(Admin|Customer|Staff)$",ErrorMessage= "User Type Must be Admin|Customer|Staff ")]
        public string UserType { get; set; }

        [ValidateNever]
        public DateTime Created_at { get; set; } = DateTime.Now;
        [ValidateNever]
        public DateTime Updated_at { get; set; } = DateTime.Now;

        [ValidateNever]
        public ICollection<Product> Products { get; set; }
        [ValidateNever]
        public ICollection<Order> Orders { get; set; }
        [ValidateNever]
        public Cart Cart { get; set; }
    }
}
