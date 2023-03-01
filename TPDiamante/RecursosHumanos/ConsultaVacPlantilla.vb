Public Class ConsultaVacPlantilla
    Dim SQL As New Comandos_SQL()
    Private Sub ConsultaVacPlantilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = SQL.EjecutarProcedimiento("SP_ConsultasVacPlantilla", "", 0, "")
        DataGridView1.ReadOnly = True
        '' DataGridView1.Columns("Clave").Visible = False
        '' DataGridView1.Columns("Almacen").Visible = False
        'DataGridView1.DefaultCellStyle.ForeColor = Color.White
        'DataGridView1.DefaultCellStyle.BackColor = Color.DarkRed
        Pintar()

    End Sub

    Private Sub Pintar()
        'DataGridView1.Rows(2).DefaultCellStyle.BackColor = Color.DarkRed
        'DataGridView1.Rows(2).DefaultCellStyle.ForeColor = Color.White
        '   DataGridView1.Rows(2).DefaultCellStyle.BackColor = Color.Black
        '  DataGridView1.Rows(2).DefaultCellStyle.ForeColor = Color.White
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    If DataGridView1.Rows(i).Cells(8).Value = DataGridView1.Rows(i).Cells(10).Value Then
        '        DataGridView1.Rows(i).Cells(8).Value = 2040
        '        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Black
        '        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Black
        '        DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.White
        '    End If

        'Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(4, i) = DataGridView1.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 5, Col + 1).NumberFormat = "@"

                    'If Col = 6 Then
                    '    exHoja.Cells.Item(Fila + 5, Col + 1) = Format(CDate(DataGridView1.Rows(Fila).Cells(Col).Value), "dd-mm-yyyy")
                    'Else
                    exHoja.Cells.Item(Fila + 5, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value
                    ' End If

                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(3).Font.Bold = 1
            exHoja.Rows.Item(3).HorizontalAlignment = 3

            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            ''Cambiamos orientacion ala hola
            exHoja.Cells.Item(1, 1) = "Reporte de Vacaciones - Plantilla de Empleados"
            exHoja.Cells.Item(2, 1) = "Fecha: " + Date.Now.ToShortDateString
            exLibro.Worksheets("Hoja2").Columns(18).HIDDEN = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        For Each Fila As DataGridViewRow In DataGridView1.Rows

            If Fila.Cells("PeriodoCorrespondiente").Value = "2023" Then
                Fila.DefaultCellStyle.BackColor = Color.DarkRed
                Fila.DefaultCellStyle.ForeColor = Color.White

            End If

        Next
    End Sub
End Class