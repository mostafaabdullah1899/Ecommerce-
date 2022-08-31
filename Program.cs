using AutoMapper;
using Final_Project.Models;
using Final_Project.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_Project

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            string ConnectionStrings = builder.Configuration.GetConnectionString("CS");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Ecommerce_Entity>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(ConnectionStrings);
            });
            builder.Services.AddIdentity<Customer, Roles>(
                options => options.Password.RequireDigit = true
                ).
                AddEntityFrameworkStores<Ecommerce_Entity>();

            
            //Registeration
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrder_DetailsRepository, Order_DetailsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
           
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}