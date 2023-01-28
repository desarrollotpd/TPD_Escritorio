namespace TPD_C.Ventas
{
 partial class Ventas_Linea_Remate_Obsoletos
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
   this.btnTotalesToXls = new System.Windows.Forms.Button();
   this.cboAgente = new System.Windows.Forms.ComboBox();
   this.label2 = new System.Windows.Forms.Label();
   this.cmbAlmacen = new System.Windows.Forms.ComboBox();
   this.btnBuscar = new System.Windows.Forms.Button();
   this.label1 = new System.Windows.Forms.Label();
   this.dtpfecha_fin = new System.Windows.Forms.DateTimePicker();
   this.label6 = new System.Windows.Forms.Label();
   this.dtpfecha_ini = new System.Windows.Forms.DateTimePicker();
   this.label3 = new System.Windows.Forms.Label();
   this.dgvTotales = new System.Windows.Forms.DataGridView();
   this.CveAgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Agente = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.CveSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.VtaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.MontoDevuelto = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.VtasNetas = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Pzas = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.PzasDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.PzasNetas = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dgvDetalles = new System.Windows.Forms.DataGridView();
   this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Sublinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.label4 = new System.Windows.Forms.Label();
   this.label5 = new System.Windows.Forms.Label();
   this.btnDetallesToXls = new System.Windows.Forms.Button();
   ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
   this.SuspendLayout();
   // 
   // btnTotalesToXls
   // 
   this.btnTotalesToXls.BackColor = System.Drawing.Color.Silver;
   this.btnTotalesToXls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
   this.btnTotalesToXls.ForeColor = System.Drawing.Color.White;
   this.btnTotalesToXls.Image = global::TPD_C.Properties.Resources.Excel2016;
   this.btnTotalesToXls.Location = new System.Drawing.Point(79, 360);
   this.btnTotalesToXls.Name = "btnTotalesToXls";
   this.btnTotalesToXls.Size = new System.Drawing.Size(39, 35);
   this.btnTotalesToXls.TabIndex = 30;
   this.btnTotalesToXls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
   this.btnTotalesToXls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
   this.btnTotalesToXls.UseVisualStyleBackColor = false;
   this.btnTotalesToXls.Click += new System.EventHandler(this.button6_Click);
   // 
   // cboAgente
   // 
   this.cboAgente.FormattingEnabled = true;
   this.cboAgente.Location = new System.Drawing.Point(4, 36);
   this.cboAgente.Name = "cboAgente";
   this.cboAgente.Size = new System.Drawing.Size(210, 21);
   this.cboAgente.TabIndex = 29;
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(4, 78);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(48, 13);
   this.label2.TabIndex = 28;
   this.label2.Text = "Almacén";
   // 
   // cmbAlmacen
   // 
   this.cmbAlmacen.FormattingEnabled = true;
   this.cmbAlmacen.Location = new System.Drawing.Point(4, 97);
   this.cmbAlmacen.Name = "cmbAlmacen";
   this.cmbAlmacen.Size = new System.Drawing.Size(210, 21);
   this.cmbAlmacen.TabIndex = 25;
   // 
   // btnBuscar
   // 
   this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
   this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
   this.btnBuscar.ForeColor = System.Drawing.Color.MediumBlue;
   this.btnBuscar.Location = new System.Drawing.Point(59, 266);
   this.btnBuscar.Name = "btnBuscar";
   this.btnBuscar.Size = new System.Drawing.Size(79, 41);
   this.btnBuscar.TabIndex = 26;
   this.btnBuscar.Text = "BUSCAR";
   this.btnBuscar.UseVisualStyleBackColor = false;
   this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(4, 20);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(92, 13);
   this.label1.TabIndex = 27;
   this.label1.Text = "Agente de Ventas";
   // 
   // dtpfecha_fin
   // 
   this.dtpfecha_fin.Location = new System.Drawing.Point(4, 215);
   this.dtpfecha_fin.Name = "dtpfecha_fin";
   this.dtpfecha_fin.Size = new System.Drawing.Size(211, 20);
   this.dtpfecha_fin.TabIndex = 34;
   // 
   // label6
   // 
   this.label6.AutoSize = true;
   this.label6.Location = new System.Drawing.Point(4, 200);
   this.label6.Name = "label6";
   this.label6.Size = new System.Drawing.Size(62, 13);
   this.label6.TabIndex = 33;
   this.label6.Text = "Fecha final:";
   // 
   // dtpfecha_ini
   // 
   this.dtpfecha_ini.Location = new System.Drawing.Point(4, 162);
   this.dtpfecha_ini.Name = "dtpfecha_ini";
   this.dtpfecha_ini.Size = new System.Drawing.Size(211, 20);
   this.dtpfecha_ini.TabIndex = 32;
   // 
   // label3
   // 
   this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(4, 146);
   this.label3.Name = "label3";
   this.label3.Size = new System.Drawing.Size(69, 13);
   this.label3.TabIndex = 31;
   this.label3.Text = "Fecha inicial:";
   // 
   // dgvTotales
   // 
   this.dgvTotales.AllowUserToAddRows = false;
   this.dgvTotales.AllowUserToResizeColumns = false;
   this.dgvTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.dgvTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
   this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.dgvTotales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CveAgente,
            this.Agente,
            this.CveSuc,
            this.Sucursal,
            this.VtaTotal,
            this.MontoDevuelto,
            this.VtasNetas,
            this.Pzas,
            this.PzasDev,
            this.PzasNetas});
   this.dgvTotales.Location = new System.Drawing.Point(219, 5);
   this.dgvTotales.Name = "dgvTotales";
   this.dgvTotales.Size = new System.Drawing.Size(1189, 277);
   this.dgvTotales.TabIndex = 36;
   this.dgvTotales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotales_CellContentClick);
   this.dgvTotales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotales_CellContentClick);
   // 
   // CveAgente
   // 
   this.CveAgente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.CveAgente.DataPropertyName = "CveAgente";
   this.CveAgente.FillWeight = 71.10243F;
   this.CveAgente.HeaderText = "CveAgente";
   this.CveAgente.Name = "CveAgente";
   this.CveAgente.ReadOnly = true;
   this.CveAgente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.CveAgente.ToolTipText = "no";
   this.CveAgente.Visible = false;
   this.CveAgente.Width = 69;
   // 
   // Agente
   // 
   this.Agente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Agente.DataPropertyName = "Agente";
   this.Agente.FillWeight = 366.5168F;
   this.Agente.HeaderText = "Agente";
   this.Agente.Name = "Agente";
   this.Agente.ReadOnly = true;
   this.Agente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Agente.Width = 150;
   // 
   // CveSuc
   // 
   this.CveSuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
   this.CveSuc.DataPropertyName = "CveSuc";
   this.CveSuc.FillWeight = 45.68525F;
   this.CveSuc.HeaderText = "CveSuc";
   this.CveSuc.Name = "CveSuc";
   this.CveSuc.ReadOnly = true;
   this.CveSuc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.CveSuc.ToolTipText = "no";
   this.CveSuc.Visible = false;
   // 
   // Sucursal
   // 
   this.Sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Sucursal.DataPropertyName = "Sucursal";
   this.Sucursal.HeaderText = "Sucursal";
   this.Sucursal.Name = "Sucursal";
   this.Sucursal.ReadOnly = true;
   this.Sucursal.Width = 62;
   // 
   // VtaTotal
   // 
   this.VtaTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.VtaTotal.DataPropertyName = "VtaTotal";
   this.VtaTotal.FillWeight = 38.22314F;
   this.VtaTotal.HeaderText = "Vta. Total";
   this.VtaTotal.Name = "VtaTotal";
   this.VtaTotal.ReadOnly = true;
   this.VtaTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.VtaTotal.Width = 61;
   // 
   // MontoDevuelto
   // 
   this.MontoDevuelto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.MontoDevuelto.DataPropertyName = "MontoDevuelto";
   this.MontoDevuelto.FillWeight = 38.90356F;
   this.MontoDevuelto.HeaderText = "Monto Devuelto";
   this.MontoDevuelto.Name = "MontoDevuelto";
   this.MontoDevuelto.ReadOnly = true;
   this.MontoDevuelto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.MontoDevuelto.Width = 64;
   // 
   // VtasNetas
   // 
   this.VtasNetas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.VtasNetas.DataPropertyName = "VtasNetas";
   this.VtasNetas.FillWeight = 39.56837F;
   this.VtasNetas.HeaderText = "Vtas Netas";
   this.VtasNetas.Name = "VtasNetas";
   this.VtasNetas.ReadOnly = true;
   this.VtasNetas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.VtasNetas.Width = 65;
   // 
   // Pzas
   // 
   this.Pzas.DataPropertyName = "Pzas";
   this.Pzas.HeaderText = "Piezas";
   this.Pzas.Name = "Pzas";
   this.Pzas.ReadOnly = true;
   this.Pzas.Width = 63;
   // 
   // PzasDev
   // 
   this.PzasDev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.PzasDev.DataPropertyName = "PzasDev";
   this.PzasDev.HeaderText = "Dev. de Piezas";
   this.PzasDev.Name = "PzasDev";
   this.PzasDev.ReadOnly = true;
   this.PzasDev.Width = 56;
   // 
   // PzasNetas
   // 
   this.PzasNetas.DataPropertyName = "PzasNetas";
   this.PzasNetas.HeaderText = "Piezas Netas";
   this.PzasNetas.Name = "PzasNetas";
   this.PzasNetas.ReadOnly = true;
   this.PzasNetas.Width = 87;
   // 
   // dgvDetalles
   // 
   this.dgvDetalles.AllowUserToAddRows = false;
   this.dgvDetalles.AllowUserToResizeColumns = false;
   this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
   this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Articulo,
            this.dataGridViewTextBoxColumn3,
            this.Descripcion,
            this.Sublinea,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
   this.dgvDetalles.Location = new System.Drawing.Point(219, 288);
   this.dgvDetalles.Name = "dgvDetalles";
   this.dgvDetalles.Size = new System.Drawing.Size(1189, 419);
   this.dgvDetalles.TabIndex = 37;
   this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
   // 
   // dataGridViewTextBoxColumn1
   // 
   this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn1.DataPropertyName = "CveAgente";
   this.dataGridViewTextBoxColumn1.FillWeight = 71.10243F;
   this.dataGridViewTextBoxColumn1.HeaderText = "Cve. Agente";
   this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
   this.dataGridViewTextBoxColumn1.ReadOnly = true;
   this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn1.ToolTipText = "no";
   this.dataGridViewTextBoxColumn1.Visible = false;
   this.dataGridViewTextBoxColumn1.Width = 69;
   // 
   // Articulo
   // 
   this.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Articulo.DataPropertyName = "Articulo";
   this.Articulo.HeaderText = "Articulo";
   this.Articulo.Name = "Articulo";
   this.Articulo.ReadOnly = true;
   this.Articulo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   // 
   // dataGridViewTextBoxColumn3
   // 
   this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
   this.dataGridViewTextBoxColumn3.DataPropertyName = "CveSuc";
   this.dataGridViewTextBoxColumn3.FillWeight = 45.68525F;
   this.dataGridViewTextBoxColumn3.HeaderText = "CveSuc";
   this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
   this.dataGridViewTextBoxColumn3.ReadOnly = true;
   this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn3.ToolTipText = "no";
   this.dataGridViewTextBoxColumn3.Visible = false;
   // 
   // Descripcion
   // 
   this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Descripcion.DataPropertyName = "Descripcion";
   this.Descripcion.HeaderText = "Descripcion";
   this.Descripcion.Name = "Descripcion";
   this.Descripcion.ReadOnly = true;
   this.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Descripcion.Width = 88;
   // 
   // Sublinea
   // 
   this.Sublinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Sublinea.DataPropertyName = "Sublinea";
   this.Sublinea.HeaderText = "Sublinea";
   this.Sublinea.Name = "Sublinea";
   this.Sublinea.ReadOnly = true;
   this.Sublinea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Sublinea.Width = 73;
   // 
   // dataGridViewTextBoxColumn5
   // 
   this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn5.DataPropertyName = "VtaTotal";
   this.dataGridViewTextBoxColumn5.FillWeight = 38.22314F;
   this.dataGridViewTextBoxColumn5.HeaderText = "Vta. Total";
   this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
   this.dataGridViewTextBoxColumn5.ReadOnly = true;
   this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn5.Width = 61;
   // 
   // dataGridViewTextBoxColumn6
   // 
   this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn6.DataPropertyName = "MontoDevuelto";
   this.dataGridViewTextBoxColumn6.FillWeight = 38.90356F;
   this.dataGridViewTextBoxColumn6.HeaderText = "Monto Devuelto";
   this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
   this.dataGridViewTextBoxColumn6.ReadOnly = true;
   this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn6.Width = 64;
   // 
   // dataGridViewTextBoxColumn7
   // 
   this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn7.DataPropertyName = "VtasNetas";
   this.dataGridViewTextBoxColumn7.FillWeight = 39.56837F;
   this.dataGridViewTextBoxColumn7.HeaderText = "Vtas. Netas";
   this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
   this.dataGridViewTextBoxColumn7.ReadOnly = true;
   this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn7.Width = 65;
   // 
   // dataGridViewTextBoxColumn8
   // 
   this.dataGridViewTextBoxColumn8.DataPropertyName = "Pzas";
   this.dataGridViewTextBoxColumn8.HeaderText = "Piezas";
   this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
   this.dataGridViewTextBoxColumn8.ReadOnly = true;
   this.dataGridViewTextBoxColumn8.Width = 63;
   // 
   // dataGridViewTextBoxColumn9
   // 
   this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn9.DataPropertyName = "PzasDev";
   this.dataGridViewTextBoxColumn9.HeaderText = "Dev. de Piezas";
   this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
   this.dataGridViewTextBoxColumn9.ReadOnly = true;
   this.dataGridViewTextBoxColumn9.Width = 56;
   // 
   // dataGridViewTextBoxColumn10
   // 
   this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn10.DataPropertyName = "PzasNetas";
   this.dataGridViewTextBoxColumn10.HeaderText = "Pzas. Netas";
   this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
   this.dataGridViewTextBoxColumn10.ReadOnly = true;
   this.dataGridViewTextBoxColumn10.Width = 89;
   // 
   // dataGridViewTextBoxColumn2
   // 
   this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn2.DataPropertyName = "Agente";
   this.dataGridViewTextBoxColumn2.FillWeight = 366.5168F;
   this.dataGridViewTextBoxColumn2.HeaderText = "Agente";
   this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
   this.dataGridViewTextBoxColumn2.ReadOnly = true;
   this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.dataGridViewTextBoxColumn2.Width = 150;
   // 
   // dataGridViewTextBoxColumn4
   // 
   this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.dataGridViewTextBoxColumn4.DataPropertyName = "Sucursal";
   this.dataGridViewTextBoxColumn4.HeaderText = "Sucursal";
   this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
   this.dataGridViewTextBoxColumn4.ReadOnly = true;
   this.dataGridViewTextBoxColumn4.Width = 62;
   // 
   // label4
   // 
   this.label4.AutoSize = true;
   this.label4.Location = new System.Drawing.Point(57, 344);
   this.label4.Name = "label4";
   this.label4.Size = new System.Drawing.Size(84, 13);
   this.label4.TabIndex = 37;
   this.label4.Text = "Exportar Totales";
   // 
   // label5
   // 
   this.label5.AutoSize = true;
   this.label5.Location = new System.Drawing.Point(57, 429);
   this.label5.Name = "label5";
   this.label5.Size = new System.Drawing.Size(87, 13);
   this.label5.TabIndex = 39;
   this.label5.Text = "Exportar Detalles";
   // 
   // btnDetallesToXls
   // 
   this.btnDetallesToXls.BackColor = System.Drawing.Color.Silver;
   this.btnDetallesToXls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
   this.btnDetallesToXls.ForeColor = System.Drawing.Color.White;
   this.btnDetallesToXls.Image = global::TPD_C.Properties.Resources.Excel2016;
   this.btnDetallesToXls.Location = new System.Drawing.Point(79, 445);
   this.btnDetallesToXls.Name = "btnDetallesToXls";
   this.btnDetallesToXls.Size = new System.Drawing.Size(39, 35);
   this.btnDetallesToXls.TabIndex = 38;
   this.btnDetallesToXls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
   this.btnDetallesToXls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
   this.btnDetallesToXls.UseVisualStyleBackColor = false;
   this.btnDetallesToXls.Click += new System.EventHandler(this.btnDetallesToXls_Click);
   // 
   // Ventas_Linea_Remate_Obsoletos
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(1408, 719);
   this.Controls.Add(this.dgvTotales);
   this.Controls.Add(this.dgvDetalles);
   this.Controls.Add(this.label5);
   this.Controls.Add(this.btnDetallesToXls);
   this.Controls.Add(this.label4);
   this.Controls.Add(this.dtpfecha_fin);
   this.Controls.Add(this.label6);
   this.Controls.Add(this.dtpfecha_ini);
   this.Controls.Add(this.label3);
   this.Controls.Add(this.btnTotalesToXls);
   this.Controls.Add(this.cboAgente);
   this.Controls.Add(this.label2);
   this.Controls.Add(this.cmbAlmacen);
   this.Controls.Add(this.btnBuscar);
   this.Controls.Add(this.label1);
   this.Name = "Ventas_Linea_Remate_Obsoletos";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Ventas líneas remate / Obsoletos";
   this.Load += new System.EventHandler(this.Ventas_Linea_Remate_Obsoletos_Load);
   ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
   ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.Button btnTotalesToXls;
  private System.Windows.Forms.ComboBox cboAgente;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.ComboBox cmbAlmacen;
  private System.Windows.Forms.Button btnBuscar;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.DateTimePicker dtpfecha_fin;
  private System.Windows.Forms.Label label6;
  private System.Windows.Forms.DateTimePicker dtpfecha_ini;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.DataGridView dgvTotales;
  private System.Windows.Forms.DataGridView dgvDetalles;
  private System.Windows.Forms.DataGridViewTextBoxColumn CveAgente;
  private System.Windows.Forms.DataGridViewTextBoxColumn Agente;
  private System.Windows.Forms.DataGridViewTextBoxColumn CveSuc;
  private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
  private System.Windows.Forms.DataGridViewTextBoxColumn VtaTotal;
  private System.Windows.Forms.DataGridViewTextBoxColumn MontoDevuelto;
  private System.Windows.Forms.DataGridViewTextBoxColumn VtasNetas;
  private System.Windows.Forms.DataGridViewTextBoxColumn Pzas;
  private System.Windows.Forms.DataGridViewTextBoxColumn PzasDev;
  private System.Windows.Forms.DataGridViewTextBoxColumn PzasNetas;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.Button btnDetallesToXls;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sublinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}