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
    public partial class FormMantRoles : Form
    {
        public FormMantRoles()
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

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMantRoles_Load(object sender, EventArgs e)
        {
            GridRoles.DataSource = scriptsUsuarios.cbRoles();
            GridPermisos.DataSource = scriptsUsuarios.cbPermisos();

            txtIdPermiso.Text = scriptsUsuarios.getLastIdPermiso().ToString();
            txtidRol.Text = scriptsUsuarios.getLastIdRol().ToString();

            //Deshabilitar botones
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

            validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
        }

        private void btnConfirmarRol_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptsUsuarios.insertRol(txtnombreRol.Text);
                    break;
                case "UPD":
                    scriptsUsuarios.updateRol(txtnombreRol.Text, System.Convert.ToInt32(txtidRol.Text));
                    break;

                case "DLT":
                    scriptsUsuarios.deleteRol(System.Convert.ToInt32(txtidRol.Text));
                    break;
            }
            btnConfirmarRol.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
            accion = "INS";
            txtnombreRol.Text = "";
            GridRoles.Enabled = true;
            txtidRol.Text = scriptsUsuarios.getLastIdRol().ToString();
            GridRoles.DataSource = scriptsUsuarios.cbRoles();
        }
        private string accion = "INS";
        private void btnCancelarRol_Click(object sender, EventArgs e)
        {
            accion = "INS";
            GridRoles.Enabled = true;
            txtidRol.Text = scriptsUsuarios.getLastIdRol().ToString();
            txtnombreRol.Text = "";
            btnConfirmarRol.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);

        }

        private void btnConfirmarPermiso_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptsUsuarios.insertPermiso(txtNombrePermiso.Text);
                    break;
                case "UPD":
                    scriptsUsuarios.updatePermiso(txtNombrePermiso.Text, System.Convert.ToInt32(txtIdPermiso.Text));
                    break;

                case "DLT":
                    scriptsUsuarios.deletePermiso(System.Convert.ToInt32(txtIdPermiso.Text));
                    break;
            }
            btnConfirmarPermiso.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
            accion = "INS";
            txtNombrePermiso.Text = "";
            GridPermisos.Enabled = true;
            txtIdPermiso.Text = scriptsUsuarios.getLastIdPermiso().ToString();
            GridPermisos.DataSource = scriptsUsuarios.cbPermisos();
        }

        private void btnCancelarPermiso_Click(object sender, EventArgs e)
        {
            btnConfirmarPermiso.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
            accion = "INS";
            GridPermisos.Enabled = true;
            txtIdPermiso.Text = scriptsUsuarios.getLastIdPermiso().ToString();
            txtNombrePermiso.Text = "";
        }

        private void GridRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridRoles.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridRoles.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtidRol.Text = GridRoles.CurrentRow.Cells[2].Value.ToString();
                    txtnombreRol.Text = GridRoles.CurrentRow.Cells[3].Value.ToString();
                    GridRoles.Enabled = false;
                    accion = "UPD";
                    btnConfirmarRol.AccessibleName = "Editar";
                    validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
                }
                if (columna == 0 && GridRoles.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridRoles.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtidRol.Text = GridRoles.CurrentRow.Cells[2].Value.ToString();
                    txtnombreRol.Text = GridRoles.CurrentRow.Cells[3].Value.ToString();
                    GridRoles.Enabled = false;
                    accion = "DLT";
                    btnConfirmarRol.AccessibleName = "Eliminar";
                    validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
                }
                if (columna == 1 && GridRoles.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private void GridPermisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridPermisos.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridPermisos.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtIdPermiso.Text = GridPermisos.CurrentRow.Cells[2].Value.ToString();
                    txtNombrePermiso.Text = GridPermisos.CurrentRow.Cells[3].Value.ToString();
                    GridPermisos.Enabled = false;
                    accion = "UPD";
                    btnConfirmarPermiso.AccessibleName = "Editar";
                    validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
                }
                if (columna == 0 && GridPermisos.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }

                    if (columna == 1 && GridPermisos.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtIdPermiso.Text = GridPermisos.CurrentRow.Cells[2].Value.ToString();
                    txtNombrePermiso.Text = GridPermisos.CurrentRow.Cells[3].Value.ToString();
                    GridPermisos.Enabled = false;
                    accion = "DLT";
                    btnConfirmarPermiso.AccessibleName = "Eliminar";
                    validaciones.seguridad_opcionesGestionPermisosRoles(this.Controls);
                }
                if (columna == 1 && GridPermisos.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }
    }
}
