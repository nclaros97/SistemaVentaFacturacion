using DATOS;
using LOGICA.LContabilidad;
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

        public static DataTable getDataClienteId(int cliId)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@cliId", cliId);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_CLIENTE_ID");
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

        public static DataTable getFacturaDetalleData(int v)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@facId", v);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_DETALLE_FACTURA_PARAMETRO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static DataTable getCompraDetalleData(int id)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@comProId", id);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_DETALLE_COMPRA_PARAMETRO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
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

        public static void deleteFactura(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@facId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_FACTURA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Factura eliminada satisfactoriamente!");
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

        public static DataTable getProducto(int v)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();

            SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_PRODUCTO");
            sqlDA.SelectCommand.Parameters.AddWithValue("@proId", v);

            sqlDA.Fill(data);

            return data;
        }

        public static object getGridFacturas()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_FACTURA");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static object getGridCompras()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWFACTUACION", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_COMPRA");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
            return data;
        }

        public static void deleteCompra(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@comProId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_COMPRA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Compra eliminada satisfactoriamente!");
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

        public static bool updateDetalleCompra(int idDetalle, int idCompra, int idProducto, float cantidad)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@comProId", idCompra);
            SqlCmd.Parameters.AddWithValue("@proId", idProducto);
            SqlCmd.Parameters.AddWithValue("@detComProCantidad", cantidad);
            SqlCmd.Parameters.AddWithValue("@detComProId", idDetalle);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_DETALLE_COMPRA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"ACTUALIZADO");

            return true;
        }

        public static bool updateDetalleFactura(int idDetalle, int idFactura, int idProducto, float cantidad)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@facId", idFactura);
            SqlCmd.Parameters.AddWithValue("@proId", idProducto);
            SqlCmd.Parameters.AddWithValue("@detFacCantidad", cantidad);
            SqlCmd.Parameters.AddWithValue("@detFacId", idDetalle);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_DETALLE_FACTURA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"ACTUALIZADO");

            return true;
        }

        public static void deleteDetalleCompra(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@detComProId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_DETALLE_COMPRA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"ELIMINADO");
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

        public static void deleteDetalleFactura(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@detFacId", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_DETALLE_FACTURA");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"ELIMINADO");
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

        public static void updateCompra(int idCompra, string descripcion, DateTime fecha, float total)
        {
            int userId = 0;
            userId = validaciones.idUsuarioSesion();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@comProFecha", fecha);
            SqlCmd.Parameters.AddWithValue("@usuId", userId);
            SqlCmd.Parameters.AddWithValue("@comProMontoTotal", total);
            SqlCmd.Parameters.AddWithValue("@comProDescripcion", descripcion);
            SqlCmd.Parameters.AddWithValue("@comProId", idCompra);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_COMPRA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Compra actualizado satisfactoriamente!");
        }

        public static void updateFactura(int idFactura, string idCliente, DateTime fecha, float total)
        {
            int userId = 0;
            userId = validaciones.idUsuarioSesion();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@facFecha", fecha);
            SqlCmd.Parameters.AddWithValue("@usuId", userId);
            SqlCmd.Parameters.AddWithValue("@facMontoTotal", total);
            SqlCmd.Parameters.AddWithValue("@cliId", idCliente);
            SqlCmd.Parameters.AddWithValue("@facId", idFactura);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_FACTURA");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Factura actualizado satisfactoriamente!");
        }

        public static bool insertCompraYDetalle(DateTime fecha, string descripcion, DataGridView dg)
        {
            float total = 0;
            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {

                total += float.Parse(dg.Rows[i].Cells[6].Value.ToString());

            }
            int userId = 0;
            int idCompra = 0;
            userId = validaciones.idUsuarioSesion();
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@comProFecha", fecha);
            SqlCmd.Parameters.AddWithValue("@usuId", userId);
            SqlCmd.Parameters.AddWithValue("@comProMontoTotal", total);
            SqlCmd.Parameters.AddWithValue("@comProDescripcion", descripcion);
            SqlCmd.Parameters.AddWithValue("accion", "INS_COMPRA");

            SqlCmd.ExecuteNonQuery();

            idCompra = GetIdCompra();

            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {

                insertDetalleCompra(idCompra, int.Parse(dg.Rows[i].Cells[0].Value.ToString()), float.Parse(dg.Rows[i].Cells[5].Value.ToString()));
            }
            crearPartida(total,"Adquisicion de productos para inventariado", "ADD_INVENTARIO");

                MessageBox.Show($"Compra Creada satisfactoriamente!");

            return true;
        }

        private static void crearPartida(float total, string descripPartida, string tipo)
        {
            if (tipo.Equals("ADD_INVENTARIO"))
            {
                DataGridView grid = new DataGridView();
                grid.Columns.Add("idCuenta", "ID CUENTA");
                grid.Columns.Add("x", "X");
                grid.Columns.Add("y", "Y");
                grid.Columns.Add("debe", "DEBE");
                grid.Columns.Add("haber", "HABER");

                grid.Rows.Add("06", "", "", total, 0);
                grid.Rows.Add("04", "", "", 0, total);

                scriptsContabilidad.insertPartidaYDetalle(descripPartida, DateTime.Now, grid);
            }
            else
            {
                DataGridView grid = new DataGridView();
                grid.Columns.Add("idCuenta", "ID CUENTA");
                grid.Columns.Add("x", "X");
                grid.Columns.Add("y", "Y");
                grid.Columns.Add("debe", "DEBE");
                grid.Columns.Add("haber", "HABER");

                grid.Rows.Add("01", "", "", total, 0);
                grid.Rows.Add("03", "", "", 0, total);

                scriptsContabilidad.insertPartidaYDetalle(descripPartida, DateTime.Now, grid);
            }
        }

        private static void insertDetalleCompra(int idCompra, int idProducto, float cantiad)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@comProId", idCompra);
            SqlCmd.Parameters.AddWithValue("@proId", idProducto);
            SqlCmd.Parameters.AddWithValue("@detComProCantidad", cantiad);
            SqlCmd.Parameters.AddWithValue("accion", "INS_DETALLE_COMPRA");

            SqlCmd.ExecuteNonQuery();

            float StockActual = GetStockActual(idProducto);
            updateStockProducto(StockActual, cantiad, idProducto,"COMPRA");

        }

        private static void updateStockProducto(float stockAc, float cant, int idPro, string acc)
        {
            float nuevoStock = 0;
            if (acc.Equals("COMPRA"))
            {
              nuevoStock = stockAc + cant;
            }
            else
            {
              nuevoStock = stockAc - cant;
            }

            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@invFechaUltimaAct", DateTime.Now);
            SqlCmd.Parameters.AddWithValue("@invStock", nuevoStock);
            SqlCmd.Parameters.AddWithValue("@proId", idPro);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_INVENTARIO_STOCK");

            SqlCmd.ExecuteNonQuery();
        }
        private static void insertDetalleFactura(int idFactura, int idProducto, float cantiad)
        {
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@facId", idFactura);
            SqlCmd.Parameters.AddWithValue("@proId", idProducto);
            SqlCmd.Parameters.AddWithValue("@detFacCantidad", cantiad);
            SqlCmd.Parameters.AddWithValue("accion", "INS_DETALLE_FACTURA");

            SqlCmd.ExecuteNonQuery();

            float StockActual = GetStockActual(idProducto);
            updateStockProducto(StockActual, cantiad, idProducto, "VENTA");
        }

        private static int GetIdCompra()
        {
            int id = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "COMPRA_ID");
            SqlCmd.Parameters.Add("@IdRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = Convert.ToInt32(SqlCmd.Parameters["@IdRetorno"].Value.ToString());

            return id;
        }

        private static float GetStockActual(int idProd)
        {
            float stock = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "STOCK_INV");
            SqlCmd.Parameters.AddWithValue("@proId", idProd);
            SqlCmd.Parameters.Add("@RetornarStockActual", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            stock = Convert.ToInt32(SqlCmd.Parameters["@RetornarStockActual"].Value.ToString());

            return stock;
        }

        private static int GetIdFactura()
        {
            int id = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "FACTURA_ID");
            SqlCmd.Parameters.Add("@IdRetorno", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = Convert.ToInt32(SqlCmd.Parameters["@IdRetorno"].Value.ToString());

            return id;
        }

        public static bool insertFacturaYDetalle(DateTime fecha, string idCliente, DataGridView dg)
        {
            float total = 0;
            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {

                total += float.Parse(dg.Rows[i].Cells[6].Value.ToString());

            }
            int userId = 0;
            int idFactura = 0;
            userId = validaciones.idUsuarioSesion();
            conexion_db.getConnection();
            SqlCommand SqlCmd = new SqlCommand("dbo.WWFACTUACION", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@facFecha", fecha);
            SqlCmd.Parameters.AddWithValue("@usuId", userId);
            SqlCmd.Parameters.AddWithValue("@facMontoTotal", total);
            SqlCmd.Parameters.AddWithValue("@cliId", idCliente);
            SqlCmd.Parameters.AddWithValue("accion", "INS_FACTURA");

            SqlCmd.ExecuteNonQuery();

            idFactura = GetIdFactura();

            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {

                insertDetalleFactura(idFactura, int.Parse(dg.Rows[i].Cells[0].Value.ToString()), float.Parse(dg.Rows[i].Cells[5].Value.ToString()));
            }
            crearPartida(total, "Venta de productos", "FACTURACION");
            MessageBox.Show($"Factura Creada satisfactoriamente!");

            return true;
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
