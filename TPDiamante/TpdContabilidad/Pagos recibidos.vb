Imports System.Data.SqlClient
Imports System.IO
Imports ClosedXML.Excel

Public Class Pagos_recibidos

    Dim DvPagos As New DataView
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cnn As SqlConnection = Nothing
        Dim cmd4 As SqlCommand = Nothing

        Try
            cnn = New SqlConnection(StrTpm)



            cmd4 = New SqlCommand("PagosRecibidos", cnn)
            cmd4.CommandType = CommandType.StoredProcedure
            'cmd4.Parameters.AddWithValue("@Tipodoc", 1)
            cmd4.Parameters.AddWithValue("@fechainicial", dtpInicio.Value.Date)
            cmd4.Parameters.AddWithValue("@fechafinal", dtpFin.Value)

            cnn.Open()

            cmd4.ExecuteNonQuery()
            cmd4.Connection.Close()

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd4
            da.SelectCommand.Connection = cnn


            ''--------------------------------------------
            Dim DsVtas As New DataSet
            da.Fill(DsVtas, "DsVtas")

            DsVtas.Tables(0).TableName = "Pagos"

            DvPagos.Table = DsVtas.Tables("Pagos")

            DataGridView1.DataSource = DvPagos


            'DisenoGrid()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                cnn.Close()
            End If
        End Try
        DisenoGrid()
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged


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

                .Columns(0).HeaderText = "Pago"

                .Columns(1).HeaderText = "Fecha de aplicación del pago"
                .Columns(1).Width = 90
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(2).HeaderText = "Fecha de recepcion del pago"
                .Columns(2).Width = 90
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(3).HeaderText = "Código cliente"
                .Columns(3).Width = 90
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(4).HeaderText = "Nombre Cliente"
                .Columns(4).Width = 150
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(5).HeaderText = "Factura"
                .Columns(5).Width = 70
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(6).HeaderText = "Fecha Factura"
                .Columns(6).Width = 70
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



                .Columns(7).HeaderText = "Importe aplicado"
                .Columns(7).Width = 90
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).DefaultCellStyle.Format = "$ ###,###,##0.##"

                'Vta Neta
                .Columns(8).HeaderText = "IVA causado"
                .Columns(8).Width = 100
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).DefaultCellStyle.Format = "$ ###,###,##0.##"

                .Columns(9).HeaderText = "Importe Pago"
                .Columns(9).Width = 70
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(9).DefaultCellStyle.Format = "$ ###,###,##0.##"

                .Columns(10).HeaderText = "Método de pago(Factura)"
                .Columns(10).Width = 90
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(11).HeaderText = "Método de pago(Pago)"
                .Columns(11).Width = 100
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                .Columns(12).HeaderText = "Banco"
                .Columns(12).Width = 100
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                .Columns(13).HeaderText = "Comentarios"
                .Columns(13).Width = 100
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns(14).HeaderText = "Folio Fiscal Timbrado"
                .Columns(14).Width = 100
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GridAExcel(DataGridView1)
    End Sub

    Sub Exportar()
        Try
            Dim dt As New DataTable()
            For Each columns As DataGridViewColumn In DataGridView1.Columns
                dt.Columns.Add(columns.HeaderText, columns.ValueType)
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                dt.Rows.Add()

                For Each cell As DataGridViewCell In row.Cells
                    If Not Convert.IsDBNull(cell.Value) = 0 Then
                        dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = IsDBNull("")
                    Else
                        If cell.Value = Nothing Then
                            dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = IsDBNull("")
                        Else
                            dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
                        End If
                    End If
                Next
            Next

            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Excel|*.xlsx"
            saveFileDialog1.Title = "Save Excel File"
            saveFileDialog1.FileName = "Export_" & DataGridView1.Name.ToString() & ".xlsx"
            saveFileDialog1.ShowDialog()
            saveFileDialog1.InitialDirectory = "C:/"

            If saveFileDialog1.FileName <> "" Then
                Dim fs As FileStream = CType(saveFileDialog1.OpenFile(), FileStream)
                fs.Close()
            End If

            Dim strFileName As String = saveFileDialog1.FileName
            Dim blnFileOpen As Boolean = False

            Using wb As New XLWorkbook
                wb.Worksheets.Add(dt, "Hoja 1")
                wb.SaveAs(strFileName)
            End Using

            Process.Start(strFileName)
        Catch ex As Exception
            MessageBox.Show("¡Error al exportar archivo: " + Environment.NewLine + ex.ToString() + "!", "¡Error en ExportarSinEstilo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas
            'y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) =
                            ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna
            'se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
        Return True
    End Function

    Private Sub DataGridView1_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        If DataGridView1.Rows(e.RowIndex).Cells("MetododePagofactura").Value <> DataGridView1.Rows(e.RowIndex).Cells("MetodoPagoPago").Value Then

            DataGridView1.Rows(e.RowIndex).Cells("Pago").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Pago").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Fecha de aplicación de pago").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Fecha de aplicación de pago").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Fecha de recepcion del pago").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Fecha de recepcion del pago").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Código cliente").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Código cliente").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Nombre Cliente").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Factura").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Factura").Style.ForeColor = Color.White



            DataGridView1.Rows(e.RowIndex).Cells("Fecha Factura").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Fecha Factura").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("ImporteAplicado").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("ImporteAplicado").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("Iva causado").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Iva causado").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("ImporteAplicado").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("ImporteAplicado").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Importe Pago").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Importe Pago").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("MetododePagofactura").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("MetododePagofactura").Style.ForeColor = Color.Red


            DataGridView1.Rows(e.RowIndex).Cells("MetodoPagoPago").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("MetodoPagoPago").Style.ForeColor = Color.White

            DataGridView1.Rows(e.RowIndex).Cells("Banco").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Banco").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("Comentarios").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Comentarios").Style.ForeColor = Color.White


            DataGridView1.Rows(e.RowIndex).Cells("Folio Fiscal Timbrado").Style.BackColor = Color.Red
            DataGridView1.Rows(e.RowIndex).Cells("Folio Fiscal Timbrado").Style.ForeColor = Color.White


        End If
    End Sub


End Class