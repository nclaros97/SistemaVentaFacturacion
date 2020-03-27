using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DATOS
{
    public class conexion_db
    {
        public static SqlConnection conexion = null;
        public static SqlConnection getConnection()
        {
            string servidor = "DESKTOP-LHQFM55"; //Reemplazar por el de uds
            string database = "supermercados";
            string usuario = "admin";
            string pssw = "admin@2020";
            try
            {
                conexion = new SqlConnection($"Data Source={servidor};Integrated " +
                $"Security=False;Initial Catalog={database};User Id={usuario};Password={pssw};");
                conexion.Open();
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error \n {ex.Message.ToString()}");
            }
            return conexion;
        }
    }
}
