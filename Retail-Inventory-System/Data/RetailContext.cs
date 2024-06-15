using Microsoft.EntityFrameworkCore;
using Retail_Inventory_System.Models;

namespace Retail_Inventory_System.Data
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions<RetailContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
