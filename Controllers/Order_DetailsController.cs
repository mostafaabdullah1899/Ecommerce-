using Final_Project.Models;
using Final_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class Order_DetailsController : Controller
    {
        IOrder_DetailsRepository order_DetailsRepository;
        IOrderRepository orderRepository;
        IProductRepository productRepository;

        public Order_DetailsController(IProductRepository product,IOrderRepository order,
            IOrder_DetailsRepository order_Details)
        {
            order_DetailsRepository = order_Details;
            productRepository = product;
            orderRepository = order;
        }
        public IActionResult Index()
        {
            return View(order_DetailsRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(order_DetailsRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Order_List"] = orderRepository.GetAll();
            ViewData["Product_List"]=productRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Order_Details order)
        {
            if (ModelState.IsValid)
            {
                order_DetailsRepository.Insert(order);
                return RedirectToAction("Index");
            }

            ViewData["Order_List"] = orderRepository.GetAll();
            ViewData["Product_List"] = productRepository.GetAll();
            return View(order);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Order_List"] = orderRepository.GetAll();
            ViewData["Product_List"] = productRepository.GetAll();
            Order_Details order = order_DetailsRepository.GetById(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Order_Details order)
        {
            if (ModelState.IsValid)
            {
                order_DetailsRepository.Update(id,order);
                return RedirectToAction("Index");
            }

            ViewData["Order_List"] = orderRepository.GetAll();
            ViewData["Product_List"] = productRepository.GetAll();
            return View(order);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            order_DetailsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
