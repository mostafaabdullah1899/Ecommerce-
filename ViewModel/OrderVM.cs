using Final_Project.Models;

namespace Final_Project.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }
        public string Address { get; set; }

        public DateTime Order_Date { get; set; }
        public DateTime Shipped_Date { get; set; }
        public double Total_Price { get; set; }
        public List<Product> products { get; set; }

    }
}
