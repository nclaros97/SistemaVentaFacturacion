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
    public partial class FormMantFuncionesRoles : Form
    {
        private bool _isInsert;

        public bool IsInsert { get => _isInsert; set => _isInsert = value; }

        public FormMantFuncionesRoles()
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptsUsuarios.insertFuncion(txtFuncion.Text);
                    break;
                case "UPD":
                    scriptsUsuarios.updateFuncion(txtFuncion.Text, System.Convert.ToInt32(txtId.Text));
                    break;

                case "DLT":
                    scriptsUsuarios.deleteFuncion(System.Convert.ToInt32(txtId.Text));
                    break;
            }
            accion = "INS";
            txtFuncion.Text = "";
            GridFunciones.Enabled = true;
            txtId.Text = scriptsUsuarios.getCurrentFuncionId();
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRoles();
        }

        private void FormMantFuncionesRoles_Load(object sender, EventArgs e)
        {
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRoles();
            txtId.Text = scriptsUsuarios.getCurrentFuncionId();
        }

        private void txtBuscarFuncion_Enter(object sender, EventArgs e)
        {
            if (txtBuscarFuncion.Text.Equals("Buscar Funcion"))
            {
                txtBuscarFuncion.Text = "";
                txtBuscarFuncion.ForeColor = Color.Black;
            }
        }

        private void txtBuscarFuncion_Leave(object sender, EventArgs e)
        {
            if (txtBuscarFuncion.Text.Equals(""))
            {
                txtBuscarFuncion.Text = "Buscar Funcion";
                txtBuscarFuncion.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtBuscarFuncion_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRolesBusqueda(txtBuscarFuncion.Text);
        }
        private string accion = "INS";
        private void GridFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridFunciones.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;
                if (columna == 0)
                {
                    //update
                    txtId.Text = GridFunciones.CurrentRow.Cells[2].Value.ToString();
                    txtFuncion.Text = GridFunciones.CurrentRow.Cells[3].Value.ToString();
                    GridFunciones.Enabled = false;
                    accion = "UPD";
                }
                if(columna == 1)
                {
                    txtId.Text = GridFunciones.CurrentRow.Cells[2].Value.ToString();
                    txtFuncion.Text = GridFunciones.CurrentRow.Cells[3].Value.ToString();
                    GridFunciones.Enabled = false;
                    accion = "DLT";
                }
            }
        }

        private void btnCancelarAccionFuncion_Click(object sender, EventArgs e)
        {
            accion = "INS";
            txtFuncion.Text = "";
            GridFunciones.Enabled = true;
            txtId.Text = scriptsUsuarios.getCurrentFuncionId();
        }
        private int idFunc;
        private void btnAsignarRolAc_Click(object sender, EventArgs e)
        {
            if (GridFunciones.SelectedRows.Count == 1)
            {
                gbAsignarRol.Enabled = true;
                idFunc = System.Convert.ToInt32(GridFunciones.CurrentRow.Cells[2].Value.ToString());
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}
