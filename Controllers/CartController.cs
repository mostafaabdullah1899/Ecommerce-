using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Nancy.Json;
using Final_Project.Repository;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class CartController : Controller
    {
        IProductRepository productRepository;

        public CartController(IProductRepository product)
        {
            productRepository = product;
        }
        
        public IActionResult Index() {
            List<int> Ids;
            if (Request.Cookies.ContainsKey("Ids") == true)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Ids = js.Deserialize<List<int>>(Request.Cookies["Ids"]);

            }
            else
            {
                Ids=new List<int>();
            }
            List<Product> products=new List<Product>();
            if (Ids.Count() == 0)
            {

            }
            else {
                 products = productRepository.GetSelectedProducts(Ids);
            }


            return View(products);
        }
        public IActionResult SelectedProductCount()
        {
            List<int> Ids;
            if (Request.Cookies.ContainsKey("Ids") == true)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Ids = js.Deserialize<List<int>>(Request.Cookies["Ids"]);

            }
            else
            {
                Ids=new List<int>();
            }
            
            if (Ids.Count()!=0)
                return Content(Ids.Count().ToString());
            else
                return Content("");
        }

    }
}
