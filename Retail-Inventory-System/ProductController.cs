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
                        break;
                    case "4":
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
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        #endregion
    }
}
