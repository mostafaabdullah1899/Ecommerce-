using Final_Project.Models;
using Final_Project.ViewModel;

namespace Final_Project.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Insert(RegisterVM customer);
        void Update(int id, Customer customer);
        void Delete(int id);
        Customer getAddress(string name);


    }
}
