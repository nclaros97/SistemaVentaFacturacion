using DATOS;
using LOGICA.LUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace LOGICA.LContabilidad
{
    public class scriptsContabilidad
    {
        public static DataTable getGrid()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWPartidasContables", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_PARTIDAS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR SELECT_GRID_PARTIDAS: \n {ex.ToString()}");
            }
            return data;
        }

        public static DataTable getCuenta(string ctaId)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();

            SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWPartidasContables", conexion_db.conexion);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CUENTA_ID");
            sqlDA.SelectCommand.Parameters.AddWithValue("@ctaId", ctaId);

            sqlDA.Fill(data);

            return data;
        }

        public static DataTable getPartidaDetalleData(string text)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWPartidasContables", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_DETALLE_PARTIDAS");
                sqlDA.SelectCommand.Parameters.AddWithValue("@parId", text);

                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR SELECT_GRID_PARTIDAS: \n {ex.ToString()}");
            }


            return data;
        }

        public static object getGridCuentas()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWPartidasContables", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CUENTAS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR SELECT_GRID_PARTIDAS: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getGridTipoCuentas()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWPartidasContables", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_TIPO_CUENTAS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR SELECT_GRID_TIPO_CUENTAS: \n {ex.ToString()}");
            }
            return data;
        }

        public static void deleteTipoCuenta(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@claCtaId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_TIPO_CUENTA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Tipo Cuenta eliminada satisfactoriamente!");
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Mensaje: " + ex.Errors[i].Message + "\n" +
                        "Linea: " + ex.Errors[i].LineNumber + "\n" +
                        "Fuente: " + ex.Errors[i].Source + "\n" +
                        "Procedimiento: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        public static void updateTipoCuenta(string text, int v)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@claCtaDescripcion", text);
            SqlCmd.Parameters.AddWithValue("@claCtaId", v);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_TIPO_CUENTA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Tipo Cuenta actualizado satisfactoriamente!");
        }

        public static void insertTipoCuenta(string text)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@claCtaDescripcion", text);
            SqlCmd.Parameters.AddWithValue("accion", "INS_TIPO_CUENTA");

            SqlCmd.ExecuteNonQuery();
        }

        public static void deleteCuenta(string v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ctaId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_CUENTA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Cuenta eliminada satisfactoriamente!");
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Mensaje: " + ex.Errors[i].Message + "\n" +
                        "Linea: " + ex.Errors[i].LineNumber + "\n" +
                        "Fuente: " + ex.Errors[i].Source + "\n" +
                        "Procedimiento: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        public static void updateCuenta(string descrip, string id, string tipoCTA)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ctaId", id);
            SqlCmd.Parameters.AddWithValue("@ctaDescripcion", descrip);
            SqlCmd.Parameters.AddWithValue("@claCtaId", tipoCTA);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_CUENTA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Cuenta actualizado satisfactoriamente!");
        }

        public static void insertCuenta(string descrip, string id, string val)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ctaId", id);
            SqlCmd.Parameters.AddWithValue("@ctaDescripcion", descrip);
            SqlCmd.Parameters.AddWithValue("@claCtaId", val);
            SqlCmd.Parameters.AddWithValue("accion", "INS_CUENTA");

            SqlCmd.ExecuteNonQuery();
        }

        public static void deletePartida(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@parId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_PARTIDA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Partida eliminada satisfactoriamente!");
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Mensaje: " + ex.Errors[i].Message + "\n" +
                        "Linea: " + ex.Errors[i].LineNumber + "\n" +
                        "Fuente: " + ex.Errors[i].Source + "\n" +
                        "Procedimiento: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        public static void deleteDetallePartida(string v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@parConDetId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_DETALLE_PARTIDA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Detalle Partida eliminada satisfactoriamente!");
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Mensaje: " + ex.Errors[i].Message + "\n" +
                        "Linea: " + ex.Errors[i].LineNumber + "\n" +
                        "Fuente: " + ex.Errors[i].Source + "\n" +
                        "Procedimiento: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        public static void updatePartida(int idPartida, string detalle, DateTime fecha)
        {
            int userId = 0;
            userId = validaciones.idUsuarioSesion();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@parDescripcion", detalle);
            SqlCmd.Parameters.AddWithValue("@parFecha", fecha);
            SqlCmd.Parameters.AddWithValue("@UserId", userId);
            SqlCmd.Parameters.AddWithValue("@parId", idPartida);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_PARTIDA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Partida actualizado satisfactoriamente!");
        }

        public static bool insertPartidaYDetalle(string descPartida, DateTime fecha, DataGridView dg)
        {
            bool cuadra = false;
            float totalDebe = 0, totalHaber = 0;

            for (int i = 0; i < dg.Rows.Count -1; i++)
            {
                
                totalDebe += float.Parse(dg.Rows[i].Cells[3].Value.ToString());
                totalHaber += float.Parse(dg.Rows[i].Cells[4].Value.ToString());

            }

            if(totalDebe == totalHaber)
            {
                cuadra = true;
            }

            if (cuadra)
            {
                int userId = 0;
                int idPartida = 0;
                userId = validaciones.idUsuarioSesion();
                conexion_db.getConnection();
                SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@parDescripcion", descPartida);
                SqlCmd.Parameters.AddWithValue("@parFecha", fecha);
                SqlCmd.Parameters.AddWithValue("@parConDetDebe", userId);
                SqlCmd.Parameters.AddWithValue("accion", "INS_PARTIDA");

                SqlCmd.ExecuteNonQuery();

                idPartida = GetIdPartida();

                for (int i = 0; i < dg.Rows.Count - 1; i++)
                {

                    insertDetallePartida(idPartida, dg.Rows[i].Cells[0].Value.ToString(), float.Parse(dg.Rows[i].Cells[3].Value.ToString()), float.Parse(dg.Rows[i].Cells[4].Value.ToString()));
                }


                MessageBox.Show($"Partida Creada satisfactoriamente!");
            }
            else
            {
                MessageBox.Show($"Las cuentas no cuadran verifique!!");
                return false;
            }
            return true;
        }

        private static void insertDetallePartida(int partId, string ctaId, float debe, float haber)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@parId", partId);
            SqlCmd.Parameters.AddWithValue("@ctaId", ctaId);
            SqlCmd.Parameters.AddWithValue("@parConDetDebe", debe);
            SqlCmd.Parameters.AddWithValue("@parConDetHaber", haber);
            SqlCmd.Parameters.AddWithValue("accion", "INS_DETALLE_PARTIDA");

            SqlCmd.ExecuteNonQuery();
        }

        private static int GetIdPartida()
        {
            int id = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "SELECT_LAST_ID_PARTIDA");
            SqlCmd.Parameters.Add("@IdRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = System.Convert.ToInt32(SqlCmd.Parameters["@IdRetorno"].Value.ToString());

            return id;
        }

        public static void updateDetallePartida(int detalleId, string cuentaId, int partId, float debe, float haber)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWPartidasContables", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@parId", partId);
            SqlCmd.Parameters.AddWithValue("@ctaId", cuentaId);
            SqlCmd.Parameters.AddWithValue("@parConDetDebe", debe);
            SqlCmd.Parameters.AddWithValue("@parConDetHaber", haber);
            SqlCmd.Parameters.AddWithValue("@parConDetId", detalleId);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_DETALLE_PARTIDA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Detalle de partida actualizado satisfactoriamente!");
        }
    }
}
