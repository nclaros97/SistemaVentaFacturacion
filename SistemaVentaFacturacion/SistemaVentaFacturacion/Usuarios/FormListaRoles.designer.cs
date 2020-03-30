namespace SistemaVentaFacturacion.Usuarios
{
    partial class FormListaRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.GridRoles = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.btnFunciones = new System.Windows.Forms.Button();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.GridFunciones = new System.Windows.Forms.DataGridView();
            this.lblFunciones = new System.Windows.Forms.Label();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.btnGestionRoles = new System.Windows.Forms.Button();
            this.btnGestionFunc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridRoles)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFunciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "ACCION";
            this.dataGridViewImageColumn1.Image = global::SistemaVentaFacturacion.Properties.Resources.rol;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleDescription = "Eliminar Rol a Usuario";
            this.btnEliminar.AccessibleName = "Eliminar";
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(746, 133);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar Rol";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "Insertar Rol a Usuario";
            this.btnNuevo.AccessibleName = "Insertar";
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(308, 44);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Asignar Rol";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // GridRoles
            // 
            this.GridRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridRoles.BackgroundColor = System.Drawing.Color.White;
            this.GridRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRoles.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRoles.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridRoles.EnableHeadersVisualStyles = false;
            this.GridRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.GridRoles.Location = new System.Drawing.Point(21, 133);
            this.GridRoles.Name = "GridRoles";
            this.GridRoles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRoles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridRoles.Size = new System.Drawing.Size(719, 281);
            this.GridRoles.TabIndex = 14;
            // 
            // txtBuscar
            // 
            this.txtBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtBuscar.Location = new System.Drawing.Point(21, 89);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(719, 38);
            this.txtBuscar.TabIndex = 13;
            this.txtBuscar.Text = "Buscar rol";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // cbRoles
            // 
            this.cbRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.cbRoles.DropDownHeight = 100;
            this.cbRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRoles.ForeColor = System.Drawing.SystemColors.Window;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.IntegralHeight = false;
            this.cbRoles.ItemHeight = 24;
            this.cbRoles.Location = new System.Drawing.Point(21, 44);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(281, 32);
            this.cbRoles.TabIndex = 15;
            this.cbRoles.SelectedIndexChanged += new System.EventHandler(this.cbRoles_SelectedIndexChanged);
            // 
            // btnFunciones
            // 
            this.btnFunciones.AccessibleName = "Visualizar";
            this.btnFunciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFunciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnFunciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFunciones.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFunciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnFunciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnFunciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFunciones.ForeColor = System.Drawing.Color.White;
            this.btnFunciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunciones.Location = new System.Drawing.Point(746, 169);
            this.btnFunciones.Name = "btnFunciones";
            this.btnFunciones.Size = new System.Drawing.Size(100, 30);
            this.btnFunciones.TabIndex = 16;
            this.btnFunciones.Text = "Funciones";
            this.btnFunciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFunciones.UseVisualStyleBackColor = false;
            this.btnFunciones.Click += new System.EventHandler(this.btnFunciones_Click);
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.BarraTitulo.Controls.Add(this.btnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(870, 38);
            this.BarraTitulo.TabIndex = 17;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::SistemaVentaFacturacion.Properties.Resources.Close;
            this.btnCerrar.Location = new System.Drawing.Point(832, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(38, 38);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // GridFunciones
            // 
            this.GridFunciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridFunciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridFunciones.BackgroundColor = System.Drawing.Color.White;
            this.GridFunciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridFunciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridFunciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridFunciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridFunciones.ColumnHeadersHeight = 30;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridFunciones.DefaultCellStyle = dataGridViewCellStyle5;
            this.GridFunciones.EnableHeadersVisualStyles = false;
            this.GridFunciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.GridFunciones.Location = new System.Drawing.Point(21, 458);
            this.GridFunciones.Name = "GridFunciones";
            this.GridFunciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.PaleVioletRed;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridFunciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GridFunciones.Size = new System.Drawing.Size(719, 207);
            this.GridFunciones.TabIndex = 18;
            // 
            // lblFunciones
            // 
            this.lblFunciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.lblFunciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunciones.ForeColor = System.Drawing.Color.White;
            this.lblFunciones.Location = new System.Drawing.Point(21, 417);
            this.lblFunciones.Name = "lblFunciones";
            this.lblFunciones.Size = new System.Drawing.Size(719, 38);
            this.lblFunciones.TabIndex = 19;
            this.lblFunciones.Text = "Funciones";
            this.lblFunciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPermisos
            // 
            this.btnPermisos.AccessibleName = "Visualizar";
            this.btnPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnPermisos.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPermisos.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnPermisos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnPermisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermisos.ForeColor = System.Drawing.Color.White;
            this.btnPermisos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermisos.Location = new System.Drawing.Point(746, 458);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(100, 30);
            this.btnPermisos.TabIndex = 20;
            this.btnPermisos.Text = "Permisos";
            this.btnPermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPermisos.UseVisualStyleBackColor = false;
            this.btnPermisos.Click += new System.EventHandler(this.btnPermisos_Click);
            // 
            // btnGestionRoles
            // 
            this.btnGestionRoles.AccessibleDescription = "Visualizar Gestion Roles y Permisos";
            this.btnGestionRoles.AccessibleName = "Visualizar";
            this.btnGestionRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnGestionRoles.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGestionRoles.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnGestionRoles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnGestionRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnGestionRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionRoles.ForeColor = System.Drawing.Color.White;
            this.btnGestionRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionRoles.Location = new System.Drawing.Point(673, 44);
            this.btnGestionRoles.Name = "btnGestionRoles";
            this.btnGestionRoles.Size = new System.Drawing.Size(173, 30);
            this.btnGestionRoles.TabIndex = 21;
            this.btnGestionRoles.Text = "Gestion Roles y Permisos";
            this.btnGestionRoles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGestionRoles.UseVisualStyleBackColor = false;
            this.btnGestionRoles.Click += new System.EventHandler(this.btnGestionRoles_Click);
            // 
            // btnGestionFunc
            // 
            this.btnGestionFunc.AccessibleDescription = "Visualizar Gestion de Funciones";
            this.btnGestionFunc.AccessibleName = "Visualizar";
            this.btnGestionFunc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestionFunc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnGestionFunc.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGestionFunc.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnGestionFunc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnGestionFunc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.btnGestionFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionFunc.ForeColor = System.Drawing.Color.White;
            this.btnGestionFunc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionFunc.Location = new System.Drawing.Point(547, 44);
            this.btnGestionFunc.Name = "btnGestionFunc";
            this.btnGestionFunc.Size = new System.Drawing.Size(120, 30);
            this.btnGestionFunc.TabIndex = 22;
            this.btnGestionFunc.Text = "Gestion Funciones";
            this.btnGestionFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGestionFunc.UseVisualStyleBackColor = false;
            this.btnGestionFunc.Click += new System.EventHandler(this.btnGestionFunc_Click);
            // 
            // FormListaRoles
            // 
            this.AccessibleName = "Formulario Lista Roles Usuario";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 677);
            this.Controls.Add(this.btnGestionFunc);
            this.Controls.Add(this.btnGestionRoles);
            this.Controls.Add(this.btnPermisos);
            this.Controls.Add(this.lblFunciones);
            this.Controls.Add(this.GridFunciones);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.btnFunciones);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.GridRoles);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormListaRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormListaClientes";
            this.Load += new System.EventHandler(this.FormListaRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridRoles)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridFunciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView GridRoles;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.Button btnFunciones;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView GridFunciones;
        private System.Windows.Forms.Label lblFunciones;
        private System.Windows.Forms.Button btnPermisos;
        private System.Windows.Forms.Button btnGestionRoles;
        private System.Windows.Forms.Button btnGestionFunc;
    }
}