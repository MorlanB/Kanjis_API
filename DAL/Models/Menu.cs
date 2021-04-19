using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Menu
    {
        public Menu() { }

        public Menu(string fileText)
        {
            String[] rows = fileText.Split('\n');
            this.items = new List<MenuItems>();
            foreach(string row in rows)
            {
                String[] props = row.Split('@');
                this.items.Add(new MenuItems() { 
                Nombre = props[0],
                Url = props[1].Replace("\r","")
                });
            }
        }

        public List<MenuItems> items { get; set; }
    }
}
