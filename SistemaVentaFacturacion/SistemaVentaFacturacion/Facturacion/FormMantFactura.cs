using LOGICA.LFacturacion;
using LOGICA.LUsuarios;
using SistemaVentaFacturacion.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion.Facturacion
{
    public partial class FormMantFactura : Form
    {
        private bool isInsert;
        public string descripcion, unidad, categoria, id;
        public float precioPro, stockIn, minimo;
        public bool IsInsert { get => isInsert; set => isInsert = value; }

        public FormMantFactura()
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
                lblAccion.Text = "Nueva Factura";
                btnEditarDetalle.Visible = false;
                btnEliminarDetalle.Visible = false;
                btnConfirmar.AccessibleName = "Insertar";
                GridDetalleFactura.Columns.RemoveAt(0);
                GridDetalleFactura.Columns[7].Visible = false;
                GridDetalleFactura.Columns[8].Visible = false;
            }
            else
            {
                GridDetalleFactura.Columns[8].Visible = false;
                GridDetalleFactura.Columns[9].Visible = false;
                // cargar datos de la compra
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getFacturaDetalleData(int.Parse(txtid.Text));
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleFactura.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleFactura.Columns[0].Visible = true;
                }
                lblAccion.Text = $"Editar Factura";
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

        private void sumPrecioTotal()
        {
            float t = 0;
            if (isInsert)
            {
                for (int i = 0; i < GridDetalleFactura.Rows.Count - 1; i++)
                {
                    t += float.Parse(GridDetalleFactura.Rows[i].Cells[6].Value.ToString());
                }
                lblTotal.Text = "";
                lblTotal.Text = $"TOTAL COMPRA L {t.ToString()}";
            }
            else
            {
                for (int i = 0; i < GridDetalleFactura.Rows.Count - 1; i++)
                {
                    t = float.Parse(GridDetalleFactura.Rows[i].Cells[7].Value.ToString());
                }
                lblTotal.Text = "";
                lblTotal.Text = $"TOTAL COMPRA L {t.ToString()}";
            }
        }
        private void btnEditarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetalleFactura.SelectedRows.Count == 1)
            {
                scriptFacturacion.updateDetalleFactura(int.Parse(GridDetalleFactura.CurrentRow.Cells[0].Value.ToString()), int.Parse(txtid.Text),
                    int.Parse(GridDetalleFactura.CurrentRow.Cells[1].Value.ToString()), float.Parse(GridDetalleFactura.CurrentRow.Cells[6].Value.ToString()));
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getFacturaDetalleData(int.Parse(txtid.Text));
                GridDetalleFactura.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleFactura.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleFactura.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (GridDetalleFactura.SelectedRows.Count == 1)
            {
                scriptFacturacion.deleteDetalleFactura(int.Parse(GridDetalleFactura.CurrentRow.Cells[0].Value.ToString()));
                // cargar datos de la partida
                DataTable GridDetalle = new DataTable();
                GridDetalle = scriptFacturacion.getFacturaDetalleData(int.Parse(txtid.Text));
                GridDetalleFactura.Rows.Clear();
                for (int i = 0; i < GridDetalle.Rows.Count; i++)
                {
                    GridDetalleFactura.Rows.Add(GridDetalle.Rows[i][0].ToString(), GridDetalle.Rows[i][1].ToString(), GridDetalle.Rows[i][2].ToString(), GridDetalle.Rows[i][3].ToString()
                        , GridDetalle.Rows[i][4].ToString(), GridDetalle.Rows[i][5].ToString(), GridDetalle.Rows[i][6].ToString(), GridDetalle.Rows[i][7].ToString());
                    GridDetalleFactura.Columns[0].Visible = true;
                }
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        public int c = 0, r = 0;

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtIdCliente.Text.Equals(""))
                {
                    MessageBox.Show("Clinte no encontrado");
                    
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = scriptFacturacion.getDataClienteId(int.Parse(txtIdCliente.Text));
                    if (dt.Rows.Count == 1)
                    {
                        txtDatosCliente.Text = $"{dt.Rows[0][1].ToString()} {dt.Rows[0][2].ToString()}";
                    }
                    else
                    {
                        MessageBox.Show("Clinte no encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.ToString()}");
            }
        }

        private void GridDetalleFactura_KeyDown(object sender, KeyEventArgs e)
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
                        fm.acc = "Facturacion";
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

        private void GridDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsInsert)
                {
                    if (e.ColumnIndex == 0)
                    {
                        try
                        {
                            if (GridDetalleFactura.CurrentRow.Cells[0].Value == null)
                            {
                                MessageBox.Show("Ingrese el codigo del producto");
                            }
                            else
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    dt = scriptFacturacion.getProducto(int.Parse(GridDetalleFactura.CurrentRow.Cells[0].Value.ToString()));
                                    if (dt.Rows.Count == 1)
                                    {
                                        if(float.Parse(dt.Rows[0][8].ToString()) > float.Parse(dt.Rows[0][9].ToString()))
                                        {

                                            GridDetalleFactura.CurrentRow.Cells[1].Value = dt.Rows[0][2].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[2].Value = dt.Rows[0][5].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[3].Value = dt.Rows[0][4].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[4].Value = dt.Rows[0][3].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[7].Value = dt.Rows[0][8].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[8].Value = dt.Rows[0][9].ToString();
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Producto {dt.Rows[0][2].ToString()} Sin existencia");
                                            GridDetalleFactura.CurrentRow.Cells[0].Value = "";
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
                    if (GridDetalleFactura.CurrentRow.Cells[5].Value != null)
                    {
                        float stock = float.Parse(GridDetalleFactura.CurrentRow.Cells[7].Value.ToString()) - float.Parse(GridDetalleFactura.CurrentRow.Cells[8].Value.ToString());
                        if (float.Parse(GridDetalleFactura.CurrentRow.Cells[5].Value.ToString()) > stock)
                        {
                            MessageBox.Show($"Stock insuficiente de producto en inventario\nCantidad Maxima = {stock}");
                            GridDetalleFactura.CurrentRow.Cells[5].Value = "";
                            GridDetalleFactura.CurrentRow.Cells[6].Value = "";
                        }
                        else
                        {
                            float precio = float.Parse(GridDetalleFactura.CurrentRow.Cells[4].Value.ToString());
                            float cantidad = float.Parse(GridDetalleFactura.CurrentRow.Cells[5].Value.ToString());

                            GridDetalleFactura.CurrentRow.Cells[6].Value = (precio * cantidad).ToString();

                            sumPrecioTotal();
                        }
                    }
                    else if (GridDetalleFactura.CurrentRow.Cells[5].Value == null && e.ColumnIndex == 5)
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
                            if (GridDetalleFactura.CurrentRow.Cells[1].Value == null)
                            {
                                MessageBox.Show("Ingrese el codigo del producto");
                            }
                            else
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    dt = scriptFacturacion.getProducto(int.Parse(GridDetalleFactura.CurrentRow.Cells[1].Value.ToString()));
                                    if (dt.Rows.Count == 1)
                                    {
                                        if (float.Parse(dt.Rows[0][8].ToString()) > float.Parse(dt.Rows[0][9].ToString()))
                                        {

                                            GridDetalleFactura.CurrentRow.Cells[2].Value = dt.Rows[0][2].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[3].Value = dt.Rows[0][5].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[4].Value = dt.Rows[0][4].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[5].Value = dt.Rows[0][3].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[8].Value = dt.Rows[0][8].ToString();
                                            GridDetalleFactura.CurrentRow.Cells[9].Value = dt.Rows[0][9].ToString();
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Producto {dt.Rows[0][2].ToString()} Sin existencia");
                                        GridDetalleFactura.CurrentRow.Cells[1].Value = "";
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
                        if (GridDetalleFactura.CurrentRow.Cells[6].Value != null)
                        {
                            float stock = float.Parse(GridDetalleFactura.CurrentRow.Cells[8].Value.ToString()) - float.Parse(GridDetalleFactura.CurrentRow.Cells[9].Value.ToString());

                            if (float.Parse(GridDetalleFactura.CurrentRow.Cells[6].Value.ToString()) > stock)
                            {
                                MessageBox.Show($"Stock insuficiente de producto en inventario\nCantidad Maxima = {stock}");
                                GridDetalleFactura.CurrentRow.Cells[6].Value = "";
                                GridDetalleFactura.CurrentRow.Cells[7].Value = "";
                            }
                            else
                            {
                                float precio = float.Parse(GridDetalleFactura.CurrentRow.Cells[5].Value.ToString());
                                float cantidad = float.Parse(GridDetalleFactura.CurrentRow.Cells[6].Value.ToString());

                                GridDetalleFactura.CurrentRow.Cells[7].Value = (precio * cantidad).ToString();
                                sumPrecioTotal();
                            }
                        }
                        else if (GridDetalleFactura.CurrentRow.Cells[5].Value == null && e.ColumnIndex == 6)
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

        private void GridDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columna = e.ColumnIndex;
            c = e.ColumnIndex;
            r = e.RowIndex;
        }

        public void DGData()
        {
            if (isInsert)
            {
                GridDetalleFactura.Rows[r].Cells[0].Value = id;
                GridDetalleFactura.Rows[r].Cells[1].Value = descripcion;
                GridDetalleFactura.Rows[r].Cells[2].Value = unidad;
                GridDetalleFactura.Rows[r].Cells[3].Value = categoria;
                GridDetalleFactura.Rows[r].Cells[4].Value = precioPro;
                GridDetalleFactura.Rows[r].Cells[7].Value = stockIn.ToString();
                GridDetalleFactura.Rows[r].Cells[8].Value = minimo.ToString();

            }
            else
            {
                GridDetalleFactura.Rows[r].Cells[1].Value = id;
                GridDetalleFactura.Rows[r].Cells[2].Value = descripcion;
                GridDetalleFactura.Rows[r].Cells[3].Value = unidad;
                GridDetalleFactura.Rows[r].Cells[4].Value = categoria;
                GridDetalleFactura.Rows[r].Cells[5].Value = precioPro;
                GridDetalleFactura.Rows[r].Cells[8].Value = stockIn.ToString();
                GridDetalleFactura.Rows[r].Cells[9].Value = minimo.ToString();
            }
        }

        private float totalCompra = 0;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!txtIdCliente.Text.Equals(""))
            {
                if (IsInsert)
                {
                    try
                    {
                        if (scriptFacturacion.insertFacturaYDetalle(fecha.Value, txtIdCliente.Text, GridDetalleFactura))
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
                    scriptFacturacion.updateFactura(Convert.ToInt32(txtid.Text), txtIdCliente.Text, fecha.Value, totalCompra);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ingrese el cliente");
            }
        }

    }
}
