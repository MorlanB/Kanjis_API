using System;

namespace DAL
{
    public class Tarjeta
    {
        public Tarjeta(){ }

        public int id { get; set; }
        public string kanji { get; set; }
        public string lectura { get; set; }
        public string significado { get; set; }
        public string notas { get; set; }

    }
}
