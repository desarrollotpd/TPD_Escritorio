<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VacacionesConsulta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VacacionesConsulta))
        Me.DGVacaciones = New System.Windows.Forms.DataGridView()
        Me.CBNomEmp = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBPeriodo = New System.Windows.Forms.ComboBox()
        Me.bExcel = New System.Windows.Forms.Button()
        Me.Estatus = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.FechaIMSSlabel = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbPeriodo = New System.Windows.Forms.RadioButton()
        Me.rbEmpleado = New System.Windows.Forms.RadioButton()
        Me.grbPeriodo = New System.Windows.Forms.GroupBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.grbEmpleado = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelPeriodo = New System.Windows.Forms.Panel()
        Me.dgvPeriodo = New System.Windows.Forms.DataGridView()
        CType(Me.DGVacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Estatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grbPeriodo.SuspendLayout()
        Me.grbEmpleado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelPeriodo.SuspendLayout()
        CType(Me.dgvPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVacaciones
        '
        Me.DGVacaciones.AllowUserToAddRows = False
        Me.DGVacaciones.AllowUserToDeleteRows = False
        Me.DGVacaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVacaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVacaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVacaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVacaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVacaciones.Location = New System.Drawing.Point(13, 37)
        Me.DGVacaciones.Name = "DGVacaciones"
        Me.DGVacaciones.ReadOnly = True
        Me.DGVacaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVacaciones.Size = New System.Drawing.Size(741, 531)
        Me.DGVacaciones.TabIndex = 4
        '
        'CBNomEmp
        '
        Me.CBNomEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBNomEmp.FormattingEnabled = True
        Me.CBNomEmp.Location = New System.Drawing.Point(78, 34)
        Me.CBNomEmp.Name = "CBNomEmp"
        Me.CBNomEmp.Size = New System.Drawing.Size(254, 21)
        Me.CBNomEmp.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Empleado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periodo:"
        Me.Label1.Visible = False
        '
        'CBPeriodo
        '
        Me.CBPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPeriodo.Enabled = False
        Me.CBPeriodo.FormattingEnabled = True
        Me.CBPeriodo.Location = New System.Drawing.Point(69, 124)
        Me.CBPeriodo.Name = "CBPeriodo"
        Me.CBPeriodo.Size = New System.Drawing.Size(127, 21)
        Me.CBPeriodo.TabIndex = 3
        Me.CBPeriodo.Visible = False
        '
        'bExcel
        '
        Me.bExcel.Image = Global.TPDiamante.My.Resources.Resources.Excel_2007
        Me.bExcel.Location = New System.Drawing.Point(300, 67)
        Me.bExcel.Name = "bExcel"
        Me.bExcel.Size = New System.Drawing.Size(32, 29)
        Me.bExcel.TabIndex = 3
        Me.bExcel.UseVisualStyleBackColor = True
        '
        'Estatus
        '
        Me.Estatus.Controls.Add(Me.Label3)
        Me.Estatus.Controls.Add(Me.ProgressBar1)
        Me.Estatus.Location = New System.Drawing.Point(162, 87)
        Me.Estatus.Name = "Estatus"
        Me.Estatus.Size = New System.Drawing.Size(167, 54)
        Me.Estatus.TabIndex = 323
        Me.Estatus.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Cargando archivo"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 29)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(140, 17)
        Me.ProgressBar1.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 16)
        Me.Label5.TabIndex = 324
        Me.Label5.Text = "Num. Empleado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 16)
        Me.Label6.TabIndex = 325
        Me.Label6.Text = "Fecha de Ingreso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 326
        Me.Label8.Text = "Antiguedad:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Location = New System.Drawing.Point(138, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 327
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Location = New System.Drawing.Point(138, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 328
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Location = New System.Drawing.Point(138, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 329
        Me.Label11.Text = "Label11"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.FechaIMSSlabel)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(13, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 177)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Info. Empleado"
        Me.GroupBox1.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label28.Location = New System.Drawing.Point(138, 94)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 16)
        Me.Label28.TabIndex = 335
        Me.Label28.Text = "Label28"
        '
        'FechaIMSSlabel
        '
        Me.FechaIMSSlabel.AutoSize = True
        Me.FechaIMSSlabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaIMSSlabel.Location = New System.Drawing.Point(6, 94)
        Me.FechaIMSSlabel.Name = "FechaIMSSlabel"
        Me.FechaIMSSlabel.Size = New System.Drawing.Size(95, 16)
        Me.FechaIMSSlabel.TabIndex = 334
        Me.FechaIMSSlabel.Text = "Fecha IMSS:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(138, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 333
        Me.Label15.Text = "Label15"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.Location = New System.Drawing.Point(138, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 332
        Me.Label14.Text = "Label14"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 16)
        Me.Label13.TabIndex = 331
        Me.Label13.Text = "Dias Vacaciones:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 16)
        Me.Label12.TabIndex = 330
        Me.Label12.Text = "Nombre:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 483)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(338, 177)
        Me.GroupBox2.TabIndex = 331
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Info. Periodo"
        Me.GroupBox2.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label26.Location = New System.Drawing.Point(229, 131)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(63, 16)
        Me.Label26.TabIndex = 340
        Me.Label26.Text = "Label26"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label25.Location = New System.Drawing.Point(229, 109)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 16)
        Me.Label25.TabIndex = 339
        Me.Label25.Text = "Label25"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label24.Location = New System.Drawing.Point(229, 65)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 16)
        Me.Label24.TabIndex = 338
        Me.Label24.Text = "Label24"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label23.Location = New System.Drawing.Point(229, 43)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 16)
        Me.Label23.TabIndex = 337
        Me.Label23.Text = "Label23"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(229, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 16)
        Me.Label22.TabIndex = 336
        Me.Label22.Text = "Label22"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(229, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 16)
        Me.Label21.TabIndex = 334
        Me.Label21.Text = "Label21"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 131)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 16)
        Me.Label20.TabIndex = 335
        Me.Label20.Text = "Saldo:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 109)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 16)
        Me.Label19.TabIndex = 334
        Me.Label19.Text = "Dias Gozados:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 87)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(202, 16)
        Me.Label18.TabIndex = 334
        Me.Label18.Text = "Dias de vacaciones por ley:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(173, 16)
        Me.Label17.TabIndex = 334
        Me.Label17.Text = "Caducidad Vacaciones:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 16)
        Me.Label16.TabIndex = 334
        Me.Label16.Text = "Inicio Vacaciones:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 16)
        Me.Label7.TabIndex = 334
        Me.Label7.Text = "Periodo Actual"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label27.Location = New System.Drawing.Point(233, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(63, 16)
        Me.Label27.TabIndex = 342
        Me.Label27.Text = "Label27"
        Me.Label27.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 16)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "Dias Gozados por Adelantado:"
        Me.Label2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.grbPeriodo)
        Me.Panel1.Controls.Add(Me.grbEmpleado)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 580)
        Me.Panel1.TabIndex = 343
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbPeriodo)
        Me.GroupBox4.Controls.Add(Me.rbEmpleado)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(10, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(338, 67)
        Me.GroupBox4.TabIndex = 343
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Búsqueda por :"
        '
        'rbPeriodo
        '
        Me.rbPeriodo.AutoSize = True
        Me.rbPeriodo.Location = New System.Drawing.Point(17, 45)
        Me.rbPeriodo.Name = "rbPeriodo"
        Me.rbPeriodo.Size = New System.Drawing.Size(68, 17)
        Me.rbPeriodo.TabIndex = 1
        Me.rbPeriodo.TabStop = True
        Me.rbPeriodo.Text = "Periodo"
        Me.rbPeriodo.UseVisualStyleBackColor = True
        '
        'rbEmpleado
        '
        Me.rbEmpleado.AutoSize = True
        Me.rbEmpleado.Location = New System.Drawing.Point(17, 22)
        Me.rbEmpleado.Name = "rbEmpleado"
        Me.rbEmpleado.Size = New System.Drawing.Size(80, 17)
        Me.rbEmpleado.TabIndex = 0
        Me.rbEmpleado.TabStop = True
        Me.rbEmpleado.Text = "Empleado"
        Me.rbEmpleado.UseVisualStyleBackColor = True
        '
        'grbPeriodo
        '
        Me.grbPeriodo.Controls.Add(Me.dtpFin)
        Me.grbPeriodo.Controls.Add(Me.Label34)
        Me.grbPeriodo.Controls.Add(Me.dtpInicio)
        Me.grbPeriodo.Controls.Add(Me.Label33)
        Me.grbPeriodo.Controls.Add(Me.Label30)
        Me.grbPeriodo.Controls.Add(Me.Label31)
        Me.grbPeriodo.Controls.Add(Me.ComboBox1)
        Me.grbPeriodo.Controls.Add(Me.Button3)
        Me.grbPeriodo.Controls.Add(Me.Label32)
        Me.grbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbPeriodo.Location = New System.Drawing.Point(7, 114)
        Me.grbPeriodo.Name = "grbPeriodo"
        Me.grbPeriodo.Size = New System.Drawing.Size(344, 193)
        Me.grbPeriodo.TabIndex = 343
        Me.grbPeriodo.TabStop = False
        Me.grbPeriodo.Text = "Búsqueda por periodo"
        '
        'dtpFin
        '
        Me.dtpFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFin.Location = New System.Drawing.Point(78, 57)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(254, 20)
        Me.dtpFin.TabIndex = 346
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(7, 57)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(19, 13)
        Me.Label34.TabIndex = 345
        Me.Label34.Text = "A:"
        '
        'dtpInicio
        '
        Me.dtpInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicio.Location = New System.Drawing.Point(78, 27)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(254, 20)
        Me.dtpInicio.TabIndex = 344
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(7, 27)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(27, 13)
        Me.Label33.TabIndex = 343
        Me.Label33.Text = "De:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label30.Location = New System.Drawing.Point(234, 183)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(63, 16)
        Me.Label30.TabIndex = 342
        Me.Label30.Text = "Label30"
        Me.Label30.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 167)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(54, 13)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "Periodo:"
        Me.Label31.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(69, 167)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(127, 21)
        Me.ComboBox1.TabIndex = 3
        Me.ComboBox1.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button3.Location = New System.Drawing.Point(196, 122)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 29)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "CONSULTAR"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(7, 183)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(221, 16)
        Me.Label32.TabIndex = 341
        Me.Label32.Text = "Dias Gozados por Adelantado:"
        Me.Label32.Visible = False
        '
        'grbEmpleado
        '
        Me.grbEmpleado.Controls.Add(Me.Label4)
        Me.grbEmpleado.Controls.Add(Me.bExcel)
        Me.grbEmpleado.Controls.Add(Me.Label27)
        Me.grbEmpleado.Controls.Add(Me.Label1)
        Me.grbEmpleado.Controls.Add(Me.CBPeriodo)
        Me.grbEmpleado.Controls.Add(Me.Button2)
        Me.grbEmpleado.Controls.Add(Me.Label2)
        Me.grbEmpleado.Controls.Add(Me.CBNomEmp)
        Me.grbEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbEmpleado.Location = New System.Drawing.Point(10, 114)
        Me.grbEmpleado.Name = "grbEmpleado"
        Me.grbEmpleado.Size = New System.Drawing.Size(338, 116)
        Me.grbEmpleado.TabIndex = 324
        Me.grbEmpleado.TabStop = False
        Me.grbEmpleado.Text = "Búsqueda por empleado"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Button2.Location = New System.Drawing.Point(196, 67)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 29)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "CONSULTAR"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.panelPeriodo)
        Me.Panel2.Controls.Add(Me.DGVacaciones)
        Me.Panel2.Controls.Add(Me.Estatus)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(358, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(766, 580)
        Me.Panel2.TabIndex = 344
        '
        'panelPeriodo
        '
        Me.panelPeriodo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelPeriodo.Controls.Add(Me.dgvPeriodo)
        Me.panelPeriodo.Location = New System.Drawing.Point(13, 37)
        Me.panelPeriodo.Name = "panelPeriodo"
        Me.panelPeriodo.Size = New System.Drawing.Size(741, 525)
        Me.panelPeriodo.TabIndex = 324
        '
        'dgvPeriodo
        '
        Me.dgvPeriodo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPeriodo.Location = New System.Drawing.Point(0, 0)
        Me.dgvPeriodo.Name = "dgvPeriodo"
        Me.dgvPeriodo.Size = New System.Drawing.Size(741, 525)
        Me.dgvPeriodo.TabIndex = 1
        '
        'VacacionesConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1124, 580)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VacacionesConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Vacaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGVacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Estatus.ResumeLayout(False)
        Me.Estatus.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grbPeriodo.ResumeLayout(False)
        Me.grbPeriodo.PerformLayout()
        Me.grbEmpleado.ResumeLayout(False)
        Me.grbEmpleado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.panelPeriodo.ResumeLayout(False)
        CType(Me.dgvPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGVacaciones As System.Windows.Forms.DataGridView
    Friend WithEvents CBNomEmp As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents bExcel As System.Windows.Forms.Button
    Friend WithEvents Estatus As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents FechaIMSSlabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grbEmpleado As GroupBox
    Friend WithEvents grbPeriodo As GroupBox
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents Label34 As Label
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents Label33 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbPeriodo As RadioButton
    Friend WithEvents rbEmpleado As RadioButton
    Friend WithEvents panelPeriodo As Panel
    Friend WithEvents dgvPeriodo As DataGridView
    Friend WithEvents Button2 As Button
End Class
