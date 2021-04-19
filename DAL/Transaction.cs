using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Transaction
    {
        #region Constructors
        public Transaction() { }
        #endregion

        #region Inserts
        public int insertTarjeta(Tarjeta tarjeta)
        {
            return 0;
        }
        #endregion

        #region Removes
        public bool removeTarjeta(int id)
        {
            return false;
        }
        #endregion

        #region Consults
        public List<Tarjeta> consultAllTarjetas()
        {
            return JsonConvert.DeserializeObject<List<Tarjeta>>(readJson("Tarjetas"));
        }

        public List<Tarjeta> consultTarjetaByMeaning(string meaning)
        {
            return consultAllTarjetas().FindAll(f => f.significado.Contains(meaning));
        }

        public Tarjeta consultTarjetaByWriting(string writing)
        {
            return consultAllTarjetas().Find(f => f.lectura.Contains(writing));
        }

        public Tarjeta consultTarjetaByKanji(string kanji)
        {
            return consultAllTarjetas().Find(f => f.kanji.Contains(kanji));
        }

        public Tarjeta consultTarjetaById(int id)
        {
            return consultAllTarjetas().Find(f => f.id == id);
        }

        public Menu consultMenuFromTxt()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\aranz\source\repos\DAL\Data\MenuData.txt");
            return new Menu(text);
        }

        public Menu consultMenuFromJson()
        {
            return JsonConvert.DeserializeObject<Menu>(readJson("MenuData"));
        }

        #endregion

        #region Updates
        public bool updateTarjeta(Tarjeta tarjeta)
        {
            return false;
        }
        #endregion

        #region utils
        private String readJson(string doc)
        {
            return System.IO.File.ReadAllText(@String.Format("C:\\Users\\aranz\\source\\repos\\DAL\\Data\\{0}.json", doc));
        }
        #endregion

    }
}
