using LOGICA.LFacturacion;
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

namespace SistemaVentaFacturacion.Productos
{
    public partial class FormMantImpuestos : Form
    {
        public FormMantImpuestos()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = "INS";
            GridImpuestos.Enabled = true;
            txtid.Text = "";
            txtImpuesto.Text = "";
            txtPOrcentaje.Text = "";
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Impuestos(this.Controls, this.AccessibleName);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptFacturacion.insertImpuesto(txtImpuesto.Text, int.Parse(txtPOrcentaje.Text));
                    break;
                case "UPD":
                    scriptFacturacion.updateImpuesto(int.Parse(txtid.Text), txtImpuesto.Text, int.Parse(txtPOrcentaje.Text));
                    break;

                case "DLT":
                    scriptFacturacion.deleteImpuesto(int.Parse(txtid.Text));
                    break;
            }
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Impuestos(this.Controls, this.AccessibleName);
            accion = "INS";
            txtid.Text = "";
            txtImpuesto.Text = "";
            txtPOrcentaje.Text = "";
            GridImpuestos.Enabled = true;
            GridImpuestos.DataSource = scriptFacturacion.getGridImpuestos();
        }

        private string accion = "INS";

        private void FormMantImpuestos_Load(object sender, EventArgs e)
        {
            GridImpuestos.DataSource = scriptFacturacion.getGridImpuestos();

            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    if (!control.Text.Equals("Cancelar"))
                    {
                        control.Enabled = false;
                    }
                }
            }

            validaciones.seguridad_Unidades(this.Controls, this.AccessibleName);
        }

        private void GridImpuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridImpuestos.CurrentRow.Cells[2].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridImpuestos.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtid.Text = GridImpuestos.CurrentRow.Cells[2].Value.ToString();
                    txtImpuesto.Text = GridImpuestos.CurrentRow.Cells[3].Value.ToString();
                    txtPOrcentaje.Text = GridImpuestos.CurrentRow.Cells[4].Value.ToString();
                    GridImpuestos.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_Impuestos(this.Controls, this.AccessibleName);
                }
                if (columna == 0 && GridImpuestos.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridImpuestos.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtid.Text = GridImpuestos.CurrentRow.Cells[2].Value.ToString();
                    txtImpuesto.Text = GridImpuestos.CurrentRow.Cells[3].Value.ToString();
                    txtPOrcentaje.Text = GridImpuestos.CurrentRow.Cells[4].Value.ToString();
                    GridImpuestos.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_Impuestos(this.Controls, this.AccessibleName);
                }
                if (columna == 1 && GridImpuestos.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }
    }
}
