using LOGICA.LUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion.Usuarios
{
    public partial class FormMantUsuarios : Form
    {
        private bool _isInsert;

        public bool IsInsert { get => _isInsert; set => _isInsert = value; }

        public FormMantUsuarios()
        {
            InitializeComponent();
            
        }

        private void FormMantUsuarios_Load(object sender, EventArgs e)
        {
            if (_isInsert)
            {
                lblAccion.Text = "Nuevo Usuario";
                txtId.Text = scriptsUsuarios.getLastId().ToString();
            }
            else
            {
                lblAccion.Text = $"Editar Usuario {txtNick.Text}";
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (IsInsert)
            {
                if (scriptsUsuarios.insertUsuario(txtNick.Text, txtNombres.Text, txtApellidos.Text, txtEmail.Text, txtTelefono.Text,
                txtPsw.Text, txtConfirmPsw.Text))
                {
                    this.Close();
                }
            }
            else
            {
                if (scriptsUsuarios.updateUsuario(System.Convert.ToInt32(txtId.Text), txtNick.Text, txtNombres.Text, txtApellidos.Text, txtEmail.Text, txtTelefono.Text,
                txtPsw.Text, txtConfirmPsw.Text))
                {
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMantRoles frm = new FormMantRoles();
            //frm.idFuncion = System.Convert.ToInt32(GridFunciones.CurrentRow.Cells[0].Value.ToString());
            //frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }
    }
}
