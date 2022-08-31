using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface IOrder_DetailsRepository
    {
        List<Order_Details> GetAll();
        Order_Details GetById(int id);
        void Insert (Order_Details item);
        void Update (int id,Order_Details item);
        void Delete (int id);
    }
}
