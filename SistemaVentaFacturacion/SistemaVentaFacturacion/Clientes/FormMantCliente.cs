using LOGICA.LFacturacion;
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

namespace SistemaVentaFacturacion.Clientes
{
    public partial class FormMantCliente : Form
    {
        private bool isInsert;

        public bool IsInsert { get => isInsert; set => isInsert = value; }

        public FormMantCliente()
        {
            InitializeComponent();
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

        private void FormMantCliente_Load(object sender, EventArgs e)
        {
            if (isInsert)
            {
                lblAccion.Text = "Nuevo Cliente";
            }
            else
            {
                lblAccion.Text = $"Editar Cliente: {txtnombre.Text} {txtapellido}";
            }
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (IsInsert)
            {
                if (scriptFacturacion.insertCliente(txtnombre.Text, txtapellido.Text, txtdireccion.Text, txttelefono.Text, txtCorreo.Text) )
                {
                    this.Close();
                }
            }
            else
            {
                if (scriptFacturacion.updateCliente(int.Parse(txtid.Text), txtnombre.Text, txtapellido.Text, txtdireccion.Text, txttelefono.Text, txtCorreo.Text) )
                {
                    this.Close();
                }
            }
        }
    }
}
