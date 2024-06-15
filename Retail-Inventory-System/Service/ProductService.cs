using Retail_Inventory_System.Data;
using Retail_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_System.Service
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            // Perform validation or additional logic here
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            // Perform validation or additional logic here
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            // Perform validation or additional logic here
            _productRepository.Delete(id);
        }

        public Product GetProductById(int id)
        {
            // Additional business logic if needed
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            // Additional business logic if needed
            return _productRepository.GetAll();
        }
    }

}
