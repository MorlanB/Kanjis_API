using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

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

        public Menu getMenuTxt()
        {
            return transaction.consultMenuFromTxt();
        }
        public Menu getMenuJson()
        {
            return transaction.consultMenuFromJson();
        }
    }
}
