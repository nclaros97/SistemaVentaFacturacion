using DATOS;
using LOGICA.LUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace LOGICA.LFacturacion
{
    public class scriptFacturacion
    {
        public static object getDataCliente()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CLIENTE");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static void deleteCliente(int cliId)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@cliId", cliId);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_CLIENTE");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Cliente eliminado satisfactoriamente!");
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

        public static object getGridCategorias()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CATEGORIAS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getGridImpuestos()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_IMPUESTOS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getCbImpuesto()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_CB_IMPUESTOS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static bool deleteCategoria(int v)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@catProductoId", v);
            SqlCmd.Parameters.AddWithValue("accion", "DLT_CATEGORIA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria eliminada!");

            return true;
        }

        public static bool deleteImpuesto(int v)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@impId", v);
            SqlCmd.Parameters.AddWithValue("accion", "DLT_IMPUESTOS");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria eliminada!");

            return true;
        }

        public static bool deleteUnidad(int v)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@uniId", v);
            SqlCmd.Parameters.AddWithValue("accion", "DLT_UNIDADES");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Unidad eliminada!");

            return true;
        }

        public static bool updateCategoria(int v, string text)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@catProductoId", v);
            SqlCmd.Parameters.AddWithValue("@catProductoDescripcion", text);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_CATEGORIA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria: {text} actualizada satisfactoriamente!");

            return true;
        }

        public static bool updateImpuesto(int v, string text, int valor)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@impId", v);
            SqlCmd.Parameters.AddWithValue("@impDescripcion", text);
            SqlCmd.Parameters.AddWithValue("@impValor", valor);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_IMPUESTOS");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria: {text} actualizada satisfactoriamente!");

            return true;
        }

        public static bool updateUnidad(int v, string text)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@uniId", v);
            SqlCmd.Parameters.AddWithValue("@uniDescripcion", text);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_UNIDADES");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Unidad: {text} actualizada satisfactoriamente!");

            return true;
        }

        public static object getGridUnidades()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_UNIDADES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static bool insertCategoria(string text)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@catProductoDescripcion", text);
            SqlCmd.Parameters.AddWithValue("accion", "INS_CATEGORIA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria: {text} Creada satisfactoriamente!");

            return true;
        }

        public static bool insertImpuesto(string text, int valor)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@impDescripcion", text);
            SqlCmd.Parameters.AddWithValue("@impValor", valor);
            SqlCmd.Parameters.AddWithValue("accion", "INS_IMPUESTOS");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Categoria: {text} Creada satisfactoriamente!");

            return true;
        }

        public static bool insertUnidad(string text)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@uniDescripcion", text);
            SqlCmd.Parameters.AddWithValue("accion", "INS_UNIDADES");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Unidad: {text} Creada satisfactoriamente!");

            return true;
        }

        public static bool updateProducto(int id, string producto, string descripcion, float precio, int categoria, int impuesto, int unidades)
        {
            int UserId = validaciones.idUsuarioSesion();
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@proId", id);
            SqlCmd.Parameters.AddWithValue("@proNombre", producto);
            SqlCmd.Parameters.AddWithValue("@proDescripcion", descripcion);
            SqlCmd.Parameters.AddWithValue("@proValor", precio);
            SqlCmd.Parameters.AddWithValue("@catProductoId", categoria);
            SqlCmd.Parameters.AddWithValue("@uniId", unidades);
            SqlCmd.Parameters.AddWithValue("@impId", impuesto);
            SqlCmd.Parameters.AddWithValue("@usuId", UserId);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_PRODUCTO");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Producto: {producto} Actualizado satisfactoriamente!");

            return true;
        }

        public static bool insertProducto(string producto, string descripcion, float precio, int categoria, int impuesto, int unidades)
        {
            int UserId = validaciones.idUsuarioSesion();
            int idProducto = 0;
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@proNombre", producto);
            SqlCmd.Parameters.AddWithValue("@proDescripcion", descripcion);
            SqlCmd.Parameters.AddWithValue("@proValor", precio);
            SqlCmd.Parameters.AddWithValue("@catProductoId", categoria);
            SqlCmd.Parameters.AddWithValue("@uniId", unidades);
            SqlCmd.Parameters.AddWithValue("@impId", impuesto);
            SqlCmd.Parameters.AddWithValue("@usuId", UserId);
            SqlCmd.Parameters.AddWithValue("accion", "INS_PRODUCTOS");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Producto: {producto} Creado satisfactoriamente!");

            idProducto = idNuevoProducto();

            SqlCommand SqlCmd2 = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd2.CommandType = CommandType.StoredProcedure;
            SqlCmd2.Parameters.AddWithValue("@proId", idProducto);
            SqlCmd2.Parameters.AddWithValue("@invFechaCreacion", DateTime.Now);
            SqlCmd2.Parameters.AddWithValue("@invFechaUltimaAct", DateTime.Now);
            SqlCmd2.Parameters.AddWithValue("accion", "INS_INVENTARIO");

            SqlCmd2.ExecuteNonQuery();

            return true;
        }


        private static int idNuevoProducto()
        {
            int id = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "PRODUCTO_ID");
            SqlCmd.Parameters.Add("@idRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = System.Convert.ToInt32(SqlCmd.Parameters["@idRetorno"].Value.ToString());

            return id;
        }

        public static object getCbCategoria()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CATEGORIAS");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getCbUnidades()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_UNIDADES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getDataProductos()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_PRODUCTO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static bool insertCliente(string nombres, string apellidos, string direccion, string telefono, string correo)
        {
            int UserId = validaciones.idUsuarioSesion();
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@cliNombres", nombres);
            SqlCmd.Parameters.AddWithValue("@cliApellidos", apellidos);
            SqlCmd.Parameters.AddWithValue("@cliCorreo", direccion);
            SqlCmd.Parameters.AddWithValue("@cliTelefono", telefono);
            SqlCmd.Parameters.AddWithValue("@cliDireccion", correo);
            SqlCmd.Parameters.AddWithValue("@usuId", UserId);
            SqlCmd.Parameters.AddWithValue("accion", "INS_CLIENTE");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Cliente: {nombres} {apellidos} Creado satisfactoriamente!");

            return true;
        }

        public static void deleteProducto(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@proId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_PRODUCTO");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Cliente eliminado satisfactoriamente!");
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

        public static object getDataInventario()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_INVENTARIO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static bool updateCliente(int cliId, string nombres, string apellidos, string direccion, string telefono, string correo)
        {
            int UserId = validaciones.idUsuarioSesion();
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@cliId", cliId);
            SqlCmd.Parameters.AddWithValue("@cliNombres", nombres);
            SqlCmd.Parameters.AddWithValue("@cliApellidos", apellidos);
            SqlCmd.Parameters.AddWithValue("@cliCorreo", direccion);
            SqlCmd.Parameters.AddWithValue("@cliTelefono", telefono);
            SqlCmd.Parameters.AddWithValue("@cliDireccion", correo);
            SqlCmd.Parameters.AddWithValue("@usuId", UserId);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_CLIENTE");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Cliente: {nombres} {apellidos} Actualizado satisfactoriamente!");

            return true;
        }
    }
}
