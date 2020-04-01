using LOGICA.LContabilidad;
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

namespace SistemaVentaFacturacion.Contabilidad
{
    public partial class FormListaPartidas : Form
    {
        public bool busqueda = false;
        public FormListaPartidas()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //FormMantCliente frm = new FormMantCliente();
            //if (GridClientes.SelectedRows.Count > 0)
            //{               
            //    frm.txtid.Text= GridClientes.CurrentRow.Cells[0].Value.ToString();
            //    frm.txtnombre.Text = GridClientes.CurrentRow.Cells[1].Value.ToString();
            //    frm.txtapellido.Text = GridClientes.CurrentRow.Cells[2].Value.ToString();
            //    frm.txtdireccion.Text = GridClientes.CurrentRow.Cells[3].Value.ToString();
            //    frm.txttelefono.Text = GridClientes.CurrentRow.Cells[4].Value.ToString();

            //    frm.ShowDialog();
             
            //}
            //else
            //    MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantPartidas frm = new FormMantPartidas();
            frm.IsInsert = true;
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (busqueda)
            {
                FormMembresia frm = Owner as FormMembresia;
                //FormMembresia frm = new FormMembresia();

                frm.txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }*/
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Equals("Buscar cliente por [Nombres, Apellidos, Telefono, Direccion, Correo Electronico]"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar cliente por [Nombres, Apellidos, Telefono, Direccion, Correo Electronico]";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Buscar
        }

        private void FormListaPartidas_Load(object sender, EventArgs e)
        {
            try
            {
                GridPartidasContables.DataSource = scriptsContabilidad.getGrid();
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

            validaciones.seguridad_opcionListaContabilidad(this.Controls, this.AccessibleName);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
            GridPartidasContables.DataSource = scriptsContabilidad.getGrid();
        }

        private void btnGestionCuenta_Click(object sender, EventArgs e)
        {
            FormMantCuentas frm = new FormMantCuentas();
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridPartidasContables.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"¿Está seguro de eliminar la partida: {GridPartidasContables.CurrentRow.Cells[1].Value.ToString()}?",
                   "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scriptsContabilidad.deletePartida(System.Convert.ToInt32(GridPartidasContables.CurrentRow.Cells[0].Value.ToString()));
                    GridPartidasContables.DataSource = scriptsContabilidad.getGrid();
                }
                else
                {
                    MessageBox.Show("Eliminacion cancelada");
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (GridPartidasContables.SelectedRows.Count == 1)
            {
                FormMantPartidas frm = new FormMantPartidas();
                frm.IsInsert = false;
                frm.txtid.Text = GridPartidasContables.CurrentRow.Cells[0].Value.ToString();
                frm.txtDetallePartida.Text = GridPartidasContables.CurrentRow.Cells[1].Value.ToString();
                frm.fecha.Value = Convert.ToDateTime(GridPartidasContables.CurrentRow.Cells[2].Value.ToString());
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
