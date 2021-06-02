using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class MenuItems
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string icon { get; set; }

        public Columns columns = new Columns();

        public class Columns
        {
            public string ID = "id";
            public string NOMBRE = "nombre";
            public string URL = "url";
            public string ICON = "icon";
        }
    }
}
