using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion.Inventario
{
    public partial class FormListaInventario : Form
    {
        public bool busqueda = false;
        public FormListaInventario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListaClientes_Load(object sender, EventArgs e)
        {
            
        }
        

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
            //FormMantCliente frm = new FormMantCliente();
            //frm.ShowDialog();
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
    }
}
