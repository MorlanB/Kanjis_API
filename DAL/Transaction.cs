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
            return consultAllTarjetas().FindAll(f => f.significado.ToLower().Contains(meaning));
        }

        public List<Tarjeta> consultTarjetaByWriting(string writing)
        {
            return consultAllTarjetas().FindAll(f => f.lectura.ToLower().Contains(writing));
        }

        public List<Tarjeta> consultTarjetaByKanji(string kanji)
        {
            return consultAllTarjetas().FindAll(f => f.kanji.ToLower().Contains(kanji));
        }

        public List<Tarjeta> consultTarjetaById(int id)
        {
            return consultAllTarjetas().FindAll(f => f.id == id);
        }

        public List<Tarjeta> consultTarjetaByAny(string element)
        {
            return consultAllTarjetas().FindAll(f =>
            f.significado.ToLower().Contains(element)||
            f.lectura.ToLower().Contains(element)||
            f.kanji.ToLower().Contains(element)||
            f.id.ToString().Equals(element));
        }

        public Menu consultMenuFromTxt()
        {
            try
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\aranz\source\repos\DAL\Data\MenuData.txt");
                return new Menu(text);
            }
            catch
            {
                return consultMenuFromJson();
            }
            
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
