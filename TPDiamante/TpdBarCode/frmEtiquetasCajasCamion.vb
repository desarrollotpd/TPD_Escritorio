Imports ZXing
Imports ZXing.QrCode
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Data.SqlClient

Public Class frmEtiquetasCajasCamion
    Dim options As New QrCodeEncodingOptions()
    Dim BarCode As String
    Dim codigoCliente As String
    Private Sub GenerateCode()
        Dim writer = New BarcodeWriter()
        'writer.Format = BarcodeFormat.CODE_128


        'Dim result = writer.Write(Name)
        'Dim path As String = ("QRImage.png")
        'Dim barcodeBitmap = New Bitmap(result)


        'Using memory As New MemoryStream()
        ' Using fs As New FileStream(path, FileMode.Create, FileAccess.ReadWrite)
        '  barcodeBitmap.Save(memory, ImageFormat.Png)
        '  Dim bytes As Byte() = memory.ToArray()
        '  fs.Write(bytes, 0, bytes.Length)
        ' End Using
        'End Using
        'pbBarCode.Visible = True
        'pbBarCode.ImageLocation = "QRImage.png"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If txtBarCode.Text <> "" And cmbArticulos.Text <> "" And txtDescripcion.Text <> "" And txtClasificacion.Text <> "" And txtCopias.Text <> "" Then
        If cmbCodigoCliente.Text.Trim <> "" And cmbNombreCliente.Text.Trim <> "" And cmbRutas.Text.Trim <> "" Then
            'Valido longitudes
            If (cmbCodigoCliente.Text.Length = 0) Then
                MessageBox.Show("Debe ingreasar el número del cliente")
                cmbCodigoCliente.Focus()
                Exit Sub
            End If

            If (cmbNombreCliente.Text.Length = 0) Then
                MessageBox.Show("Debe ingresar el nombre del cliente")
                cmbNombreCliente.Focus()
                Exit Sub
            End If

            If (cmbRutas.Text.Trim.Length = 0) Then
                MessageBox.Show("Debe ingresar la ruta")
                cmbRutas.Focus()
                Exit Sub
            End If

            If (txtCopias.Text.Trim().Equals("")) Then
                MessageBox.Show("Deberá indicar el número de copias a imprimir")
                txtCopias.Focus()
                Exit Sub
            ElseIf (IsNumeric(txtCopias.Text.Trim()).Equals(False)) Then
                MessageBox.Show("Deberá indicar un valor numerico de copias a imprimir")
                txtCopias.Focus()
                Exit Sub
            ElseIf (Integer.Parse(txtCopias.Text.Trim()) <= 0) Then
                MessageBox.Show("Deberá indicar un valor superior a cero para el número de copias a imprimir")
                txtCopias.Focus()
                Exit Sub
            End If

            zplPrint(cmbCodigoCliente.Text, cmbNombreCliente.Text, cmbRutas.Text, txtCopias.Text)
        Else
            MessageBox.Show("Verifique que los campos para la generacion de la ubicación esten todos llenos con información")
        End If
    End Sub

    Sub zplPrint(numCte As String, NombreCte As String, Ruta As String, Copias As Integer)
        Dim ipZebra As String = "192.168.8.163"
        Dim port As Integer = 9100
        Dim posX As String

        'Los codigos tendran siempre la misma longitud en caracteres
        '  BLQ: 2
        '  SCC: 2
        '  RCK: 1
        '  NVL: 1
        'SPCIO: 3

        Dim DescEtiqueta As String = "ok"
        Dim BarCode As String = DescEtiqueta
        Dim DescUbicacion = "BLQ:"

        If Copias <> 0 Then
            For i = 1 To Copias
                'ETIQUETA IZQUIERDA
                Dim ZPLCommand As String = "^XA^CI28^PW792"
                'Numero de cliente
                ZPLCommand &= "^FO50,50^A0N,60,60^FB700,1,0,C^FD " & cmbCodigoCliente.Text & "^FS"


                'Nombre del cliente
                ZPLCommand &= "^FO70,140^A0N,60,30^FB700,3,0,C^FD" + cmbNombreCliente.Text + "^FS"

                'Nombre de Ruta
                ZPLCommand &= "^FO70,320^A0N,60,60^FB700,1,0,C^FD" + cmbRutas.Text + "^FS"

                ZPLCommand &= "^XZ" 'Creo que con esto manda a imprimir

                'Return
                Try
                    Dim Cliente As New System.Net.Sockets.TcpClient()
                    Cliente.Connect(ipZebra, port)

                    Dim writer As New System.IO.StreamWriter(Cliente.GetStream())
                    writer.Write(ZPLCommand)
                    writer.Flush()

                    writer.Close()
                    Cliente.Close()

                    If (Integer.Parse(txtCopias.Text.Trim()) > 1) Then
                        MessageBox.Show("Las etiquetas fueron impresas correctamente", "Impresión correcta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("La etiqueta fue impresa correctamente", "Impresión correcta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            Next
        Else
            MessageBox.Show("Para generar las etiquetas el número de copias debe de ser diferente a 0(cero)", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub llenaCliente()
        Using SqlConnection As New SqlConnection(StrCon)
            Dim DSetTablas As New DataSet

   Dim ConsutaLista As String = "SELECT CardCode FROM SBO_TPD.dbo.OCRD WHERE frozenFor = 'N' AND CardCode like 'C-%' ORDER BY CARDCODE ASC"
   Dim daClientes As New SqlDataAdapter(ConsutaLista, SqlConnection)

            daClientes.Fill(DSetTablas, "Clientes")

            Me.cmbCodigoCliente.DataSource = DSetTablas.Tables("Clientes")
            Me.cmbCodigoCliente.DisplayMember = "CardCode"
            Me.cmbCodigoCliente.ValueMember = "CardCode"
            Me.cmbCodigoCliente.SelectedIndex = 0
        End Using
    End Sub





    Private Sub llenaNombreCliente()
        Using SqlConnection As New SqlConnection(StrCon)
            Dim DSetTablas As New DataSet

            Dim ConsutaLista As String = "SELECT CardName FROM SBO_TPD.dbo.OCRD where CardCode = '" + codigoCliente + "'"
            Dim daClientes As New SqlDataAdapter(ConsutaLista, SqlConnection)

            daClientes.Fill(DSetTablas, "Cliente")

            Me.cmbNombreCliente.DataSource = DSetTablas.Tables("Cliente")
            Me.cmbNombreCliente.DisplayMember = "CardName"
            Me.cmbNombreCliente.ValueMember = "CardName"
            ' Me.cmbNombreCliente.SelectedIndex = 0
        End Using
    End Sub


    Private Sub llenaRutaCliente()
        Using SqlConnection As New SqlConnection(StrCon)
            Dim DSetTablas As New DataSet

            Dim ConsutaLista As String = "SELECT U_BXP_Ruta FROM SBO_TPD.dbo.OCRD where CardCode = '" + codigoCliente + "'"
            Dim daClientes As New SqlDataAdapter(ConsutaLista, SqlConnection)

            daClientes.Fill(DSetTablas, "ClienteRuta")

            Me.cmbRutas.DataSource = DSetTablas.Tables("ClienteRuta")
            Me.cmbRutas.DisplayMember = "U_BXP_Ruta"
            Me.cmbRutas.ValueMember = "U_BXP_Ruta"
            ' Me.cmbNombreCliente.SelectedIndex = 0
        End Using
    End Sub
    Private Sub frmEtiquetasCajasCamion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaCliente()
    End Sub

 Private Sub cmbCodigoCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCodigoCliente.SelectedIndexChanged
  codigoCliente = cmbCodigoCliente.Text
  llenaNombreCliente()
  llenaRutaCliente()
 End Sub

End Class