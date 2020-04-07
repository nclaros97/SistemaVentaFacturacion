using LOGICA.LFacturacion;
using LOGICA.LUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion.Productos
{
    public partial class FormMantCompras : Form
    {
        private bool isInsert;
        public string descripcion, unidad, categoria, id;
        public float precioPro;
        public bool IsInsert { get => isInsert; set => isInsert = value; }

        public FormMantCompras()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMantCompras_Load(object sender, EventArgs e)
        {
            if (isInsert)
            {
                lblAccion.Text = "Nueva Compra";
                btnEditarDetalle.Visible = false;
                btnEliminarDetalle.Visible = false;
                btnConfirmar.AccessibleName = "Insertar";
                GridDetalleCompra.Columns.RemoveAt(0);
            }
            else
            {
                // cargar datos de la compra
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getCompraDetalleData(int.Parse(txtid.Text));
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleCompra.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleCompra.Columns[0].Visible = true;
                }
                lblAccion.Text = $"Editar Compra";
                btnEditarDetalle.Visible = true;
                btnEliminarDetalle.Visible = true;
                btnConfirmar.AccessibleName = "Editar";
                sumPrecioTotal();
            }
            foreach (Control item in this.Controls)
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
            validaciones.seguridad_FormularioCompras(this.Controls, this.AccessibleName);
        }

        private void GridDetalleCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsInsert)
                {
                    if (e.ColumnIndex == 0)
                    {
                        try
                        {
                            if (GridDetalleCompra.CurrentRow.Cells[0].Value == null)
                            {
                                MessageBox.Show("Ingrese el codigo del producto");
                            }
                            else
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    dt = scriptFacturacion.getProducto(int.Parse(GridDetalleCompra.CurrentRow.Cells[0].Value.ToString()));
                                    if (dt.Rows.Count == 1)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {

                                            GridDetalleCompra.CurrentRow.Cells[1].Value = dt.Rows[i][2].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[2].Value = dt.Rows[i][5].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[3].Value = dt.Rows[i][4].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[4].Value = dt.Rows[i][3].ToString();
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
                    if (GridDetalleCompra.CurrentRow.Cells[5].Value != null)
                    {
                        float precio = float.Parse(GridDetalleCompra.CurrentRow.Cells[4].Value.ToString());
                        float cantidad = float.Parse(GridDetalleCompra.CurrentRow.Cells[5].Value.ToString());

                        GridDetalleCompra.CurrentRow.Cells[6].Value = (precio * cantidad).ToString();

                        sumPrecioTotal();
                    }
                    else if (GridDetalleCompra.CurrentRow.Cells[5].Value == null && e.ColumnIndex == 5)
                    {
                        MessageBox.Show("Cantiad no valida");
                    }
                }
                else
                {
                    if (e.ColumnIndex == 1)
                    {
                        try
                        {
                            if (GridDetalleCompra.CurrentRow.Cells[1].Value == null)
                            {
                                MessageBox.Show("Ingrese el codigo del producto");
                            }
                            else
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    dt = scriptFacturacion.getProducto(int.Parse(GridDetalleCompra.CurrentRow.Cells[1].Value.ToString()));
                                    if (dt.Rows.Count == 1)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {

                                            GridDetalleCompra.CurrentRow.Cells[2].Value = dt.Rows[i][2].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[3].Value = dt.Rows[i][5].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[4].Value = dt.Rows[i][4].ToString();
                                            GridDetalleCompra.CurrentRow.Cells[5].Value = dt.Rows[i][3].ToString();
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
                    if (e.ColumnIndex == 6)
                    {
                        if (GridDetalleCompra.CurrentRow.Cells[6].Value != null)
                        {
                            float precio = float.Parse(GridDetalleCompra.CurrentRow.Cells[5].Value.ToString());
                            float cantidad = float.Parse(GridDetalleCompra.CurrentRow.Cells[6].Value.ToString());

                            GridDetalleCompra.CurrentRow.Cells[7].Value = (precio * cantidad).ToString();
                            sumPrecioTotal();
                        }
                        else if (GridDetalleCompra.CurrentRow.Cells[5].Value == null && e.ColumnIndex == 6)
                        {
                            MessageBox.Show("Cantiad no valida");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: \n {ex.ToString()}");
            }
        }
        private void sumPrecioTotal()
        {
            float t = 0;
            if (isInsert)
            {
                for (int i = 0; i < GridDetalleCompra.Rows.Count - 1; i++)
                {
                    t += float.Parse(GridDetalleCompra.Rows[i].Cells[6].Value.ToString());
                }
                lblTotal.Text = "";
                lblTotal.Text = $"TOTAL COMPRA L {t.ToString()}";
            }
            else
            {
                for (int i = 0; i < GridDetalleCompra.Rows.Count - 1; i++)
                {
                    t = float.Parse(GridDetalleCompra.Rows[i].Cells[7].Value.ToString());
                }
                lblTotal.Text = "";
                lblTotal.Text = $"TOTAL COMPRA L {t.ToString()}";
            }
        }
        private void btnEditarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetalleCompra.SelectedRows.Count == 1)
            {
                scriptFacturacion.updateDetalleCompra(int.Parse(GridDetalleCompra.CurrentRow.Cells[0].Value.ToString()), int.Parse(txtid.Text),
                    int.Parse(GridDetalleCompra.CurrentRow.Cells[1].Value.ToString()), float.Parse(GridDetalleCompra.CurrentRow.Cells[6].Value.ToString()));
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getCompraDetalleData(int.Parse(txtid.Text));
                GridDetalleCompra.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleCompra.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleCompra.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetalleCompra.SelectedRows.Count == 1)
            {
                scriptFacturacion.deleteDetalleCompra(int.Parse(GridDetalleCompra.CurrentRow.Cells[0].Value.ToString()));
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getCompraDetalleData(int.Parse(txtid.Text));
                GridDetalleCompra.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleCompra.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleCompra.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        public int c = 0, r = 0;

        private void GridDetalleCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsInsert)
            {
                if (c == 0)
                {
                    if (e.KeyData == Keys.F1)
                    {
                        FormProductos fm = new FormProductos();
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
                        FormProductos fm = new FormProductos();
                        AddOwnedForm(fm);
                        fm.r = r;
                        fm.c = c;
                        fm.ShowDialog();
                    }
                }
            }
        }

        private void GridDetalleCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columna = e.ColumnIndex;
            c = e.ColumnIndex;
            r = e.RowIndex;
        }

        public void DGData()
        {
            if (isInsert)
            {
                GridDetalleCompra.Rows[r].Cells[0].Value = id;
                GridDetalleCompra.Rows[r].Cells[1].Value = descripcion;
                GridDetalleCompra.Rows[r].Cells[2].Value = unidad;
                GridDetalleCompra.Rows[r].Cells[3].Value = categoria;
                GridDetalleCompra.Rows[r].Cells[4].Value = precioPro;
            }
            else
            {
                GridDetalleCompra.Rows[r].Cells[1].Value = id;
                GridDetalleCompra.Rows[r].Cells[2].Value = descripcion;
                GridDetalleCompra.Rows[r].Cells[3].Value = unidad;
                GridDetalleCompra.Rows[r].Cells[4].Value = categoria;
                GridDetalleCompra.Rows[r].Cells[5].Value = precioPro;
            }
        }

        private float totalCompra = 0;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (IsInsert)
            {
                try
                {
                    if (scriptFacturacion.insertCompraYDetalle(fecha.Value, txtDescripcion.Text, GridDetalleCompra))
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
                scriptFacturacion.updateCompra(Convert.ToInt32(txtid.Text), txtDescripcion.Text, fecha.Value, totalCompra);
                this.Close();
            }
        }

    }
}
