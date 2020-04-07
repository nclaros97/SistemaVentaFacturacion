namespace SistemaVentaFacturacion.Facturacion
{
    partial class FormMantFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridDetalleFactura = new System.Windows.Forms.DataGridView();
            this.detalleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAccion = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnEditarDetalle = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.txtDatosCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDetalleFactura
            // 
            this.GridDetalleFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDetalleFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridDetalleFactura.BackgroundColor = System.Drawing.Color.White;
            this.GridDetalleFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridDetalleFactura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridDetalleFactura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDetalleFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridDetalleFactura.ColumnHeadersHeight = 30;
            this.GridDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalleId,
            this.ctaId,
            this.ctaDescripcion,
            this.ctaClasificacion,
            this.debe,
            this.precio,
            this.cantidad,
            this.subTotal,
            this.stock,
            this.cantMinima});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridDetalleFactura.DefaultCellStyle = dataGridViewCellStyle5;
            this.GridDetalleFactura.EnableHeadersVisualStyles = false;
            this.GridDetalleFactura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.GridDetalleFactura.Location = new System.Drawing.Point(23, 119);
            this.GridDetalleFactura.Name = "GridDetalleFactura";
            this.GridDetalleFactura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDetalleFactura.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GridDetalleFactura.Size = new System.Drawing.Size(1105, 515);
            this.GridDetalleFactura.TabIndex = 23;
            this.GridDetalleFactura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetalleFactura_CellClick);
            this.GridDetalleFactura.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetalleFactura_CellEndEdit);
            this.GridDetalleFactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridDetalleFactura_KeyDown);
            // 
            // detalleId
            // 
            this.detalleId.HeaderText = "DETALLE ID";
            this.detalleId.Name = "detalleId";
            // 
            // ctaId
            // 
            this.ctaId.HeaderText = "PRODUCTO ID";
            this.ctaId.Name = "ctaId";
            // 
            // ctaDescripcion
            // 
            this.ctaDescripcion.HeaderText = "DESCRIPCION";
            this.ctaDescripcion.Name = "ctaDescripcion";
            // 
            // ctaClasificacion
            // 
            this.ctaClasificacion.HeaderText = "UNIDAD";
            this.ctaClasificacion.Name = "ctaClasificacion";
            // 
            // debe
            // 
            this.debe.HeaderText = "CATEGORIA";
            this.debe.Name = "debe";
            // 
            // precio
            // 
            this.precio.HeaderText = "PRECIO";
            this.precio.Name = "precio";
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "CANTIDAD";
            this.cantidad.Name = "cantidad";
            // 
            // subTotal
            // 
            this.subTotal.HeaderText = "SUB TOTAL";
            this.subTotal.Name = "subTotal";
            // 
            // stock
            // 
            this.stock.HeaderText = "STOCK";
            this.stock.Name = "stock";
            // 
            // cantMinima
            // 
            this.cantMinima.HeaderText = "MINIMO";
            this.cantMinima.Name = "cantMinima";
            // 
            // lblAccion
            // 
            this.lblAccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.lblAccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.ForeColor = System.Drawing.Color.White;
            this.lblAccion.Location = new System.Drawing.Point(0, 0);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(1256, 38);
            this.lblAccion.TabIndex = 24;
            this.lblAccion.Text = "Accion";
            this.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(23, 81);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(67, 23);
            this.txtIdCliente.TabIndex = 31;
            this.txtIdCliente.TextChanged += new System.EventHandler(this.txtIdCliente_TextChanged);
            this.txtIdCliente.Leave += new System.EventHandler(this.txtIdCliente_Leave);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(475, 51);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(244, 20);
            this.fecha.TabIndex = 30;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(23, 52);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(244, 23);
            this.txtid.TabIndex = 29;
            this.txtid.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(408, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fecha:";
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.AccessibleName = "Eliminar";
            this.btnEliminarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnEliminarDetalle.FlatAppearance.BorderSize = 0;
            this.btnEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(1134, 160);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarDetalle.TabIndex = 33;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.UseVisualStyleBackColor = false;
            this.btnEliminarDetalle.Visible = false;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnEditarDetalle
            // 
            this.btnEditarDetalle.AccessibleName = "Editar";
            this.btnEditarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnEditarDetalle.FlatAppearance.BorderSize = 0;
            this.btnEditarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEditarDetalle.Location = new System.Drawing.Point(1134, 119);
            this.btnEditarDetalle.Name = "btnEditarDetalle";
            this.btnEditarDetalle.Size = new System.Drawing.Size(100, 35);
            this.btnEditarDetalle.TabIndex = 32;
            this.btnEditarDetalle.Text = "Editar";
            this.btnEditarDetalle.UseVisualStyleBackColor = false;
            this.btnEditarDetalle.Visible = false;
            this.btnEditarDetalle.Click += new System.EventHandler(this.btnEditarDetalle_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleName = "Insertar";
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(1028, 638);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 35);
            this.btnConfirmar.TabIndex = 34;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(0, 630);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(1256, 47);
            this.lblTotal.TabIndex = 35;
            this.lblTotal.Text = "TOTAL COMPRA L 00.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = global::SistemaVentaFacturacion.Properties.Resources.Close;
            this.BtnCerrar.Location = new System.Drawing.Point(1218, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(38, 38);
            this.BtnCerrar.TabIndex = 36;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // txtDatosCliente
            // 
            this.txtDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatosCliente.Location = new System.Drawing.Point(96, 81);
            this.txtDatosCliente.Name = "txtDatosCliente";
            this.txtDatosCliente.ReadOnly = true;
            this.txtDatosCliente.Size = new System.Drawing.Size(276, 23);
            this.txtDatosCliente.TabIndex = 37;
            // 
            // FormMantFactura
            // 
            this.AccessibleName = "Formulario Facturacion";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 677);
            this.Controls.Add(this.txtDatosCliente);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminarDetalle);
            this.Controls.Add(this.btnEditarDetalle);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAccion);
            this.Controls.Add(this.GridDetalleFactura);
            this.Name = "FormMantFactura";
            this.Text = "FormListaProductis";
            this.Load += new System.EventHandler(this.FormMantCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetalleFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView GridDetalleFactura;
        private System.Windows.Forms.Label lblAccion;
        public System.Windows.Forms.TextBox txtIdCliente;
        public System.Windows.Forms.DateTimePicker fecha;
        public System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Button btnEditarDetalle;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button BtnCerrar;
        public System.Windows.Forms.TextBox txtDatosCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantMinima;
    }
}