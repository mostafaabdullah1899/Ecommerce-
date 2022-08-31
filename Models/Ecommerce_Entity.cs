using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Final_Project.ViewModel;

namespace Final_Project.Models
{
    public class Ecommerce_Entity:IdentityDbContext<Customer,Roles,int>
    {
       public Ecommerce_Entity() 
        { }

       public Ecommerce_Entity(DbContextOptions options):base(options) 
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Final_Project.ViewModel.RegisterVM>? RegisterVM { get; set; }

        public DbSet<Final_Project.ViewModel.LoginVM>? LoginVM { get; set; }

    }
}
