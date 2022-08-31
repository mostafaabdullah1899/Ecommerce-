using Final_Project.Models;
using Final_Project.Repository;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;

namespace Final_Project.Controllers
{
    public class OrderController : Controller
    {
        IProductRepository productRepository;
        IOrderRepository orderRepository;
        ICustomerRepository customerRepository;

        //After registeration, Injection occurs 
        public OrderController(IProductRepository productRepository,IOrderRepository order,ICustomerRepository customer)
        {
            this.productRepository=productRepository;
            orderRepository = order;
           customerRepository = customer;
        }
        public IActionResult Index()
        {
            Customer customer = customerRepository.getAddress(User.Identity.Name);
            List<Order> customerOrders = orderRepository.GetAllById(customer.Id);
            return View(customerOrders);
        }

        public IActionResult Detalis(int id)
        {
            return View(orderRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            OrderVM orderVM = new OrderVM();
            orderVM.Customer_Name = User.Identity.Name;
            orderVM.Order_Date=DateTime.Now;
            orderVM.Shipped_Date=orderVM.Order_Date.AddDays(7);
            Customer customer= customerRepository.getAddress(User.Identity.Name);
            orderVM.Address=customer.Address;
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
            List<Product> products = new List<Product>();

            orderVM.products=productRepository.GetSelectedProducts(Ids);
            orderVM.Total_Price=orderVM.products.Select(p => p.Price).Sum();

           ViewData["Cust_List"]=customerRepository.GetAll();
            return View(orderVM);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Order order)
        {
            Customer customer = customerRepository.getAddress(User.Identity.Name);

            order.Customer_Id=customer.Id;
            orderRepository.Insert(order);

            //Empty Cart
            Response.Cookies.Append("Ids", JsonConvert.SerializeObject(new List<int>()));
           
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Cust_List"] = customerRepository.GetAll();
            Order order=orderRepository.GetById(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Update(id, order);
                return RedirectToAction("Index");
            }
            
            ViewData["Cust_List"] = customerRepository.GetAll();
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            orderRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult AdminView()
        {
            return View(orderRepository.GetAll());
        }

    }
}
