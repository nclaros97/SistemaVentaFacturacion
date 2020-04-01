using LOGICA.LContabilidad;
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

namespace SistemaVentaFacturacion.Contabilidad
{
    public partial class FormMantCuentas : Form
    {
        public FormMantCuentas()
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
            accion = "INS";
            GridCuentas.Enabled = true;
            txtid.Text = "";
            txtCuenta.Text = "";
            getCb();
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Cuentas(this.Controls, this.AccessibleName);
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getCb()
        {
            cbTipoCuenta.DisplayMember = "TIPO";
            cbTipoCuenta.ValueMember = "ID";
            cbTipoCuenta.DataSource = scriptsContabilidad.getGridTipoCuentas();
        }
        private void FormMantCuentas_Load(object sender, EventArgs e)
        {
            //llamar metodo para cargar combobox
            getCb();

            //llamar metoo para cargar grid
            GridCuentas.DataSource = scriptsContabilidad.getGridCuentas();

            foreach (Control control in this.Controls)
            {
                if(control is Button)
                {
                    if (!control.Text.Equals("Cancelar"))
                    {
                        control.Enabled = false;
                    }
                }
            }

            validaciones.seguridad_Cuentas(this.Controls, this.AccessibleName);

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptsContabilidad.insertCuenta(txtCuenta.Text,txtid.Text,cbTipoCuenta.SelectedValue.ToString());
                    break;
                case "UPD":
                    scriptsContabilidad.updateCuenta(txtCuenta.Text, txtid.Text, cbTipoCuenta.SelectedValue.ToString());
                    break;

                case "DLT":
                    scriptsContabilidad.deleteCuenta(txtid.Text);
                    break;
            }
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
            accion = "INS";
            txtid.Text = "";
            txtCuenta.Text = "";
            getCb();
            GridCuentas.Enabled = true;
            GridCuentas.DataSource = scriptsContabilidad.getGridCuentas();
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
           //volver a llamar metodo para cargar combobox
        }

        private void btnGestionTipoCuenta_Click(object sender, EventArgs e)
        {
            FormMantClasificacionCuenta frm = new FormMantClasificacionCuenta();
            frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
            frm.ShowDialog();
        }

        private string accion = "INS";
        private void GridCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridCuentas.CurrentRow.Cells[2].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridCuentas.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtid.Text = GridCuentas.CurrentRow.Cells[2].Value.ToString();
                    txtCuenta.Text = GridCuentas.CurrentRow.Cells[3].Value.ToString();
                    cbTipoCuenta.SelectedItem = GridCuentas.CurrentRow.Cells[4].Value.ToString();
                    GridCuentas.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
                }
                if (columna == 0 && GridCuentas.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridCuentas.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtid.Text = GridCuentas.CurrentRow.Cells[2].Value.ToString();
                    txtCuenta.Text = GridCuentas.CurrentRow.Cells[3].Value.ToString();
                    cbTipoCuenta.SelectedItem = GridCuentas.CurrentRow.Cells[4].Value.ToString();
                    GridCuentas.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
                }
                if (columna == 1 && GridCuentas.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }
    }
}
