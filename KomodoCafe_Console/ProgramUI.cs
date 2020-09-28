using KomodoCafe_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    public class ProgramUI
    {
    private MenuItemsRepo _menuItemRepo = new MenuItemsRepo();
    public void Run()
        {
            SeedItemList();
            Menu();
        }

        //menu method
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display all options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add menu item to menu...\n" +
                    "2. Delete menu item from the menu...\n" +
                    "3. View the menu...\n" +
                    "4. Exit"
                    );

                //get the user's input
                string input = Console.ReadLine();

                //decide what to do with user's input
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;

                    case "2":
                        DeleteExistingMenuItem();
                        break;

                    case "3":
                        ViewAllMenuItems();
                        break;

                    case "4":
                        Console.WriteLine("Exiting Menu...");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid menu item.");
                        break;

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
            //create new menu item
            private void AddNewMenuItem()
            {
            Console.Clear(); 
             MenuItems newContent = new MenuItems();

            Console.WriteLine("Enter the Item Number for the Menu Item:");
            string itemNoAsString = Console.ReadLine();
            newContent.ItemNo = int.Parse(itemNoAsString);
           
            Console.WriteLine("Enter the name of the meal you want to add:");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of this Meal Item:");
            newContent.MealDesc = Console.ReadLine();

            Console.WriteLine("What are the ingredients of this Meal Item?");

            newContent.ItemIngredients = Console.ReadLine();
           
            Console.WriteLine("What is the price of this meal item?");
            string priceOfMealItem = Console.ReadLine();
            newContent.Price = decimal.Parse(priceOfMealItem);

            _menuItemRepo.AddMenuItemToList(newContent);
           
            }

            //remove existing menu item
            private void DeleteExistingMenuItem()
            {
            ViewAllMenuItems();
            Console.WriteLine("\nEnter the item number of the item you'd like to remove:");

            int itemNo = int.Parse(Console.ReadLine());

            bool wasDeleted = _menuItemRepo.RemoveMenuItem(itemNo);

            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
    }

            //view all menu items
            private void ViewAllMenuItems()
            {
                List<MenuItems> listOfMenuItems = _menuItemRepo.GetMenuList();
                
                foreach(MenuItems item in listOfMenuItems)
            {
                Console.WriteLine(
                    $"Item: {item.ItemNo}\n" +
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.MealDesc}\n" +
                    $"Ingredients: {item.ItemIngredients}\n" +
                    $"Price: {item.Price}\n");
            }

            }

        //seed method to have default values populated in the list

        private void SeedItemList()
        { 
        MenuItems hamburger = new MenuItems(1, "Hamburger", "Quarter pound beef patty on a bun", "sirloin patty, pickles, ketchup, mustard", 4.25m);
            MenuItems chickenSalad = new MenuItems(2, "Grilled Chicken Salad", "Grilled Chicken Strips on a bed of greens", "grilled chicken, leafy greens, tomatoes, cucumbers, cheese" ,5.50m);
            _menuItemRepo.AddMenuItemToList(hamburger);
            _menuItemRepo.AddMenuItemToList(chickenSalad);
        }
    }
}


