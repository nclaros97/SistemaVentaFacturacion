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
    public partial class FormMantUnidades : Form
    {
        public FormMantUnidades()
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
            GridUnidades.Enabled = true;
            txtid.Text = "";
            txtCategoria.Text = "";
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Unidades(this.Controls, this.AccessibleName);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptFacturacion.insertUnidad(txtCategoria.Text);
                    break;
                case "UPD":
                    scriptFacturacion.updateUnidad(int.Parse(txtid.Text), txtCategoria.Text);
                    break;

                case "DLT":
                    scriptFacturacion.deleteUnidad(int.Parse(txtid.Text));
                    break;
            }
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Unidades(this.Controls, this.AccessibleName);
            accion = "INS";
            txtid.Text = "";
            txtCategoria.Text = "";
            GridUnidades.Enabled = true;
            GridUnidades.DataSource = scriptFacturacion.getGridUnidades();
        }

        private string accion = "INS";
        private void GridCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridUnidades.CurrentRow.Cells[2].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridUnidades.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtid.Text = GridUnidades.CurrentRow.Cells[2].Value.ToString();
                    txtCategoria.Text = GridUnidades.CurrentRow.Cells[3].Value.ToString();
                    GridUnidades.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_Unidades(this.Controls, this.AccessibleName);
                }
                if (columna == 0 && GridUnidades.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridUnidades.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtid.Text = GridUnidades.CurrentRow.Cells[2].Value.ToString();
                    txtCategoria.Text = GridUnidades.CurrentRow.Cells[3].Value.ToString();
                    GridUnidades.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_Unidades(this.Controls, this.AccessibleName);
                }
                if (columna == 1 && GridUnidades.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }

        private void FormMantUnidades_Load(object sender, EventArgs e)
        {
            GridUnidades.DataSource = scriptFacturacion.getGridUnidades();

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
    }
}
