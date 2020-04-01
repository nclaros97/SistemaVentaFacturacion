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

namespace SistemaVentaFacturacion.Productos
{
    public partial class FormListaProductos : Form
    {
        public bool busqueda = false;
        public FormListaProductos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void FormListaProductos_Load(object sender, EventArgs e)
        {
            //grid
            GridProductos.DataSource = scriptFacturacion.getDataProductos();
            //deshabilitar botones
            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    if (!item.Name.Equals("BtnCerrar"))
                    {
                        item.Enabled = false;
                    }
                }
            }
            //seguridad
            validaciones.segurida_productos(this.Controls, this.AccessibleName);
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
            GridProductos.DataSource = scriptFacturacion.getDataProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantProductos frm = new FormMantProductos();
            frm.IsInsert = true;
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (GridProductos.SelectedRows.Count == 1)
            {
                FormMantProductos frm = new FormMantProductos();

                frm.IsInsert = false;
                frm.txtid.Text = GridProductos.CurrentRow.Cells[0].Value.ToString();
                frm.txtProducto.Text = GridProductos.CurrentRow.Cells[1].Value.ToString();
                frm.txtDescripcion.Text = GridProductos.CurrentRow.Cells[2].Value.ToString();
                frm.txtPrecio.Text = GridProductos.CurrentRow.Cells[3].Value.ToString();
                frm.cbCategoria.SelectedValue = int.Parse(GridProductos.CurrentRow.Cells[4].Value.ToString());
                frm.cbUnidades.SelectedValue = int.Parse(GridProductos.CurrentRow.Cells[6].Value.ToString());
                frm.cbImpuestos.SelectedValue = int.Parse(GridProductos.CurrentRow.Cells[8].Value.ToString());
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridProductos.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"¿Está seguro de eliminar al producto: {GridProductos.CurrentRow.Cells[1].Value.ToString()}?",
                    "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scriptFacturacion.deleteProducto(Convert.ToInt32(GridProductos.CurrentRow.Cells[0].Value.ToString()));
                    GridProductos.DataSource = scriptFacturacion.getDataProductos();
                }
                else
                {
                    MessageBox.Show("Eliminacion cancelada");
                }
            }
            else
                MessageBox.Show("seleccione una fila para poder eliminar por favor");
        }
    }
}
