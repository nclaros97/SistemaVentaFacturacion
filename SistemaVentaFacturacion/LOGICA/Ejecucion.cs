using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace LOGICA
{
    public class Ejecucion
    {
        public static List<String> obtenerConsulta(String query)
        {
            List<string> datos = new List<string>();
            SqlDataReader dr = null;
            try
            {
                SqlCommand da = new SqlCommand(query, conexion_db.conexion);
                dr = da.ExecuteReader();
                while (dr.Read())
                {
                    datos.Add(Convert.ToString(dr["usuNick"].ToString()));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error query \n {ex.Message.ToString()}");
            }
            return datos;
        }
    }
}
