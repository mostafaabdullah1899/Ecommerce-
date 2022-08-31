using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Repository
{
    public class OrderRepository : IOrderRepository
    {
        Ecommerce_Entity context;

        public OrderRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Order> GetAll()
        {
            return context.Orders.Include(d=>d.Customer).ToList();
        }
        public List<Order> GetAllById(int id)
        {
            return context.Orders.Include(d => d.Customer).Where(d=>d.Customer_Id==id).ToList();
        }
        
        public Order GetById(int id)
        {
            return context.Orders.Include(d => d.Customer).FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Update(int id, Order order)
        {
            Order oldorder = GetById(id);
            oldorder.Order_Date = order.Order_Date;
            oldorder.Shipped_Date=order.Shipped_Date;
            oldorder.Customer_Id = order.Customer_Id;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = GetById(id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
