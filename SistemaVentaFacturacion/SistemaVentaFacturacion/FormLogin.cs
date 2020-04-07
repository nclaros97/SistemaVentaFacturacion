using LOGICA.LUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion
{
    public partial class FormLogin : Form
    {
        public bool estado = false;
        public bool c = true;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogo_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "admin";
            txtPass.Text = "AdminTotal@2020";
            FormMenuPrincipal frm = Owner as FormMenuPrincipal;
            frm.cerrar = c;
            frm.isLogin = true;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {

            try
            {
                //verificar si el usuario existe o los datos son correctos
                if (scriptsUsuarios.Login(txtUsuario.Text, txtPass.Text))
                {

                    try
                    {
                        //si el usuario existe se obtienen los datos de permisos y funciones
                        DataTable credenciales = new DataTable();
                        credenciales = scriptsUsuarios.getCredencialesUsuario(txtUsuario.Text, txtPass.Text);
                        string usuNick = "";
                        string rolesDescrip = "";
                        //se crea una lista de la clase funciones y otra de la clase permiso para agregar los permisos y funciones del usuario para poder acceder a ellos en el sistema
                        //para poder verificar los accesos del sistema
                        List<funciones> funciones = new List<funciones>();
                        List<permisos> permisos = new List<permisos>();
                        List<string> rolDescrip = new List<string>();
                        for (int i = 0; i < credenciales.Rows.Count; i++)
                        {
                            funciones.Add(new funciones
                            {
                                NombreFuncion = credenciales.Rows[i][4].ToString(),
                                RolDescripcion = credenciales.Rows[i][3].ToString(),
                                UserNick = credenciales.Rows[i][0].ToString(),
                                UserId = Convert.ToInt32(credenciales.Rows[i][8].ToString())
                            });
                            //verificar si en los datos retornados del usuario existe rol asignado 
                            //si no existe no se agrega la lista
                            if (!credenciales.Rows[i][3].ToString().Equals(""))
                            {
                                rolDescrip.Add($"{credenciales.Rows[i][3].ToString()} \n");
                            }
                            if (!credenciales.Rows[i][5].ToString().Equals(""))
                            {
                                DataTable data = new DataTable();
                                data = scriptsUsuarios.getPermisosUsuario(Convert.ToInt32(credenciales.Rows[i][5].ToString()));

                                for (int x = 0; x < data.Rows.Count; x++)
                                {
                                    permisos.Add(new permisos
                                    {
                                        NombreFuncion = data.Rows[x][0].ToString(),
                                        Permiso = data.Rows[x][1].ToString(),
                                        Nivel = Convert.ToBoolean(data.Rows[x][2].ToString())
                                    });
                                }
                            }

                        }
                        usuNick = credenciales.Rows[0][0].ToString();
                        string[] roles = rolDescrip.Distinct().ToArray();
                        foreach (var rol in roles)
                        {
                            rolesDescrip += $"{rol}";
                        }
                        MessageBox.Show($"Sesion Iniciada como: {usuNick} Rol(es): \n{rolesDescrip}");
                        //cierra formulario y estable la sesion en el sistema como verdadero.
                        FormMenuPrincipal frm = Owner as FormMenuPrincipal;
                        frm.sesion = true;
                        frm.cerrar = false;
                        frm.isLogin = false;
                        //se muestran los datos del usuario logeado
                        frm.nombreCompleto = $"{credenciales.Rows[0][6].ToString()} {credenciales.Rows[0][7].ToString()}";
                        frm.correo = $"{credenciales.Rows[0][1].ToString()}";
                        frm.cargos = rolesDescrip;
                        frm.funciones = funciones;
                        frm.permisos = permisos;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ERROR OBTENER DATOS USUARIO LOGUEADO: \n {ex.ToString()}");
                    }
                }
                else
                {
                    //si los datos son incorrectos la sesion sigue en falso y vueve al login
                    FormMenuPrincipal frm = Owner as FormMenuPrincipal;
                    frm.sesion = false;
                    frm.cerrar = false;
                    this.Close();
                    MessageBox.Show($"Usuario o Contraseña incorrecta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR LOGIN: \n {ex.ToString()}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal frm = Owner as FormMenuPrincipal;
            frm.sesion = true;
            frm.cerrar = c;
            this.Close();
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
