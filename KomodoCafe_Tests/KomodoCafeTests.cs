using System;
using KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class KomodoCafeTests
    {
        MenuItemsRepo menuOperations = new MenuItemsRepo();

        [TestMethod]
        public void AddMenuItem()
        {
            MenuItems menuItem1 = new MenuItems(1, "meal1", "Meal1 Description", "ingred1, ingred2, ingred3, ingred4", 3.25m);
            
            menuOperations.AddMenuItemToList(menuItem1);

            MenuItems menuItem2 = new MenuItems(2, "meal2", "Meal2 Description", "ingred2.1, ingred2.2, ingred2.3, ingred2.4", 3.50m);
            menuOperations.AddMenuItemToList(menuItem2);

            MenuItems menuItem3 = new MenuItems()
            {
                 

            };

        }

        [TestMethod]
        public void ReturnListOfItems()
        {
            menuOperations.GetMenuList();
        }

        [TestMethod]
        public void RemoveMenuItem()
        {
            menuOperations.RemoveMenuItem(2);
        }
    }
}
      