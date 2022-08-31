using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Shipped_Date { get; set; }

        public double Total_Price { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual List<Order_Details>? Order_Details { get; set; }
}
}
