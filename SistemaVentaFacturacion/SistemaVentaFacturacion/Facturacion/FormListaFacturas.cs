using LOGICA.LFacturacion;
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

namespace SistemaVentaFacturacion.Facturacion
{
    public partial class FormListaFacturas : Form
    {
        public bool busqueda = false;
        public FormListaFacturas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (GridFacturas.SelectedRows.Count > 0)
            {
                FormMantFactura hijo = new FormMantFactura();
                AddOwnedForm(hijo);
                hijo.IsInsert = false;
                hijo.FormBorderStyle = FormBorderStyle.None;
                hijo.TopLevel = false;
                hijo.Dock = DockStyle.Fill;
                hijo.Top = (this.Height / 2) - (hijo.Height / 2);
                hijo.Left = (this.Width / 2) - (hijo.Width / 2);
                hijo.FormClosed += new FormClosedEventHandler(Form_Closed);
                hijo.ControlBox = false;
                this.Controls.Add(hijo);
                this.Tag = hijo;
                hijo.BringToFront();
                hijo.txtid.Text = GridFacturas.CurrentRow.Cells[0].Value.ToString();
                hijo.txtIdCliente.Text = GridFacturas.CurrentRow.Cells[3].Value.ToString();
                hijo.fecha.Value = DateTime.Parse(GridFacturas.CurrentRow.Cells[1].Value.ToString());
                hijo.Show();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantFactura hijo = new FormMantFactura();
            AddOwnedForm(hijo);
            hijo.IsInsert = true;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            hijo.Top = (this.Height / 2) - (hijo.Height / 2);
            hijo.Left = (this.Width / 2) - (hijo.Width / 2);
            hijo.FormClosed += new FormClosedEventHandler(Form_Closed);
            hijo.ControlBox = false;
            this.Controls.Add(hijo);
            this.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            GridFacturas.DataSource = scriptFacturacion.getGridFacturas();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Equals("Buscar"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Buscar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridFacturas.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"¿Está seguro de eliminar la factura: {GridFacturas.CurrentRow.Cells[1].Value.ToString()} Cliente: {GridFacturas.CurrentRow.Cells[2].Value.ToString()}?",
                   "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scriptFacturacion.deleteFactura(Convert.ToInt32(GridFacturas.CurrentRow.Cells[0].Value.ToString()));
                    GridFacturas.DataSource = scriptFacturacion.getGridFacturas();
                }
                else
                {
                    MessageBox.Show("Eliminacion cancelada");
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void FormListaFacturas_Load(object sender, EventArgs e)
        {
            try
            {
                GridFacturas.DataSource = scriptFacturacion.getGridFacturas();
                GridFacturas.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR OBTENER GRID: \n {ex.ToString()}");
            }

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    if (!item.Name.Equals("BtnCerrar"))
                    {
                        item.Enabled = false;
                    }

                }
            }

            validaciones.seguridad_Facturas(this.Controls, this.AccessibleName);
        }

        private void GridFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
