using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        
        public virtual List<Order_Details>? Order_Details { get; set; }

    }
}
