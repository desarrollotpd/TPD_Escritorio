namespace TPD_C.Ventas
{
 partial class frmExistenciasArticulosRemate
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
   this.button6 = new System.Windows.Forms.Button();
   this.cboLinea = new System.Windows.Forms.ComboBox();
   this.label2 = new System.Windows.Forms.Label();
   this.label1 = new System.Windows.Forms.Label();
   this.btnBuscar = new System.Windows.Forms.Button();
   this.cmbAlmacen = new System.Windows.Forms.ComboBox();
   this.dgvArticulosRemate = new System.Windows.Forms.DataGridView();
   this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Sublinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.puebla = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Merida = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Tuxtla = new System.Windows.Forms.DataGridViewTextBoxColumn();
   this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
   ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosRemate)).BeginInit();
   this.SuspendLayout();
   // 
   // button6
   // 
   this.button6.BackColor = System.Drawing.Color.Silver;
   this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
   this.button6.ForeColor = System.Drawing.Color.White;
   this.button6.Image = global::TPD_C.Properties.Resources.Excel2016;
   this.button6.Location = new System.Drawing.Point(77, 216);
   this.button6.Name = "button6";
   this.button6.Size = new System.Drawing.Size(39, 35);
   this.button6.TabIndex = 24;
   this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
   this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
   this.button6.UseVisualStyleBackColor = false;
   this.button6.Click += new System.EventHandler(this.button6_Click);
   // 
   // cboLinea
   // 
   this.cboLinea.FormattingEnabled = true;
   this.cboLinea.Location = new System.Drawing.Point(15, 26);
   this.cboLinea.Name = "cboLinea";
   this.cboLinea.Size = new System.Drawing.Size(179, 21);
   this.cboLinea.TabIndex = 7;
   // 
   // label2
   // 
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(15, 68);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(48, 13);
   this.label2.TabIndex = 6;
   this.label2.Text = "Almacén";
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(15, 10);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(35, 13);
   this.label1.TabIndex = 5;
   this.label1.Text = "Línea";
   // 
   // btnBuscar
   // 
   this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
   this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
   this.btnBuscar.ForeColor = System.Drawing.Color.MediumBlue;
   this.btnBuscar.Location = new System.Drawing.Point(60, 131);
   this.btnBuscar.Name = "btnBuscar";
   this.btnBuscar.Size = new System.Drawing.Size(79, 41);
   this.btnBuscar.TabIndex = 4;
   this.btnBuscar.Text = "BUSCAR";
   this.btnBuscar.UseVisualStyleBackColor = false;
   this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
   // 
   // cmbAlmacen
   // 
   this.cmbAlmacen.FormattingEnabled = true;
   this.cmbAlmacen.Location = new System.Drawing.Point(15, 87);
   this.cmbAlmacen.Name = "cmbAlmacen";
   this.cmbAlmacen.Size = new System.Drawing.Size(179, 21);
   this.cmbAlmacen.TabIndex = 3;
   // 
   // dgvArticulosRemate
   // 
   this.dgvArticulosRemate.AllowUserToAddRows = false;
   this.dgvArticulosRemate.AllowUserToResizeColumns = false;
   this.dgvArticulosRemate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.dgvArticulosRemate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
   this.dgvArticulosRemate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.dgvArticulosRemate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Descripcion,
            this.Sublinea,
            this.Price,
            this.puebla,
            this.Merida,
            this.Tuxtla,
            this.Total});
   this.dgvArticulosRemate.Location = new System.Drawing.Point(207, 10);
   this.dgvArticulosRemate.Name = "dgvArticulosRemate";
   this.dgvArticulosRemate.Size = new System.Drawing.Size(910, 708);
   this.dgvArticulosRemate.TabIndex = 0;
   // 
   // Articulo
   // 
   this.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Articulo.DataPropertyName = "Articulo";
   this.Articulo.FillWeight = 71.10243F;
   this.Articulo.HeaderText = "Artículo";
   this.Articulo.Name = "Articulo";
   this.Articulo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Articulo.Width = 69;
   // 
   // Descripcion
   // 
   this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Descripcion.DataPropertyName = "Descripcion";
   this.Descripcion.FillWeight = 366.5168F;
   this.Descripcion.HeaderText = "Descripción";
   this.Descripcion.Name = "Descripcion";
   this.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Descripcion.Width = 88;
   // 
   // Sublinea
   // 
   this.Sublinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Sublinea.DataPropertyName = "Sublinea";
   this.Sublinea.FillWeight = 45.68525F;
   this.Sublinea.HeaderText = "Línea";
   this.Sublinea.Name = "Sublinea";
   this.Sublinea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Sublinea.Width = 60;
   // 
   // Price
   // 
   this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Price.DataPropertyName = "Price";
   this.Price.HeaderText = "$PrecioL1";
   this.Price.Name = "Price";
   this.Price.Width = 62;
   // 
   // puebla
   // 
   this.puebla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.puebla.DataPropertyName = "01";
   this.puebla.FillWeight = 39.56837F;
   this.puebla.HeaderText = "Puebla";
   this.puebla.Name = "puebla";
   this.puebla.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.puebla.Width = 65;
   // 
   // Merida
   // 
   this.Merida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Merida.DataPropertyName = "03";
   this.Merida.FillWeight = 38.90356F;
   this.Merida.HeaderText = "Mérida";
   this.Merida.Name = "Merida";
   this.Merida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Merida.Width = 64;
   // 
   // Tuxtla
   // 
   this.Tuxtla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Tuxtla.DataPropertyName = "07";
   this.Tuxtla.FillWeight = 38.22314F;
   this.Tuxtla.HeaderText = "Tuxtla";
   this.Tuxtla.Name = "Tuxtla";
   this.Tuxtla.Resizable = System.Windows.Forms.DataGridViewTriState.False;
   this.Tuxtla.Width = 61;
   // 
   // Total
   // 
   this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
   this.Total.DataPropertyName = "Total";
   this.Total.HeaderText = "Total";
   this.Total.Name = "Total";
   this.Total.Width = 56;
   // 
   // frmExistenciasArticulosRemate
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(1120, 719);
   this.Controls.Add(this.dgvArticulosRemate);
   this.Controls.Add(this.button6);
   this.Controls.Add(this.cboLinea);
   this.Controls.Add(this.label2);
   this.Controls.Add(this.cmbAlmacen);
   this.Controls.Add(this.btnBuscar);
   this.Controls.Add(this.label1);
   this.Name = "frmExistenciasArticulosRemate";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Existencias Artículos en Remate";
   this.Load += new System.EventHandler(this.frmExistenciasArticulosRemate_Load_1);
   ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosRemate)).EndInit();
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion
  private System.Windows.Forms.Button btnBuscar;
  private System.Windows.Forms.ComboBox cmbAlmacen;
  private System.Windows.Forms.Button button6;
  private System.Windows.Forms.ComboBox cboLinea;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvArticulosRemate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sublinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn puebla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Merida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuxtla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
 }
}