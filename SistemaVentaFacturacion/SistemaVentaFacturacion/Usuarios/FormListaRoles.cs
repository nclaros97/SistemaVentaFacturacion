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
    public partial class FormListaRoles : Form
    {
        public bool IsInsert = false;
        public int UserId;
        public string userNick;
        public bool busqueda = false;
        private int rolSeleccionado;
        public FormListaRoles()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListaRoles_Load(object sender, EventArgs e)
        {
            try
            {
                GridRoles.DataSource = scriptsUsuarios.getGridRoles(UserId);
                cbRoles.ValueMember = "rolId";
                cbRoles.DisplayMember = "rolDescripcion";
                cbRoles.DataSource = scriptsUsuarios.cbRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.Message.ToString()}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Agregar Rol al usuario
            //verificar si ya esta el rol
            if (scriptsUsuarios.verificarRoleUser(UserId,rolSeleccionado) == 0)
            {
                scriptsUsuarios.setUserRole(rolSeleccionado, UserId, userNick);
                GridRoles.DataSource = scriptsUsuarios.getGridRoles(UserId);
            }
            else
            {
                MessageBox.Show($"El Rol: {cbRoles.Text} ya esta asignado");
            }
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
            GridRoles.DataSource = scriptsUsuarios.getGridRoles(UserId);
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
            if(txtBuscar.Text.Equals("Buscar rol"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar rol";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GridRoles.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"¿Está seguro de eliminar el rol {GridRoles.CurrentRow.Cells[2].Value.ToString()} al usuario: {userNick}?",
                    "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scriptsUsuarios.deleteRolUsuario(System.Convert.ToInt32(GridRoles.CurrentRow.Cells[0].Value.ToString()));
                    GridRoles.DataSource = scriptsUsuarios.getGridRoles(UserId);
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
            GridRoles.DataSource = scriptsUsuarios.getGridRolesBusqueda(UserId,txtBuscar.Text);
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            //cargar grid con todas las funciones del rol selecionado
            if (GridRoles.SelectedRows.Count == 1)
            {

                GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRoles(System.Convert.ToInt32(GridRoles.CurrentRow.Cells[1].Value.ToString()));
            }
            else
                MessageBox.Show("seleccione una fila para poder cargar las funciones por favor");
            
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            //cargar modal con los permisos de la funcion seleccionada
            if (GridFunciones.SelectedRows.Count == 1)
            {
                FormMantPermisosFunciones frm = new FormMantPermisosFunciones();
                frm.idFuncion = System.Convert.ToInt32(GridFunciones.CurrentRow.Cells[0].Value.ToString());
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("seleccione una fila para poder cargar los permisos por favor");
        }

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolSeleccionado = System.Convert.ToInt32(cbRoles.SelectedValue.ToString());
        }

        private void btnGestionRoles_Click(object sender, EventArgs e)
        {
            FormMantRoles frm = new FormMantRoles();
            //frm.idFuncion = System.Convert.ToInt32(GridFunciones.CurrentRow.Cells[0].Value.ToString());
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }

        private void btnGestionFunc_Click(object sender, EventArgs e)
        {
            FormMantFuncionesRoles frm = new FormMantFuncionesRoles();
            //frm.idFuncion = System.Convert.ToInt32(GridFunciones.CurrentRow.Cells[0].Value.ToString());
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }
    }
}
