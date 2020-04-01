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
using System.Data.SqlClient;

namespace SistemaVentaFacturacion.Usuarios
{
    public partial class FormListaUsuarios : Form
    {

        public bool busqueda = false;
        public FormListaUsuarios()
        {
            InitializeComponent();
            GridUsuarios.DataSource = scriptsUsuarios.getGrid();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            if (GridUsuarios.SelectedRows.Count == 1)
            {
                FormMantUsuarios frm = new FormMantUsuarios();
                frm.IsInsert = false;
                frm.txtId.Text = GridUsuarios.CurrentRow.Cells[1].Value.ToString();
                frm.txtNick.Text = GridUsuarios.CurrentRow.Cells[2].Value.ToString();
                frm.txtNombres.Text = GridUsuarios.CurrentRow.Cells[3].Value.ToString();
                frm.txtApellidos.Text = GridUsuarios.CurrentRow.Cells[4].Value.ToString();
                frm.txtEmail.Text = GridUsuarios.CurrentRow.Cells[5].Value.ToString();
                frm.txtTelefono.Text = GridUsuarios.CurrentRow.Cells[6].Value.ToString();
                frm.IsInsert = false;
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
                FormMantUsuarios frm = new FormMantUsuarios();
                frm.IsInsert = true;
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
            GridUsuarios.DataSource = scriptsUsuarios.getGrid();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Equals("Buscar usuario"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar usuario";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridUsuarios.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"¿Está seguro de eliminar al usuario: {GridUsuarios.CurrentRow.Cells[1].Value.ToString()}?",
                    "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scriptsUsuarios.deleteUsuario(System.Convert.ToInt32(GridUsuarios.CurrentRow.Cells[1].Value.ToString()));
                    GridUsuarios.DataSource = scriptsUsuarios.getGrid();
                }
                else
                {
                    MessageBox.Show("Eliminacion cancelada");
                }
            }
            else
                MessageBox.Show("seleccione una fila para poder eliminar por favor");
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridUsuarios.DataSource = scriptsUsuarios.getGridBusqueda(txtBuscar.Text);
        }

        private void GridUsuarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.GridUsuarios.Cursor = Cursors.Hand;
            }
            else
            {
                this.GridUsuarios.Cursor = Cursors.Default;
            }
        }
        int columna;
        int fila;
        
        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (!GridUsuarios.CurrentRow.Cells[1].Value.ToString().Equals(""))
                {
                    fila = e.RowIndex;
                    columna = e.ColumnIndex;
                    if (columna == 0 && GridUsuarios.CurrentRow.Cells[0].ReadOnly == false)
                    {
                        FormListaRoles frm = new FormListaRoles();
                        frm.IsInsert = true;
                        frm.UserId = System.Convert.ToInt32(GridUsuarios.CurrentRow.Cells[1].Value.ToString());
                        frm.userNick = GridUsuarios.CurrentRow.Cells[2].Value.ToString();
                        frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                        frm.ShowDialog();
                }
                if(columna == 0 && GridUsuarios.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                }
        }

        private void FormListaUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                GridUsuarios.DataSource = scriptsUsuarios.getGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }

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

            validaciones.seguridad_opcionListaUsuario(this.Controls, this.AccessibleName, GridUsuarios);
            
        }
    }
}
