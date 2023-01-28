
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class FacturasXmlConta

    Public StrTpm As String = conexion_universal.CadenaSQL

    Dim DvConta As New DataView

    Private Sub FacturasXmlConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Devuelve el primer dia del mes de la fecha actual
        Dim FechaIni As New Date
        FechaIni = Today
        FechaIni = FechaIni.AddDays(-FechaIni.Day + 1)

        'Devuelve el ultimo dia del mes de la fecha actual
        Dim FechaFin As New Date
        FechaFin = Today
        FechaFin = FechaFin.AddDays(-FechaFin.Day + 1).AddMonths(1).AddDays(-1)

        DTIni.Value = FechaIni
        DTFin.Value = FechaFin

        CBDocumento.SelectedItem = "Facturas"

        'Me.DTIni.Value = Format("dd/MM/yyyy")
        'Me.DTFin.Value = Format("dd/MM/yyyy")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            'Me.DTIni.Value = Format("dd/MM/yyyy")
            'Me.DTFin.Value = Format("dd/MM/yyyy")

            'MsgBox(DTIni.Value)
            'MsgBox(DTFin.Value)

            Dim cnn As SqlConnection = Nothing

            Dim cmd4 As SqlCommand = Nothing

            If CBDocumento.Text = "Facturas" Then
                Try
                    cnn = New SqlConnection(StrTpm)

                    cmd4 = New SqlCommand("FNCConta", cnn)
                    cmd4.CommandType = CommandType.StoredProcedure
                    cmd4.Parameters.AddWithValue("@Tipodoc", 1)
                    cmd4.Parameters.AddWithValue("@FechaInicial", DTIni.Value)
                    cmd4.Parameters.AddWithValue("@FechaFinal", DTFin.Value)

                    cnn.Open()

                    cmd4.ExecuteNonQuery()
                    cmd4.Connection.Close()

                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd4
                    da.SelectCommand.Connection = cnn


                    ''--------------------------------------------
                    Dim DsVtas As New DataSet
                    da.Fill(DsVtas, "DsVtas")

                    DsVtas.Tables(0).TableName = "Inventario"

                    DvConta.Table = DsVtas.Tables("Inventario")

                    DataGridView1.DataSource = DvConta


                    DisenoGrid()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                        cnn.Close()
                    End If
                End Try

            ElseIf CBDocumento.Text = "Notas de Crédito" Then
                Try
                    cnn = New SqlConnection(StrTpm)

                    cmd4 = New SqlCommand("FNCConta_Back", cnn)
                    cmd4.CommandType = CommandType.StoredProcedure
                    cmd4.Parameters.AddWithValue("@Tipodoc", 2)
                    cmd4.Parameters.AddWithValue("@FechaInicial", DTIni.Value)
                    cmd4.Parameters.AddWithValue("@FechaFinal", DTFin.Value)

                    cnn.Open()

                    cmd4.ExecuteNonQuery()
                    cmd4.Connection.Close()

                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd4
                    da.SelectCommand.Connection = cnn


                    ''--------------------------------------------
                    Dim DsVtas As New DataSet
                    da.Fill(DsVtas, "DsVtas")

                    DsVtas.Tables(0).TableName = "Inventario"

                    DvConta.Table = DsVtas.Tables("Inventario")

                    DataGridView1.DataSource = DvConta

                    DisenoGrid()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                        cnn.Close()
                    End If
                End Try

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub bExcel_Click(sender As Object, e As EventArgs) Handles bExcel.Click
        Try
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DataGridView1.ColumnCount
            Dim NRow As Integer = DataGridView1.RowCount


            fFormatoExcel(exLibro, NRow)


            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(5, i) = DataGridView1.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    'exHoja.Cells.Item(Fila + 6, Col + 1).NumberFormat = "@"
                    exHoja.Cells.Item(Fila + 6, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                Next

                Estatus.Visible = True
                ProgressBar1.Value = (Fila * 100) / NRow
            Next

            Estatus.Visible = False

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(4).Font.Bold = 1
            exHoja.Rows.Item(4).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True


            ''Cambiamos orientacion ala hola
            exHoja.Cells.Item(1, 1) = "Reporte de " & CBDocumento.Text
            exHoja.Cells.Item(2, 1) = "Fecha del: " + DTIni.Value + "  Al  " + DTFin.Value

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

        End Try
    End Sub

    Private Sub fFormatoExcel(exLibro As Microsoft.Office.Interop.Excel.Workbook, NRow As Integer)
        Try
            exLibro.Worksheets("Hoja2").Cells.Range("A5:M" + 5.ToString).Interior.ColorIndex = 20

        Catch ex As Exception

        End Try


    End Sub


    Private Sub DisenoGrid()
        Try
            With DataGridView1
                '.DataSource = DtAgte
                '.ReadOnly = True
                'Color de Renglones en Grid
                .AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
                .AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
                .DefaultCellStyle.BackColor = Color.AliceBlue
                .DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue

                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Propiedad para no mostrar el cuadro que se encuentra en la parte
                'Superior Izquierda del gridview
                .RowHeadersVisible = True
                .RowHeadersWidth = 25

                .Columns(0).HeaderText = "Serie"
                .Columns(0).Width = 40
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                .Columns(1).HeaderText = "Número de Documento"
                .Columns(1).Width = 70
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                .Columns(2).HeaderText = "Fecha de Contabilización"
                .Columns(2).Width = 90
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Descripcion	
                .Columns(3).HeaderText = "Tipo de Documento"
                .Columns(3).Width = 65
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Linea	
                .Columns(4).HeaderText = "Clave Proveedor"
                .Columns(4).Width = 80
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                'Precio L9
                .Columns(5).HeaderText = "Nombre"
                .Columns(5).Width = 180
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft



                'Vta Neta
                .Columns(6).HeaderText = "Total Documento"
                .Columns(6).Width = 80
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).DefaultCellStyle.Format = "$ ###,###,##0.##"

                .Columns(7).HeaderText = "Comentarios"
                .Columns(7).Width = 230
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft




                .Columns(8).HeaderText = "Ruta"
                .Columns(8).Width = 140
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                .Columns(9).HeaderText = "Nombre de archivo"
                .Columns(9).Width = 140
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                .Columns(10).HeaderText = "Extensión"
                .Columns(10).Width = 60
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        BuscarXML()
    End Sub


    Public Sub BuscarXML()
        Try

            'Me.DTIni.Value = Format("dd/MM/yyyy")
            'Me.DTFin.Value = Format("dd/MM/yyyy")

            'MsgBox(DTIni.Value)
            'MsgBox(DTFin.Value)

            Dim cnn As SqlConnection = Nothing

            Dim cmd4 As SqlCommand = Nothing

            If CBDocumento.Text = "Facturas" Then
                Try
                    cnn = New SqlConnection(StrTpm)

                    cmd4 = New SqlCommand("FNCConta_xml", cnn)
                    cmd4.CommandType = CommandType.StoredProcedure
                    cmd4.Parameters.AddWithValue("@Tipodoc", 1)
                    cmd4.Parameters.AddWithValue("@FechaInicial", DTIni.Value)
                    cmd4.Parameters.AddWithValue("@FechaFinal", DTFin.Value)
                    cmd4.Parameters.AddWithValue("@param", TextBox1.Text.Trim)

                    cnn.Open()

                    cmd4.ExecuteNonQuery()
                    cmd4.Connection.Close()

                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd4
                    da.SelectCommand.Connection = cnn


                    ''--------------------------------------------
                    Dim DsVtas As New DataSet
                    da.Fill(DsVtas, "DsVtas")

                    DsVtas.Tables(0).TableName = "Inventario"

                    DvConta.Table = DsVtas.Tables("Inventario")

                    DataGridView1.DataSource = DvConta


                    DisenoGrid()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                        cnn.Close()
                    End If
                End Try

            ElseIf CBDocumento.Text = "Notas de Crédito" Then
                Try
                    cnn = New SqlConnection(StrTpm)

                    cmd4 = New SqlCommand("FNCConta_Back_xml", cnn)
                    cmd4.CommandType = CommandType.StoredProcedure
                    cmd4.Parameters.AddWithValue("@Tipodoc", 2)
                    cmd4.Parameters.AddWithValue("@FechaInicial", DTIni.Value)
                    cmd4.Parameters.AddWithValue("@FechaFinal", DTFin.Value)
                    cmd4.Parameters.AddWithValue("@param", DTFin.Value)
                    cnn.Open()

                    cmd4.ExecuteNonQuery()
                    cmd4.Connection.Close()

                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd4
                    da.SelectCommand.Connection = cnn


                    ''--------------------------------------------
                    Dim DsVtas As New DataSet
                    da.Fill(DsVtas, "DsVtas")

                    DsVtas.Tables(0).TableName = "Inventario"

                    DvConta.Table = DsVtas.Tables("Inventario")

                    DataGridView1.DataSource = DvConta

                    DisenoGrid()

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                        cnn.Close()
                    End If
                End Try

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DTIni_ValueChanged(sender As Object, e As EventArgs) Handles DTIni.ValueChanged

    End Sub

    Private Sub DTFin_ValueChanged(sender As Object, e As EventArgs) Handles DTFin.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub CBDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBDocumento.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class