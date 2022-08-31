using Final_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Final_Project.Models;
using Final_Project.Repository;

namespace Final_Project.Controllers
{
    
    public class AdminDomainController : Controller 
    {

    private readonly UserManager<Customer> userManager;
    private readonly SignInManager<Customer> signInManager;


        ICustomerRepository customerRepository;
        IProductRepository productRepository;
        IOrderRepository orderRepository;

        public AdminDomainController
            (UserManager<Customer> userManager, SignInManager<Customer> signInManager,
            ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.customerRepository=customerRepository;
            this.productRepository=productRepository;
            this.orderRepository=orderRepository;
        }

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
                Customer customer = await userManager.FindByNameAsync(userVM.UserName);
                if (customer != null)
                {
                    bool Pass = await userManager.CheckPasswordAsync(customer, userVM.Password);
                    if (Pass)
                    {
                        await signInManager.SignInAsync(customer, userVM.RememberMe);
                        return RedirectToAction("Index", "AdminDomain");
                    }
                }
                ModelState.AddModelError("", "Username or Password are invalid ");
            }
            return View(userVM);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewBag.Clients=customerRepository.GetAll().Count();
            ViewBag.Sales=orderRepository.GetAll().Select(o => o.Total_Price).Sum();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Customer()
        {
            
            return View(customerRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Product()
        {

            return View(productRepository.GetAll());
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Order()
        {

            return View(orderRepository.GetAll());
        }

    }
}
