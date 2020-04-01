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
    public partial class FormMantCategorias : Form
    {
        public FormMantCategorias()
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

        private void FormMantCategorias_Load(object sender, EventArgs e)
        {
            GridCategorias.DataSource = scriptFacturacion.getGridCategorias();

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

            validaciones.seguridad_Categorias(this.Controls, this.AccessibleName);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = "INS";
            GridCategorias.Enabled = true;
            txtid.Text = "";
            txtCategoria.Text = "";
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Categorias(this.Controls, this.AccessibleName);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case "INS":
                    scriptFacturacion.insertCategoria(txtCategoria.Text);
                    break;
                case "UPD":
                    scriptFacturacion.updateCategoria(int.Parse(txtid.Text), txtCategoria.Text);
                    break;

                case "DLT":
                    scriptFacturacion.deleteCategoria(int.Parse(txtid.Text));
                    break;
            }
            btnConfirmar.AccessibleName = "Insertar";
            validaciones.seguridad_Categorias(this.Controls, this.AccessibleName);
            accion = "INS";
            txtid.Text = "";
            txtCategoria.Text = "";
            GridCategorias.Enabled = true;
            GridCategorias.DataSource = scriptFacturacion.getGridCategorias();
        }

        private string accion = "INS";
        private void GridCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridCategorias.CurrentRow.Cells[2].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridCategorias.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update
                    txtid.Text = GridCategorias.CurrentRow.Cells[2].Value.ToString();
                    txtCategoria.Text = GridCategorias.CurrentRow.Cells[3].Value.ToString();
                    GridCategorias.Enabled = false;
                    accion = "UPD";
                    btnConfirmar.AccessibleName = "Editar";
                    validaciones.seguridad_Categorias(this.Controls, this.AccessibleName);
                }
                if (columna == 0 && GridCategorias.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
                if (columna == 1 && GridCategorias.CurrentRow.Cells[1].ReadOnly == false)
                {
                    txtid.Text = GridCategorias.CurrentRow.Cells[2].Value.ToString();
                    txtCategoria.Text = GridCategorias.CurrentRow.Cells[3].Value.ToString();
                    GridCategorias.Enabled = false;
                    accion = "DLT";
                    btnConfirmar.AccessibleName = "Eliminar";
                    validaciones.seguridad_Categorias(this.Controls, this.AccessibleName);
                }
                if (columna == 1 && GridCategorias.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }
    }
}
