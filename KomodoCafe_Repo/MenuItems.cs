using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo
{
    public class MenuItems
    {
        public int ItemNo { get; set; }
        public string MealName { get; set; }
        public string MealDesc { get; set; }
        public string ItemIngredients { get; set; }
        public decimal Price { get; set; }

        public MenuItems() { }
        public MenuItems(int itemNo, string mealName, string mealDesc, string itemIngredients, decimal price)
        {
            ItemNo = itemNo;
            MealName = mealName;
            MealDesc = mealDesc;
            ItemIngredients = itemIngredients;
            Price = price;
        }
    }    
}
