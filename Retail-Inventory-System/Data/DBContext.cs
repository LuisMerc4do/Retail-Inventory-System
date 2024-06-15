using Microsoft.EntityFrameworkCore;
using Retail_Inventory_System.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    // Add DbSet properties for other entities as needed

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=LUISMERCADO\\SQLEXPRESS;Database=CodingTest;Trusted_Connection=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your model here (e.g., entity relationships, constraints)
    }
}
