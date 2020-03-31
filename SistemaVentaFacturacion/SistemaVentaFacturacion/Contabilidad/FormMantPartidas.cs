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
    public partial class FormMantPartidas : Form
    {
        private bool _isInsert;

        public bool IsInsert { get => _isInsert; set => _isInsert = value; }

        public FormMantPartidas()
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

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMantPartidas_Load(object sender, EventArgs e)
        {
            if (_isInsert)
            {
                lblAccion.Text = "Nuevo Usuario";
                txtid.Text = scriptsUsuarios.getLastIdPartida().ToString();
            }
            else
            {
                lblAccion.Text = $"Editar Partida {txtDetallePartida.Text}";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //llamar a las funcion de gestion db INS, UPD
            if (_isInsert)
            {

            }
            else
            {

            }

            this.Close();
        }

        private void GridDetallePartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GridDetallePartidas.CurrentRow.Cells[1].Value.ToString().Equals(""))
            {
                int fila = e.RowIndex;
                int columna = e.ColumnIndex;

                if (columna == 0 && GridDetallePartidas.CurrentRow.Cells[0].ReadOnly == false)
                {
                    //update Detalle Partida mismo grid
                    
                    //validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);

                }
                if (columna == 0 && GridDetallePartidas.CurrentRow.Cells[0].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }

                if (columna == 1 && GridDetallePartidas.CurrentRow.Cells[1].ReadOnly == false)
                {
                    //delete detalle Partida Mismo Grid
                    
                   //validaciones.seguridad_opcionesGestionFuncionesRolesPermisos(this.Controls);
                }
                if (columna == 1 && GridDetallePartidas.CurrentRow.Cells[1].ReadOnly == true)
                {
                    MessageBox.Show("Accion no permitida");
                }
            }
        }
    }
}
