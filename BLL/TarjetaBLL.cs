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

        public Tarjeta GetTarjetaByWriting(string writing)
        {
            return transaction.consultTarjetaByWriting(writing);
        }

        public Tarjeta GetTarjetaByKanji( string kanji)
        {
            return transaction.consultTarjetaByKanji(kanji);
        }

        public Tarjeta GetTarjetaById(int id)
        {
            return transaction.consultTarjetaById(id);
        }
        #endregion


    }
}
