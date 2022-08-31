using Final_Project.Models;
using Final_Project.Repository;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {

        ICustomerRepository CustomerRepository;
        public CustomerController(ICustomerRepository customer)
        {
            CustomerRepository = customer;

        }
        public IActionResult Index()
        {
            return View(CustomerRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(CustomerRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(RegisterVM customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Insert(customer);
                return RedirectToAction("AdminView");
            }
            return View(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer customer = CustomerRepository.GetById(id);
            return View(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Update(id, customer);
                return RedirectToAction("AdminView");
            }
            return View(customer);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            CustomerRepository.Delete(id);
            return RedirectToAction("AdminView");
        }
        [Authorize(Roles="Admin")]
        public IActionResult AdminView()
        {
            return View(CustomerRepository.GetAll());
        }
    }
}
