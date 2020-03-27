using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace LOGICA.LUsuarios
{
    public class scriptsUsuarios
    {
        public scriptsUsuarios()
        {
            
        }
        public static DataTable getGrid()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_USER");
                sqlDA.Fill(data);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable getGridRoles(int usuId)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("idUsuario", usuId);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_ROLES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static void updateFuncion(string text, int id)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@funDescripcion", text);
            SqlCmd.Parameters.AddWithValue("@idFuncion", id);
            SqlCmd.Parameters.AddWithValue("accion", "UPD_FUNCION");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Funcion: {text} Actualizado satisfactoriamente!");
        }

        public static string getCurrentFuncionId()
        {
            string id = "";

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "SELECT_LAST_ID_FUNCION");
            SqlCmd.Parameters.Add("@contadorFunciones", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = (System.Convert.ToInt32(SqlCmd.Parameters["@contadorFunciones"].Value.ToString())+1).ToString();

            return id;
        }

        public static void deleteFuncion(int v)
        {
            conexion_db.getConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@idFuncion", v);
                SqlCmd.Parameters.AddWithValue("accion", "DLT_FUNCION");
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show($"Funcion eliminado satisfactoriamente!");
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

        public static DataTable getGridFuncionesRoles()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_FUNCIONES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable getGridFuncionesRolesBusqueda(string texto)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@parametro", texto);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_FUNCIONES_PARAMETRO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static void insertFuncion(string funcion)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@funDescripcion", funcion);
            SqlCmd.Parameters.AddWithValue("accion", "INS_FUNCION");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Funcion: {funcion} Creado satisfactoriamente!");
        }

        public static void insertRol(string rol)
        {
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@rolDescripcion", rol);
            SqlCmd.Parameters.AddWithValue("accion", "INS_ROL");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Rol: {rol} Creado satisfactoriamente!");
        }

        public static DataTable getGridFuncionesRoles(int rolI)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@rolId", rolI);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_FUNCIONES_USER");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable getGridFuncionesRolesPermisos(int funcionId)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("@idFuncion", funcionId);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_PERMISOS_FUNCIONES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable getGridRolesBusqueda(int usuId, string texto)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("idUsuario", usuId);
                sqlDA.SelectCommand.Parameters.AddWithValue("@parametro", texto);
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_ROLES_PARAMETRO");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable cbRoles()
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "CB_ROLES");
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static DataTable getGridBusqueda(string texto)
        {
            conexion_db.getConnection();
            DataTable data = new DataTable();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter("dbo.WWUsuarios", conexion_db.conexion);
                sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDA.SelectCommand.Parameters.AddWithValue("accion", "SELECT_GRID_USER_PARAMETRO");
                sqlDA.SelectCommand.Parameters.AddWithValue("parametro", texto);
                sqlDA.Fill(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
            return data;
        }

        public static bool insertUsuario(string nick, string nombres, string apellidos, string email, string telefono,
            string psw, string pswconfirm)
        {
            conexion_db.getConnection();
            if (psw.Equals(pswconfirm))
            {
                if (validaciones.verificarPassw(psw,false))
                {
                    if (validaciones.verificarEmail(email))
                    {
                        if (nick.Equals("") || nombres.Equals("") || apellidos.Equals("")
                            || telefono.Equals(""))
                        {
                            MessageBox.Show("No se permite dejar campos vacios");
                            return false;
                        }
                        else
                        {
                            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
                            SqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlCmd.Parameters.AddWithValue("usuNick", nick);
                            SqlCmd.Parameters.AddWithValue("usuNombres", nombres);
                            SqlCmd.Parameters.AddWithValue("usuApellidos", apellidos);
                            SqlCmd.Parameters.AddWithValue("usuCorreo", email);
                            SqlCmd.Parameters.AddWithValue("usuTelefono", telefono);
                            SqlCmd.Parameters.AddWithValue("usuPassw", validaciones.EncriptarPsw(psw));
                            SqlCmd.Parameters.AddWithValue("accion", "INS");

                            SqlCmd.ExecuteNonQuery();
                            MessageBox.Show($"Usuario: {nick} Creado satisfactoriamente!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email en formato incorrecto");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña debe de contener al menos 6 letras 2 numeros y 1 caracter especial");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return false;
            }

            return true;
        }

        public static bool updateUsuario(int id,string nick, string nombres, string apellidos, string email, string telefono,
            string psw, string pswconfirm)
        {
            conexion_db.getConnection();
            if (psw.Equals(pswconfirm) || (psw.Equals("") || pswconfirm.Equals("")))
            {
                if (validaciones.verificarPassw(psw,true))
                {
                    if (validaciones.verificarEmail(email))
                    {
                        if (nick.Equals("") || nombres.Equals("") || apellidos.Equals("")
                            || telefono.Equals(""))
                        {
                            MessageBox.Show("No se permite dejar campos vacios");
                            return false;
                        }
                        else
                        {
                            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
                            SqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlCmd.Parameters.AddWithValue("usuNick", nick);
                            SqlCmd.Parameters.AddWithValue("usuNombres", nombres);
                            SqlCmd.Parameters.AddWithValue("usuApellidos", apellidos);
                            SqlCmd.Parameters.AddWithValue("usuCorreo", email);
                            SqlCmd.Parameters.AddWithValue("usuTelefono", telefono);
                            SqlCmd.Parameters.AddWithValue("idUsuario", id);
                            if (psw.Equals(""))
                            {
                                SqlCmd.Parameters.AddWithValue("usuPassw", "");
                            }
                            else
                            {
                                SqlCmd.Parameters.AddWithValue("usuPassw", validaciones.EncriptarPsw(psw));
                            }
                            SqlCmd.Parameters.AddWithValue("accion", "UPD");

                            SqlCmd.ExecuteNonQuery();
                            MessageBox.Show($"Usuario: {nick} Actualizado satisfactoriamente!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email en formato incorrecto");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña debe de contener al menos 6 letras 2 numeros y 1 caracter especial");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return false;
            }

            return true;
        }

        public static bool deleteUsuario(int id)
        {
            conexion_db.getConnection();
       
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("idUsuario", id);
            SqlCmd.Parameters.AddWithValue("accion", "DLT");
            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Usuario eliminado satisfactoriamente!");
            return true;
        }

        public static bool deleteRolUsuario(int id)
        {
            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@idRoleUser", id);
            SqlCmd.Parameters.AddWithValue("accion", "DLT_ROL_USER");
            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Rol de usuario eliminado satisfactoriamente!");
            return true;
        }

        public static int getLastId()
        {
            int id = 0;

            conexion_db.getConnection();

            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "SELECT_LAST_ID_USER");
            SqlCmd.Parameters.Add("@returnId", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            id = System.Convert.ToInt32(SqlCmd.Parameters["@returnId"].Value.ToString());
            return id + 1;
        }

        public static int verificarRoleUser(int userId, int rolId)
        {
            int cantidad = 0;

            conexion_db.getConnection();
            
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("accion", "VERIFICAR_EXISTENCIA_ROLE_USUARIO");
            SqlCmd.Parameters.AddWithValue("@idUsuario", userId);
            SqlCmd.Parameters.AddWithValue("@rolId", rolId);
            SqlCmd.Parameters.Add("@contadorRolesUser", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            cantidad = System.Convert.ToInt32(SqlCmd.Parameters["@contadorRolesUser"].Value.ToString());
            return cantidad;
        }

        public static bool setUserRole(int rol, int userId, string userNick)
        {
            conexion_db.getConnection();
           
            SqlCommand SqlCmd = new SqlCommand("dbo.WWUsuarios", conexion_db.conexion);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@rolId", rol);
            SqlCmd.Parameters.AddWithValue("@usuNick", userNick);
            SqlCmd.Parameters.AddWithValue("@idUsuario", userId);
            SqlCmd.Parameters.AddWithValue("accion", "INS_ROL_USER");

            SqlCmd.ExecuteNonQuery();
            MessageBox.Show($"Rol de usuario añadido satisfactoriamente!");
                        
            return true;
        }
    }
}
