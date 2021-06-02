using DAL.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections;

namespace DAL
{
    public class Transaction
    {
        #region Constructors
        public Transaction() { }
        #endregion

        #region Inserts
        public bool insert(string table, String[] columns, Object[] values)
        {
            try
             {
                MySqlConnection conn = new MySqlConnection("server=sql3.freemysqlhosting.net;database=sql3411147;user id=sql3411147;Password=ubqILdYXFd;");
                conn.Open();

                string query = string.Format(
                    "INSERT INTO {0} ({1}) VALUES ({2})",
                    table,
                    string.Join(", ", columns),
                    string.Join(", ", columns.Select(c => string.Format("@{0}", c))));

                MySqlCommand cmd = new MySqlCommand(query, conn);

                for (int i = 0; i < columns.Count(); i++)
                    cmd.Parameters.AddWithValue(columns[i], values[i]);

                cmd.ExecuteNonQuery();

                conn.Close();

                return true;
             }
             catch (MySqlException ex)
             {
                return false;
             }
            
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

        private List<Dictionary<string, object>> sqlQuery(string table, List<string> select, Dictionary<string, WhereCond> whereS = null)
        {
            if (whereS == null)
                whereS = new Dictionary<string, WhereCond>();

            conn.Open();

            string query = string.Format("SELECT {0} FROM {1} {2} {3}",
               string.Join(",", select),
               table,
               whereS.Count > 0 ? "WHERE" : "",//Aquí se construye el Sql Query.
               string.Join(" ",//separa un arreglo con el caracter
               whereS.Select(s => string.Format("{0} {1} {2} @{3}", s.Value.op, s.Key ,s.Value.comparer, s.Key)))
               );

            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Aquí se agregan los valores de los parámetros del where.
            foreach (KeyValuePair<string, WhereCond> where in whereS)
            {
                cmd.Parameters.AddWithValue(@where.Key, where.Value.comparer == where.Value.compare.LIKE ? "%" + where.Value.value + "%" : where.Value.value);
            }

            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);

            //Lista de columnas/Propiedades del objeto
            var columns = ds.Tables[0].Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
            //Crea diccionario con el string de la columna y el valor de la fila
            List<Dictionary<string, object>> result = ds.Tables[0].Rows.Cast<DataRow>().ToList().Select(s =>
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < columns.Count; i++)
                    if (null != s.ItemArray[i])
                        row.Add(columns[i], s.ItemArray[i]);
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


        //public List<Tarjeta> consultTarjetaByAny(string element)
        //{
        //    List<string> select = new List<string>();
        //    select.Add("*");
        //    return sqlQuery("Tarjeta", select, typeof(Tarjeta))
        //        .Select(s=>(Tarjeta)s)
        //        .ToList()
        //        .FindAll(f =>
        //    f.significado.ToLower().Contains(element) ||
        //    f.lectura.ToLower().Contains(element) ||
        //    f.kanji.ToLower().Contains(element) ||
        //    f.id.ToString().Equals(element));
        //}

        public List<Tarjeta> consultTarjeta(Dictionary<string, WhereCond> whereS = null, params string[] select)
        {
            return getAllTarjetas(whereS, select);
            //    .FindAll(f =>
            //f.significado.ToLower().Contains(element) ||
            //f.lectura.ToLower().Contains(element) ||
            //f.kanji.ToLower().Contains(element) ||
            //f.id.ToString().Equals(element));
        }

        //public Menu consultMenuFromJson()
        //{
        //    return JsonConvert.DeserializeObject<Menu>(readJson("MenuData"));
        //}

        #endregion

        #region Updates
        public bool updateTarjeta(Tarjeta tarjeta)
        {
            return false;
        }
        #endregion

        #region Entities

        public List<MenuItems> getMenuItems(Dictionary<string, WhereCond> whereS = null, params string[] select)
        {
            List<Dictionary<string, object>> menuItems = sqlQuery("MenuItems", select.ToList(), whereS);
            MenuItems.Columns columns = new MenuItems().columns;
            List<MenuItems> items = menuItems.Select(s =>
            new MenuItems()
            {
                id = (int) s[columns.ID],
                nombre = s[columns.NOMBRE] == DBNull.Value? "Sin datos" : (string) s[columns.NOMBRE],
                url = s[columns.URL] == DBNull.Value ? "Sin datos" : (string)s[columns.URL],
                icon = s[columns.ICON] == DBNull.Value ? "Sin datos" : (string)s[columns.ICON]
            }).ToList();
            return items;
        }

        public List<Tarjeta> getAllTarjetas(Dictionary<string, WhereCond> whereS = null, params string[] select)
        {
            List<Dictionary<string, object>> tarjetas = sqlQuery("Tarjeta", select.ToList(), whereS);
            Tarjeta.Columns columns = new Tarjeta().columns;
            List<Tarjeta> lTarjetas = tarjetas.Select(s =>
            new Tarjeta()
            {
                id = (int)s[columns.ID],
                kanji = s[columns.KANJI] == DBNull.Value ? "Sin datos" : (string)s[columns.KANJI],
                lectura = s[columns.LECTURA] == DBNull.Value ? "Sin datos" : (string)s[columns.LECTURA],
                significado = s[columns.SIGNIFICADO] == DBNull.Value ? "Sin datos" : (string)s[columns.SIGNIFICADO],
                notas = s[columns.NOTAS] == DBNull.Value ? "Sin datos" : (string)s[columns.NOTAS],
                diccionario = s[columns.DICCIONARIO] == DBNull.Value ? "Sin datos" : (string)s[columns.DICCIONARIO]
            }).ToList();
            return lTarjetas;
        }

        public bool insertTarjeta(Tarjeta tarjeta)
        {
            Tarjeta.Columns columns = new Tarjeta().columns;
            return insert("Tarjeta",
                columns.ToArray(),
                tarjeta.GetType().GetProperties().Select(s => s.GetValue(tarjeta, null)).Where(w => w == null || w.GetType() != typeof(Tarjeta.Columns)).ToArray()
                );
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