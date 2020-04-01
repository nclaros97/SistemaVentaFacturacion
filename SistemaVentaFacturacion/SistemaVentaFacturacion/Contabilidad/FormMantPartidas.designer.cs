namespace SistemaVentaFacturacion.Contabilidad
{
    partial class FormMantPartidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.lblAccion = new System.Windows.Forms.Label();
            this.txtDetallePartida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.PDatos = new System.Windows.Forms.Panel();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnEditarDetalle = new System.Windows.Forms.Button();
            this.GridDetallePartidas = new System.Windows.Forms.DataGridView();
            this.detalleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarraTitulo.SuspendLayout();
            this.PDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetallePartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.BarraTitulo.Controls.Add(this.BtnCerrar);
            this.BarraTitulo.Controls.Add(this.lblAccion);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(873, 38);
            this.BarraTitulo.TabIndex = 2;
            this.BarraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.BarraTitulo_Paint);
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = global::SistemaVentaFacturacion.Properties.Resources.Close;
            this.BtnCerrar.Location = new System.Drawing.Point(835, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(38, 38);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // lblAccion
            // 
            this.lblAccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.ForeColor = System.Drawing.Color.White;
            this.lblAccion.Location = new System.Drawing.Point(0, 0);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(873, 38);
            this.lblAccion.TabIndex = 15;
            this.lblAccion.Text = "Accion";
            this.lblAccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDetallePartida
            // 
            this.txtDetallePartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetallePartida.Location = new System.Drawing.Point(132, 98);
            this.txtDetallePartida.Name = "txtDetallePartida";
            this.txtDetallePartida.Size = new System.Drawing.Size(244, 23);
            this.txtDetallePartida.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(25, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detalle Partida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(25, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.AccessibleName = "Insertar";
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(660, 442);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 35);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(25, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(132, 71);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(244, 23);
            this.txtid.TabIndex = 13;
            this.txtid.Text = "0";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(132, 127);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(244, 20);
            this.fecha.TabIndex = 18;
            // 
            // PDatos
            // 
            this.PDatos.Controls.Add(this.btnEliminarDetalle);
            this.PDatos.Controls.Add(this.btnEditarDetalle);
            this.PDatos.Controls.Add(this.btnConfirmar);
            this.PDatos.Controls.Add(this.GridDetallePartidas);
            this.PDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PDatos.Location = new System.Drawing.Point(0, 157);
            this.PDatos.Name = "PDatos";
            this.PDatos.Size = new System.Drawing.Size(873, 480);
            this.PDatos.TabIndex = 19;
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.AccessibleName = "Eliminar";
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnEliminarDetalle.FlatAppearance.BorderSize = 0;
            this.btnEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(766, 92);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(100, 35);
            this.btnEliminarDetalle.TabIndex = 24;
            this.btnEliminarDetalle.Text = "Eliminar";
            this.btnEliminarDetalle.UseVisualStyleBackColor = false;
            this.btnEliminarDetalle.Visible = false;
            this.btnEliminarDetalle.Click += new System.EventHandler(this.btnEliminarDetalle_Click);
            // 
            // btnEditarDetalle
            // 
            this.btnEditarDetalle.AccessibleName = "Editar";
            this.btnEditarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnEditarDetalle.FlatAppearance.BorderSize = 0;
            this.btnEditarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnEditarDetalle.Location = new System.Drawing.Point(766, 51);
            this.btnEditarDetalle.Name = "btnEditarDetalle";
            this.btnEditarDetalle.Size = new System.Drawing.Size(100, 35);
            this.btnEditarDetalle.TabIndex = 23;
            this.btnEditarDetalle.Text = "Editar";
            this.btnEditarDetalle.UseVisualStyleBackColor = false;
            this.btnEditarDetalle.Visible = false;
            this.btnEditarDetalle.Click += new System.EventHandler(this.btnEditarDetalle_Click);
            // 
            // GridDetallePartidas
            // 
            this.GridDetallePartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDetallePartidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridDetallePartidas.BackgroundColor = System.Drawing.Color.White;
            this.GridDetallePartidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridDetallePartidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridDetallePartidas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDetallePartidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridDetallePartidas.ColumnHeadersHeight = 30;
            this.GridDetallePartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalleId,
            this.ctaId,
            this.ctaDescripcion,
            this.ctaClasificacion,
            this.debe,
            this.haber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridDetallePartidas.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridDetallePartidas.EnableHeadersVisualStyles = false;
            this.GridDetallePartidas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.GridDetallePartidas.Location = new System.Drawing.Point(0, 0);
            this.GridDetallePartidas.Name = "GridDetallePartidas";
            this.GridDetallePartidas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDetallePartidas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridDetallePartidas.Size = new System.Drawing.Size(760, 436);
            this.GridDetallePartidas.TabIndex = 22;
            this.GridDetallePartidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetallePartidas_CellClick);
            this.GridDetallePartidas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetallePartidas_CellEndEdit);
            this.GridDetallePartidas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridDetallePartidas_KeyDown);
            // 
            // detalleId
            // 
            this.detalleId.HeaderText = "DETALLE ID";
            this.detalleId.Name = "detalleId";
            // 
            // ctaId
            // 
            this.ctaId.HeaderText = "CTA ID";
            this.ctaId.Name = "ctaId";
            // 
            // ctaDescripcion
            // 
            this.ctaDescripcion.HeaderText = "DESCRIPCION";
            this.ctaDescripcion.Name = "ctaDescripcion";
            // 
            // ctaClasificacion
            // 
            this.ctaClasificacion.HeaderText = "TIPO";
            this.ctaClasificacion.Name = "ctaClasificacion";
            // 
            // debe
            // 
            this.debe.HeaderText = "DEBE";
            this.debe.Name = "debe";
            // 
            // haber
            // 
            this.haber.HeaderText = "HABER";
            this.haber.Name = "haber";
            // 
            // FormMantPartidas
            // 
            this.AccessibleName = "Formulario Partidas Contables";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 637);
            this.Controls.Add(this.PDatos);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDetallePartida);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMantPartidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMantCliente";
            this.Load += new System.EventHandler(this.FormMantPartidas_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.PDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetallePartidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.TextBox txtDetallePartida;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblAccion;
        public System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Panel PDatos;
        private System.Windows.Forms.DataGridView GridDetallePartidas;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Button btnEditarDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn debe;
        private System.Windows.Forms.DataGridViewTextBoxColumn haber;
    }
}