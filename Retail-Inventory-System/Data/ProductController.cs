using Retail_Inventory_System.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_System.Data
{
    //public class ProductController
    //{
    //    private readonly ProductService _productService;

    //    public ProductController()
    //    {
    //        _productService = new ProductService();
    //    }

    //    public void InsertProduct()
    //    {
    //        var habit
    //        _habitService.AddHabit(habit);
    //    }

    //    public void GetProducts()
    //    {
    //        var habits = _habitService.GetHabits();
    //        View.GetHabitsView.DisplayHabits(habits);
    //    }

    //    public void DeleteProducts()
    //    {
    //        _habitService.DeleteHabitRecord(View.DeleteHabitView.DeleteHabitRecord());
    //    }

    //    public void UpdateProducts()
    //    {
    //        Console.WriteLine("Enter the ID of the habit you want to update:");
    //        if (int.TryParse(Console.ReadLine(), out int id))
    //        {
    //            var existingHabit = _habitService.GetHabits().FirstOrDefault(h => h.Id == id);
    //            if (existingHabit == null)
    //            {
    //                Console.WriteLine($"Habit with ID {id} not found.");
    //                return;
    //            }

    //            var updatedHabit = View.UpdateHabitView.UpdateHabitDetails(existingHabit);
    //            _habitService.UpdateHabit(updatedHabit);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid ID. Please enter a valid number.");
    //        }
    //    }
    //}
}
