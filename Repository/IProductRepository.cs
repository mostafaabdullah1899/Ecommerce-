using Final_Project.Models;
using Final_Project.ViewModel;

namespace Final_Project.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<Product> GetSelectedProducts(List<int> productsId);
        Product GetById(int id);
        void Insert(Product product);
        void Update(int id,Product product);
        void Delete(int id);
    }
}
