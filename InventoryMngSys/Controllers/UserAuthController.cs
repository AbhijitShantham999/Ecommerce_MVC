using InventoryMngSys.Models;
using InventoryMngSys.Services;
using InventoryMngSys.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                    //storing in session
                    HttpContext.Session.SetString("Username", userExists.Username);
                    HttpContext.Session.SetString("UserId", userExists.UserId.ToString());

                    Console.WriteLine("Logged in Successfully");
                    return RedirectToAction("Index", "Home");
                }
                TempData["Invalid"] = "Invalid Username or Password";
                return View(user);
            }
            Console.WriteLine("Invalid Model, Please check form");
            return View(user);
        }
    }
}
