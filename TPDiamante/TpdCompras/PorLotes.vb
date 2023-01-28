Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO


Public Class PorLotes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName

        Dim objConn As OleDbConnection
        Dim oleDA As OleDbDataAdapter
        Dim ds As DataSet
        Dim FileName As String
        FileName = TextBox1.Text

        Try
            'Create a OLEDB connection for Excel file
            Dim connectionString As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1"""
            objConn = New OleDbConnection(connectionString)
            oleDA = New OleDbDataAdapter("select * from [Hoja1$]", objConn)
            ds = New DataSet()
            'Fill the Data Set
            oleDA.Fill(ds)
            'Set DataSource of DataGridView
            DataGridView1.DataSource = ds.Tables(0)
            ds.Dispose()
            oleDA.Dispose()
            objConn.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        DataGridView1.AutoResizeColumnHeadersHeight()

        DataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)


    End Sub

    Private Sub PorLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cnn As SqlConnection = Nothing

        Dim cmd4 As SqlCommand = Nothing
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cnn = New SqlConnection(StrTpm)

            'SELECT Estado 0,FecSuc 1,FecAlm 2,Factura 3,FecFac 4,DiasTransFecFacFecRecAlm 5,CardCode 6,CardName 7,
            'Sucursal 8, Almacen 9, Cantidad 10, ItemCode 11, ItemName 12, ItmsGrpNam 13, "
            'Proveedor 14,Id 15"


            cmd4 = New SqlCommand("SP_InsetarTransportar", cnn)
            cmd4.CommandType = CommandType.StoredProcedure
            cmd4.Parameters.AddWithValue("@Id_Transportar", i)
            cmd4.Parameters.AddWithValue("@Articulo", DataGridView1.Rows(i).Cells(0).Value())
            cmd4.Parameters.AddWithValue("@Cantidad", DataGridView1.Rows(i).Cells(1).Value())
            cmd4.Parameters.AddWithValue("@De", ComboBox1.Text)
            cmd4.Parameters.AddWithValue("@A", ComboBox2.Text)
            cmd4.Parameters.AddWithValue("@Fecha", Date.Parse(DateTimePicker1.Value).Date.ToString("yyyyMMdd"))
            cmd4.Parameters.AddWithValue("@NumeroLote", "")
            cmd4.Parameters.AddWithValue("@Opcion", "INSERTAR")


            'cmd4.Parameters.AddWithValue("@FecEntAl", Date.Parse(DGGarantias.Item(33, i).Value).Date.ToString("yyyyMMdd"))

            cnn.Open()

            cmd4.ExecuteNonQuery()
            cmd4.Connection.Close()
            'Using cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Ruta)
            '    Dim Sqlguardar As String
            '    Sqlguardar = "INSERT INTO T_TransportarExcel (Articulo, Cantidad, De, A, Fecha, NumeroLote) " _
            '        & "VALUES (@Articulo, @Cantidad, @De, @A, @Fecha, NumeroLote )"
            '    Dim cmd As New OleDbCommand(Sqlguardar, cnx)
            '    cmd.CommandType = CommandType.Text
            '    cmd.Parameters.AddWithValue("@Articulo", DataGridView1.Rows(i).Cells(0).Value())
            '    cmd.Parameters.AddWithValue("@Cantidad", DataGridView1.Rows(i).Cells(1).Value())
            '    cmd.Parameters.AddWithValue("@De", ComboBox1.Text)
            '    cmd.Parameters.AddWithValue("@A", ComboBox2.Text)
            '    cmd.Parameters.AddWithValue("@Fecha", DateTimePicker1.Value)
            '    cmd.Parameters.AddWithValue("@NumeroLote", "")
            '    cnx.Open()
            '    cmd.ExecuteNonQuery()
            '    cnx.Close()
            'End Using
        Next


    End Sub
End Class