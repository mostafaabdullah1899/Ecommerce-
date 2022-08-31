using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }
    }
}
