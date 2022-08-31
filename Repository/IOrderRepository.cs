using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        List<Order> GetAllById(int id);
        Order GetById(int id);
        void Insert (Order order);
        void Update (int id,Order order);
        void Delete(int id);
    }
}
