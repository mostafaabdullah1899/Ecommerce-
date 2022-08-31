using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
