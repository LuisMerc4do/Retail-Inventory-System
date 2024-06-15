using Microsoft.EntityFrameworkCore.Query;
using Retail_Inventory_System.Models;
using Retail_Inventory_System.Service;

namespace Retail_Inventory_System
{
    public class ProductController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task Run()
        {
            bool exitMenu = false;
            string menuSelection = "";
            while (!exitMenu)
            {
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Get Product From ID");
                Console.WriteLine("0. Exit");
                int selectedOption = 0;
                bool validInputTwo = int.TryParse(Console.ReadLine(), out selectedOption);
                if (validInputTwo && selectedOption >= 0 && selectedOption < 5)
                {
                    menuSelection = selectedOption.ToString();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                    // Restart the loop to prompt the user again
                    continue;
                }
                switch (menuSelection)
                {
                    case "1":
                        await InsertProductUI();
                        break;
                    case "2":
                        await DeleteProductUI();
                        break;
                    case "3":
                        await UpdateProductUI();
                        break;
                    case "4":
                        await ViewAllProducts();
                        break;
                    case "5":
                        await ViewProductByID();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, Please enter a number between 0 and 5.");
                        break;
                }
            }
        }
        public static bool validResult(string readResult)
        {
            if (string.IsNullOrEmpty(readResult))
            {
                Console.WriteLine("Invalid Input please insert an String");
                return false;
            }
            return true;
        }
        #region INSERT PRODUCT
        public async Task InsertProductUI()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Add New Product");
                DateTime dateCreation = DateTime.Now;
                // Name validation
                string name;
                while (true)
                {
                    Console.Write("Enter product name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Product name cannot be empty. Please enter a valid product name.");
                    }
                    else
                    {
                        break;
                    }
                }

                // Description validation
                string description;
                while (true)
                {
                    Console.Write("Enter product description: ");
                    description = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine("Product description cannot be empty. Please enter a valid product description.");
                    }
                    else
                    {
                        break;
                    }
                }

                // Category validation
                string category;
                while (true)
                {
                    Console.Write("Enter product category: ");
                    category = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(category))
                    {
                        Console.WriteLine("Product description cannot be empty. Please enter a valid product description.");
                    }
                    else
                    {
                        break;
                    }
                }

                // Price validation
                decimal price;
                while (true)
                {
                    Console.Write("Enter product price: ");
                    if (decimal.TryParse(Console.ReadLine(), out price) && price > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid positive decimal number.");
                    }
                }

                // Stock validation
                int stock;
                while (true)
                {
                    Console.Write("Enter product stock: ");
                    if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid stock. Please enter a valid non-negative integer.");
                    }
                }
                if (await _productService.ProductExistsAsync(name))
                {
                    Console.WriteLine("A product with this name already exists.");
                    return;
                }
                Product newProduct = new Product
                {
                    Name = name,
                    Description = description,
                    Category = category,
                    Price = price,
                    Stock = stock,
                    CreatedDate = dateCreation
                };

                await _productService.AddProductAsync(newProduct);

                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion

        #region DELETE PRODUCT
        public async Task DeleteProductUI()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Delete a Product by ID");
                // ID validation
                int id;
                while (true)
                {
                    Console.Write("Enter product ID: ");
                    if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID Syntax. Please enter a valid positive number.");
                    }
                }
                await _productService.DeleteProductAsync(id);

                Console.WriteLine("Product Deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion

        #region UPDATE PRODUCT
        public async Task UpdateProductUI()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Update an existing Product");
                Console.WriteLine("Inser ID of existing Product");
                // ID validation
                int id;
                while (true)
                {
                    Console.Write("Enter product ID: ");
                    if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID Syntax. Please enter a valid positive number.");
                    }
                }
                var productToUpdate = await _productService.GetProductByIdAsync(id);
                if (productToUpdate == null)
                {
                    Console.WriteLine($"Product with ID{id} not found.");
                    return;
                }
                // Name validation
                string updatedName;
                Console.Write("Enter new product name or press enter to keep the current name: ");
                updatedName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedName))
                {
                    productToUpdate.Name = updatedName;
                }
                else
                {
                    productToUpdate.Name = productToUpdate.Name;
                }

                // Description validation
                string updatedDescription;
                Console.Write("Enter new product description or press enter to keep the current Description: ");
                updatedDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedDescription))
                {
                    productToUpdate.Description = updatedDescription;
                }
                else
                {
                    productToUpdate.Description = productToUpdate.Description;
                }

                // Category validation
                string Updatedcategory;
                Console.Write("Enter new product category or press enter to keep the current Category: ");
                Updatedcategory = Console.ReadLine();
                if (!string.IsNullOrEmpty(Updatedcategory))
                {
                    productToUpdate.Category = Updatedcategory;
                }
                else
                {
                    productToUpdate.Category = productToUpdate.Category;
                }

                // Price validation
                decimal updatedPrice;
                Console.Write("Enter new product price or press enter to keep the current Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out updatedPrice) && updatedPrice > 0)
                {
                    productToUpdate.Price = productToUpdate.Price;
                }
                else
                {
                    productToUpdate.Price = updatedPrice;
                }

                // Stock validation
                int updatedStock;
                Console.Write("Enter new product stock or press enter to keep the current Stock: ");
                if (!int.TryParse(Console.ReadLine(), out updatedStock) && updatedStock >= 0)
                {
                    productToUpdate.Stock = productToUpdate.Stock;
                }
                else
                {
                    productToUpdate.Stock = updatedStock;
                }

                await _productService.UpdateProductAsync(productToUpdate);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Product updated successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion

        #region VIEALLPRODUCTS
        public async Task ViewAllProducts()
        {
            Console.Clear();
            Console.WriteLine("View All Products");
            var allProducts = await _productService.GetAllProductsAsync();
            if (allProducts.Any())
            {
                foreach (var item in allProducts)
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Description: {item.Description}, Price: ${item.Price}, Category: {item.Category}, Stock: {item.Stock}, Creation Date: {item.CreatedDate}\n");
                }
            }

        }
        #endregion

        #region VIEWPRODUCTBYID
        public async Task ViewProductByID()
        {
            Console.Clear();
            Console.WriteLine("View Product By ID");
            Console.WriteLine("Inser ID of existing Product");
            // ID validation
            int selectedId;
            while (true)
            {
                Console.Write("Enter product ID: ");
                if (int.TryParse(Console.ReadLine(), out selectedId) && selectedId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid ID Syntax. Please enter a valid positive number.");
                }
            }
            var item = await _productService.GetProductByIdAsync(selectedId);
            if (item == null)
            {
                Console.WriteLine($"Product with ID{selectedId} not found.");
                return;
            }
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Description: {item.Description}, Price: ${item.Price}, Category: {item.Category}, Stock: {item.Stock}, Creation Date: {item.CreatedDate}\n");
        }
        #endregion
    }
}