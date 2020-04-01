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
    public partial class FormMantProductos : Form
    {
        private bool isInsert;

        public bool IsInsert { get => isInsert; set => isInsert = value; }

        public FormMantProductos()
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

        public void comboboxs()
        {
            //cb unidades
            cbUnidades.DisplayMember = "UNIDAD";
            cbUnidades.ValueMember = "ID";
            cbUnidades.DataSource = scriptFacturacion.getCbUnidades();
            //cb categoria
            cbCategoria.DisplayMember = "CATEGORIA";
            cbCategoria.ValueMember = "ID";
            cbCategoria.DataSource = scriptFacturacion.getCbCategoria();
            //cb impuesto
            cbImpuestos.DisplayMember = "IMPUESTO";
            cbImpuestos.ValueMember = "ID";
            cbImpuestos.DataSource = scriptFacturacion.getCbImpuesto();
        }

        private void FormMantProductos_Load(object sender, EventArgs e)
        {
            //carga combobox
            comboboxs();
            if (isInsert)
            {
                lblAccion.Text = "Nuevo Producto";
            }
            else
            {
                lblAccion.Text = $"Editar Producto {txtProducto.Text}";
            }
            validaciones.seguridad_CaracteristicasProducto(this.Controls);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (isInsert)
            {
                if (scriptFacturacion.insertProducto(txtProducto.Text, txtDescripcion.Text, float.Parse(txtPrecio.Text),int.Parse(cbCategoria.SelectedValue.ToString()), int.Parse(cbImpuestos.SelectedValue.ToString()),
                    int.Parse(cbUnidades.SelectedValue.ToString())) )
                {
                    this.Close();
                }
            }
            else
            {
                if (scriptFacturacion.updateProducto(int.Parse(txtid.Text), txtProducto.Text, txtDescripcion.Text, float.Parse(txtPrecio.Text), int.Parse(cbCategoria.SelectedValue.ToString()), int.Parse(cbImpuestos.SelectedValue.ToString()),
                    int.Parse(cbUnidades.SelectedValue.ToString())))
                {
                    this.Close();
                }
            }
        }

        private void btnGestionCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                FormMantCategorias frm = new FormMantCategorias();
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form3_Closed(object sender, EventArgs e)
        {
            //refrescar comboboxs
            try
            {
                comboboxs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("X "+ ex.ToString());
            }
        }

        private void btnGestionUnidades_Click(object sender, EventArgs e)
        {
            try
            {
                FormMantUnidades frm = new FormMantUnidades();
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGestionImpuesto_Click(object sender, EventArgs e)
        {
            try
            {
                FormMantImpuestos frm = new FormMantImpuestos();
                frm.FormClosed += new FormClosedEventHandler(Form3_Closed);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
