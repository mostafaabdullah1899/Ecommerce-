using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Final_Project.Repository;
namespace Final_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IProductRepository ProductRepository;        
        public HomeController(IProductRepository productRepository,ILogger<HomeController> logger)
        {
            this.ProductRepository = productRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ProductRepository.GetAll().Take(6)) ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}