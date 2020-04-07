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
    public partial class FormMantPartidas : Form
    {
        private bool _isInsert;
        public bool IsInsert { get => _isInsert; set => _isInsert = value; }

        public string cuenta, tipo, codigo;

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
                lblAccion.Text = "Nueva Partida";
                //txtid.Text = scriptsUsuarios.getLastIdPartida().ToString();
                btnEditarDetalle.Visible = false;
                btnEliminarDetalle.Visible = false;
                btnConfirmar.AccessibleName = "Insertar";
                GridDetallePartidas.Columns.RemoveAt(0);
            }
            else
            {
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptsContabilidad.getPartidaDetalleData(txtid.Text);
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetallePartidas.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString());
                    GridDetallePartidas.Columns[0].Visible = true;
                }
                lblAccion.Text = $"Editar Partida {txtDetallePartida.Text}";
                btnEditarDetalle.Visible = true;
                btnEliminarDetalle.Visible = true;
                btnConfirmar.AccessibleName = "Editar";
            }
            foreach (Control item in PDatos.Controls)
            {
                if (item is Button)
                {
                    if (!item.Name.Equals("BtnCerrar"))
                    {
                        item.Enabled = false;
                    }

                }
            }
            //llamar funcion para validad los permisos
            validaciones.seguridad_FormularioPartidas(PDatos.Controls,this.AccessibleName);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (_isInsert)
            {
                try
                {
                    if(scriptsContabilidad.insertPartidaYDetalle(txtDetallePartida.Text, fecha.Value, GridDetallePartidas))
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                scriptsContabilidad.updatePartida(Convert.ToInt32(txtid.Text),txtDetallePartida.Text, fecha.Value);
            }
        }

        private void GridDetallePartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columna = e.ColumnIndex;
            c = e.ColumnIndex;
            r = e.RowIndex;
            if(columna == 1)
            {

            }
        }

        private void btnEditarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetallePartidas.SelectedRows.Count == 1)
            {
                scriptsContabilidad.updateDetallePartida(Convert.ToInt32(GridDetallePartidas.CurrentRow.Cells[0].Value.ToString()), GridDetallePartidas.CurrentRow.Cells[1].Value.ToString(),
                    Convert.ToInt32(txtid.Text),
                    float.Parse(GridDetallePartidas.CurrentRow.Cells[4].Value.ToString()), float.Parse(GridDetallePartidas.CurrentRow.Cells[5].Value.ToString()));
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptsContabilidad.getPartidaDetalleData(txtid.Text);
                GridDetallePartidas.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetallePartidas.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString());
                    GridDetallePartidas.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetallePartidas.SelectedRows.Count == 1)
            {
                scriptsContabilidad.deleteDetallePartida(GridDetallePartidas.CurrentRow.Cells[0].Value.ToString());
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptsContabilidad.getPartidaDetalleData(txtid.Text);
                GridDetallePartidas.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetallePartidas.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString());
                    GridDetallePartidas.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void GridDetallePartidas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (IsInsert)
            {
                if (e.ColumnIndex == 0)
                {
                    try
                    {
                        if (GridDetallePartidas.CurrentRow.Cells[0].Value == null)
                        {
                            MessageBox.Show("Ingrese el codigo de la cuenta");
                        }
                        else
                        {
                            try
                            {
                                DataTable dt = new DataTable();
                                dt = scriptsContabilidad.getCuenta(GridDetallePartidas.CurrentRow.Cells[0].Value.ToString());
                                if (dt.Rows.Count == 1)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {

                                        GridDetallePartidas.CurrentRow.Cells[1].Value = dt.Rows[i][1].ToString();
                                        GridDetallePartidas.CurrentRow.Cells[2].Value = dt.Rows[i][3].ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Codigo invalido");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        if (GridDetallePartidas.CurrentRow.Cells[1].Value == null)
                        {
                            MessageBox.Show("Ingrese el codigo de la cuenta");
                        }
                        else
                        {
                            try
                            {
                                DataTable dt = new DataTable();
                                dt = scriptsContabilidad.getCuenta(GridDetallePartidas.CurrentRow.Cells[1].Value.ToString());
                                if (dt.Rows.Count == 1)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {

                                        GridDetallePartidas.CurrentRow.Cells[2].Value = dt.Rows[i][1].ToString();
                                        GridDetallePartidas.CurrentRow.Cells[3].Value = dt.Rows[i][3].ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Codigo invalido");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        public int c;
        public int r;

        private void PDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        public void DGData()
        {
            GridDetallePartidas.Rows[r].Cells[0].Value = codigo;
            GridDetallePartidas.Rows[r].Cells[1].Value = cuenta;
            GridDetallePartidas.Rows[r].Cells[2].Value = tipo;
        }

        private void GridDetallePartidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsInsert)
            {
                if (c == 0)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        FormListaCuenta fm = new FormListaCuenta();
                        AddOwnedForm(fm);
                        fm.r = r;
                        fm.c = c;
                        fm.ShowDialog();
                    }
                }
            }
            else
            {
                if (c == 1)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        FormListaCuenta fm = new FormListaCuenta();
                        AddOwnedForm(fm);
                        fm.r = r;
                        fm.c = c;
                        fm.ShowDialog();
                    }
                }
            }
        }
    }
}
