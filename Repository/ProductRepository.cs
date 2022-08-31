using Final_Project.Models;
using Final_Project.ViewModel;

namespace Final_Project.Repository
{
    public class ProductRepository : IProductRepository
    {
        Ecommerce_Entity context;

        public ProductRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public List<Product> GetSelectedProducts(List<int> productsId)
        {
            List<Product> products=new List<Product>();
            foreach (int id in productsId) { 
                products.Add(context.Products.Where(products => products.Id == id).FirstOrDefault());
            }
            return products;
        }
      
        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Product product)
        {
            Product newProduct=new Product();
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.Color = product.Color;
            newProduct.Image=product.Image;
            newProduct.Quantity=product.Quantity;
            newProduct.Description=product.Description;
            context.Products.Add(newProduct);
            context.SaveChanges();
        }

       
        public void Update(int id, Product product)
        {
            Product oldProduct = GetById(id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Color = product.Color;
            oldProduct.Image=product.Image;
            oldProduct.Quantity=product.Quantity;
            oldProduct.Description=product.Description;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = GetById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
