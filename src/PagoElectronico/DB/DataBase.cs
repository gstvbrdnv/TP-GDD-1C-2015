using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PagoElectronico.DB
{
    static class DataBase
    {

        static private string strCon = "Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD1C2015;Persist Security Info=True;User ID=gd;Password=gd2015";
        static private SqlConnection sqlCon = new SqlConnection(strCon);
        static public string schema = "NOLARECURSO.";

        /// <summary>
        /// Ejecuta comando y lo devuelve en un datatable
        /// </summary>
        /// <param name="command">Comando</param>
        /// <returns></returns>
        static public DataTable ExecuteReader(string command)
        {
            if (command.IndexOf("grp_proximoOrden") > -1)
            {

            }
            DataTable dataTable = new DataTable();
            try
            {

                sqlCon.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command, sqlCon);
                dataAdapter.Fill(dataTable);
                dataAdapter.Dispose();

            }
            catch
            {
                throw;
            }
            finally
            {

                sqlCon.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// Ejecuta comando y devuelve un número
        /// </summary>
        /// <param name="command">Comando</param>
        /// <returns></returns>
        static public int ExecuteCardinal(string command)
        {
            SqlDataReader reader = null;
            Int32 temp;

            try
            {
                sqlCon.Open();

                reader = (new SqlCommand(command, sqlCon)).ExecuteReader();
                reader.Read();

                //--Es convert porque hay veces que trae Decimal y el getInt no entiende nada :)
                temp = Convert.ToInt32(reader[0]);

            }
            catch
            {
                throw;
            }
            finally
            {

                sqlCon.Close();
            }
            return temp;
        }

        static public Int64 ExecuteCardinal64(string command)
        {
            SqlDataReader reader = null;
            Int64 temp;

            try
            {
                sqlCon.Open();

                reader = (new SqlCommand(command, sqlCon)).ExecuteReader();
                reader.Read();

                //--Es convert porque hay veces que trae Decimal y el getInt no entiende nada :)
                temp = Convert.ToInt64(reader[0]);

            }
            catch
            {
                throw;
            }
            finally
            {

                sqlCon.Close();
            }
            return temp;
        }

        /// <summary>
        /// Ejecuta comando y devuelve la cantidad de filas afectadas
        /// </summary>
        /// <param name="command">Comando</param>
        /// <returns></returns>
        static public int ExecuteNonQuery(string command)
        {
            int temp;

            try
            {
                sqlCon.Open();

                temp = (new SqlCommand(command, sqlCon)).ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
            }
            return temp;
        }
    }
}
