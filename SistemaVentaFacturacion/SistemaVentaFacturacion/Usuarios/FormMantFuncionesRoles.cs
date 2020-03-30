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
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
            accion = "INS";
            txtFuncion.Text = "";
            GridFunciones.Enabled = true;
            txtId.Text = scriptsUsuarios.getCurrentFuncionId().ToString();
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRoles();
        }

        private void FormMantFuncionesRoles_Load(object sender, EventArgs e)
        {
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRoles();
            txtId.Text = scriptsUsuarios.getCurrentFuncionId().ToString();
            cbRoles.ValueMember = "ID";
            cbRoles.DisplayMember = "ROL";
            cbRoles.DataSource = scriptsUsuarios.cbRoles();

            cbPermisos.ValueMember = "ID";
            cbPermisos.DisplayMember = "PERMISO";
            cbPermisos.DataSource = scriptsUsuarios.cbPermisos();

            string nombreFuncion = "";
            foreach (Control item in this.Controls)
            {
                //filtro solo groupbox
                if (item is GroupBox)
                {
                    nombreFuncion = item.AccessibleName;
                    //si es groupbox que recorra todos los objetos dentro del groupbox
                    foreach (Control control in item.Controls)
                    {
                        if (control is Button)
                        {
                            if (!control.Text.Equals("Cancelar"))
                            {

                                control.Enabled = false;
                            }
                        }
                    }
                }
            }

            validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
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
                
                if (columna == 0 && GridFunciones.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtId.Text = GridFunciones.CurrentRow.Cells[2].Value.ToString();
                    txtFuncion.Text = GridFunciones.CurrentRow.Cells[3].Value.ToString();
                    GridFunciones.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);

                }
                if (columna == 0 && GridFunciones.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
               
                if (columna == 1 && GridFunciones.CurrentRow.Cells[1].ReadOnly == false)
                {
                    //delete
                    txtId.Text = GridFunciones.CurrentRow.Cells[2].Value.ToString();
                    txtFuncion.Text = GridFunciones.CurrentRow.Cells[3].Value.ToString();
                    GridFunciones.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
                }
                if (columna == 1 && GridFunciones.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private void btnCancelarAccionFuncion_Click(object sender, EventArgs e)
        {
            accion = "INS";
            txtFuncion.Text = "";
            GridFunciones.Enabled = true;
            txtId.Text = scriptsUsuarios.getCurrentFuncionId().ToString();
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
        }
        private int idFunc;
        private string funcion;
        private void btnAsignarRolAc_Click(object sender, EventArgs e)
        {
            if (GridFunciones.SelectedRows.Count == 1)
            {
                gbAsignarRol.Enabled = true;
                idFunc = Convert.ToInt32(GridFunciones.CurrentRow.Cells[2].Value.ToString());
                funcion = GridFunciones.CurrentRow.Cells[3].Value.ToString();
                GridRolFuncion.DataSource = scriptsUsuarios.getGridRolFuncion(idFunc);
                lblFuncionActual.Text = $"Funcion Actual: {funcion}";
                validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnAsignarRol_Click(object sender, EventArgs e)
        {
            //Agregar Rol a la Funcion
            //verificar si ya esta el rol y la funcion agregada
            if (scriptsUsuarios.verificarRoleFuncion(Convert.ToInt32(cbRoles.SelectedValue.ToString()), idFunc) == 0)
            {
                scriptsUsuarios.setFuncionRole(Convert.ToInt32(cbRoles.SelectedValue.ToString()), idFunc);
                GridRolFuncion.DataSource = scriptsUsuarios.getGridRolFuncion(idFunc);
            }
            else
            {
                MessageBox.Show($"El Rol: {cbRoles.Text} y la Funcion: {funcion} ya estan asignado");
            }
        }

        private void txtBuscarFuncionRol_Enter(object sender, EventArgs e)
        {
                if (txtBuscarFuncion.Text.Equals("Buscar rol asignado a funcion"))
            {
                txtBuscarFuncionRol.Text = "";
                txtBuscarFuncionRol.ForeColor = Color.Black;
            }
        }

        private void txtBuscarFuncionRol_Leave(object sender, EventArgs e)
        {
            if (txtBuscarFuncionRol.Text.Equals(""))
            {
                txtBuscarFuncionRol.Text = "Buscar rol asignado a funcion";
                txtBuscarFuncionRol.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtBuscarFuncionRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridFunciones.DataSource = scriptsUsuarios.getGridFuncionesRolesBusqueda(txtBuscarFuncionRol.Text);
        }

        private void GridRolFuncion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridFunciones.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;
                if (columna == 0 && GridRolFuncion.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //delete
                    try
                    {
                        scriptsUsuarios.deleteFunRol(Convert.ToInt32(GridRolFuncion.CurrentRow.Cells[1].Value.ToString()));
                        GridRolFuncion.DataSource = scriptsUsuarios.getGridRolFuncion(idFunc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar Funcion asignada: \n {ex.ToString()}");
                    }
                }
                if(columna == 0 && GridRolFuncion.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private int funRolId;
        private string rolDescrip;
        private string funDescrip;
        private void btnAsignarPermisoAc_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridRolFuncion.SelectedRows.Count == 1)
                {
                    gbAsignarPermisos.Enabled = true;
                    funRolId = Convert.ToInt32(GridRolFuncion.CurrentRow.Cells[1].Value.ToString());
                    rolDescrip = GridRolFuncion.CurrentRow.Cells[3].Value.ToString();
                    funDescrip = GridRolFuncion.CurrentRow.Cells[5].Value.ToString();
                    GridPermiso.DataSource = scriptsUsuarios.getGridPermisos(funRolId);
                    lblFunRol.Text = $"Funcion Actual: {funRolId} {funDescrip}, Rol Actual: {rolDescrip}";
                    validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
                }
                else
                    MessageBox.Show("seleccione una fila por favor");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.ToString()}");
            }
        }

        private void txtBuscarPermisoRol_Enter(object sender, EventArgs e)
        {
            if (txtBuscarPermisoRol.Text.Equals("Buscar permiso"))
            {
                txtBuscarPermisoRol.Text = "";
                txtBuscarPermisoRol.ForeColor = Color.Black;
            }
        }

        private void txtBuscarPermisoRol_Leave(object sender, EventArgs e)
        {
            if (txtBuscarPermisoRol.Text.Equals(""))
            {
                txtBuscarPermisoRol.Text = "Buscar permiso";
                txtBuscarPermisoRol.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtBuscarPermisoRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            GridPermiso.DataSource = scriptsUsuarios.getGridPermisosBusqueda(funRolId,txtBuscarPermisoRol.Text);
        }

        private int idPerFunCambio;
        private void GridPermiso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridPermiso.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;
                //Eliminar
                if (columna == 0 && GridPermiso.CurrentRow.Cells[0].ReadOnly == false)
                {
                    scriptsUsuarios.deleteFunRolPermiso(Convert.ToInt32(GridPermiso.CurrentRow.Cells[1].Value.ToString()));
                    GridPermiso.DataSource = scriptsUsuarios.getGridPermisos(funRolId);
                }
                if(columna == 0 && GridPermiso.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitda");
                }
                if(columna == 4 && GridPermiso.CurrentRow.Cells[4].ReadOnly == false)
                {
                    if (Convert.ToBoolean(GridPermiso.CurrentRow.Cells[4].EditedFormattedValue) == true)
                    {
                        idPerFunCambio = Convert.ToInt32(GridPermiso.CurrentRow.Cells[1].Value.ToString());
                        scriptsUsuarios.updateValorPermisoAsignado(idPerFunCambio, 0);
                        GridPermiso.DataSource = scriptsUsuarios.getGridPermisos(funRolId);
                    }
                    else
                    {
                        idPerFunCambio = Convert.ToInt32(GridPermiso.CurrentRow.Cells[1].Value.ToString());
                        scriptsUsuarios.updateValorPermisoAsignado(idPerFunCambio, 1);
                        GridPermiso.DataSource = scriptsUsuarios.getGridPermisos(funRolId);
                    }
                    
                }
                if(columna == 4 && GridPermiso.CurrentRow.Cells[4].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (scriptsUsuarios.verificarPermisoRoleFuncion(funRolId, Convert.ToInt32(cbPermisos.SelectedValue.ToString())) == 0)
            {
                int accion=0;
                string descrip = "N/A";
                switch (cbPermisos.Text)
                {
                    case "Insertar":
                        descrip = "El usuario puede insertar";
                        break;
                    case "Editar":
                        descrip = "El usuario puede editar";
                        break;

                    case "Eliminar":
                        descrip = "El usuario puede eliminar";
                        break;

                    case "Visualizar":
                        descrip = "El usuario puede visualizar";
                        break;
                }
                if (chkbAccion.Checked)
                {
                    accion = 1;
                }
                scriptsUsuarios.setPermisoFuncionRole(Convert.ToInt32(cbPermisos.SelectedValue.ToString()),funRolId,descrip,accion);
                GridPermiso.DataSource = scriptsUsuarios.getGridPermisos(funRolId);
                chkbAccion.Checked = false;
            }
            else
            {
                MessageBox.Show($"El permiso {cbPermisos.Text} ya esta asignado a la funcion {funDescrip} con el rol {rolDescrip}");
            }
        }
    }
}
