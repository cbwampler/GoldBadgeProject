using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo
{
    public class MenuItemsRepo
    {
        //list that will hold all menu items
        public List<MenuItems> _listOfMenuItems = new List<MenuItems>();
        
        //add a menu item to the list
        public void AddMenuItemToList(MenuItems item)
        {
            _listOfMenuItems.Add(item);
        }

        //View all menu items
        public List<MenuItems> GetMenuList()
        {
            return _listOfMenuItems;
        }

        //delete a menu item
        
        public bool RemoveMenuItem(int itemNo)
        {
            MenuItems item = GetContentByItemNo(itemNo);
            if(item == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method for other methods
        public MenuItems GetContentByItemNo(int itemNo)
        {
            foreach(MenuItems item in _listOfMenuItems)
            {
                if(item.ItemNo == itemNo)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
