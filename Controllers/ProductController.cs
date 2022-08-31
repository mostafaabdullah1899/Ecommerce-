using AutoMapper;
using Final_Project.Models;
using Final_Project.Repository;
using Final_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        IWebHostEnvironment webHostEnvironment;
        IProductRepository productRepository;

        public ProductController(IProductRepository product, IWebHostEnvironment webHostEnvironment)
        {
            productRepository = product;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = AutoMapperConfig.Mapper;

        }
        public IActionResult Index()
        {
            return View(productRepository.GetAll());
        }
       
        public IActionResult Details(int id)
        {
            return View(productRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(ProductVM productVM)
        {
            if(productVM.ImageFile == null ||productVM.ImageFile.Length == 0) {
                ModelState.AddModelError("ImageFile","You Must Choose Image");
            }


            if (ModelState.IsValid)
            {
                Product product=mapper.Map<Product>(productVM);
                product.Image=uploadImage(productVM.ImageFile);

                productRepository.Insert(product);

                return RedirectToAction("AdminView");

            }
       
            return View(productVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productRepository.GetById(id);
            ProductVM productVM= mapper.Map<ProductVM>(product);
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,ProductVM productVM)
        {
            if (ModelState.IsValid)
            {

                Product product = mapper.Map<Product>(productVM);
                if (productVM.ImageFile != null && productVM.ImageFile.Length != 0)
                {
                    product.Image=uploadImage(productVM.ImageFile, productVM.Image);
                }
                productRepository.Update(id, product);
                return RedirectToAction("AdminView");
            }

            return View(productVM);
        }

        public IActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("AdminView");
        }
        
        public string uploadImage(IFormFile Image,string currentImage="")
        {
            

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = Guid.NewGuid().ToString() + "." + Path.GetExtension(Image.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }

            //Delete Old Image
            if (!string.IsNullOrEmpty(currentImage))
            {
                string oldFilePath = Path.Combine(uploadsFolder, currentImage);
                System.IO.File.Delete(oldFilePath);
            }

            return uniqueFileName;
        }

        public IActionResult AdminView()
        {
            return View(productRepository.GetAll());
        }


        public IActionResult SetCookie(int id)
        {
            List<int>Ids;
            if (Request.Cookies.ContainsKey("Ids") == true)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                 Ids = js.Deserialize< List<int> >(Request.Cookies["Ids"]);

            }
            else {
                Ids=new List<int>();      
            }
            Ids.Add(id);

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(3);


            Response.Cookies.Append("Ids", JsonConvert.SerializeObject(Ids), cookieOptions);
            if(Ids.Count()!=0)
                return Content(Ids.Count().ToString());
            else
                return Content("");
        }
        public IActionResult EmptyCart() {
            List<int> Ids=new List<int>();
            Response.Cookies.Append("Ids", JsonConvert.SerializeObject(Ids));
            return RedirectToAction("Index");
        }


    }
}
