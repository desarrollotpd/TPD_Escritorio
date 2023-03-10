Imports System.Data.SqlClient

'Imports System.filesys

Public Class FormatoVacaciones

    Dim periodo1 As String
    'Public StrTpm As String = conexion_universal.CadenaSQL
    Public conexion As New SqlConnection(StrTpm)
    'Public conexion2 As New SqlConnection(conexion_universal.CadenaSQL)
    Public DvDetalle As New DataView
    Dim DvLP As New DataView
    Dim strTemp As String = ""
    Dim NumOVta As Long
    Dim NumAuto As Integer
    Dim Antiguedad As Decimal
    Dim NumDiasVac As Integer
    Dim AñosTrascurridos As Integer
    Dim DiaVac As Integer
    Dim Modificado As Integer = 0
    Dim DiasSol As Integer
    Dim FechaIngreso As String
    Dim TopeGlobal As Integer
    Public conexion2 As New SqlConnection(StrTpm)
    Dim dt As DataSet
    Dim DiasRest1 As Integer
    Dim FolioInicio As Integer
    Dim DvAgentes As New DataView
    'BindingSource  
    Private WithEvents bs As New BindingSource
    ' Adaptador de datos sql  
    Private SqlDataAdapter As SqlDataAdapter
    ' Cadena de conexión  
    Private cs As String = conexion_universal.cConstanteTPM
    ' flag  
    Private bEdit As Boolean
    Public StrCon As String = conexion_universal.CadenaSQLSAP
    Private FolioMax As Integer
    Dim SQL As New Comandos_SQL()
    Dim periodoCorrespondiente As String


    Private Sub FormatoVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConsutaLista As String
        SQL.LlenarComboBox2("	SELECT DISTINCT  TPDW1.dbo.dat_empleado.numero_empleado AS Codigo,  TPDW1.dbo.dat_empleado.nombre + ' ' + TPDW1.dbo.dat_empleado.apellido_paterno + ' ' + TPDW1.dbo.dat_empleado.apellido_materno  AS Nombre FROM  TPDW1.dbo.dat_empleado LEFT OUTER JOIN Empleados ON TPDW1.dbo.dat_empleado.numero_empleado = Empleados.NumEmp WHERE  (TPDW1.dbo.dat_empleado.estatus = 0) ORDER BY Nombre", CBNomEmp)

        'Using SqlConnection As New Data.SqlClient.SqlConnection(StrTpm)
        '    'Dim DSetTablas As New DataSet
        '    'ConsutaLista = "SELECT NumEmp,NomEmp+' '+AppEmp+' '+ApmMat AS 'NomEmp' FROM Empleados where Status = 'Activo' and Vacaciones = 'Si' ORDER BY NomEmp "
        '    'Dim daGEmpleado As New SqlClient.SqlDataAdapter(ConsutaLista, SqlConnection)
        '    'Dim DSetTablas As New DataSet
        '    conexion2.Open()
        '    Dim command As SqlCommand
        '    Dim adapter As SqlDataAdapter
        '    Dim dtTable As DataTable = New DataTable
        '    command = New SqlCommand("SP_Consultas", conexion2)
        '    command.CommandType = CommandType.StoredProcedure
        '    command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "ACTIVOS"
        '    command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = 1
        '    command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
        '    adapter = New SqlDataAdapter(command)
        '    adapter.Fill(dtTable)
        '    Dim DSetTablas As New DataSet
        '    'AGREGAR FILA
        '    Dim fila As Data.DataRow
        '    'Asignamos a fila la nueva Row(Fila)del Dataset
        '    fila = DSetTablas.Tables("Empleados").NewRow
        '    'Agregamos los valores a los campos de la tabla
        '    fila("NomEmp") = "--Ningun Resultado--"
        '    fila("NumEmp") = 1010
        '    'Agregamos la fila que acabamos de crear a nuestra tabla del DataSet
        '    DSetTablas.Tables("Empleados").Rows.Add(fila)
        '    DvLP.Table = DSetTablas.Tables("Empleados")
        '    DvLP.RowFilter = "NumEmp <> 1010"
        '    Me.CBNomEmp.DataSource = DvLP
        '    Me.CBNomEmp.DisplayMember = "NomEmp"
        '    Me.CBNomEmp.ValueMember = "NumEmp"
        '    Me.CBNomEmp.SelectedIndex = -1
        'End Using

        'Procedimiento para obtener el número de transacción más actual
        Dim cmdCuenta As New Data.SqlClient.SqlCommand
        Dim FormatWO As String = ""
        cmdCuenta.CommandText = "SELECT MAX(Folio) FROM SolicitudVacaciones "
        cmdCuenta.CommandType = CommandType.Text
        cmdCuenta.Connection = New Data.SqlClient.SqlConnection(StrTpm)
        cmdCuenta.Connection.Open()
        'NumOVta = IIf(IsDBNull(cmdCuenta.ExecuteScalar()), 0, Val(cmdCuenta.ExecuteScalar()))

        With cmdCuenta
            NumOVta = IIf(IsDBNull(.ExecuteScalar()), 0, .ExecuteScalar())
            .Connection.Close()
        End With

        FolioMax = NumOVta

        If FolioMax = 0 Then
            FolioMax = 1
        End If

        NumOVta += 1

        TBFolio.Text = NumOVta
        TBFolio.Text = Format(NumOVta, "0000")
        TBFolio.TextAlign = HorizontalAlignment.Right

        'DisenoGridVArt()

        'CBDiasSol.SelectedIndex = 0

        'DTPFec1.Value = Date.Now
        'DTPFec2.Value = Date.Now
        'DTPFec3.Value = Date.Now
        'DTPFec4.Value = Date.Now
        'DTPFec5.Value = Date.Now

        CBNomEmp.Focus()

        TBDiasRest.Text = ""


        If TBFolio.Text = 1 Then
            PictureBox1.Enabled = False
            PictureBox2.Enabled = False
        End If

    End Sub


    Private Sub LimpiaCampos()
        Try
            TBNumEmp.Text = ""
            CBDiasSol.SelectedValue = 99
            DTPFecIng.Value = Date.Now
            TBAntiguedad.Text = ""
            TBDiasVac.Text = ""
            TBFecIniVac.Text = ""
            TBFecCadVac.Text = ""
            TBDiasRest.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            'DTPFec1.Value = Date.Now
            'DTPFec2.Value = Date.Now
            'DTPFec3.Value = Date.Now
            'DTPFec4.Value = Date.Now
            'DTPFec5.Value = Date.Now
            'CKAut1.Checked = False
            'CKAut2.Checked = False
            'CKAut3.Checked = False
            'CKAut4.Checked = False
            'CKAut5.Checked = False
            'DGVCap.Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub



    Private Sub CBDiasSol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBDiasSol.SelectedIndexChanged

        'If CBDiasSol.Text = "" Then
        '    DTPFec1.Visible = False
        '    DTPFec2.Visible = False
        '    DTPFec3.Visible = False
        '    DTPFec4.Visible = False
        '    DTPFec5.Visible = False

        '    CKAut1.Visible = False
        '    CKAut2.Visible = False
        '    CKAut3.Visible = False
        '    CKAut4.Visible = False
        '    CKAut5.Visible = False

        '    'regresar DTPicker a DIA ACTUAL
        '    DTPFec1.Value = Date.Now
        '    DTPFec2.Value = Date.Now
        '    DTPFec3.Value = Date.Now
        '    DTPFec4.Value = Date.Now
        '    DTPFec5.Value = Date.Now
        '    'desactivar checked
        '    CKAut1.Checked = False
        '    CKAut2.Checked = False
        '    CKAut3.Checked = False
        '    CKAut4.Checked = False
        '    CKAut5.Checked = False



        'ElseIf CBDiasSol.Text = "1" Then
        '    DTPFec1.Visible = True
        '    DTPFec2.Visible = False
        '    DTPFec3.Visible = False
        '    DTPFec4.Visible = False
        '    DTPFec5.Visible = False

        '    CKAut1.Visible = True
        '    CKAut2.Visible = False
        '    CKAut3.Visible = False
        '    CKAut4.Visible = False
        '    CKAut5.Visible = False

        '    'regresar DTPicker a DIA ACTUAL
        '    DTPFec2.Value = Date.Now
        '    DTPFec3.Value = Date.Now
        '    DTPFec4.Value = Date.Now
        '    DTPFec5.Value = Date.Now
        '    'desactivar checked
        '    CKAut2.Checked = False
        '    CKAut3.Checked = False
        '    CKAut4.Checked = False
        '    CKAut5.Checked = False

        'ElseIf CBDiasSol.Text = "2" Then
        '    DTPFec1.Visible = True
        '    DTPFec2.Visible = True
        '    DTPFec3.Visible = False
        '    DTPFec4.Visible = False
        '    DTPFec5.Visible = False

        '    CKAut1.Visible = True
        '    CKAut2.Visible = True
        '    CKAut3.Visible = False
        '    CKAut4.Visible = False
        '    CKAut5.Visible = False

        '    'regresar DTPicker a DIA ACTUAL
        '    DTPFec3.Value = Date.Now
        '    DTPFec4.Value = Date.Now
        '    DTPFec5.Value = Date.Now
        '    'desactivar checked
        '    CKAut3.Checked = False
        '    CKAut4.Checked = False
        '    CKAut5.Checked = False

        'ElseIf CBDiasSol.Text = "3" Then
        '    DTPFec1.Visible = True
        '    DTPFec2.Visible = True
        '    DTPFec3.Visible = True
        '    DTPFec4.Visible = False
        '    DTPFec5.Visible = False

        '    CKAut1.Visible = True
        '    CKAut2.Visible = True
        '    CKAut3.Visible = True
        '    CKAut4.Visible = False
        '    CKAut5.Visible = False

        '    'regresar DTPicker a DIA ACTUAL
        '    DTPFec4.Value = Date.Now
        '    DTPFec5.Value = Date.Now
        '    'desactivar checked
        '    CKAut4.Checked = False
        '    CKAut5.Checked = False

        'ElseIf CBDiasSol.Text = "4" Then
        '    DTPFec1.Visible = True
        '    DTPFec2.Visible = True
        '    DTPFec3.Visible = True
        '    DTPFec4.Visible = True

        '    CKAut1.Visible = True
        '    CKAut2.Visible = True
        '    CKAut3.Visible = True
        '    CKAut4.Visible = True

        '    'regresar DTPicker a DIA ACTUAL
        '    DTPFec5.Value = Date.Now
        '    'desactivar checked
        '    CKAut5.Checked = False

        'ElseIf CBDiasSol.Text = "5" Then
        '    DTPFec1.Visible = True
        '    DTPFec2.Visible = True
        '    DTPFec3.Visible = True
        '    DTPFec4.Visible = True
        '    DTPFec5.Visible = True

        '    CKAut1.Visible = True
        '    CKAut2.Visible = True
        '    CKAut3.Visible = True
        '    CKAut4.Visible = True
        '    CKAut5.Visible = True

        'End If



    End Sub




    Private Sub Actualizar(Optional ByVal bCargar As Boolean = True)
        ' Actualizar y guardar cambios  
        'If Not bs.DataSource Is Nothing Then
        '    SqlDataAdapter.Update(CType(bs.DataSource, DataTable))
        '    If bCargar Then
        '        'cargar_registros("Select * from SC_Objetivos order by anio DESC, mes DESC, groupname DESC, slpname", DGObjetivos)
        '        'cargar_registros("Select * from SC_Objetivos where mes = " & Month(Now) & " order by anio DESC, mes DESC, groupcode DESC, slpname", DGObjetivos)

        '        cargar_registros("SELECT '',0,NULL,NULL," & TBDiasVac.Text & " UNION ALL SELECT *,1,0 FROM SolVacacionesHistorico WHERE NumEmpleado=" & TBNumEmp.Text & "AND Periodo=" & TBPeriodoCom.Text & "", DGVacaciones)

        '        Disenogrid()

        '        'If DGVacaciones.RowCount > 1 Then
        '        '    For i = 1 To DGVacaciones.RowCount - 1
        '        '        DGVacaciones.Item(4, i).Value = TBDiasVac.Text - i
        '        '    Next
        '        'End If

        '    End If
        'End If
    End Sub

    'Private Sub Disenogrid()
    '    With DGVacaciones
    '        ' Establecer el origen de datos para el DataGridview  
    '        DGVacaciones.DataSource = bs

    '        ' alternar color de filas  
    '        .AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
    '        .DefaultCellStyle.BackColor = Color.CornflowerBlue
    '        .DefaultCellStyle.BackColor = Color.AliceBlue
    '        .DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
    '        '.RowsDefaultCellStyle = 

    '        'Propiedad para no mostrar el cuadro que se encuentra en la parte
    '        'Superior Izquierda del gridview
    '        .RowHeadersVisible = False
    '        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        'Color de linea del grid

    '        'centrar encabezados del datagrid 
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    '        Try
    '            .Columns(0).Visible = False
    '            .Columns(0).HeaderText = "No. Empleado"
    '            .Columns(0).Width = 40
    '            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '            .Columns(1).Visible = False
    '            .Columns(1).HeaderText = "Ejercicio"
    '            .Columns(1).Width = 40
    '            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    '            .Columns(2).HeaderText = "Histórico"
    '            .Columns(2).Width = 100
    '            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '            .Columns(3).HeaderText = "Días Tomados"
    '            .Columns(3).Width = 70
    '            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '            .Columns(4).HeaderText = "Días restantes"
    '            .Columns(4).Width = 70
    '            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '            'If DGVacaciones.RowCount > 1 Then
    '            '    If DGVacaciones.RowCount > 1 Then
    '            '        For i = 1 To DGVacaciones.RowCount - 1
    '            '            DGVacaciones.Item(4, i).Value = TBDiasVac.Text - i
    '            '        Next
    '            '    End If
    '            'End If

    '        Catch ex As Exception
    '            'MsgBox(ex.Message)
    '        End Try

    '    End With
    'End Sub


    Private Sub GenerarDiasVac(ByVal dia As String, ByVal periodo As String)
        'MsgBox("entre " & Convert.ToDateTime(dia).ToString & "--" & periodo)
        'If CmbAgteVta.SelectedValue = 999 And Mes <> 99 Then
        '---Inserta objetivos en 0 de todos los AGENTES 
        '----PROCEDIMIENTO

        Dim conexion As New SqlConnection(StrTpm)
        Dim command As New SqlCommand("SPInsertDiasAtzado", conexion)

        Try

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Folio", TBFolio.Text)
            command.Parameters.AddWithValue("@NumEmpleado", TBNumEmp.Text)
            command.Parameters.AddWithValue("@Periodo", periodo)
            command.Parameters.AddWithValue("@DiaSol", Convert.ToDateTime(dia))
            command.Parameters.AddWithValue("@DiasRest", 0)


            'If DiaVac = 1 Then
            '    'MsgBox(DGVCap.Item("Restantes", 0).Value.ToString)
            '    command.Parameters.AddWithValue("@DiaSol", DTPFec1.Value)
            '    command.Parameters.AddWithValue("@DiasRest", DGVCap.Item("Restantes", 0).Value.ToString)
            'ElseIf DiaVac = 2 Then
            '    command.Parameters.AddWithValue("@DiaSol", DTPFec2.Value)
            '    command.Parameters.AddWithValue("@DiasRest", DGVCap.Item("Restantes", 1).Value.ToString)
            'ElseIf DiaVac = 3 Then
            '    command.Parameters.AddWithValue("@DiaSol", DTPFec3.Value)
            '    command.Parameters.AddWithValue("@DiasRest", DGVCap.Item("Restantes", 2).Value.ToString)
            'ElseIf DiaVac = 4 Then
            '    command.Parameters.AddWithValue("@DiaSol", DTPFec4.Value)
            '    command.Parameters.AddWithValue("@DiasRest", DGVCap.Item("Restantes", 3).Value.ToString)
            'ElseIf DiaVac = 5 Then
            '    command.Parameters.AddWithValue("@DiaSol", DTPFec5.Value)
            '    command.Parameters.AddWithValue("@DiasRest", DGVCap.Item("Restantes", 4).Value.ToString)
            'End If

            conexion.Open()
            command.ExecuteNonQuery()
            'cargar_registros("SELECT ''  AS 'NumEmpleado',0 'Periodo',NULL 'DiaSol',NULL 'DiasTomados'," & TBDiasVac.Text & _
            '                         " 'DiasRest' UNION ALL SELECT NumEmpleado,Periodo,DiaSol,1,0 FROM SolVacacionesHistorico WHERE NumEmpleado='" & _
            '                         TBNumEmp.Text & "' AND Periodo=" & TBPeriodoCom.SelectedValue.ToString & " ORDER BY NumEmpleado,DiaSol DESC", DGVacaciones)

            'If DGVacaciones.RowCount > 1 Then
            '    For i = 1 To DGVacaciones.RowCount - 2
            '        DGVacaciones.Item(4, i).Value = TBDiasVac.Text - i
            '    Next
            'End If

            'TBDiasRest.Text = TBDiasRest.Text - 1

            Modificado = 1


            'If Antiguedad < 1 And Convert.ToInt32(TBDiasRest.Text) = -6 Then
            '    'TBPeriodoCom.Text = TBPeriodoCom.Text + 1
            'ElseIf Convert.ToInt32(TBDiasVac.Text) < Convert.ToInt32(TBDiasRest.Text) Then
            '    'TBPeriodoCom.Text = TBPeriodoCom.Text + 1
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MsgBox("Estos registros ya existen")
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try

        'MsgBox("el valor de mes es: " & Mes)

        'End If
    End Sub

    Private Sub EliminarDiasVac()

        'If CmbAgteVta.SelectedValue = 999 And Mes <> 99 Then
        '---Inserta objetivos en 0 de todos los AGENTES 
        '----PROCEDIMIENTO
        'For i As Integer = 0 To DGVCap.RowCount - 1
        Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
        Dim command As New SqlCommand("SPEliminaDiasAtzado", conexion)
        Try



            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Folio", TBFolio.Text)
            command.Parameters.AddWithValue("@NumEmpleado", TBNumEmp.Text)
            command.Parameters.AddWithValue("@Periodo", TBPeriodoCom.SelectedValue.ToString)

            If DiaVac = 1 Then
                command.Parameters.AddWithValue("@DiaSol", DTPFec1.Value)
            ElseIf DiaVac = 2 Then
                command.Parameters.AddWithValue("@DiaSol", DTPFec2.Value)
            ElseIf DiaVac = 3 Then
                command.Parameters.AddWithValue("@DiaSol", DTPFec3.Value)
            ElseIf DiaVac = 4 Then
                command.Parameters.AddWithValue("@DiaSol", DTPFec4.Value)
            ElseIf DiaVac = 5 Then
                command.Parameters.AddWithValue("@DiaSol", DTPFec5.Value)
            End If

            conexion.Open()
            command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MsgBox("Estos registros ya existen")
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try

        'Next

        'cargar_registros("SELECT ''  AS 'NumEmpleado',0 'Periodo',NULL 'DiaSol',NULL 'DiasTomados'," & TBDiasVac.Text & _
        '                         " 'DiasRest' UNION ALL SELECT NumEmpleado,Periodo,DiaSol,1,0 FROM SolVacacionesHistorico WHERE NumEmpleado='" & _
        '                         TBNumEmp.Text & "' AND Periodo=" & TBPeriodoCom.SelectedValue.ToString & " ORDER BY NumEmpleado,DiaSol DESC", DGVacaciones)

        'If DGVacaciones.RowCount > 1 Then
        '    For i = 1 To DGVacaciones.RowCount - 2
        '        DGVacaciones.Item(4, i).Value = TBDiasVac.Text - i
        '    Next
        'End If


        TBDiasRest.Text = TBDiasRest.Text + 1


        'MsgBox("el valor de mes es: " & Mes)

        'End If
    End Sub

    Private Sub CKAut1_Click(sender As Object, e As EventArgs) Handles CKAut1.Click
        'MsgBox(TBDiasRest.Text.ToString)
        If CBNomEmp.Text <> "" Then

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = 0
            End If

            If CKAut1.Checked = True Then

                'If DGVacaciones.RowCount > 1 Then

                '    'MsgBox(DTPFec1.Text)

                '    For i As Integer = 1 To DGVacaciones.RowCount - 1
                '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                '        If DTPFec1.Text = DGVacaciones.Item(2, i).Value Then
                '            'MsgBox("El artículo ya ha sido agregado.")

                '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
                '                            "seleccione otro para continuar.", "Error al agregar.",
                '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                '            CKAut1.Checked = False
                '            Return
                '        End If
                '    Next

                'End If

                If (MessageBox.Show(
                                     "¿Confirma autorización del día " & DTPFec1.Text & "? ",
                                     "Proceso de autorización.", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 1

                    'GenerarDiasVac()

                    NumAuto = TBDiasAut.Text + 1

                    Try
                        TBDiasRest.Text = TBDiasRest.Text - 1
                        DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TBPeriodoCom.Text, DTPFec1.Text.ToString, TBDiasRest.Text)
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut1.Checked = False
                End If

            Else 'si checked = false
                If (MessageBox.Show(
                                    "¿Confirma que desea quitar autorización del día " & DTPFec1.Text & "? ",
                                    "Proceso de autorización.", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 1

                    EliminarDiasVac()

                    NumAuto = TBDiasAut.Text - 1

                    Try
                        For i As Integer = 0 To DGVCap.RowCount - 1
                            'MsgBox(DTPFec1.Text)
                            'MsgBox(DGVCap.Item(3, i).Value)
                            'Dim auxfec1 As String = DTPFec1.Text.ToString

                            If DTPFec1.Text = DGVCap.Item(3, i).Value Then
                                'MsgBox("verdadero")

                                DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)

                                DGVCap.Rows(i).Selected = True

                                Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut1.Checked = True
                End If

            End If

            TBDiasAut.Text = NumAuto

        End If

    End Sub

    Private Sub CKAut2_Click(sender As Object, e As EventArgs) Handles CKAut2.Click

        If CBNomEmp.Text <> "" Then

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = 0
            End If

            If CKAut2.Checked = True Then

                'If DGVacaciones.RowCount > 1 Then

                '    'MsgBox(DTPFec1.Text)

                '    For i As Integer = 1 To DGVacaciones.RowCount - 1
                '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                '        If DTPFec2.Text = DGVacaciones.Item(2, i).Value Then
                '            'MsgBox("El artículo ya ha sido agregado.")

                '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
                '                            "seleccione otro para continuar.", "Error al agregar.",
                '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                '            CKAut2.Checked = False
                '            Return
                '        End If
                '    Next

                'End If

                If (MessageBox.Show(
                                     "¿Confirma autorización del día " & DTPFec2.Text & "? ",
                                     "Proceso de autorización.", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 2

                    'GenerarDiasVac()

                    NumAuto = TBDiasAut.Text + 1

                    Try
                        TBDiasRest.Text = TBDiasRest.Text - 1
                        Me.DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TBPeriodoCom.Text, DTPFec2.Text, TBDiasRest.Text)
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut2.Checked = False
                End If

            Else 'si checked = false
                If (MessageBox.Show(
                                    "¿Confirma que desea quitar autorización del día " & DTPFec2.Text & "? ",
                                    "Proceso de autorización.", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 2

                    EliminarDiasVac()

                    NumAuto = TBDiasAut.Text - 1

                    Try
                        For i As Integer = 0 To DGVCap.RowCount - 1
                            'MsgBox(DTPFec1.Text)
                            'MsgBox(DGVCap.Item(3, i).Value)
                            'Dim auxfec1 As String = DTPFec1.Text.ToString

                            If DTPFec2.Text = DGVCap.Item(3, i).Value Then
                                'MsgBox("verdadero")
                                DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)
                                Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut2.Checked = True
                End If

            End If

            TBDiasAut.Text = NumAuto

        End If
    End Sub


    Private Sub CKAut3_Click(sender As Object, e As EventArgs) Handles CKAut3.Click

        If CBNomEmp.Text <> "" Then

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = 0
            End If

            If CKAut3.Checked = True Then

                'If DGVacaciones.RowCount > 1 Then

                '    'MsgBox(DTPFec1.Text)

                '    For i As Integer = 1 To DGVacaciones.RowCount - 1
                '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                '        If DTPFec3.Text = DGVacaciones.Item(2, i).Value Then
                '            'MsgBox("El artículo ya ha sido agregado.")

                '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
                '                            "seleccione otro para continuar.", "Error al agregar.",
                '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                '            CKAut3.Checked = False
                '            Return
                '        End If
                '    Next

                'End If

                If (MessageBox.Show(
                                     "¿Confirma autorización del día " & DTPFec3.Text & "? ",
                                     "Proceso de autorización.", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 3

                    'GenerarDiasVac()

                    NumAuto = TBDiasAut.Text + 1

                    Try
                        TBDiasRest.Text = TBDiasRest.Text - 1
                        Me.DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TBPeriodoCom.Text, DTPFec3.Text, TBDiasRest.Text)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Else
                    CKAut3.Checked = False
                End If

            Else 'si checked = false
                If (MessageBox.Show(
                                    "¿Confirma que desea quitar autorización del día " & DTPFec3.Text & "? ",
                                    "Proceso de autorización.", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 3

                    EliminarDiasVac()

                    NumAuto = TBDiasAut.Text - 1

                    Try
                        For i As Integer = 0 To DGVCap.RowCount - 1
                            'MsgBox(DTPFec1.Text)
                            'MsgBox(DGVCap.Item(3, i).Value)
                            'Dim auxfec1 As String = DTPFec1.Text.ToString

                            If DTPFec3.Text = DGVCap.Item(3, i).Value Then
                                'MsgBox("verdadero")
                                DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)

                                Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut3.Checked = True
                End If

            End If

            TBDiasAut.Text = NumAuto

        End If

    End Sub

    Private Sub CKAut4_Click(sender As Object, e As EventArgs) Handles CKAut4.Click

        If CBNomEmp.Text <> "" Then

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = 0
            End If

            If CKAut4.Checked = True Then

                'If DGVacaciones.RowCount > 1 Then

                '    'MsgBox(DTPFec1.Text)

                '    For i As Integer = 1 To DGVacaciones.RowCount - 1
                '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                '        If DTPFec4.Text = DGVacaciones.Item(2, i).Value Then
                '            'MsgBox("El artículo ya ha sido agregado.")

                '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
                '                            "seleccione otro para continuar.", "Error al agregar.",
                '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                '            CKAut4.Checked = False
                '            Return
                '        End If
                '    Next

                'End If

                If (MessageBox.Show(
                                     "¿Confirma autorización del día " & DTPFec4.Text & "? ",
                                     "Proceso de autorización.", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 4

                    'GenerarDiasVac()

                    NumAuto = TBDiasAut.Text + 1

                    Try
                        TBDiasRest.Text = TBDiasRest.Text - 1
                        Me.DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TBPeriodoCom.Text, DTPFec4.Text, TBDiasRest.Text)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Else
                    CKAut4.Checked = False
                End If

            Else 'si checked = false
                If (MessageBox.Show(
                                    "¿Confirma que desea quitar autorización del día " & DTPFec4.Text & "? ",
                                    "Proceso de autorización.", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 4

                    EliminarDiasVac()

                    NumAuto = TBDiasAut.Text - 1

                    Try
                        For i As Integer = 0 To DGVCap.RowCount - 1
                            'MsgBox(DTPFec1.Text)
                            'MsgBox(DGVCap.Item(3, i).Value)
                            'Dim auxfec1 As String = DTPFec1.Text.ToString

                            If DTPFec4.Text = DGVCap.Item(3, i).Value Then
                                'MsgBox("verdadero")
                                DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)
                                Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut4.Checked = True
                End If

            End If

            TBDiasAut.Text = NumAuto

        End If

    End Sub

    Private Sub CKAut5_Click(sender As Object, e As EventArgs) Handles CKAut5.Click

        If CBNomEmp.Text <> "" Then

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = 0
            End If

            If CKAut5.Checked = True Then

                'If DGVacaciones.RowCount > 1 Then

                '    'MsgBox(DTPFec1.Text)

                '    For i As Integer = 1 To DGVacaciones.RowCount - 1
                '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                '        If DTPFec5.Text = DGVacaciones.Item(2, i).Value Then
                '            'MsgBox("El artículo ya ha sido agregado.")

                '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
                '                            "seleccione otro para continuar.", "Error al agregar.",
                '            MessageBoxButtons.OK, MessageBoxIcon.Information)

                '            CKAut5.Checked = False
                '            Return
                '        End If
                '    Next

                'End If

                If (MessageBox.Show(
                                     "¿Confirma autorización del día " & DTPFec5.Text & "? ",
                                     "Proceso de autorización.", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 5

                    'GenerarDiasVac()

                    NumAuto = TBDiasAut.Text + 1

                    Try
                        TBDiasRest.Text = TBDiasRest.Text - 1
                        Me.DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TBPeriodoCom.Text, DTPFec5.Text, TBDiasRest.Text)
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut5.Checked = False
                End If

            Else 'si checked = false
                If (MessageBox.Show(
                                    "¿Confirma que desea quitar autorización del día " & DTPFec5.Text & "? ",
                                    "Proceso de autorización.", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                    DiaVac = 5

                    EliminarDiasVac()

                    NumAuto = TBDiasAut.Text - 1

                    Try
                        For i As Integer = 0 To DGVCap.RowCount - 1
                            'MsgBox(DTPFec1.Text)
                            'MsgBox(DGVCap.Item(3, i).Value)
                            'Dim auxfec1 As String = DTPFec1.Text.ToString

                            If DTPFec5.Text = DGVCap.Item(3, i).Value Then
                                'MsgBox("verdadero")
                                DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)
                                Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try

                Else
                    CKAut5.Checked = True
                End If

            End If

            TBDiasAut.Text = NumAuto

        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        FolioInicio = TBFolio.Text
        Dim vSinValor As Integer = 0

        If (CBNomEmp.SelectedIndex.ToString = "-1") Then
            MessageBox.Show("Selecciona un Empleado", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'BtnImprimir.Enabled = True
            Return
        End If


        If DGVCap.RowCount < 1 Then
            vSinValor = 1
        End If

        If vSinValor = 1 Then
            MessageBox.Show("No hay días de vacaciones autorizados. Verifique.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'BtnImprimir.Enabled = True
            Return
        End If

        Try
            If CBNomEmp.Text <> "" Then

                If (MessageBox.Show(
                                        "¿Confirma que desea guardar esta solicitud de vacaciones? ",
                                        "Guardar solicitud.", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then



                    'If CKAut1.Checked = True Then
                    '    iteracion = 1
                    'End If
                    'If CKAut2.Checked = True Then
                    '    iteracion = 2
                    'End If
                    'If CKAut3.Checked = True Then
                    '    iteracion = 3
                    'End If
                    'If CKAut4.Checked = True Then
                    '    iteracion = 4
                    'End If
                    'If CKAut5.Checked = True Then
                    '    iteracion = 5
                    'End If

                    'MsgBox(iteracion)
                    'Dim row As DataGridViewRow = DGVCap.Rows(e.RowIndex)

                    Dim row As DataGridViewRow

                    Dim periodo3 As Integer
                    Dim i2 As Integer = 0

                    For it As Integer = 0 To (DGVCap.RowCount) - 1
                        row = DGVCap.Rows(it)
                        'MsgBox(row.Cells("Periodo").Value.ToString.Substring(0, 4) & " -- " & row.Cells("DiaSol").Value.ToString)

                        If periodo3 <> row.Cells("Periodo").Value.ToString.Substring(0, 4) Then
                            i2 = i2 + 1
                            If i2 = 2 Then
                                TBFolio.Text = CInt(TBFolio.Text) + 1
                            End If
                            periodo3 = row.Cells("Periodo").Value.ToString.Substring(0, 4)
                        End If

                        GenerarDiasVac(row.Cells("DiaSol").Value.ToString, row.Cells("Periodo").Value.ToString.Substring(0, 4))
                    Next

                    'For it As Integer = 0 To iteracion - 1
                    '    DiaVac = it + 1
                    '    GenerarDiasVac()
                    'Next

                    TBFolio.Text = FolioInicio

                    'Return

                    Dim row1 As DataGridViewRow
                    Dim periodo2 As Integer
                    Dim i1 As Integer = 0
                    Dim PeriodoDias As Integer
                    For it As Integer = 0 To (DGVCap.RowCount) - 1
                        row1 = DGVCap.Rows(it)
                        'MsgBox(row.Cells("Periodo").Value.ToString.Substring(0, 4) & " -- " & row.Cells("DiaSol").Value.ToString)
                        PeriodoDias = CInt(row1.Cells("DiasVac").Value)
                        If periodo2 <> row1.Cells("Periodo").Value.ToString.Substring(0, 4) Then
                            DiasRest1 = CInt(row1.Cells("DiasRest").Value)
                            i1 = i1 + 1
                            If i1 = 2 Then
                                TBFolio.Text = CInt(TBFolio.Text) + 1
                            End If
                            periodo2 = row1.Cells("Periodo").Value.ToString.Substring(0, 4)
                            GenerarSolicitudVac(PeriodoDias, periodo2)

                        Else
                            DiasRest1 = CInt(row1.Cells("DiasRest").Value)
                            Actualizar1()

                        End If


                    Next




                    Me.DGVCap.Columns("Borrar").Visible = False
                    MessageBox.Show("Registros guardados correctamente.", "Operación exitosa.", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information)

                    Modificado = 0

                    TBNumEmp.Enabled = False
                    ' CBNomEmp.Enabled = False
                    CBDiasSol.Enabled = False
                    txttipo.Text = ""
                    BtnImprimir.Enabled = True
                    BtnNvo.Enabled = True
                    BSave.Enabled = False
                    CBNomEmp.Text = ""

                Else
                    Modificado = 1
                End If

            Else

                'If CKAut1.Checked = False And CKAut2.Checked = False And CKAut3.Checked = False And CKAut4.Checked = False And CKAut5.Checked = False Then

                '    MessageBox.Show("No hay días autorizados. Verifique. ", _
                '                         "Guardar solicitud.", MessageBoxButtons.OK, _
                '                         MessageBoxIcon.Exclamation)
                '    Return
                'End If

                'If (MessageBox.Show( _
                '             "¿Confirma que desea asignar este día de vacaciones para todos los empleados? ", _
                '             "Guardar solicitud.", MessageBoxButtons.YesNo, _
                '             MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                '    GenerarSolicitudVacTODOS()

                '    BSave.Enabled = False
                '    BtnNvo.Enabled = True
                '    BtnImprimir.Enabled = False

                '    MessageBox.Show("Registros guardados correctamente.", "Operación exitosa.", MessageBoxButtons.OK, _
                '    MessageBoxIcon.Information)

                'Else
                '    Modificado = 1
                'End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        LimpiaCampos()
        TBPeriodoCom.Enabled = False
        'Me.Enabled = False
        'BtnImprimir.Enabled = True
    End Sub

    Private Sub FormatoVacaciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Modificado = 1 Then

            If DGVCap.RowCount > 0 Then
                Try
                    If (MessageBox.Show(
                                               "¿Desea guardar los cambios realizados? ",
                                               "Guardar solicitud.", MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                        GenerarSolicitudVac(0, 0)

                        MessageBox.Show("Registros guardados correctamente.", "Operación exitosa.", MessageBoxButtons.OK,
                                         MessageBoxIcon.Information)

                    Else

                        EliminarHistorico()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub Actualizar1()
        Dim conexion3 As New SqlConnection(StrTpm)
        conexion3.Open()

        Dim command3 As New SqlCommand("SP_Consultas", conexion3)
        Try
            command3.CommandType = CommandType.StoredProcedure
            command3.Parameters.AddWithValue("@opcion", "ACTUALIZAR")
            command3.Parameters.AddWithValue("@id", TBFolio.Text)
            command3.Parameters.AddWithValue("@Periodo", CStr(DiasRest1))



            command3.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MsgBox("Estos registros ya existen")
        Finally
            conexion.Dispose()
            command3.Dispose()
        End Try

    End Sub
    Private Sub GenerarSolicitudVac(PeriodoDias As Integer, periodon As String)
        '----PROCEDIMIENTO 1
        Dim conexion As New SqlConnection(StrTpm)
        Dim command As New SqlCommand("SPGuardaSol", conexion)
        Try
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Folio", TBFolio.Text)
            command.Parameters.AddWithValue("@FechaSol", DTPFecSol.Value)
            command.Parameters.AddWithValue("@NumEmpleado", TBNumEmp.Text)
            command.Parameters.AddWithValue("@NomEmpleado", CBNomEmp.Text)
            command.Parameters.AddWithValue("@FechaIMSS", Convert.ToDateTime(TextBox1.Text.ToString))
            command.Parameters.AddWithValue("@Antiguedad", TBAntiguedad.Text)
            command.Parameters.AddWithValue("@DiasVac", PeriodoDias)
            command.Parameters.AddWithValue("@FecIniVac", Date.Parse(TBFecIniVac.Text).Date.ToString("yyyyMMdd"))
            command.Parameters.AddWithValue("@FecCadVac", Date.Parse(TBFecCadVac.Text).Date.ToString("yyyyMMdd"))
            command.Parameters.AddWithValue("@Periodo", periodon) ' TextBox2.Text.ToString.Substring(0, 4))
            command.Parameters.AddWithValue("@DiasRest", DiasRest1)
            command.Parameters.AddWithValue("@DiasSol", 0)
            command.Parameters.AddWithValue("@DiasAut", 0)

            conexion.Open()
            command.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MsgBox("Estos registros ya existen")
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try

    End Sub

    Private Sub GenerarSolicitudVacTODOS()
        'MsgBox("ey2")
        '----PROCEDIMIENTO 1
        If CKAut1.Checked = True Then
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPGuardaSolTODOS", conexion)
            Try
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@FechaSol", DTPFec1.Value)

                conexion.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try
        End If

        If CKAut2.Checked = True Then
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPGuardaSolTODOS", conexion)
            Try
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@FechaSol", DTPFec2.Value)

                conexion.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try
        End If

        If CKAut3.Checked = True Then
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPGuardaSolTODOS", conexion)
            Try
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@FechaSol", DTPFec3.Value)

                conexion.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try
        End If

        If CKAut4.Checked = True Then
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPGuardaSolTODOS", conexion)
            Try
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@FechaSol", DTPFec4.Value)

                conexion.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try
        End If

        If CKAut5.Checked = True Then
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPGuardaSolTODOS", conexion)
            Try
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@FechaSol", DTPFec5.Value)

                conexion.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try
        End If




    End Sub

    Private Sub EliminarSolicitudVac()
        '----PROCEDIMIENTO 1
        Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
        Dim command As New SqlCommand("SPEliminaDias", conexion)
        Try
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Folio", TBFolio.Text)
            command.Parameters.AddWithValue("@FechaSol", DTPFecSol.Value)
            command.Parameters.AddWithValue("@NumEmpleado", TBNumEmp.Text)
            command.Parameters.AddWithValue("@FecIniVac", Date.Parse(TBFecIniVac.Text).Date.ToString("yyyyMMdd"))
            command.Parameters.AddWithValue("@FecCadVac", Date.Parse(TBFecCadVac.Text).Date.ToString("yyyyMMdd"))


            conexion.Open()
            command.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MsgBox("Estos registros ya existen")
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try

    End Sub

    Private Sub CBDiasSol_Click(sender As Object, e As EventArgs) Handles CBDiasSol.Click
        'If TBNumEmp.Text = "" Then
        '    MessageBox.Show( _
        '              "Ingrese número o nombre de empleado.", _
        '              "Seleccione empleado.", MessageBoxButtons.OK, _
        '              MessageBoxIcon.Exclamation)

        '    TBNumEmp.Focus()

        'End If
    End Sub


    Private Sub EliminarHistorico()

        'If CmbAgteVta.SelectedValue = 999 And Mes <> 99 Then
        '---Inserta objetivos en 0 de todos los AGENTES 
        '----PROCEDIMIENTO
        For i As Integer = 0 To DGVCap.RowCount - 1
            Dim conexion As New SqlConnection(conexion_universal.CadenaSQL)
            Dim command As New SqlCommand("SPEliminaDiasAtzado", conexion)
            Try



                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@Folio", DGVCap.Item(0, i).Value)
                command.Parameters.AddWithValue("@NumEmpleado", DGVCap.Item(1, i).Value)
                command.Parameters.AddWithValue("@Periodo", DGVCap.Item(2, i).Value)
                command.Parameters.AddWithValue("@DiaSol", Date.Parse(DGVCap.Item(3, i).Value).Date.ToString("yyyyMMdd"))

                conexion.Open()
                command.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'MsgBox("Estos registros ya existen")
            Finally
                conexion.Dispose()
                command.Dispose()
            End Try

        Next
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim row1 As DataGridViewRow
        Dim periodo2 As Integer
        Dim i1 As Integer = 0
        Dim folio As Integer
        For it As Integer = 0 To (DGVCap.RowCount) - 1
            row1 = DGVCap.Rows(it)
            'MsgBox(row.Cells("Periodo").Value.ToString.Substring(0, 4) & " -- " & row.Cells("DiaSol").Value.ToString)
            If periodo2 <> row1.Cells("Periodo").Value.ToString.Substring(0, 4) Then
                'DiasRest1 = CInt(row1.Cells("DiasRest").Value)
                i1 = i1 + 1
                If i1 = 1 Then
                    folio = TBFolio.Text
                ElseIf i1 > 1 Then
                    folio = TBFolio.Text + 1
                End If
                periodo2 = row1.Cells("Periodo").Value.ToString.Substring(0, 4)
                TBDiasVac.Text = row1.Cells("DiasVac").Value
                Imprimir(periodo2, TBDiasRest.Text, folio)
            End If
        Next

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        TBNumEmp.Enabled = False
        CBNomEmp.Enabled = False
        CBDiasSol.Enabled = False
        BSave.Enabled = False
        BtnNvo.Enabled = True

        VerFolioAnterior()

        CKAut1.Enabled = False
        CKAut2.Enabled = False
        CKAut3.Enabled = False
        CKAut4.Enabled = False
        CKAut5.Enabled = False
    End Sub

    Private Sub Imprimir(periodo2 As String, DiasRest1 As Integer, folio As Integer)


        Dim vSinValor As Integer = 0

        'Try
        Dim DTVacaciones As New DataTable("SolVacaciones")

        DTVacaciones.Columns.Add("IdSolicitud", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("FechSol", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("NumEmp", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("NomEmp", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("FecIng", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("DiasVac", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("FecIniVac", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("FecCadVac", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("Periodo", Type.GetType("System.String"))
        DTVacaciones.Columns.Add("DiasRest", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("DiasSol", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("DiasAut", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("DiaSol", Type.GetType("System.DateTime"))

        DTVacaciones.Columns.Add("Tomados", Type.GetType("System.Int32"))
        DTVacaciones.Columns.Add("Restantes", Type.GetType("System.Int32"))

        Dim columnas As DataColumnCollection = DTVacaciones.Columns

        Dim series As String = ""
        Dim _filaTemp As DataRow

        'For Each row As DataGridViewRow In Me.DGVCap.Rows
        '    Fila += 1
        '    vTotSIva += row.Cells(5).Value
        '    If row.Cells(5).Value = 0 Then
        '        vSinValor = 1
        '        Exit For
        '    End If

        'Next

        If DGVCap.RowCount < 1 Then
            vSinValor = 1
        End If

        If vSinValor = 1 Then
            MessageBox.Show("No hay días de vacaciones autorizados. Verifique.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'BtnImprimir.Enabled = True
            Return
        End If

        Dim con As Integer

        For Each row As DataGridViewRow In Me.DGVCap.Rows

            'contador = contador + 1
            _filaTemp = DTVacaciones.NewRow()

            _filaTemp(columnas(0)) = folio
            _filaTemp(columnas(1)) = CDate(DTPFecSol.Text).ToString("dd/MM/yyyy")
            _filaTemp(columnas(2)) = TBNumEmp.Text
            _filaTemp(columnas(3)) = CBNomEmp.Text
            _filaTemp(columnas(4)) = TextBox1.Text
            _filaTemp(columnas(5)) = TBDiasVac.Text
            _filaTemp(columnas(6)) = TBFecIniVac.Text
            _filaTemp(columnas(7)) = TBFecCadVac.Text
            _filaTemp(columnas(8)) = periodo2 'TextBox2.Text
            _filaTemp(columnas(9)) = DiasRest1 'TBDiasRest.Text
            '_filaTemp(columnas(10)) = CBDiasSol.Text
            _filaTemp(columnas(10)) = 1

            If TBDiasAut.Text = "" Then
                TBDiasAut.Text = CBDiasSol.Text
            End If
            '_filaTemp(columnas(11)) = TBDiasAut.Text
            _filaTemp(columnas(11)) = 1

            _filaTemp(columnas(12)) = row.Cells(3).Value.ToString

            _filaTemp(columnas(13)) = 1                 'tomados
            '_filaTemp(columnas(14)) = row.Cells(4).Value.ToString   'restantes
            _filaTemp(columnas(14)) = 1   'restantes
            '_filaTemp(columnas(29)) = vTotIva.ToString
            '_filaTemp(columnas(10)) = row.Cells(0).Value + row.Cells(0).Value

            DTVacaciones.Rows.Add(_filaTemp)

            con = con + 1

        Next

        Dim informe As New CRSolVacaciones
        RepComsultaP.MdiParent = Inicio
        informe.SetDataSource(DTVacaciones)
        RepComsultaP.CrVConsulta.ReportSource = informe
        RepComsultaP.Show()

        'Catch ex As Exception
        '    'ErrOV = 1

        '    'MsgBox(ex.Message)

        '    MessageBox.Show("No fue posible mostrar la orden de venta. " & ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        'End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        TBNumEmp.Enabled = False
        CBNomEmp.Enabled = False
        CBDiasSol.Enabled = False
        BSave.Enabled = False
        BtnNvo.Enabled = True

        VerFolioSiguiente()
        PanelFechas.Enabled = False

        CKAut1.Enabled = False
        CKAut2.Enabled = False
        CKAut3.Enabled = False
        CKAut4.Enabled = False
        CKAut5.Enabled = False
    End Sub

    Private Sub VerFolioSiguiente()
        LimpiaCampos()

        'MsgBox(TBFolio.Text)
        'MsgBox(FolioMax)

        If TBFolio.Text >= FolioMax Then

            conexion.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT folio,FechaSol,NumEmpleado,NomEmpleado,FechaIMSS, " &
                                                           "antiguedad,DiasVac,FecIniVac,FecCadVac,Periodo,DiasRest," &
                                                           "DiasSol,DiasAut FROM SolicitudVacaciones " &
                                                           "where folio = @folio ", conexion)
            cmd.Parameters.AddWithValue("@folio", 1)

            Dim cmd2 As SqlCommand = New SqlCommand("SELECT DiaSol,DiasRest FROM SolVacacionesHistorico " &
                                                            "where folio = @folio ORDER BY DiasRest DESC ", conexion)
            cmd2.Parameters.AddWithValue("@folio", 1)


            Try

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    Dim row As DataRow = dt.Rows(0)

                    TBFolio.Text = CStr(row("folio"))

                    DTPFecSol.Value = CStr(row("FechaSol"))

                    CBNomEmp.Text = ""
                    CBNomEmp.SelectedText = CStr(row("NomEmpleado"))

                    DTPFecIng.Value = CStr(row("FechaIMSS"))

                    TBAntiguedad.Text = CStr(row("antiguedad")) 'Format(CStr(row("antiguedad")), "##.#0")

                    TBDiasVac.Text = CStr(row("DiasVac"))

                    TBFecIniVac.Text = CStr(row("FecIniVac"))

                    TBFecCadVac.Text = CStr(row("FecCadVac"))

                    TBPeriodoCom.Text = CStr(row("Periodo"))

                    TBDiasRest.Text = CStr(row("DiasRest"))

                    CBDiasSol.Text = CStr(row("DiasSol"))

                    TBDiasAut.Text = CStr(row("DiasAut"))

                    TBNumEmp.Text = CStr(row("NumEmpleado"))
                End If

                '--------------******************************************
                '--------------******************************************

                Dim da2 As SqlDataAdapter = New SqlDataAdapter(cmd2)
                Dim dt2 As New DataTable
                da2.Fill(dt2)

                DGVCap.DataSource = dt2

                If dt2.Rows.Count = 1 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True

                ElseIf dt2.Rows.Count = 2 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True

                ElseIf dt2.Rows.Count = 3 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True

                ElseIf dt2.Rows.Count = 4 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True

                ElseIf dt2.Rows.Count = 5 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True
                    Dim row6 As DataRow = dt2.Rows(4)
                    DTPFec5.Value = CStr(row6("DiaSol"))
                    CKAut5.Checked = True

                End If

                '-----------------------------
                '-----------------------------

            Catch exsql As SqlException
                'MsgBox(exsql.Message)
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
            End Try

        Else

            conexion.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT folio,FechaSol,NumEmpleado,NomEmpleado,FechaIMSS, " &
                                                           "antiguedad,DiasVac,FecIniVac,FecCadVac,Periodo,DiasRest," &
                                                           "DiasSol,DiasAut FROM SolicitudVacaciones " &
                                                           "where folio = @folio ", conexion)
            cmd.Parameters.AddWithValue("@folio", TBFolio.Text + 1)

            Dim cmd2 As SqlCommand = New SqlCommand("SELECT DiaSol,DiasRest FROM SolVacacionesHistorico " &
                                                            "where folio = @folio ORDER BY DiasRest DESC", conexion)
            cmd2.Parameters.AddWithValue("@folio", TBFolio.Text + 1)

            Try

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    Dim row As DataRow = dt.Rows(0)

                    TBFolio.Text = CStr(row("folio"))

                    DTPFecSol.Value = CStr(row("FechaSol"))

                    CBNomEmp.Text = ""
                    CBNomEmp.SelectedText = CStr(row("NomEmpleado"))

                    DTPFecIng.Value = CStr(row("FechaIMSS"))

                    TBAntiguedad.Text = CStr(row("antiguedad")) 'Format(CStr(row("antiguedad")), "##.#0")

                    TBDiasVac.Text = CStr(row("DiasVac"))

                    TBFecIniVac.Text = CStr(row("FecIniVac"))

                    TBFecCadVac.Text = CStr(row("FecCadVac"))

                    TBPeriodoCom.Text = CStr(row("Periodo"))

                    TBDiasRest.Text = CStr(row("DiasRest"))

                    CBDiasSol.Text = CStr(row("DiasSol"))

                    TBDiasAut.Text = CStr(row("DiasAut"))

                    TBNumEmp.Text = CStr(row("NumEmpleado"))
                End If

                '--------------******************************************
                '--------------******************************************

                Dim da2 As SqlDataAdapter = New SqlDataAdapter(cmd2)
                Dim dt2 As New DataTable
                da2.Fill(dt2)

                DGVCap.DataSource = dt2

                If dt2.Rows.Count = 1 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True

                ElseIf dt2.Rows.Count = 2 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True

                ElseIf dt2.Rows.Count = 3 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True

                ElseIf dt2.Rows.Count = 4 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True

                ElseIf dt2.Rows.Count = 5 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True
                    Dim row6 As DataRow = dt2.Rows(4)
                    DTPFec5.Value = CStr(row6("DiaSol"))
                    CKAut5.Checked = True

                End If

                '-----------------------------
                '-----------------------------

            Catch exsql As SqlException
                'MsgBox(exsql.Message)
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
            End Try

        End If

    End Sub

    Private Sub VerFolioAnterior()
        LimpiaCampos()

        'MsgBox(TBFolio.Text)
        'MsgBox(FolioMax)

        If TBFolio.Text = 1 Then

            conexion.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT folio,FechaSol,NumEmpleado,NomEmpleado,FechaIMSS, " &
                                                           "antiguedad,DiasVac,FecIniVac,FecCadVac,Periodo,DiasRest," &
                                                           "DiasSol,DiasAut FROM SolicitudVacaciones " &
                                                           "where folio = @folio ", conexion)
            cmd.Parameters.AddWithValue("@folio", FolioMax)

            Dim cmd2 As SqlCommand = New SqlCommand("SELECT DiaSol,DiasRest FROM SolVacacionesHistorico " &
                                                            "where folio = @folio ORDER BY DiasRest DESC ", conexion)
            cmd2.Parameters.AddWithValue("@folio", FolioMax)

            Try
                '-----------------------------
                '-----------------------------
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                DGVCap.DataSource = dt

                If dt.Rows.Count > 0 Then

                    Dim row As DataRow = dt.Rows(0)

                    TBFolio.Text = CStr(row("folio"))

                    DTPFecSol.Value = CStr(row("FechaSol"))

                    CBNomEmp.Text = ""
                    CBNomEmp.SelectedText = CStr(row("NomEmpleado"))

                    DTPFecIng.Value = CStr(row("FechaIMSS"))

                    TBAntiguedad.Text = CStr(row("antiguedad")) 'Format(CStr(row("antiguedad")), "##.#0")

                    TBDiasVac.Text = CStr(row("DiasVac"))

                    TBFecIniVac.Text = CStr(row("FecIniVac"))

                    TBFecCadVac.Text = CStr(row("FecCadVac"))

                    TBPeriodoCom.Text = CStr(row("Periodo"))

                    TBDiasRest.Text = CStr(row("DiasRest"))

                    CBDiasSol.Text = CStr(row("DiasSol"))

                    TBDiasAut.Text = CStr(row("DiasAut"))

                    TBNumEmp.Text = CStr(row("NumEmpleado"))

                End If

                '-----------------------------
                '-----------------------------
                Dim da2 As SqlDataAdapter = New SqlDataAdapter(cmd2)
                Dim dt2 As New DataTable
                da2.Fill(dt2)

                DGVCap.DataSource = dt2

                If dt2.Rows.Count = 1 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True

                ElseIf dt2.Rows.Count = 2 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True

                ElseIf dt2.Rows.Count = 3 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True

                ElseIf dt2.Rows.Count = 4 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True

                ElseIf dt2.Rows.Count = 5 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True
                    Dim row6 As DataRow = dt2.Rows(4)
                    DTPFec5.Value = CStr(row6("DiaSol"))
                    CKAut5.Checked = True

                End If

                '-----------------------------
                '-----------------------------

            Catch exsql As SqlException
                'MsgBox(exsql.Message)
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
            End Try

        Else

            conexion.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT folio,FechaSol,NumEmpleado,NomEmpleado,FechaIMSS, " &
                                                           "antiguedad,DiasVac,FecIniVac,FecCadVac,Periodo,DiasRest," &
                                                           "DiasSol,DiasAut FROM SolicitudVacaciones " &
                                                           "where folio = @folio ", conexion)
            cmd.Parameters.AddWithValue("@folio", TBFolio.Text - 1)

            Dim cmd2 As SqlCommand = New SqlCommand("SELECT DiaSol,DiasRest " &
                                                            "FROM SolVacacionesHistorico where folio = @folio ORDER BY DiasRest DESC", conexion)
            cmd2.Parameters.AddWithValue("@folio", TBFolio.Text - 1)

            Try

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    Dim row As DataRow = dt.Rows(0)

                    TBFolio.Text = CStr(row("folio"))

                    DTPFecSol.Value = CStr(row("FechaSol"))

                    TBNumEmp.Text = CStr(row("NumEmpleado"))

                    CBNomEmp.Text = ""
                    CBNomEmp.SelectedText = CStr(row("NomEmpleado"))

                    DTPFecIng.Value = CStr(row("FechaIMSS"))

                    TBAntiguedad.Text = CStr(row("antiguedad")) 'Format(CStr(row("antiguedad")), "##.#0")

                    TBDiasVac.Text = CStr(row("DiasVac"))

                    TBFecIniVac.Text = CStr(row("FecIniVac"))

                    TBFecCadVac.Text = CStr(row("FecCadVac"))

                    TBPeriodoCom.Text = CStr(row("Periodo"))

                    TBDiasRest.Text = CStr(row("DiasRest"))

                    CBDiasSol.Text = CStr(row("DiasSol"))

                    TBDiasAut.Text = CStr(row("DiasAut"))

                    TBNumEmp.Text = CStr(row("NumEmpleado"))
                    '--------------******************************************

                End If

                '-----------------------------
                '-----------------------------
                Dim da2 As SqlDataAdapter = New SqlDataAdapter(cmd2)
                Dim dt2 As New DataTable
                da2.Fill(dt2)

                DGVCap.DataSource = dt2

                If dt2.Rows.Count = 1 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True

                ElseIf dt2.Rows.Count = 2 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True

                ElseIf dt2.Rows.Count = 3 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True

                ElseIf dt2.Rows.Count = 4 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True

                ElseIf dt2.Rows.Count = 5 Then
                    Dim row2 As DataRow = dt2.Rows(0)
                    DTPFec1.Value = CStr(row2("DiaSol"))
                    CKAut1.Checked = True
                    Dim row3 As DataRow = dt2.Rows(1)
                    DTPFec2.Value = CStr(row3("DiaSol"))
                    CKAut2.Checked = True
                    Dim row4 As DataRow = dt2.Rows(2)
                    DTPFec3.Value = CStr(row4("DiaSol"))
                    CKAut3.Checked = True
                    Dim row5 As DataRow = dt2.Rows(3)
                    DTPFec4.Value = CStr(row5("DiaSol"))
                    CKAut4.Checked = True
                    Dim row6 As DataRow = dt2.Rows(4)
                    DTPFec5.Value = CStr(row6("DiaSol"))
                    CKAut5.Checked = True

                End If

                '-----------------------------
                '-----------------------------


            Catch exsql As SqlException
                'MsgBox(exsql.Message)
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
            End Try

        End If

    End Sub

    Private Sub BtnNvo_Click(sender As Object, e As EventArgs) Handles BtnNvo.Click

        Me.Close()

        Dim frm As New FormatoVacaciones
        'frm.Show()

        frm.MdiParent = Inicio

        frm.Show()

        'Dim frm As New FormatoVacaciones
        'frm.Show()

        'BSave.Enabled = True

        'Me.Refresh()

        ''Try
        ''    ''MsgBox(DGVCap.RowCount)
        ''    'For i As Integer = 0 To DGVCap.RowCount - 1
        ''    '    'DGVCap.Rows.RemoveAt(i)
        ''    '    Me.DGVCap.Rows.RemoveAt(i)
        ''    'Next

        ''    For i As Integer = 0 To DGVCap.RowCount - 1
        ''        'MsgBox(DTPFec1.Text)
        ''        'MsgBox(DGVCap.Item(3, i).Value)
        ''        'Dim auxfec1 As String = DTPFec1.Text.ToString

        ''        DGVCap.CurrentCell = DGVCap.Rows(0).Cells(0)

        ''        DGVCap.Rows(0).Selected = True

        ''        Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)

        ''    Next
        ''    'DGVCap.DataSource = DBNull.Value
        ''    DGVCap.Refresh()

        ''    'Me.DGVCap.EndEdit()

        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try

        ''TBNumEmp.Enabled = True
        ''CBNomEmp.Enabled = True
        ''CBNomEmp.SelectedValue = 99

        ''CBDiasSol.Enabled = True

        ' ''Procedimiento para obtener el número de transacción más actual
        ''Dim cmdCuenta As New Data.SqlClient.SqlCommand
        ''Dim FormatWO As String = ""
        ''cmdCuenta.CommandText = "SELECT MAX(Folio) FROM SolicitudVacaciones "
        ''cmdCuenta.CommandType = CommandType.Text
        ''cmdCuenta.Connection = New Data.SqlClient.SqlConnection(StrTpm)
        ''cmdCuenta.Connection.Open()
        ' ''NumOVta = IIf(IsDBNull(cmdCuenta.ExecuteScalar()), 0, Val(cmdCuenta.ExecuteScalar()))

        ''With cmdCuenta
        ''    NumOVta = IIf(IsDBNull(.ExecuteScalar()), 0, .ExecuteScalar())
        ''    .Connection.Close()
        ''End With

        ''FolioMax = NumOVta

        ''If FolioMax = 0 Then
        ''    FolioMax = 1
        ''End If

        ''NumOVta += 1

        ''TBFolio.Text = NumOVta
        ''TBFolio.Text = Format(NumOVta, "0000")
        ''TBFolio.TextAlign = HorizontalAlignment.Right

        ' ''DisenoGridVArt()

        ''CBDiasSol.SelectedIndex = 0

        ''DTPFec1.Value = Date.Now
        ''DTPFec2.Value = Date.Now
        ''DTPFec3.Value = Date.Now
        ''DTPFec4.Value = Date.Now
        ''DTPFec5.Value = Date.Now

        CBNomEmp.Focus()

        CKAut1.Enabled = True
        CKAut2.Enabled = True
        CKAut3.Enabled = True
        CKAut4.Enabled = True
        CKAut5.Enabled = True
    End Sub


    Private Sub Datos()

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable = New DataTable
        Dim command1 As SqlCommand
        Dim adapter1 As SqlDataAdapter
        Dim dtTable1 As DataTable = New DataTable


        conexion.Close()
            conexion.Open()

        '   dtTable = New DataTable
        command = New SqlCommand("SP_ConsultaVac", conexion2)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add(New SqlParameter("@NumEmp", SqlDbType.Int)).Value = CBNomEmp.SelectedValue

        adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTable)
            'DataGridView1.DataSource = Nothing
            ' DataGridView1.DataSource = dtTable
            conexion.Close()
        TBNumEmp.Text = dtTable.Rows(0).Item(0)
        TextBox1.Text = dtTable.Rows(0).Item(5)
        TBAntiguedad.Text = dtTable.Rows(0).Item(6)
        TBDiasVac.Text = dtTable.Rows(0).Item(12)
        TBFecIniVac.Text = dtTable.Rows(0).Item(13)
        TBFecCadVac.Text = dtTable.Rows(0).Item(14)
        TextBox2.Text = dtTable.Rows(0).Item(7) & " - " & (dtTable.Rows(0).Item(9) + 1)
        periodoCorrespondiente = dtTable.Rows(0).Item(7)
        TBDiasRest.Text = dtTable.Rows(0).Item(8)
        '  TBNumEmp.Text = dtTable.Rows(0).Item(0)
        '  TBNumEmp.Text = dtTable.Rows(0).Item(0)
    End Sub



    Private Sub BtnEmpleados_Click(sender As Object, e As EventArgs) Handles BtnEmpleados.Click

    End Sub

    Private Sub CalculoPeriodo()

        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable = New DataTable
        Dim command1 As SqlCommand
        Dim adapter1 As SqlDataAdapter
        Dim dtTable1 As DataTable = New DataTable

        Try
            conexion.Close()
            conexion.Open()

            '   dtTable = New DataTable
            command = New SqlCommand("SP_Consultas", conexion2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "PERIODO"
            command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = CBNomEmp.SelectedValue
            command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = TBPeriodoCom.SelectedValue
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTable)
            'DataGridView1.DataSource = Nothing
            ' DataGridView1.DataSource = dtTable
            conexion.Close()
            TBNumEmp.Text = dtTable.Rows(0).Item(2)
            TextBox1.Text = dtTable.Rows(0).Item(4)
            TBAntiguedad.Text = dtTable.Rows(0).Item(5)
            TBDiasVac.Text = dtTable.Rows(0).Item(6)
            TBFecIniVac.Text = dtTable.Rows(0).Item(7)
            TBFecCadVac.Text = dtTable.Rows(0).Item(8)
            TextBox2.Text = dtTable.Rows(0).Item(9) & " - " & (dtTable.Rows(0).Item(9) + 1)
            TBDiasRest.Text = dtTable.Rows(0).Item(10)
            '  TBNumEmp.Text = dtTable.Rows(0).Item(0)
            '  TBNumEmp.Text = dtTable.Rows(0).Item(0)

        Catch ex As Exception
            command1 = New SqlCommand("SP_Consultas", conexion2)
            command1.CommandType = CommandType.StoredProcedure
            command1.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "AYOS"
            command1.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = CBNomEmp.SelectedValue
            command1.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = TBPeriodoCom.SelectedValue
            adapter1 = New SqlDataAdapter(command1)
            adapter1.Fill(dtTable1)
            'DataGridView1.DataSource = Nothing
            ' DataGridView1.DataSource = dtTable
            TBDiasRest.Text = dtTable1.Rows(0).Item(0)

            TextBox2.Text = dtTable1.Rows(0).Item(6) & " - " & CInt(dtTable1.Rows(0).Item(6)) + 1
            ' TBPeriodoCom.Text = dtTable1.Rows(0).Item(6) & " - " & CInt(dtTable1.Rows(0).Item(6)) + 1
            'If dtTable1.Rows(0).Item(0) = 0 Then
            '    TextBox2.Text = dtTable1.Rows(0).Item(6) + 1 & " - " & CInt(dtTable1.Rows(0).Item(6)) + 2
            '    TBPeriodoCom.Text = dtTable1.Rows(0).Item(6) + & " - " & CInt(dtTable1.Rows(0).Item(6)) + 2
            'End If

            TBDiasVac.Text = dtTable1.Rows(0).Item(0)


            TBNumEmp.Text = CBNomEmp.SelectedValue


            TextBox1.Text = dtTable1.Rows(0).Item(4).ToString
            TBAntiguedad.Text = dtTable1.Rows(0).Item(1)
            TBFecIniVac.Text = dtTable1.Rows(0).Item(7)
            TBFecCadVac.Text = dtTable1.Rows(0).Item(8)
            txttipo.Text = dtTable1.Rows(0).Item(5)
            conexion.Close()





        End Try

    End Sub

    Private Sub TBPeriodoCom_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles TBPeriodoCom.SelectionChangeCommitted
        If TBPeriodoCom.SelectedValue = periodoCorrespondiente Then
            Datos()
        Else
            CalculoPeriodo()
        End If




        ''MsgBox("periodo")
        ''Dim diasRestantes As Integer
        'Dim bandera_entero As Integer = 123
        '''MsgBox(FechaIngreso)
        'Dim SumaAnios As Integer
        'SumaAnios = 0
        'If (TopeGlobal = TBPeriodoCom.SelectedValue) Then
        '    'MsgBox("estas seleccionando el ultimo")


        '    SumaAnios = Integer.Parse(TBPeriodoCom.SelectedValue.ToString) - DatePart("yyyy", FechaIngreso)
        '    Antiguedad = DateDiff("d", FechaIngreso, Date.Now()) / 365
        '    'Antiguedad = DateDiff("d", CStr(row("FechaIMSS")), Date.Now) / 365
        '    TBAntiguedad.Text = Format(Antiguedad, "##.#0")
        '    If Antiguedad < 1 Then
        '        NumDiasVac = 0
        '    ElseIf Antiguedad >= 1 And Antiguedad < 2 Then
        '        NumDiasVac = 3
        '    ElseIf Antiguedad >= 2 And Antiguedad < 3 Then
        '        NumDiasVac = 4
        '    ElseIf Antiguedad >= 3 And Antiguedad < 4 Then
        '        NumDiasVac = 4
        '    ElseIf Antiguedad >= 4 And Antiguedad < 5 Then
        '        NumDiasVac = 5
        '    ElseIf Antiguedad >= 5 And Antiguedad < 10 Then
        '        NumDiasVac = 6
        '    ElseIf Antiguedad >= 10 Then
        '        NumDiasVac = 7
        '    End If

        '    TBDiasVac.Text = NumDiasVac
        '    TBFecIniVac.Text = Me.DTPFecIng.Value.Date.AddYears(SumaAnios)
        '    TBFecCadVac.Text = Me.DTPFecIng.Value.Date.AddYears(SumaAnios + 1)

        '    'Dim diasRestantes As Integer

        '    'diasRestantes = TBDiasVac.Text - DGVacaciones.RowCount + 2

        '    'TBDiasRest.Text = diasRestantes
        'Else
        '    'MsgBox(Integer.Parse(TBPeriodoCom.SelectedValue.ToString) & "-" & DatePart("yyyy", FechaIngreso))
        '    SumaAnios = Integer.Parse(TBPeriodoCom.SelectedValue.ToString) - DatePart("yyyy", FechaIngreso)
        '    'MsgBox(SumaAnios)

        '    Antiguedad = DateDiff("d", FechaIngreso, Me.DTPFecIng.Value.Date.AddYears(SumaAnios)) / 365

        '    'MsgBox(Antiguedad)
        '    TBAntiguedad.Text = Format(Antiguedad, "##.#0")
        '    If Antiguedad < 1 Then
        '        NumDiasVac = 0
        '    ElseIf Antiguedad >= 1 And Antiguedad < 2 Then
        '        NumDiasVac = 6
        '    ElseIf Antiguedad >= 2 And Antiguedad < 3 Then
        '        NumDiasVac = 8
        '    ElseIf Antiguedad >= 3 And Antiguedad < 4 Then
        '        NumDiasVac = 10
        '    ElseIf Antiguedad >= 4 And Antiguedad < 5 Then
        '        NumDiasVac = 12
        '    ElseIf Antiguedad >= 5 And Antiguedad < 10 Then
        '        NumDiasVac = 14
        '    ElseIf Antiguedad >= 10 Then
        '        NumDiasVac = 16
        '    End If

        '    TBDiasVac.Text = NumDiasVac
        '    TBFecIniVac.Text = Me.DTPFecIng.Value.Date.AddYears(SumaAnios)
        '    TBFecCadVac.Text = Me.DTPFecIng.Value.Date.AddYears(SumaAnios + 1)



        '    'Dim diasRestantes As Integer

        '    'diasRestantes = TBDiasVac.Text - DGVacaciones.RowCount + 2

        '    'TBDiasRest.Text = diasRestantes

        'End If

        'For indice2 As Integer = 0 To dt.Tables(1).Rows.Count - 1
        '    If (CStr(dt.Tables(1).Rows(indice2)(0)) = TBPeriodoCom.SelectedValue.ToString) Then
        '        bandera_entero = Integer.Parse(dt.Tables(1).Rows(indice2)(1))
        '    End If

        'Next

        'If (bandera_entero = 123) Then
        '    TBDiasRest.Text = TBDiasVac.Text
        'Else
        '    TBDiasRest.Text = Integer.Parse(TBDiasVac.Text.ToString) - bandera_entero
        'End If


    End Sub

    Private Sub CBNomEmp_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CBNomEmp.SelectionChangeCommitted
        Rutina()

        Datos()


        'CalculoPeriodo()

        TBPeriodoCom.Enabled = True
    End Sub



    Public Sub Rutina()

        Dim tope As Integer
        Dim consulta As String = ""
        Dim da = New SqlDataAdapter

        Try
            LimpiaCampos()
            'conexion = New SqlConnection(StrTpm) 'ORIGINAL
            'Dim cmd = New SqlCommand("SP_Consultas", conexion)
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "SELECCION"
            'cmd.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = CBNomEmp.SelectedValue
            'cmd.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
            'conexion.Open()

            ''da.SelectCommand = cmd
            ''da.SelectCommand.Connection = conexion
            ''da.SelectCommand.CommandTimeout = 10000
            ''cmd.ExecuteNonQuery()
            'da = New SqlDataAdapter(cmd)
            ' da.Fill(dt)

            '' da.Fill(dt)




            conexion2.Close()

            conexion2.Open()
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable = New DataTable
            command = New SqlCommand("SP_Consultas", conexion2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "SELECCION"
            command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = CBNomEmp.SelectedValue
            command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTable)

            If dtTable.Rows.Count > 0 Then

                DTPFecIng.Value = dtTable.Rows(0).Item(2) ' CStr(row("FechaIMSS"))
                FechaIngreso = dtTable.Rows(0).Item(2)  ' CStr(row("FechaIMSS"))
                txttipo.Text = dtTable.Rows(0).Item(3) 'CStr(row("Tipo"))
                tope = Integer.Parse(dtTable.Rows(0).Item(4)) 'Integer.Parse(row("Tope"))
                AñosTrascurridos = tope - DTPFecIng.Value.Year
                Dim dt2 As DataTable
                Dim dr2 As DataRow
                Dim currentyear As Integer
                Dim bandera_entero As Integer = 123
                dt2 = New DataTable("Tabla")
                dt2.Columns.Add("Codigo")
                dt2.Columns.Add("Descripcion")
                currentyear = Integer.Parse(DatePart("yyyy", DTPFecIng.Value))
                TextBox2.Text = tope.ToString & " - " & (tope + 1).ToString
                TopeGlobal = Integer.Parse(dtTable.Rows(0).Item(4)) 'Integer.Parse(row("Tope"))
                For y As Integer = currentyear To tope Step 1
                    dr2 = dt2.NewRow()
                    dr2("Codigo") = y
                    dr2("Descripcion") = y & " - " & y + 1
                    dt2.Rows.Add(dr2)
                Next
                If AñosTrascurridos <= -1 Then
                    dr2 = dt2.NewRow()
                    dr2("Codigo") = Year(Today)
                    dr2("Descripcion") = Year(Today) & " - " & Year(Today) + 1
                    dt2.Rows.Add(dr2)
                    TBDiasRest.Text = "0"
                End If

                TBPeriodoCom.DataSource = dt2
                TBPeriodoCom.ValueMember = "Codigo"
                TBPeriodoCom.DisplayMember = "Descripcion"
                TBPeriodoCom.SelectedValue = TopeGlobal.ToString
                TBPeriodoCom.Text = tope.ToString & " - " & (tope + 1).ToString



            End If
            conexion2.Close()

        Catch exsql As SqlException
            MsgBox("eror sql: " & exsql.Message)
        Catch ex As Exception
            MsgBox("exception: " & ex.Message)
        Finally
            If conexion2 IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                conexion2.Close()
            End If
        End Try


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        'MsgBox(TBDiasRest.Text.ToString)
        If CBNomEmp.Text <> "" Then

            'If TBDiasAut.Text = "" Then
            '    TBDiasAut.Text = 0
            'End If

            'If CKAut1.Checked = True Then

            'If DGVacaciones.RowCount > 1 Then

            '    'MsgBox(DTPFec1.Text)

            '    For i As Integer = 1 To DGVacaciones.RowCount - 1
            '        'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
            '        If DTPFec1.Text = DGVacaciones.Item(2, i).Value Then
            '            'MsgBox("El artículo ya ha sido agregado.")

            '            MessageBox.Show("Este día ya ha sido asignado anteriormente, " & _
            '                            "seleccione otro para continuar.", "Error al agregar.",
            '            MessageBoxButtons.OK, MessageBoxIcon.Information)

            '            CKAut1.Checked = False
            '            Return
            '        End If
            '    Next

            'End If
            'MsgBox(DGVCap.RowCount)
            If DGVCap.RowCount >= 1 Then

                'MsgBox(DTPFec1.Text)

                For i As Integer = 0 To DGVCap.RowCount - 1
                    'MsgBox(DGVArt.Item(0, DGVArt.CurrentCell.RowIndex).Value & " = " & DGVCap.Item(1, i).Value)
                    If DTPFec1.Text = DGVCap.Item(3, i).Value Then
                        'MsgBox("El artículo ya ha sido agregado.")

                        MessageBox.Show("Este día ya ha sido asignado anteriormente, " &
                                                         "seleccione otro para continuar.", "Error al agregar.",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'CKAut1.Checked = False
                        Return
                    End If
                Next

            End If

            If (MessageBox.Show(
                              "¿Confirma autorización del día " & DTPFec1.Text & "? ",
                              "Proceso de autorización.", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

                DiaVac = 1

                'GenerarDiasVac()

                'NumAuto = TBDiasAut.Text + 1

                Try
                    TBDiasRest.Text = TBDiasRest.Text - 1
                    DGVCap.Rows.Add(TBFolio.Text, TBNumEmp.Text, TextBox2.Text, DTPFec1.Text.ToString, TBDiasRest.Text, TBDiasVac.Text, "Borrar")
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try

            Else
                CKAut1.Checked = False
            End If

            'Else 'si checked = false
            '    If (MessageBox.Show( _
            '             "¿Confirma que desea quitar autorización del día " & DTPFec1.Text & "? ", _
            '             "Proceso de autorización.", MessageBoxButtons.YesNo, _
            '             MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then

            '        DiaVac = 1

            '        EliminarDiasVac()

            '        NumAuto = TBDiasAut.Text - 1

            '        Try
            '            For i As Integer = 0 To DGVCap.RowCount - 1
            '                'MsgBox(DTPFec1.Text)
            '                'MsgBox(DGVCap.Item(3, i).Value)
            '                'Dim auxfec1 As String = DTPFec1.Text.ToString

            '                If DTPFec1.Text = DGVCap.Item(3, i).Value Then
            '                    'MsgBox("verdadero")

            '                    DGVCap.CurrentCell = DGVCap.Rows(i).Cells(0)

            '                    DGVCap.Rows(i).Selected = True

            '                    Me.DGVCap.Rows.Remove(DGVCap.CurrentRow)
            '                End If
            '            Next
            '        Catch ex As Exception
            '            'MsgBox(ex.Message)
            '        End Try

            '    Else
            '        CKAut1.Checked = True
            '    End If

            'End If

            TBDiasAut.Text = NumAuto

        End If
    End Sub

    Private Sub DGVCap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVCap.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DGVCap.Rows(e.RowIndex)
            Try
                If Me.DGVCap.Columns(e.ColumnIndex).Name = "Borrar" Then
                    If (MessageBox.Show("¿Esta seguro que sea borrar el dia " & row.Cells("DiaSol").Value.ToString & "?",
                                             "Advertencia",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation)) = MsgBoxResult.Yes Then
                        Me.DGVCap.Rows.Remove(row)
                        TBDiasRest.Text = TBDiasRest.Text + 1
                    End If
                    'MsgBox("voy a borrar el dia " & row.Cells("DiaSol").Value.ToString)

                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TBPeriodoCom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TBPeriodoCom.SelectedIndexChanged

    End Sub

    Private Sub CBNomEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBNomEmp.SelectedIndexChanged

    End Sub

    'Private Sub CBNomEmp_KeyUp(sender As Object, e As KeyEventArgs) Handles CBNomEmp.KeyUp
    '    Try
    '        If e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
    '            strTemp = CBNomEmp.Text
    '            If strTemp.Trim.CompareTo(String.Empty) = 0 Then
    '                DvLP.RowFilter = String.Empty
    '                DvLP.RowFilter = "NumEmp <> 1010"
    '            Else
    '                Dim strRowFilter As String = String.Concat("NomEmp LIKE '%", CBNomEmp.Text, "%' and NumEmp <> 1010 ")
    '                DvLP.RowFilter = strRowFilter
    '                'MsgBox(DvLP.Count)
    '                If DvLP.Count = 0 Then
    '                    DvLP.RowFilter = "NumEmp = 1010"
    '                End If

    '            End If


    '            CBNomEmp.Text = ""
    '            CBNomEmp.Text = strTemp
    '            CBNomEmp.SelectionStart = strTemp.Length
    '            CBNomEmp.SelectedIndex = -1
    '            CBNomEmp.DroppedDown = True
    '            CBNomEmp.SelectedIndex = -1
    '            CBNomEmp.Text = ""
    '            CBNomEmp.Text = strTemp
    '            CBNomEmp.SelectionStart = strTemp.Length

    '        End If



    '        'DvClte.RowFilter = "Nombre2 like '%" & CmbCliente.Text & "%'"
    '        'CmbCliente.DroppedDown = True
    '    Catch ex As Exception
    '        'MsgBox("errror en filtro nuevo " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub CBNomEmp_DropDown(sender As Object, e As EventArgs) Handles CBNomEmp.DropDown
    '    Me.Cursor = Cursors.Arrow

    '    If strTemp <> "" Then
    '        CBNomEmp.Text = strTemp
    '        CBNomEmp.SelectionStart = strTemp.Length
    '    End If
    '    'CBNomEmp.SelectionStart = strTemp.Length
    'End Sub

    'Private Sub CBNomEmp_Leave(sender As Object, e As EventArgs) Handles CBNomEmp.Leave
    '    Try
    '        If CBNomEmp.SelectedIndex.ToString = "-1" Or CBNomEmp.SelectedValue = 1010 Then
    '            If strTemp <> "" Then
    '                CBNomEmp.Text = strTemp
    '                CBNomEmp.SelectionStart = strTemp.Length
    '            End If
    '            'MessageBox.Show("Por favor elige a un empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            CBNomEmp.SelectedIndex = -1
    '            LimpiaCampos()
    '            Return
    '        End If
    '        Rutina()
    '    Catch ex As Exception

    '    End Try
    'End Sub

End Class