﻿
Option Explicit On
'Option Strict On
Imports System.Data.SqlClient

Public Class ControlEnvios


  Public conexion As New SqlConnection(conexion_universal.CadenaSQLSAP)
  Public conexion2 As New SqlConnection(conexion_universal.CadenaSQL)

  Public DvDetalle As New DataView
    Public DvPeso As New DataView

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        '***********BUSCAR POR*********** 
        '********NUMERO DE FACTURA*******
        '
        If TBDocNum.Text <> "" Then


            conexion.Open()
            Dim cmd As SqlCommand = New SqlCommand("SELECT T0.DocEntry,T0.cardcode,T0.cardname,case when T3.name IS NULL then '' else t3.NAME end as 'cntctcode', " & _
            "CASE WHEN T0.numatcard IS NULL THEN '' ELSE T0.numatcard END AS 'numatcard',CASE WHEN T0.cursource IS NULL THEN '' ELSE T0.cursource END AS cursource, " & _
            "CASE WHEN T0.series IS NULL THEN '' ELSE T2.seriesname END AS seriesname, " & _
            "CASE WHEN T0.docstatus='C' THEN 'Cerrado' WHEN T0.printed='N' AND T0.docstatus='O' THEN 'Abierto' " & _
            "WHEN (T0.printed='Y' OR T0.printed='A') AND T0.docstatus='O' THEN 'Abrir: Imprimido' ELSE '' END as 'status', " & _
            "T0.docdate,T0.docduedate,T0.taxdate,T1.slpname,CASE WHEN t0.ownercode IS NULL THEN '' ELSE t0.ownercode END, " & _
            "t0.Comments, CASE WHEN T0.DiscPrcnt IS NULL THEN 0 ELSE CONVERT(DECIMAL(5,2),T0.DiscPrcnt) END AS DiscPrcnt, t0.doctype, " & _
            "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.VatSumFC) END AS 'VATSUM', " & _
            "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC) END AS 'doctotal', " & _
            "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.doctotal-t0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.VatSumFC) END as 'antdesc', " & _
            "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.paidtodate) ELSE CONVERT(DECIMAL(9,2),T0.PaidFC) end as 'impapli', " & _
            "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal - T0.PaidToDate) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.PaidFC) END AS 'saldopendiente' " & _
            "FROM OINV T0 " & _
            "LEFT JOIN OSLP T1 ON T0.SlpCode=T1.SlpCode " & _
            "LEFT JOIN NNM1 T2 ON T0.Series=T2.Series " & _
            "LEFT JOIN OCPR T3 ON T0.CntctCode=T3.CntctCode where docnum = @docnum ", conexion)
            cmd.Parameters.AddWithValue("@docnum", TBDocNum.Text)

            Try

                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    TBDocNum.BackColor = Color.White
                    TBCliente.BackColor = Color.White
                    TBNomCli.BackColor = Color.White

                    Dim row As DataRow = dt.Rows(0)

                    TBDocEntry.Text = CStr(row("docentry"))
                    TBCliente.Text = CStr(row("cardcode"))
                    TBNomCli.Text = CStr(row("cardname"))
                    TBPerCon.Text = CStr(row("cntctcode"))
                    'IIf(row(1) Is DbNull.Value, "", Convert.ToString(row(1)))         

                    TBNumRef.Text = IIf(CStr(row("numatcard")) Is DBNull.Value, "", Convert.ToString(CStr(row("numatcard"))))

                    If CStr(row("cursource")) = "L" Then
                        TBCurSource.Text = "Moneda local"
                    Else
                        TBCurSource.Text = "Moneda del sistema"
                    End If

                    TBSeries.Text = CStr(row("seriesname"))
                    TBEstado.Text = CStr(row("status"))
                    TBDocDate.Text = CStr(row("docdate"))
                    TBFecVen.Text = CStr(row("docduedate"))
                    TBFecDoc.Text = CStr(row("taxdate"))

                    If CStr(row("doctype")) = "I" Then
                        TBDocType.Text = "Artículo"
                    Else
                        TBDocType.Text = "Servicio"
                    End If

                    TBAgente.Text = CStr(row("slpname"))

                    TBComentarios.Text = CStr(row("comments"))


                    TBDescuento.Text = CStr(row("DiscPrcnt"))
                    TBDescuento.TextAlign = HorizontalAlignment.Right

                    TBAntesDesc.Text = CStr(row("antdesc"))
                    TBAntesDesc.TextAlign = HorizontalAlignment.Right

                    TBImpuesto.Text = CStr(row("vatsum"))
                    TBImpuesto.TextAlign = HorizontalAlignment.Right

                    TBTotalDoc.Text = CStr(row("doctotal"))
                    TBTotalDoc.TextAlign = HorizontalAlignment.Right

                    TBImporteApli.Text = CStr(row("impapli"))
                    TBImporteApli.TextAlign = HorizontalAlignment.Right

                    TBSaldoPen.Text = CStr(row("saldopendiente"))
                    TBSaldoPen.TextAlign = HorizontalAlignment.Right

                    '--------------******************************************

                    '--------------******************************************
                    '--------------******************************************
                    conexion2.Open()
                    Dim cmd4 As SqlCommand = Nothing
                    cmd4 = New SqlCommand("DetalleControlEnvios", conexion2)
                    cmd4.CommandType = CommandType.StoredProcedure
                    cmd4.Parameters.Add("@docentry", SqlDbType.Int).Value = TBDocEntry.Text


                    cmd4.ExecuteNonQuery()
                    cmd4.Connection.Close()
                    Dim da2 As New SqlDataAdapter
                    da2.SelectCommand = cmd4
                    da2.SelectCommand.Connection = conexion2


                    ''--------------------------------------------
                    Dim DsVtas As New DataSet
                    da2.Fill(DsVtas, "DsVtas")

                    DsVtas.Tables(0).TableName = "Detalle"
                    DsVtas.Tables(1).TableName = "Peso"

                    DvDetalle.Table = DsVtas.Tables("Detalle")

                    DGDetalle.DataSource = DvDetalle

                    DataGridView1.DataSource = DsVtas.Tables("Peso")

                    Label24.Text = DataGridView1.Item(0, 0).Value & " Kg"
                    'Label24.FontSize = 18 'Tamaño
                    'Label24.FontName = "Symbol" 'Tipo

                    DisenoGrid()

                Else
                    MsgBox("No hay factura con este folio")
                End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        If conexion2 IsNot Nothing AndAlso conexion2.State <> ConnectionState.Closed Then
                            conexion2.Close()
                        End If
            End Try



            '--------------******************************************
            ' ''ESTE CODIGO SE AGREGO EL SABADO
            conexion.Open()
            Dim cmd2 As SqlCommand = New SqlCommand("SELECT * FROM TPM.DBO.ControlEnviosHora " & _
            " WHERE Factura = @docnum ", conexion)
            cmd2.Parameters.AddWithValue("@docnum", TBDocNum.Text)

            'Dim dtFin As New DataTable
            Try

                Dim da3 As SqlDataAdapter = New SqlDataAdapter(cmd2)
                Dim dt2 As New DataTable
                da3.Fill(dt2)

                If dt2.Rows.Count > 0 Then

                    Dim row2 As DataRow = dt2.Rows(0)
                    TextBox1.Text = ""
                    TextBox1.Text = CStr(row2("Hora"))
                    'TextBox1.TextAlign = HorizontalAlignment.Center

                    ComboBox1.Text = CStr(row2("empacador"))

                    Timer1.Enabled = False
                Else

                    TextBox1.Text = ""
                    ComboBox1.Text = ""
                    Timer1.Enabled = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
            End Try

            '--------------******************************************

                    '***********************************************
                    '***********************************************
                    '***************CLAVE DEL CLIENTE***************
                    '***********************************************
                    '***********************************************

                ElseIf TBCliente.Text <> "" Then

                    conexion.Open()
                    Dim cmd As SqlCommand = New SqlCommand("SELECT T0.DocEntry,T0.DocNum,T0.cardname,case when T3.name IS NULL then '' else t3.NAME end as 'cntctcode', " & _
                    "CASE WHEN T0.numatcard IS NULL THEN '' ELSE T0.numatcard END AS 'numatcard',CASE WHEN T0.cursource IS NULL THEN '' ELSE T0.cursource END AS cursource, " & _
                    "CASE WHEN T0.series IS NULL THEN '' ELSE T2.seriesname END AS seriesname, " & _
                    "CASE WHEN T0.docstatus='C' THEN 'Cerrado' WHEN T0.printed='N' AND T0.docstatus='O' THEN 'Abierto' " & _
                    "WHEN (T0.printed='Y' OR T0.printed='A') AND T0.docstatus='O' THEN 'Abrir: Imprimido' ELSE '' END as 'status', " & _
                    "T0.docdate,T0.docduedate,T0.taxdate,T1.slpname,CASE WHEN t0.ownercode IS NULL THEN '' ELSE t0.ownercode END, " & _
                    "t0.Comments, CASE WHEN T0.DiscPrcnt IS NULL THEN 0 ELSE CONVERT(DECIMAL(9,2),T0.DiscPrcnt) END AS DiscPrcnt, t0.doctype, " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.VatSumFC) END AS 'VATSUM', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC) END AS 'doctotal', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.doctotal-t0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.VatSumFC) END as 'antdesc', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.paidtodate) ELSE CONVERT(DECIMAL(9,2),T0.PaidFC) end as 'impapli', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal - T0.PaidToDate) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.PaidFC) END AS 'saldopendiente' " & _
                    "FROM OINV T0 " & _
                    "LEFT JOIN OSLP T1 ON T0.SlpCode=T1.SlpCode " & _
                    "LEFT JOIN NNM1 T2 ON T0.Series=T2.Series " & _
                    "LEFT JOIN OCPR T3 ON T0.CntctCode=T3.CntctCode where T0.CardCode = @CardCode ", conexion)
                    cmd.Parameters.AddWithValue("@CardCode", TBCliente.Text)

                    Try

                        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If dt.Rows.Count = 1 Then

                            TBDocNum.BackColor = Color.White
                            TBCliente.BackColor = Color.White
                            TBNomCli.BackColor = Color.White

                            Dim row As DataRow = dt.Rows(0)

                            TBDocEntry.Text = CStr(row("docentry"))
                            TBDocNum.Text = CStr(row("DocNum"))
                            TBNomCli.Text = CStr(row("cardname"))
                            TBPerCon.Text = CStr(row("cntctcode"))
                            'IIf(row(1) Is DbNull.Value, "", Convert.ToString(row(1)))         

                            TBNumRef.Text = IIf(CStr(row("numatcard")) Is DBNull.Value, "", Convert.ToString(CStr(row("numatcard"))))

                            If CStr(row("cursource")) = "L" Then
                                TBCurSource.Text = "Moneda local"
                            Else
                                TBCurSource.Text = "Moneda del sistema"
                            End If

                            TBSeries.Text = CStr(row("seriesname"))
                            TBEstado.Text = CStr(row("status"))
                            TBDocDate.Text = CStr(row("docdate"))
                            TBFecVen.Text = CStr(row("docduedate"))
                            TBFecDoc.Text = CStr(row("taxdate"))

                            If CStr(row("doctype")) = "I" Then
                                TBDocType.Text = "Artículo"
                            Else
                                TBDocType.Text = "Servicio"
                            End If

                            TBAgente.Text = CStr(row("slpname"))

                            TBComentarios.Text = CStr(row("comments"))
                            TBDescuento.Text = CStr(row("DiscPrcnt"))
                            TBAntesDesc.Text = CStr(row("antdesc"))
                            TBImpuesto.Text = CStr(row("vatsum"))
                            TBTotalDoc.Text = CStr(row("doctotal"))
                            TBImporteApli.Text = CStr(row("impapli"))
                            TBSaldoPen.Text = CStr(row("saldopendiente"))


                            '--------------******************************************
                            '--------------******************************************
                            '--------------******************************************
                            conexion2.Open()
                            Dim cmd4 As SqlCommand = Nothing
                            cmd4 = New SqlCommand("DetalleFact", conexion2)
                            cmd4.CommandType = CommandType.StoredProcedure
                            cmd4.Parameters.Add("@docentry", SqlDbType.Int).Value = TBDocEntry.Text


                            cmd4.ExecuteNonQuery()
                            cmd4.Connection.Close()
                            Dim da2 As New SqlDataAdapter
                            da2.SelectCommand = cmd4
                            da2.SelectCommand.Connection = conexion2


                            ''--------------------------------------------
                            Dim DsVtas As New DataSet
                            da2.Fill(DsVtas, "DsVtas")

                            DsVtas.Tables(0).TableName = "Detalle"


                            DvDetalle.Table = DsVtas.Tables("Detalle")

                            DGDetalle.DataSource = DvDetalle


                            DisenoGrid()

                        ElseIf dt.Rows.Count > 1 Then
                            'MsgBox("PARTE PARA PROGRAMAR")
                            Module1.NumCli = TBCliente.Text
                            FacturasDetalleCliente.Show()

                        Else
                            MsgBox("No hay factura con este folio")
                        End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        If conexion2 IsNot Nothing AndAlso conexion2.State <> ConnectionState.Closed Then
                            conexion2.Close()
                        End If
                    End Try

                    '***********************************************
                    '***********************************************
                    '**************NOMBRE DEL CLIENTE***************
                    '***********************************************
                    '***********************************************

                ElseIf TBNomCli.Text <> "" Then


                    conexion.Open()
                    Dim cmd As SqlCommand = New SqlCommand("SELECT T0.DocEntry,T0.DocNum,T0.cardcode,case when T3.name IS NULL then '' else t3.NAME end as 'cntctcode', " & _
                    "CASE WHEN T0.numatcard IS NULL THEN '' ELSE T0.numatcard END AS 'numatcard',CASE WHEN T0.cursource IS NULL THEN '' ELSE T0.cursource END AS cursource, " & _
                    "CASE WHEN T0.series IS NULL THEN '' ELSE T2.seriesname END AS seriesname, " & _
                    "CASE WHEN T0.docstatus='C' THEN 'Cerrado' WHEN T0.printed='N' AND T0.docstatus='O' THEN 'Abierto' " & _
                    "WHEN (T0.printed='Y' OR T0.printed='A') AND T0.docstatus='O' THEN 'Abrir: Imprimido' ELSE '' END as 'status', " & _
                    "T0.docdate,T0.docduedate,T0.taxdate,T1.slpname,CASE WHEN t0.ownercode IS NULL THEN '' ELSE t0.ownercode END, " & _
                    "t0.Comments, CASE WHEN T0.DiscPrcnt IS NULL THEN 0 ELSE CONVERT(DECIMAL(9,2),T0.DiscPrcnt) END AS DiscPrcnt, t0.doctype, " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.VatSumFC) END AS 'VATSUM', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC) END AS 'doctotal', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.doctotal-t0.vatsum) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.VatSumFC) END as 'antdesc', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),t0.paidtodate) ELSE CONVERT(DECIMAL(9,2),T0.PaidFC) end as 'impapli', " & _
                    "CASE WHEN T0.DocCur = 'MXP' THEN CONVERT(DECIMAL(9,2),T0.DocTotal - T0.PaidToDate) ELSE CONVERT(DECIMAL(9,2),T0.DocTotalFC - T0.PaidFC) END AS 'saldopendiente' " & _
                    "FROM OINV T0 " & _
                    "LEFT JOIN OSLP T1 ON T0.SlpCode=T1.SlpCode " & _
                    "LEFT JOIN NNM1 T2 ON T0.Series=T2.Series " & _
                    "LEFT JOIN OCPR T3 ON T0.CntctCode=T3.CntctCode where T0.CardName LIKE @CardName + '%' ", conexion)
                    cmd.Parameters.AddWithValue("@CardName", TBNomCli.Text)

                    Try

                        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        If dt.Rows.Count = 1 Then
                            Dim row As DataRow = dt.Rows(0)

                            TBDocEntry.Text = CStr(row("docentry"))
                            TBDocNum.Text = CStr(row("DocNum"))
                            TBCliente.Text = CStr(row("CardCode"))
                            TBPerCon.Text = CStr(row("cntctcode"))
                            'IIf(row(1) Is DbNull.Value, "", Convert.ToString(row(1)))         

                            TBNumRef.Text = IIf(CStr(row("numatcard")) Is DBNull.Value, "", Convert.ToString(CStr(row("numatcard"))))

                            If CStr(row("cursource")) = "L" Then
                                TBCurSource.Text = "Moneda local"
                            Else
                                TBCurSource.Text = "Moneda del sistema"
                            End If

                            TBSeries.Text = CStr(row("seriesname"))
                            TBEstado.Text = CStr(row("status"))
                            TBDocDate.Text = CStr(row("docdate"))
                            TBFecVen.Text = CStr(row("docduedate"))
                            TBFecDoc.Text = CStr(row("taxdate"))

                            If CStr(row("doctype")) = "I" Then
                                TBDocType.Text = "Artículo"
                            Else
                                TBDocType.Text = "Servicio"
                            End If

                            TBAgente.Text = CStr(row("slpname"))

                            TBComentarios.Text = CStr(row("comments"))
                            TBDescuento.Text = CStr(row("DiscPrcnt"))
                            TBAntesDesc.Text = CStr(row("antdesc"))
                            TBImpuesto.Text = CStr(row("vatsum"))
                            TBTotalDoc.Text = CStr(row("doctotal"))
                            TBImporteApli.Text = CStr(row("impapli"))
                            TBSaldoPen.Text = CStr(row("saldopendiente"))

                            '--------------******************************************
                            '--------------******************************************
                            '--------------******************************************
                            conexion2.Open()
                            Dim cmd4 As SqlCommand = Nothing
                            cmd4 = New SqlCommand("DetalleFact", conexion2)
                            cmd4.CommandType = CommandType.StoredProcedure
                            cmd4.Parameters.Add("@docentry", SqlDbType.Int).Value = TBDocEntry.Text


                            cmd4.ExecuteNonQuery()
                            cmd4.Connection.Close()
                            Dim da2 As New SqlDataAdapter
                            da2.SelectCommand = cmd4
                            da2.SelectCommand.Connection = conexion2


                            ''--------------------------------------------
                            Dim DsVtas As New DataSet
                            da2.Fill(DsVtas, "DsVtas")

                            DsVtas.Tables(0).TableName = "Detalle"


                            DvDetalle.Table = DsVtas.Tables("Detalle")

                            DGDetalle.DataSource = DvDetalle


                            DisenoGrid()

                        ElseIf dt.Rows.Count > 1 Then
                            'MsgBox("PARTE PARA PROGRAMAR")
                            Module1.NomCli = TBNomCli.Text
                            Form3.Show()

                        Else
                            MsgBox("No hay factura con este folio")
                        End If


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If conexion IsNot Nothing AndAlso conexion.State <> ConnectionState.Closed Then
                            conexion.Close()
                        End If
                        If conexion2 IsNot Nothing AndAlso conexion2.State <> ConnectionState.Closed Then
                            conexion2.Close()
                        End If
                    End Try

                End If  'TBDocNum.Text <> ""

        Try

            'Dim peso As Decimal = 0
            'For i = 0 To DGDetalle.RowCount
            '    peso = peso + DGDetalle.Item(17, i).Value
            'Next

            'Label24.Text = peso

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DisenoGrid()
        '-------Diseño de DATAGRID Totales
        With Me.DGDetalle
            '.DataSource = DtAgte
            '.ReadOnly = True
            'Color de Renglones en Grid
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
            .AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
            .DefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue


            'Propiedad para no mostrar el cuadro que se encuentra en la parte
            'Superior Izquierda del gridview
            .RowHeadersVisible = True
            .RowHeadersWidth = 25
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'Color de linea del grid

            DGDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Try

                'Catch ex As Exception

                'End Try


                .Columns(0).HeaderText = "Número de Art."
                .Columns(0).Width = 100
                .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(0).ReadOnly = True

                .Columns(1).HeaderText = "Descripción"
                .Columns(1).Width = 200
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(1).ReadOnly = True

                .Columns(2).HeaderText = "Stock"
                .Columns(2).Width = 60
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).DefaultCellStyle.Format = "###,###,###"
                .Columns(2).ReadOnly = True


                .Columns(3).HeaderText = "Almacén"
                .Columns(3).Width = 50
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).ReadOnly = True

                .Columns(4).HeaderText = "Cantidad"
                .Columns(4).Width = 50
                .Columns(4).DefaultCellStyle.Format = "#,##0"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).ReadOnly = True

                .Columns(5).HeaderText = "Lista de Precios"
                .Columns(5).Width = 50
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).ReadOnly = True

                .Columns(6).HeaderText = "Precio Unitario"
                .Columns(6).Width = 85
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).DefaultCellStyle.Format = "$ #,##0.##0"
                .Columns(6).ReadOnly = True

                .Columns(7).HeaderText = "% de descuento"
                .Columns(7).Width = 75
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).DefaultCellStyle.Format = "#0.#0 %"
                .Columns(7).ReadOnly = True

                .Columns(8).HeaderText = "Precio tras el descuento"
                .Columns(8).Width = 85
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(8).DefaultCellStyle.Format = "$ ###,##0.#0"
                .Columns(8).ReadOnly = True

                .Columns(9).HeaderText = "Moneda"
                .Columns(9).Width = 90
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(9).DefaultCellStyle.Format = "$ ###,##0.#0"
                .Columns(9).Visible = False
                .Columns(9).ReadOnly = True

                .Columns(10).HeaderText = "Indicador de impuestos"
                .Columns(10).Width = 100
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(10).Visible = False
                .Columns(10).ReadOnly = True

                .Columns(11).HeaderText = "Total (ML)"
                .Columns(11).Width = 90
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(11).DefaultCellStyle.Format = "$ ###,###,##0.#0"
                .Columns(11).ReadOnly = True

                .Columns(12).HeaderText = "Comisión"
                .Columns(12).Width = 60
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(12).DefaultCellStyle.Format = "##0.#0"
                .Columns(12).ReadOnly = True

                .Columns(13).HeaderText = "Precio bruto"
                .Columns(13).Width = 75
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(13).DefaultCellStyle.Format = "$ ###,###,##0.#0"
                .Columns(13).Visible = False
                .Columns(13).ReadOnly = True

                .Columns(14).HeaderText = "Precio de coste ingreso bruto"
                .Columns(14).Width = 80
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(14).DefaultCellStyle.Format = "$ ###,###,##0.#0"
                .Columns(14).Visible = False
                .Columns(14).ReadOnly = True

                .Columns(15).HeaderText = "Ingreso bruto (ML)"
                .Columns(15).Width = 75
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(15).DefaultCellStyle.Format = "$ ###,###,##0.#0"
                .Columns(15).Visible = False
                .Columns(15).ReadOnly = True

                .Columns(16).HeaderText = "Total bruto (ML)"
                .Columns(16).Width = 80
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(16).DefaultCellStyle.Format = "$ ###,###,##0.#0"
                .Columns(16).Visible = False
                .Columns(16).ReadOnly = True

                .Columns(17).HeaderText = "Peso kg"
                .Columns(17).Width = 60
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(17).DefaultCellStyle.Format = "###,##0.#0"
                .Columns(17).ReadOnly = True

                .Columns(18).HeaderText = "Peso Total"
                .Columns(18).Width = 60
                .Columns(18).DefaultCellStyle.Format = "###,##0.#0"
                .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(19).HeaderText = "Caja"
                .Columns(19).Width = 55
                .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                .Columns(20).HeaderText = "DocEntry"
                .Columns(20).Width = 60
                .Columns(20).Visible = False

            Catch ex As Exception

            End Try

        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DGDetalle.Columns.Clear()

        'Recorremos todos los controles del formulario que enviamos  
        For Each control As Control In Me.Controls

            'Filtramos solo aquellos de tipo TextBox 
            If TypeOf control Is TextBox Then
                control.Text = "" ' eliminar el texto  
            End If
        Next

        TBDocNum.BackColor = Color.Cornsilk
        TBCliente.BackColor = Color.Cornsilk
        TBNomCli.BackColor = Color.Cornsilk

    End Sub

    Private Sub FacturaConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox1.Text = Now.ToString("hh:mm:ss")
        'Timer1.Enabled = True

        TBDocNum.BackColor = Color.Cornsilk
        TBCliente.BackColor = Color.Cornsilk
        TBNomCli.BackColor = Color.Cornsilk
    End Sub

    Private Sub DGDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles DGDetalle.CurrentCellChanged

    End Sub

    Private Sub DGDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGDetalle.CellEndEdit
        'If Me.DGDetalle.Columns(e.ColumnIndex).Name = "Seguimiento" Then

        Dim cnn As SqlConnection = Nothing

        Dim cmd4 As SqlCommand = Nothing

        'For i = 0 To DGGarantias.RowCount - 1

        Try

            cnn = New SqlConnection(StrTpm)

            'SELECT Estado 0,FecSuc 1,FecAlm 2,Factura 3,FecFac 4,DiasTransFecFacFecRecAlm 5,CardCode 6,CardName 7,
            'Sucursal 8, Almacen 9, Cantidad 10, ItemCode 11, ItemName 12, ItmsGrpNam 13, "
            'Proveedor 14,Id 15"


            cmd4 = New SqlCommand("UpdateControlEnvios", cnn)
            cmd4.CommandType = CommandType.StoredProcedure
            cmd4.Parameters.AddWithValue("@docentry", TBDocNum.Text)
            cmd4.Parameters.AddWithValue("@ITEMCODE", DGDetalle.Item(0, DGDetalle.CurrentRow.Index).Value)
            cmd4.Parameters.AddWithValue("@NUMCAJA", DGDetalle.Item(19, DGDetalle.CurrentRow.Index).Value)

            cnn.Open()

            cmd4.ExecuteNonQuery()
            cmd4.Connection.Close()

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd4
            da.SelectCommand.Connection = cnn

            ''--------------------------------------------
            'Dim DsVtas As New DataSet
            'da.Fill(DsVtas, "DsVtas")

            ''DsVtas.Tables(0).TableName = "Inventario"

            ''DvInventario.Table = DsVtas.Tables("Inventario")

            ''DGInventario.DataSource = DvInventario

        Catch ex As Exception
            'Return
            'MsgBox(ex.Message)
        Finally
            If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                cnn.Close()
            End If
        End Try

        'Next

        'End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox1.Text = Now.ToString("hh:mm:ss")
        TextBox1.TextAlign = HorizontalAlignment.Center
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim cnn As SqlConnection = Nothing

        Dim cmd4 As SqlCommand = Nothing

        'For i = 0 To DGGarantias.RowCount - 1

        Try

            cnn = New SqlConnection(StrTpm)

            'SELECT Estado 0,FecSuc 1,FecAlm 2,Factura 3,FecFac 4,DiasTransFecFacFecRecAlm 5,CardCode 6,CardName 7,
            'Sucursal 8, Almacen 9, Cantidad 10, ItemCode 11, ItemName 12, ItmsGrpNam 13, "
            'Proveedor 14,Id 15"


            cmd4 = New SqlCommand("UpdateControlEnviosHora", cnn)
            cmd4.CommandType = CommandType.StoredProcedure
            cmd4.Parameters.AddWithValue("@docentry", TBDocNum.Text)
            cmd4.Parameters.AddWithValue("@Hora", TextBox1.Text)
            cmd4.Parameters.AddWithValue("@Empacador", ComboBox1.Text)

            cnn.Open()

            cmd4.ExecuteNonQuery()
            cmd4.Connection.Close()

            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd4
            da.SelectCommand.Connection = cnn

            ''--------------------------------------------
            'Dim DsVtas As New DataSet
            'da.Fill(DsVtas, "DsVtas")

            ''DsVtas.Tables(0).TableName = "Inventario"

            ''DvInventario.Table = DsVtas.Tables("Inventario")

            ''DGInventario.DataSource = DvInventario

        Catch ex As Exception
            'Return
            MsgBox(ex.Message)
        Finally
            If cnn IsNot Nothing AndAlso cnn.State <> ConnectionState.Closed Then
                cnn.Close()
            End If
        End Try
    End Sub
End Class
