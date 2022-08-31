using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Repository
{
    public class Order_DetailsRepository : IOrder_DetailsRepository
    {
        Ecommerce_Entity context;

        public Order_DetailsRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Order_Details> GetAll()
        {
            return context.Order_Details.Include(d=>d.Product).Include(x=>x.Order).ToList();
        }

        public Order_Details GetById(int id)
        {
            return context.Order_Details.Include(d => d.Product).Include(x => x.Order).FirstOrDefault(z => z.Id == id);
        }

        public void Insert(Order_Details item)
        {
            context.Order_Details.Add(item);
            context.SaveChanges();
        }

        public void Update(int id, Order_Details item)
        {
            Order_Details order = GetById(id);
            order.OrderID = item.OrderID;
            order.ProductID = item.ProductID;
            order.Quantity = item.Quantity;

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Order_Details order = GetById(id);
            context.Order_Details.Remove(order);
            context.SaveChanges();
        }
    }
}
