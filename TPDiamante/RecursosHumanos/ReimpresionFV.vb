Imports System.Data.SqlClient

Public Class ReimpresionFV
    Public conexion2 As New SqlConnection(StrTpm)
    Public conexion As New SqlConnection(StrTpm)
    Dim DvLP As New DataView
    Dim indice As Integer


    Private Sub ReimpresionFV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboboxEmpleado()
    End Sub

    Private Sub LlenarComboboxEmpleado()
        conexion2.Open()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable = New DataTable
        command = New SqlCommand("SP_Consultas", conexion2)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "ACTIVOS"
        command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = 1
        command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
        adapter = New SqlDataAdapter(command)
        adapter.Fill(dtTable)
        Dim DSetTablas As New DataSet
        adapter.Fill(DSetTablas, "Empleados")
        Dim fila As Data.DataRow
        fila = DSetTablas.Tables("Empleados").NewRow
        fila("NomEmp") = "--Ningun Resultado--"
        fila("NumEmp") = 1010
        DSetTablas.Tables("Empleados").Rows.Add(fila)
        DvLP.Table = DSetTablas.Tables("Empleados")
        DvLP.RowFilter = "NumEmp <> 1010"
        Me.CBNomEmp.DataSource = DvLP
        Me.CBNomEmp.DisplayMember = "NomEmp"
        Me.CBNomEmp.ValueMember = "NumEmp"
        Me.CBNomEmp.DataSource = DSetTablas.Tables(0)
        Me.CBNomEmp.DisplayMember = "NomEmp"
        Me.CBNomEmp.ValueMember = "NumEmp"
        conexion2.Close()

    End Sub
    Private Sub CBNomEmp_TextChanged(sender As Object, e As EventArgs) Handles CBNomEmp.TextChanged
        Try
            conexion.Close()
            conexion.Open()
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable = New DataTable
            '   dtTable = New DataTable
            command = New SqlCommand("SP_Consultas", conexion2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "CONSULTA VACACIONES"
            command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = CBNomEmp.SelectedValue
            command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTable)
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = dtTable
            conexion.Close()
            LlenarGrid()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub LlenarGrid()
        With Me.DataGridView1

            Try
                .Columns(2).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(10).Visible = False
            Catch ex As Exception
            End Try

        End With
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(9).ReadOnly = True
        DataGridView1.Columns(11).ReadOnly = True

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        indice = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value

        Try
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable = New DataTable
            command = New SqlCommand("SP_Consultas", conexion2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@opcion", SqlDbType.NVarChar)).Value = "DIAS VACACIONES"
            command.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = indice
            command.Parameters.Add(New SqlParameter("@Periodo", SqlDbType.NVarChar)).Value = ""
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtTable)
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = dtTable
        Catch ex As Exception

        End Try
        Imprimir()
    End Sub

    Private Sub Imprimir()

        Dim vSinValor As Integer = 0
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
        If DataGridView2.RowCount < 1 Then
            vSinValor = 1
        End If
        If vSinValor = 1 Then
            MessageBox.Show("No hay días de vacaciones autorizados. Verifique.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim con As Integer
        For Each row As DataGridViewRow In Me.DataGridView2.Rows
            _filaTemp = DTVacaciones.NewRow()
            _filaTemp(columnas(0)) = row.Cells(0).Value
            _filaTemp(columnas(1)) = CDate(row.Cells(1).Value).ToString("dd/MM/yyyy")
            _filaTemp(columnas(2)) = row.Cells(2).Value
            _filaTemp(columnas(3)) = row.Cells(3).Value
            _filaTemp(columnas(4)) = row.Cells(4).Value
            _filaTemp(columnas(5)) = row.Cells(11).Value
            _filaTemp(columnas(6)) = row.Cells(7).Value
            _filaTemp(columnas(7)) = row.Cells(8).Value
            _filaTemp(columnas(8)) = row.Cells(9).Value
            _filaTemp(columnas(9)) = row.Cells(10).Value
            _filaTemp(columnas(10)) = 1
            _filaTemp(columnas(11)) = 1
            _filaTemp(columnas(12)) = row.Cells(12).Value
            _filaTemp(columnas(13)) = 1
            _filaTemp(columnas(14)) = 1
            DTVacaciones.Rows.Add(_filaTemp)
            con = con + 1
        Next

        Dim informe As New CRSolVacaciones
        RepComsultaP.MdiParent = Inicio
        informe.SetDataSource(DTVacaciones)
        RepComsultaP.CrVConsulta.ReportSource = informe
        RepComsultaP.Show()

    End Sub

    Private Sub CBNomEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBNomEmp.SelectedIndexChanged

    End Sub
End Class