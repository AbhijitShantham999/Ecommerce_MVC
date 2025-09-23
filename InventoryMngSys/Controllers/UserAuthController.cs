using Microsoft.AspNetCore.Mvc;
using InventoryMngSys.Services;
using InventoryMngSys.Models;
using InventoryMngSys.ViewModels;

namespace InventoryMngSys.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly SignupAuthService _signupService;
        private readonly LoginAuthService _loginService;

        public UserAuthController(SignupAuthService signup, LoginAuthService login)
        {
            _signupService = signup;
            _loginService = login;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signupService.SignUp(user);
                if (result)
                {
                    Console.WriteLine("User Signedup, Record Created");
                    return RedirectToAction("Index","Home");
                }

            }
            Console.WriteLine("Invalid Model");
            return View(user);
        }

        [HttpGet]
        public IActionResult Login() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user) {

            if (ModelState.IsValid)
            {
                var userExists = await _loginService.Login(user);
                if (userExists != null)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            Console.WriteLine("Invalid Model, Please check form");
            return View(user);
        }


    }
}
