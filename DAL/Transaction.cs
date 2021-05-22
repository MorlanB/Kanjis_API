using DAL.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace DAL
{
    public class Transaction
    {
        #region Constructors
        public Transaction() { }
        #endregion

        #region Inserts
        public int insertTarjeta(object data)
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
        //public void sqlQuery()
        //{
        //    MySqlConnection con = new MySqlConnection("server=sql3.freemysqlhosting.net;database=sql3411147;user id=sql3411147;Password=ubqILdYXFd;");
        //    MySqlCommand cmd;
        //    con.Open();
        //    try
        //    {
        //        cmd = con.CreateCommand();
        //        cmd.CommandText = "SELECT * FROM sql3411147.Tarjeta";
        //        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        adapt.Fill(ds);

        //        var columns = ds.Tables[0].Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
        //        List<DataRow> rows = ds.Tables[0].Rows.Cast<DataRow>().ToList();
        //        List<Tarjeta> tarjetas =
        //            ds.Tables[0].Rows.Cast<DataRow>().ToList().Select(s =>
        //                new Tarjeta(
        //                    Convert.ToInt32(s.ItemArray[0]),
        //                    s.ItemArray[1].ToString(),
        //                    s.ItemArray[2].ToString(),
        //                    s.ItemArray[3].ToString(),
        //                    s.ItemArray[4].ToString()
        //                    )).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        MySqlConnection conn = new MySqlConnection("server=sql3.freemysqlhosting.net;database=sql3411147;user id=sql3411147;Password=ubqILdYXFd;");

        public List<object> sqlQuery(string table, List<string> select, Type resultType, Dictionary<string, string> whereS = null)
        {
            if (whereS == null)
                whereS = new Dictionary<string, string>();

            conn.Open();

            string query = string.Format("SELECT {0} FROM {1} {2} {3}",
               string.Join(",", select),
               table,
               whereS.Count > 0 ? "WHERE" : "",
               string.Join(" ", whereS.Select(s => string.Format("{0}=@{1}", s.Key, s.Key)))
               );

            MySqlCommand cmd = new MySqlCommand(query, conn);

            foreach (KeyValuePair<string, string> where in whereS)
            {
                cmd.Parameters.AddWithValue(where.Key, where.Value);
            }

            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            var columns = ds.Tables[0].Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
            var result = ds.Tables[0].Rows.Cast<DataRow>().ToList().Select(s =>
            {
                dynamic row = System.Reflection.Assembly.GetAssembly(resultType).CreateInstance(
                   string.Format("{0}.Models.{1}",
                      this.GetType().Namespace,
                      resultType.Name)
                   );
                for (int i = 0; i < columns.Count; i++)
                    if (null != s.ItemArray[i])
                        row.GetType().GetProperty(columns[i]).SetValue(row, s.ItemArray[i]);
                return row;
            }
            ).ToList();
            conn.Close();
            return result;
        }

        //public List<Tarjeta> consultAllTarjetas()
        //{
        //    return JsonConvert.DeserializeObject<List<Tarjeta>>(readJson("Tarjetas"));
        //}

        //public List<Tarjeta> consultTarjetaByMeaning(string meaning)
        //{
        //    return consultAllTarjetas().FindAll(f => f.significado.ToLower().Contains(meaning));
        //}

        //public List<Tarjeta> consultTarjetaByWriting(string writing)
        //{
        //    return consultAllTarjetas().FindAll(f => f.lectura.ToLower().Contains(writing));
        //}

        //public List<Tarjeta> consultTarjetaByKanji(string kanji)
        //{
        //    return consultAllTarjetas().FindAll(f => f.kanji.ToLower().Contains(kanji));
        //}

        //public List<Tarjeta> consultTarjetaById(int id)
        //{
        //    return consultAllTarjetas().FindAll(f => f.id == id);
        //}


        public List<Tarjeta> consultTarjetaByAny(string element)
        {
            List<string> select = new List<string>();
            select.Add("*");
            return sqlQuery("Tarjeta", select, typeof(Tarjeta))
                .Select(s=>(Tarjeta)s)
                .ToList()
                .FindAll(f =>
            f.significado.ToLower().Contains(element) ||
            f.lectura.ToLower().Contains(element) ||
            f.kanji.ToLower().Contains(element) ||
            f.id.ToString().Equals(element));
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
            try
            {
                return System.IO.File.ReadAllText(@String.Format("C:\\Users\\aranz\\source\\repos\\DAL\\Data\\{0}.json", doc));
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (System.IO.InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        #endregion

    }
}
