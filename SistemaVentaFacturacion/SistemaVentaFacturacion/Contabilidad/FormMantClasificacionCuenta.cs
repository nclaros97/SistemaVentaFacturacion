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
    public partial class FormMantClasificacionCuenta : Form
    {
        public FormMantClasificacionCuenta()
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


        private void FormMantClasificacionCuenta_Load(object sender, EventArgs e)
        {
            //llamar metodo para cargar grid
            GridTipoCuentas.DataSource = scriptsContabilidad.getGridTipoCuentas();

            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    if (!item.Text.Equals("Cancelar"))
                    {
                        item.Enabled = false;
                    }
                }
            }

            validaciones.seguridad_opcionesTipoCuenta(this.Controls,this.AccessibleName);

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptsContabilidad.insertTipoCuenta(txtTipoCuenta.Text);
                    break;
                case "UPD":
                    scriptsContabilidad.updateTipoCuenta(txtTipoCuenta.Text, System.Convert.ToInt32(txtid.Text));
                    break;

                case "DLT":
                    scriptsContabilidad.deleteTipoCuenta(System.Convert.ToInt32(txtid.Text));
                    break;
            }
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
            accion = "INS";
            txtid.Text = "";
            txtTipoCuenta.Text = "";
            GridTipoCuentas.Enabled = true;
            GridTipoCuentas.DataSource = scriptsContabilidad.getGridTipoCuentas();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals("Buscar Tipo Cuenta"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar Tipo Cuenta";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        private string accion = "INS";
        private void GridTipoCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridTipoCuentas.CurrentRow.Cells[2].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridTipoCuentas.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtid.Text = GridTipoCuentas.CurrentRow.Cells[2].Value.ToString();
                    txtTipoCuenta.Text = GridTipoCuentas.CurrentRow.Cells[3].Value.ToString();
                    GridTipoCuentas.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
                }
                if (columna == 0 && GridTipoCuentas.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridTipoCuentas.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtid.Text = GridTipoCuentas.CurrentRow.Cells[2].Value.ToString();
                    txtTipoCuenta.Text = GridTipoCuentas.CurrentRow.Cells[3].Value.ToString();
                    GridTipoCuentas.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
                }
                if (columna == 1 && GridTipoCuentas.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = "INS";
            GridTipoCuentas.Enabled = true;
            txtid.Text = "";
            txtTipoCuenta.Text = "";
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_opcionesTipoCuenta(this.Controls, this.AccessibleName);
        }
    }
}
