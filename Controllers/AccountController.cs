using Final_Project.Models;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Final_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;

        public AccountController
            (UserManager<Customer> userManager,SignInManager<Customer> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer= await userManager.FindByNameAsync(userVM.UserName);
                if(customer != null)
                {
                    bool Pass = await userManager.CheckPasswordAsync(customer,userVM.Password);
                    if (Pass)
                    {
                         await signInManager.SignInAsync(customer, userVM.RememberMe);
                       
                        return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError("", "Username or Password are invalid ");
            }
            return View(userVM);
        }


        [HttpGet]
     public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                customer.UserName = userVM.UserName;
                customer.Address = userVM.Address;
                customer.PasswordHash = userVM.Password;
                customer.PhoneNumber = userVM.PhoneNumber;
                customer.Email = userVM.Email;
                

                IdentityResult result= await userManager.CreateAsync(customer,userVM.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(customer, false);
             
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> AdminLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","AdminDomain");
        }


    }
}
