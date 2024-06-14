using Microsoft.EntityFrameworkCore;
using Retail_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_System.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;Database=RetailManagement;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        public DbSet<Product> Product { get; set; }
    }
}
