using Microsoft.EntityFrameworkCore;
using Retail_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_System.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Set<Product>().Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }
    }

}
