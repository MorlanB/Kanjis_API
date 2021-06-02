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
        public string diccionario { get; set; }

        public Tarjeta(string kanji, string lectura, string significado, string notas, string diccionario, int id = 0) 
        {
            this.id = id;
            this.kanji = kanji;
            this.lectura = lectura;
            this.significado = significado;
            this.notas = notas;
            this.diccionario = diccionario;
        }

        public Columns columns = new Columns();

        public class Columns
        {
            public String[] ToArray()
            {
                return new string[] { this.ID, this.KANJI, this.LECTURA, this.SIGNIFICADO, this.NOTAS, this.DICCIONARIO };
            }

            public string ID = "id";
            public string KANJI = "kanji";
            public string LECTURA = "lectura";
            public string SIGNIFICADO = "significado";
            public string NOTAS = "notas";
            public string DICCIONARIO = "diccionario";
        }

    }
}
