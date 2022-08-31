using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Order_Details
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }

       public virtual Order? Order { get; set; }
       public virtual Product? Product { get; set; } 
    }
}
