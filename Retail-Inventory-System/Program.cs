using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Retail_Inventory_System.Data;
using Retail_Inventory_System.Service;

namespace Retail_Inventory_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var serviceProvider = host.Services;

            // Example usage
            var productController = serviceProvider.GetRequiredService<ProductController>();
            productController.Run().Wait();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<RetailContext>(options =>
                        options.UseSqlServer("Server=LUISMERCADO\\SQLEXPRESS;Database=CodingTest;Trusted_Connection=True;TrustServerCertificate=True;"));

                    services.AddScoped<IProductRepository, ProductRepository>();
                    services.AddScoped<ProductService>();
                    services.AddScoped<ProductController>();
                });
    }
}
