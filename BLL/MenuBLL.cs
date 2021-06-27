using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using System.Linq;

namespace BLL
{
    public class MenuBLL
    {
        private Transaction transaction;

        #region Constructor
        public MenuBLL()
        {
            transaction = new Transaction();
        }
        #endregion
        public Menu getMenu()
        {
            MenuItems.Columns columns = new MenuItems.Columns();
            Menu menu = new Menu();
            menu.items = transaction.getMenuItems(null, columns.ID, columns.NOMBRE, columns.URL, columns.ICON);
            return menu;

            //Menu menu = new Menu();
            //List<string> select = new List<string>();
            //select.Add("*");
            //Type type = typeof(MenuItems);
            //menu.items = transaction.sqlQuery("MenuItems",select, type)
            //    .Select(s => (MenuItems)s)
            //    .ToList();
            //return menu;
        }

        //public Menu getMenuJson()
        //{
        //    return transaction.consultMenuFromJson();
        //}
    }
}
