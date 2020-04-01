using LOGICA.LContabilidad;
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

namespace SistemaVentaFacturacion.Contabilidad
{
    public partial class FormListaCuenta : Form
    {
        public int r, c;
        public FormListaCuenta()
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

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormListaCuenta_Load(object sender, EventArgs e)
        {
            GridCuenta.DataSource = scriptsContabilidad.getGridCuentas();
        }

        private void GridCuenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(GridCuenta.SelectedRows.Count == 1)
            {
                FormMantPartidas frm = Owner as FormMantPartidas;
                frm.cuenta = GridCuenta.CurrentRow.Cells[1].Value.ToString();
                frm.codigo = GridCuenta.CurrentRow.Cells[0].Value.ToString();
                frm.tipo = GridCuenta.CurrentRow.Cells[3].Value.ToString();
                frm.DGData();
                this.Close();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
