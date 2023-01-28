namespace TPD_C.TOP_Operacion
{
    partial class AdministracionPesos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbRutas = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbTarimas = new System.Windows.Forms.ComboBox();
            this.txtOentrega = new System.Windows.Forms.TextBox();
            this.rbTarima = new System.Windows.Forms.RadioButton();
            this.rbOEntrega = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblTotal2 = new System.Windows.Forms.Label();
            this.lblPeso2 = new System.Windows.Forms.Label();
            this.lblCliente2 = new System.Windows.Forms.Label();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPesoR = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTotalsinIva = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntrega = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.totales = new System.Windows.Forms.Label();
            this.lblPiezasTotales = new System.Windows.Forms.Label();
            this.lblpesoTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvOrdenesEntrega = new System.Windows.Forms.DataGridView();
            this.OrdenEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piezastotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalsinIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ruta2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEntrega)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 725);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbRutas);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.cmbTarimas);
            this.groupBox2.Controls.Add(this.txtOentrega);
            this.groupBox2.Controls.Add(this.rbTarima);
            this.groupBox2.Controls.Add(this.rbOEntrega);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 232);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONSULTA";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Ruta";
            // 
            // cmbRutas
            // 
            this.cmbRutas.FormattingEnabled = true;
            this.cmbRutas.Location = new System.Drawing.Point(26, 168);
            this.cmbRutas.Name = "cmbRutas";
            this.cmbRutas.Size = new System.Drawing.Size(208, 21);
            this.cmbRutas.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(84, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "BUSCAR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbTarimas
            // 
            this.cmbTarimas.FormattingEnabled = true;
            this.cmbTarimas.Location = new System.Drawing.Point(26, 106);
            this.cmbTarimas.Name = "cmbTarimas";
            this.cmbTarimas.Size = new System.Drawing.Size(179, 21);
            this.cmbTarimas.TabIndex = 3;
            this.cmbTarimas.SelectedIndexChanged += new System.EventHandler(this.cmbTarimas_SelectedIndexChanged);
            // 
            // txtOentrega
            // 
            this.txtOentrega.Location = new System.Drawing.Point(28, 51);
            this.txtOentrega.Name = "txtOentrega";
            this.txtOentrega.Size = new System.Drawing.Size(177, 20);
            this.txtOentrega.TabIndex = 2;
            this.txtOentrega.TextChanged += new System.EventHandler(this.txtOentrega_TextChanged);
            // 
            // rbTarima
            // 
            this.rbTarima.AutoSize = true;
            this.rbTarima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTarima.Location = new System.Drawing.Point(15, 85);
            this.rbTarima.Name = "rbTarima";
            this.rbTarima.Size = new System.Drawing.Size(63, 17);
            this.rbTarima.TabIndex = 1;
            this.rbTarima.TabStop = true;
            this.rbTarima.Text = "Tarima";
            this.rbTarima.UseVisualStyleBackColor = true;
            this.rbTarima.CheckedChanged += new System.EventHandler(this.rbTarima_CheckedChanged);
            // 
            // rbOEntrega
            // 
            this.rbOEntrega.AutoSize = true;
            this.rbOEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOEntrega.Location = new System.Drawing.Point(15, 30);
            this.rbOEntrega.Name = "rbOEntrega";
            this.rbOEntrega.Size = new System.Drawing.Size(125, 17);
            this.rbOEntrega.TabIndex = 0;
            this.rbOEntrega.TabStop = true;
            this.rbOEntrega.Text = "Orden de Entrega";
            this.rbOEntrega.UseVisualStyleBackColor = true;
            this.rbOEntrega.CheckedChanged += new System.EventHandler(this.rbOEntrega_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.lblTotal2);
            this.groupBox1.Controls.Add(this.lblPeso2);
            this.groupBox1.Controls.Add(this.lblCliente2);
            this.groupBox1.Controls.Add(this.lblCodigo2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblPesoR);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lblTotalsinIva);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblPeso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEntrega);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 464);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Silver;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::TPD_C.Properties.Resources.Excel2016;
            this.button6.Location = new System.Drawing.Point(16, 410);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 35);
            this.button6.TabIndex = 24;
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Silver;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(15, 327);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 26);
            this.button5.TabIndex = 23;
            this.button5.Text = "QUITAR";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblTotal2
            // 
            this.lblTotal2.AutoSize = true;
            this.lblTotal2.Location = new System.Drawing.Point(25, 257);
            this.lblTotal2.Name = "lblTotal2";
            this.lblTotal2.Size = new System.Drawing.Size(13, 13);
            this.lblTotal2.TabIndex = 22;
            this.lblTotal2.Text = "--";
            // 
            // lblPeso2
            // 
            this.lblPeso2.AutoSize = true;
            this.lblPeso2.Location = new System.Drawing.Point(13, 210);
            this.lblPeso2.Name = "lblPeso2";
            this.lblPeso2.Size = new System.Drawing.Size(13, 13);
            this.lblPeso2.TabIndex = 21;
            this.lblPeso2.Text = "--";
            // 
            // lblCliente2
            // 
            this.lblCliente2.AutoSize = true;
            this.lblCliente2.Location = new System.Drawing.Point(13, 171);
            this.lblCliente2.Name = "lblCliente2";
            this.lblCliente2.Size = new System.Drawing.Size(13, 13);
            this.lblCliente2.TabIndex = 20;
            this.lblCliente2.Text = "--";
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.Location = new System.Drawing.Point(12, 131);
            this.lblCodigo2.Name = "lblCodigo2";
            this.lblCodigo2.Size = new System.Drawing.Size(13, 13);
            this.lblCodigo2.TabIndex = 19;
            this.lblCodigo2.Text = "--";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(16, 368);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 26);
            this.button4.TabIndex = 18;
            this.button4.Text = "GUARDAR";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(69, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Kg.";
            // 
            // lblPesoR
            // 
            this.lblPesoR.AutoSize = true;
            this.lblPesoR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoR.Location = new System.Drawing.Point(12, 265);
            this.lblPesoR.Name = "lblPesoR";
            this.lblPesoR.Size = new System.Drawing.Size(0, 15);
            this.lblPesoR.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(25, 316);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 15);
            this.lblTotal.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "$";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(16, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "AGREGAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTotalsinIva
            // 
            this.lblTotalsinIva.AutoSize = true;
            this.lblTotalsinIva.Location = new System.Drawing.Point(6, 311);
            this.lblTotalsinIva.Name = "lblTotalsinIva";
            this.lblTotalsinIva.Size = new System.Drawing.Size(0, 13);
            this.lblTotalsinIva.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "$ TOTAL SIN I.V.A";
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(6, 265);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(0, 13);
            this.lblPeso.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "PESO:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(6, 216);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCliente.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "CLIENTE:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 166);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(0, 13);
            this.lblCodigo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CÓDIGO CLIENTE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ORDEN DE ENTREGA";
            // 
            // txtEntrega
            // 
            this.txtEntrega.Location = new System.Drawing.Point(26, 46);
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(179, 20);
            this.txtEntrega.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(15, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.totales);
            this.panel2.Controls.Add(this.lblPiezasTotales);
            this.panel2.Controls.Add(this.lblpesoTotal);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dgvOrdenesEntrega);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(271, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 725);
            this.panel2.TabIndex = 2;
            // 
            // totales
            // 
            this.totales.AutoSize = true;
            this.totales.Location = new System.Drawing.Point(564, 104);
            this.totales.Name = "totales";
            this.totales.Size = new System.Drawing.Size(13, 13);
            this.totales.TabIndex = 29;
            this.totales.Text = "--";
            // 
            // lblPiezasTotales
            // 
            this.lblPiezasTotales.AutoSize = true;
            this.lblPiezasTotales.Location = new System.Drawing.Point(564, 74);
            this.lblPiezasTotales.Name = "lblPiezasTotales";
            this.lblPiezasTotales.Size = new System.Drawing.Size(13, 13);
            this.lblPiezasTotales.TabIndex = 28;
            this.lblPiezasTotales.Text = "--";
            // 
            // lblpesoTotal
            // 
            this.lblpesoTotal.AutoSize = true;
            this.lblpesoTotal.Location = new System.Drawing.Point(564, 49);
            this.lblpesoTotal.Name = "lblpesoTotal";
            this.lblpesoTotal.Size = new System.Drawing.Size(13, 13);
            this.lblpesoTotal.TabIndex = 25;
            this.lblpesoTotal.Text = "--";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(433, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "$ TOTAL SIN IVA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(460, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "PESO TOTAL:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(433, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "PIEZAS TOTALES:";
            // 
            // dgvOrdenesEntrega
            // 
            this.dgvOrdenesEntrega.AllowUserToAddRows = false;
            this.dgvOrdenesEntrega.AllowUserToResizeColumns = false;
            this.dgvOrdenesEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenesEntrega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenesEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesEntrega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdenEntrega,
            this.CodigoCliente,
            this.Factura,
            this.ClienteNombre,
            this.Piezastotales,
            this.Peso,
            this.TotalsinIVA,
            this.Ruta2});
            this.dgvOrdenesEntrega.Location = new System.Drawing.Point(28, 132);
            this.dgvOrdenesEntrega.Name = "dgvOrdenesEntrega";
            this.dgvOrdenesEntrega.ReadOnly = true;
            this.dgvOrdenesEntrega.Size = new System.Drawing.Size(631, 576);
            this.dgvOrdenesEntrega.TabIndex = 0;
            // 
            // OrdenEntrega
            // 
            this.OrdenEntrega.DataPropertyName = "Entrega";
            this.OrdenEntrega.HeaderText = "Orden de Entrega";
            this.OrdenEntrega.Name = "OrdenEntrega";
            this.OrdenEntrega.ReadOnly = true;
            // 
            // CodigoCliente
            // 
            this.CodigoCliente.DataPropertyName = "CodigoCliente";
            this.CodigoCliente.HeaderText = "Código Cliente";
            this.CodigoCliente.Name = "CodigoCliente";
            this.CodigoCliente.ReadOnly = true;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            this.Factura.ReadOnly = true;
            // 
            // ClienteNombre
            // 
            this.ClienteNombre.DataPropertyName = "ClienteNombre";
            this.ClienteNombre.HeaderText = "Cliente";
            this.ClienteNombre.Name = "ClienteNombre";
            this.ClienteNombre.ReadOnly = true;
            // 
            // Piezastotales
            // 
            this.Piezastotales.DataPropertyName = "Piezastotales";
            this.Piezastotales.HeaderText = "Piezas";
            this.Piezastotales.Name = "Piezastotales";
            this.Piezastotales.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "Peso";
            this.Peso.HeaderText = "Peso (Kg)";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            // 
            // TotalsinIVA
            // 
            this.TotalsinIVA.DataPropertyName = "TotalsinIVA";
            this.TotalsinIVA.HeaderText = "Total";
            this.TotalsinIVA.Name = "TotalsinIVA";
            this.TotalsinIVA.ReadOnly = true;
            // 
            // Ruta2
            // 
            this.Ruta2.DataPropertyName = "Ruta2";
            this.Ruta2.HeaderText = "Ruta";
            this.Ruta2.Name = "Ruta2";
            this.Ruta2.ReadOnly = true;
            // 
            // AdministracionPesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 725);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdministracionPesos";
            this.Text = "AdministracionPesos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdministracionPesos_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesEntrega)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTotalsinIva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEntrega;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrdenesEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPesoR;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTarima;
        private System.Windows.Forms.RadioButton rbOEntrega;
        private System.Windows.Forms.ComboBox cmbTarimas;
        private System.Windows.Forms.TextBox txtOentrega;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblCodigo2;
        private System.Windows.Forms.Label lblCliente2;
        private System.Windows.Forms.Label lblPeso2;
        private System.Windows.Forms.Label lblTotal2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label totales;
        private System.Windows.Forms.Label lblPiezasTotales;
        private System.Windows.Forms.Label lblpesoTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
  private System.Windows.Forms.Label label12;
  private System.Windows.Forms.ComboBox cmbRutas;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdenEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piezastotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalsinIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta2;
    }
}