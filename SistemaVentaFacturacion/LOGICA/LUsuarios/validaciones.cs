using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LOGICA.LUsuarios
{
    public class validaciones
    {
        private static List<funciones> funcionesG = new List<funciones>();
        private static List<permisos> permisosG = new List<permisos>();

        public static List<funciones> FuncionesG { get => funcionesG; set => funcionesG = value; }
        public static List<permisos> PermisosG { get => permisosG; set => permisosG = value; }

        public static bool verificarPassw(string psw, bool editar)
        {
            if (editar)
            {
                if (psw.Equals(""))
                {
                    return true;
                }
                else
                {
                    //letras de la A a la Z, mayusculas y minusculas
                    Regex letras = new Regex(@"[a-zA-z]{6}");
                    //digitos del 0 al 9
                    Regex numeros = new Regex(@"[0-9]{1}");
                    //cualquier caracter del conjunto
                    Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]{1}");

                    //si no contiene las letras, regresa false
                    if (!letras.IsMatch(psw))
                    {
                        return false;
                    }
                    //si no contiene los numeros, regresa false
                    if (!numeros.IsMatch(psw))
                    {
                        return false;
                    }

                    //si no contiene los caracteres especiales, regresa false
                    if (!caracEsp.IsMatch(psw))
                    {
                        return false;
                    }
                    //si cumple con todo, regresa true
                }
            }
            else
            {
                //letras de la A a la Z, mayusculas y minusculas
                Regex letras = new Regex(@"[a-zA-z]{6}");
                //digitos del 0 al 9
                Regex numeros = new Regex(@"[0-9]{1}");
                //cualquier caracter del conjunto
                Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]{1}");

                //si no contiene las letras, regresa false
                if (!letras.IsMatch(psw))
                {
                    return false;
                }
                //si no contiene los numeros, regresa false
                if (!numeros.IsMatch(psw))
                {
                    return false;
                }

                //si no contiene los caracteres especiales, regresa false
                if (!caracEsp.IsMatch(psw))
                {
                    return false;
                }
                //si cumple con todo, regresa true
            }
            return true;
        }

        public static void seguridad_opcionesListaRolesUser(Control.ControlCollection controls, string name)
        {
            try
            {
                foreach (Control control in controls)
                {
                    if (control is Button)
                    {
                        foreach (var funcion in funcionesG)
                        {
                            if (name.Equals(funcion.NombreFuncion))
                            {
                                foreach (var item in permisosG)
                                {
                                    if (item.Permiso.Equals(control.AccessibleName) && name.Equals(item.NombreFuncion) && item.Nivel)
                                    {
                                        control.Enabled = true;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al habilitar las funciones: \n {ex.ToString()}");
            }
        }
         
        public static void seguridad_opcionesGestionFuncionesRolesPermisos(Control.ControlCollection controlForm)
        {
            string nombreFuncion = "";
            //Recorre todos los objetos del formulario
            foreach (Control item in controlForm)
            {
                //filtro solo groupbox
                if(item is GroupBox)
                {
                    nombreFuncion = item.AccessibleName;
                    //si es groupbox que recorra todos los objetos dentro del groupbox
                    foreach (Control control in item.Controls)
                    {
                        //filtro por Datagrid en cada groupbox
                        if(control is DataGridView)
                        {
                            //filtro cada datagrid total 3 en el formulario
                            if (control.Name.Equals("GridFunciones"))
                            {
                                //Paso el control como DataGridView para recorrerlo
                                DataGridView data = control as DataGridView;
                                for (int i = 0; i < data.Rows.Count -1; i++)
                                {
                                    //recorrer las funciones disponibles del ususario logeado
                                    foreach (var funcion1 in funcionesG)
                                    {
                                       
                                        //recorrer los permisos de las funciones
                                        if (funcion1.NombreFuncion.Equals(nombreFuncion))
                                        {
                                            foreach (var permisos in permisosG)
                                            {
                                                if (permisos.Permiso.Equals("Editar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[0].ReadOnly = false;
                                                }
                                                if (permisos.Permiso.Equals("Eliminar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[1].ReadOnly = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (control.Name.Equals("GridRolFuncion"))
                            {
                                DataGridView data = control as DataGridView;
                                for (int i = 0; i < data.Rows.Count -1; i++)
                                {
                                    if (data.Rows[i].Cells.Count > 1)
                                    {
                                        foreach (var funcion2 in funcionesG)
                                        {
                                            if (funcion2.NombreFuncion.Equals(nombreFuncion))
                                            {
                                                foreach (var permisos in permisosG)
                                                {
                                                    if (permisos.Permiso.Equals("Eliminar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                    {
                                                        data.Rows[i].Cells[0].ReadOnly = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (control.Name.Equals("GridPermiso"))
                            {
                                DataGridView data = control as DataGridView;
                                for (int i = 0; i < data.Rows.Count -1; i++)
                                {
                                    if (data.Rows[i].Cells.Count > 1)
                                    {
                                        data.Rows[i].Cells[4].ReadOnly = true;
                                        foreach (var funcion in funcionesG)
                                        {
                                            if (funcion.NombreFuncion.Equals(nombreFuncion))
                                            {

                                                foreach (var permisos in permisosG)
                                                {
                                                    if (permisos.Permiso.Equals("Eliminar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                    {
                                                        data.Rows[i].Cells[0].ReadOnly = false;
                                                    }
                                                    if (permisos.Permiso.Equals("Editar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                    {
                                                        data.Rows[i].Cells[4].ReadOnly = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        if(control is Button)
                        {
                            foreach (var funcion3 in funcionesG)
                            {
                                if (funcion3.NombreFuncion.Equals(nombreFuncion))
                                {
                                    foreach (var permiso in permisosG)
                                    {
                                        if (permiso.Permiso.Equals(control.AccessibleName) && nombreFuncion.Equals(permiso.NombreFuncion) && permiso.Nivel)
                                        {
                                            control.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void seguridad_opcionesGestionPermisosRoles(Control.ControlCollection controlForm)
        {
            string nombreFuncion = "";
            //Recorre todos los objetos del formulario
            foreach (Control item in controlForm)
            {
                //filtro solo groupbox
                if (item is GroupBox)
                {
                    nombreFuncion = item.AccessibleName;
                    //si es groupbox que recorra todos los objetos dentro del groupbox
                    foreach (Control control in item.Controls)
                    {
                        //filtro por Datagrid en cada groupbox
                        if (control is DataGridView)
                        {
                            //filtro cada datagrid total 3 en el formulario
                            if (control.Name.Equals("GridRoles"))
                            {
                                //Paso el control como DataGridView para recorrerlo
                                DataGridView data = control as DataGridView;
                                for (int i = 0; i < data.Rows.Count - 1; i++)
                                {
                                    //recorrer las funciones disponibles del ususario logeado
                                    foreach (var funcion in funcionesG)
                                    {

                                        //recorrer los permisos de las funciones
                                        if (funcion.NombreFuncion.Equals(nombreFuncion))
                                        {
                                            foreach (var permisos in permisosG)
                                            {
                                                if (permisos.Permiso.Equals("Editar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[0].ReadOnly = false;
                                                }
                                                if (permisos.Permiso.Equals("Eliminar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[1].ReadOnly = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (control.Name.Equals("GridPermisos"))
                            {
                                //Paso el control como DataGridView para recorrerlo
                                DataGridView data = control as DataGridView;
                                for (int i = 0; i < data.Rows.Count - 1; i++)
                                {
                                    //recorrer las funciones disponibles del ususario logeado
                                    foreach (var funcion in funcionesG)
                                    {

                                        //recorrer los permisos de las funciones
                                        if (funcion.NombreFuncion.Equals(nombreFuncion))
                                        {
                                            foreach (var permisos in permisosG)
                                            {
                                                if (permisos.Permiso.Equals("Editar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[0].ReadOnly = false;
                                                }
                                                if (permisos.Permiso.Equals("Eliminar") && nombreFuncion.Equals(permisos.NombreFuncion) && permisos.Nivel)
                                                {
                                                    data.Rows[i].Cells[1].ReadOnly = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        if (control is Button)
                        {
                            foreach (var funcion in funcionesG)
                            {
                                if (funcion.NombreFuncion.Equals(nombreFuncion))
                                {
                                    foreach (var permiso in permisosG)
                                    {
                                        if (permiso.Permiso.Equals(control.AccessibleName) && nombreFuncion.Equals(permiso.NombreFuncion) && permiso.Nivel)
                                        {
                                            control.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void seguridad_opcionListaUsuario(Control.ControlCollection controlCollection, string name, DataGridView dg)
        {
            MessageBox.Show(name);
            try
            {
                foreach (Control control in controlCollection)
                {
                    if (control is Button)
                    {
                        foreach (var funcion in funcionesG)
                        {
                            if (name.Equals(funcion.NombreFuncion))
                            {
                                foreach (var item in permisosG)
                                {
                                    if (item.Permiso.Equals(control.AccessibleName) && name.Equals(item.NombreFuncion) && item.Nivel)
                                    {
                                        control.Enabled = true;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al habilitar las funciones: \n {ex.ToString()}");
            }

            for (int i = 0; i < dg.Rows.Count -1 ; i++)
            {
                foreach (var funcion in funcionesG)
                {
                    if (funcion.NombreFuncion.Equals(name))
                    {
                        foreach (var permiso in permisosG)
                        {
                            //permiso para visualizar Formulario Lista Roles Usuario desde Lista Usuario
                            if (permiso.Permiso.Equals("Visualizar") && permiso.NombreFuncion.Equals("Formulario Lista Roles Usuario") && permiso.Nivel)
                            {

                                dg.Rows[i].Cells[0].ReadOnly = false;
                            }
                        }
                    }
                }
            }

        }

        public static bool verificarEmail(string email)
        {
            string sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, sFormato) ==false)
            {
                return false;
            }
            return true;
        }
        public static string EncriptarPsw(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);

            return result;
        }
        public static string DesencriptarPsw(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static void seguridad_deshabilitarMenu(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                {
                    control.Enabled = false;
                    control.Visible = false;
                }
            }
        }

        public static void seguridad_habilitarMenu(Control.ControlCollection controls)
        {
            try
            {
                foreach (Control control in controls)
                {
                    if (control is Button)
                    {
                        foreach (var funcion in funcionesG)
                        {
                            if (control.AccessibleName.Equals(funcion.NombreFuncion))
                            {
                                control.Enabled = true;
                                control.Visible = true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al habilitar las funciones: \n {ex.ToString()}");
            }
        }
    }
}
