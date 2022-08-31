using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModel
{
    public class ProductVM
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }

        public IFormFile? ImageFile { get; set; }
        //  public string Image { get; set; }

        public String? Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Quantity { get; set; }
    }
}
