using DAL;
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
        public IEnumerable<Tarjeta> GetAllTarjetas()
        {
            return transaction.consultAllTarjetas().OrderBy(o => o.significado).AsEnumerable();
        }
        public List<Tarjeta> GetTarjetaByMeaning(string meaning)
        {
            return transaction.consultTarjetaByMeaning(meaning);
        }        

        public List<Tarjeta> GetTarjetaByWriting(string writing)
        {
            return transaction.consultTarjetaByWriting(writing);
        }

        public List<Tarjeta> GetTarjetaByKanji(string kanji)
        {
            return transaction.consultTarjetaByKanji(kanji);
        }

        public List<Tarjeta> GetTarjetaById(int id)
        {
            return transaction.consultTarjetaById(id);
        }

        public List<Tarjeta> GetTarjetaByAny(string element)
        {
            return transaction.consultTarjetaByAny(element);
        }
        #endregion


    }
}
