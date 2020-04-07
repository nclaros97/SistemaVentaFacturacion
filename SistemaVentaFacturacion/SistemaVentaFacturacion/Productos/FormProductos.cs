using LOGICA.LContabilidad;
using LOGICA.LFacturacion;
using SistemaVentaFacturacion.Facturacion;
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

namespace SistemaVentaFacturacion.Productos
{ 
    public partial class FormProductos : Form
    {
        public int r, c;
        public string acc;
        public FormProductos()
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
            GridProductos.DataSource = scriptFacturacion.getDataProductos();
            GridProductos.Columns[8].Visible = false;
            GridProductos.Columns[9].Visible = false;
        }

        private void GridCuenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(GridProductos.SelectedRows.Count == 1)
            {
                if (acc.Equals("Facturacion"))
                {
                    FormMantFactura frm = Owner as FormMantFactura;
                    frm.id = GridProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.descripcion = GridProductos.CurrentRow.Cells[2].Value.ToString();
                    frm.unidad = GridProductos.CurrentRow.Cells[5].Value.ToString();
                    frm.categoria = GridProductos.CurrentRow.Cells[4].Value.ToString();
                    frm.precioPro = float.Parse(GridProductos.CurrentRow.Cells[3].Value.ToString());
                    frm.stockIn = float.Parse(GridProductos.CurrentRow.Cells[8].Value.ToString());
                    frm.minimo = float.Parse(GridProductos.CurrentRow.Cells[9].Value.ToString());
                    frm.DGData();
                    this.Close();
                }
                else
                {
                    FormMantCompras frm = Owner as FormMantCompras;
                    frm.id = GridProductos.CurrentRow.Cells[0].Value.ToString();
                    frm.descripcion = GridProductos.CurrentRow.Cells[2].Value.ToString();
                    frm.unidad = GridProductos.CurrentRow.Cells[5].Value.ToString();
                    frm.categoria = GridProductos.CurrentRow.Cells[4].Value.ToString();
                    frm.precioPro = float.Parse(GridProductos.CurrentRow.Cells[3].Value.ToString());
                    frm.DGData();
                    this.Close();
                }

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
