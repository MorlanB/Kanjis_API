using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class TarjetaBLL
    {
        private Transaction transaction;

        #region Constructor
        public TarjetaBLL()
        {
            transaction = new Transaction();
        }
        #endregion

        #region Consultas
        //public IEnumerable<Tarjeta> GetAllTarjetas()
        //{
        //    return transaction.consultAllTarjetas().OrderBy(o => o.significado).AsEnumerable();
        //}
        //public List<Tarjeta> GetTarjetaByMeaning(string meaning)
        //{
        //    return transaction.consultTarjetaByMeaning(meaning);
        //}        

        //public List<Tarjeta> GetTarjetaByWriting(string writing)
        //{
        //    return transaction.consultTarjetaByWriting(writing);
        //}

        //public List<Tarjeta> GetTarjetaByKanji(string kanji)
        //{
        //    return transaction.consultTarjetaByKanji(kanji);
        //}

        //public List<Tarjeta> GetTarjetaById(int id)
        //{
        //    return transaction.consultTarjetaById(id);
        //}

        public List<Tarjeta> GetTarjetaByAny(string element)
        {
            Tarjeta.Columns columns = new Tarjeta.Columns();
            WhereCond.Operator op = new WhereCond.Operator();
            WhereCond.Compare compare = new WhereCond.Compare();
            Dictionary<string, WhereCond> conditions = new Dictionary<string, WhereCond>()
            {
                ["id"] = new WhereCond(element, compare.EQUALS),
                ["kanji"] = new WhereCond(element, compare.LIKE, op.OR),
                ["lectura"] = new WhereCond(element, compare.LIKE, op.OR),
                ["significado"] = new WhereCond(element, compare.LIKE, op.OR),
                ["notas"] = new WhereCond(element, compare.LIKE, op.OR),
                ["diccionario"] = new WhereCond(element, compare.LIKE, op.OR)
            };
            return transaction.consultTarjeta(conditions, columns.ID, columns.KANJI, columns.LECTURA, columns.NOTAS, columns.SIGNIFICADO, columns.DICCIONARIO);
        }

        public IEnumerable<Tarjeta> getAllTarjetas()
        {
            Tarjeta.Columns columns = new Tarjeta.Columns();
            return transaction.getAllTarjetas(null, columns.ID, columns.KANJI, columns.LECTURA, columns.NOTAS, columns.SIGNIFICADO, columns.DICCIONARIO).AsEnumerable();
            //List<string> select = new List<string>();
            //select.Add("*");
            //return transaction.sqlQuery("Tarjeta", select, typeof(Tarjeta))
            //    .Select(s => (Tarjeta)s)
            //    .OrderBy(o => o.significado).AsEnumerable();
        }

        public bool insertTarjeta(string kanji, string lectura, string significado, string notas, string diccionario)
        {
            Tarjeta newTarjeta = new Tarjeta(kanji, lectura, significado, notas, diccionario);
            return transaction.insertTarjeta(newTarjeta);
        }
        
        #endregion

    }
}
