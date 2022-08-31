using Final_Project.Models;
using Final_Project.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        Ecommerce_Entity context;

        public CustomerRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Customer> GetAll()
        {
            return context.customers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.customers.FirstOrDefault(d=> d.Id == id);
        }

        public void Insert(RegisterVM customerVM)
        {
            Customer customer = new Customer();
            customer.UserName = customerVM.UserName;
            customer.Email = customerVM.Email;
            customer.PhoneNumber = customerVM.PhoneNumber;
            customer.Address = customerVM.Address;
            customer.PasswordHash = customerVM.Password;

            context.Add(customer);
            context.SaveChanges();
        }

        public void Update(int id, Customer oldCustomer)
        {
            Customer customerToUpdate = GetById(id);
            customerToUpdate.UserName = oldCustomer.UserName;
            customerToUpdate.Email = oldCustomer.Email;
            customerToUpdate.PhoneNumber = oldCustomer.PhoneNumber;
            customerToUpdate.Address = oldCustomer.Address;
            customerToUpdate.PasswordHash = oldCustomer.PasswordHash;


            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer customer = GetById(id);
            context.customers.Remove(customer);
            context.SaveChanges();
        }
        public Customer getAddress(string name)
        {
            return context.customers.FirstOrDefault(N => N.UserName==name);
        }
    }
}
