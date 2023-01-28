using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Collections.Generic;

namespace TPD_C.Ventas
{
 public partial class frmExistenciasArticulosRemate : Form
 {
  public frmExistenciasArticulosRemate()
  {
   InitializeComponent();
  }

  DataView dvLineas = new DataView();
  DataView dvAlmacen = new DataView();
    
  public void llenarLineas()
  {
   string llenaLineas = "SELECT ' TODOS' U_sublinea UNION SELECT DISTINCT U_sublinea FROM OITM T0 INNER JOIN OITW T1 ON T0.ItemCode = T1.ItemCode  WHERE T0.U_sublinea IS NOT NULL AND ItmsGrpCod = 205 AND T1.OnHand >0 and WhsCode in('01','03','07') ORDER BY U_sublinea ASC";
   conexion.conectar(false);

   SqlDataAdapter DALineas = new SqlDataAdapter(llenaLineas, conexion.con);

   DataSet DsLineas = new DataSet();

   DALineas.Fill(DsLineas, "Lineas");
   dvLineas.Table = DsLineas.Tables["Lineas"];
   cboLinea.DataSource = dvLineas;
   cboLinea.DisplayMember = "U_sublinea";
   cboLinea.ValueMember = "U_sublinea";

   conexion.cerra_conectar();
  }

  public void llenarAlmacenes()
  {
   string llenaAlmacenes = "SELECT '999' CveAlmacen, 'TODOS' U_sublinea UNION SELECT WhsCode CveAlmacen, WhsName Almacen FROM SBO_TPD.dbo.OWHS WHERE WhsCode IN ('01','03','07')";
   conexion.conectar(true);

   SqlDataAdapter DAlmacen = new SqlDataAdapter(llenaAlmacenes, conexion.con);

   DataSet DsAlmacen = new DataSet();

   DAlmacen.Fill(DsAlmacen, "Almacen");

   dvAlmacen.Table = DsAlmacen.Tables["Almacen"];
   cmbAlmacen.DataSource = dvAlmacen;
   cmbAlmacen.DisplayMember = "U_sublinea";
   cmbAlmacen.ValueMember = "CveAlmacen";

   conexion.cerra_conectar();
  }

  public void cargarInformacion()
  {
   conexion.conectar(true);
   SqlCommand cmd = new SqlCommand("SP_RpteExistenciasArticulosRemate2", conexion.con);
   cmd.CommandType = CommandType.StoredProcedure;

   cmd.Parameters.AddWithValue("@Almacen", Convert.ToString(cmbAlmacen.SelectedValue));
   cmd.Parameters.AddWithValue("@Linea", Convert.ToString(cboLinea.SelectedValue));

   SqlDataAdapter da = new SqlDataAdapter(cmd);
   DataTable dt = new DataTable();
   da.Fill(dt);
   dgvArticulosRemate.DataSource = dt;
   conexion.cerra_conectar();
  }

  public void diseñoGrid()
  {
            dgvArticulosRemate.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dgvArticulosRemate.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvArticulosRemate.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvArticulosRemate.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            dgvArticulosRemate.Columns["Articulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArticulosRemate.Columns["Articulo"].ReadOnly = true;
            dgvArticulosRemate.Columns["Articulo"].Width = 110;

            dgvArticulosRemate.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArticulosRemate.Columns["Descripcion"].ReadOnly = true;
            dgvArticulosRemate.Columns["Descripcion"].Width = 340;

            dgvArticulosRemate.Columns["Sublinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArticulosRemate.Columns["Sublinea"].ReadOnly = true;
            dgvArticulosRemate.Columns["Sublinea"].Width = 130;

            dgvArticulosRemate.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArticulosRemate.Columns["Price"].ReadOnly = true;
            dgvArticulosRemate.Columns["Price"].Width =70;
            dgvArticulosRemate.Columns["Price"].DefaultCellStyle.Format = "###,###,###.00";


   //          .Columns(6).HeaderText = "$ Ventas Netas"
   //.Columns(6).Width = 90
   //.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
   //.Columns(6).DefaultCellStyle.Format = "###,###,###.00"


            dgvArticulosRemate.Columns["Puebla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvArticulosRemate.Columns["Puebla"].ReadOnly = true;
            dgvArticulosRemate.Columns["Puebla"].Width = 50;
            dgvArticulosRemate.Columns["Puebla"].DefaultCellStyle.Format = "###,##0";

            dgvArticulosRemate.Columns["Merida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvArticulosRemate.Columns["Merida"].ReadOnly = true;
            dgvArticulosRemate.Columns["Merida"].Width = 50;
            dgvArticulosRemate.Columns["Merida"].DefaultCellStyle.Format = "###,##0";

            dgvArticulosRemate.Columns["Tuxtla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvArticulosRemate.Columns["Tuxtla"].ReadOnly = true;
            dgvArticulosRemate.Columns["Tuxtla"].Width = 50;
            dgvArticulosRemate.Columns["Tuxtla"].DefaultCellStyle.Format = "###,##0";

            dgvArticulosRemate.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvArticulosRemate.Columns["Total"].ReadOnly = true;
            dgvArticulosRemate.Columns["Total"].Width = 50;
            dgvArticulosRemate.Columns["Total"].DefaultCellStyle.Format = "###,##0";

            dgvArticulosRemate.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

  private void button5_Click(object sender, EventArgs e)
  {
   dgvArticulosRemate.Rows.RemoveAt(dgvArticulosRemate.CurrentRow.Index);
  }

  private void button6_Click(object sender, EventArgs e){
   DataTable dt = new DataTable();

   List<Boolean> columnas = new List<bool>();

   //Adding the Columns
   foreach (DataGridViewColumn column in dgvArticulosRemate.Columns)
   {
    if (!column.HeaderText.Equals("Puebla") && !column.HeaderText.Equals("Mérida") && !column.HeaderText.Equals("Tuxtla")) {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else if (column.HeaderText.Equals("Puebla") && (cmbAlmacen.SelectedValue.Equals("01") || cmbAlmacen.SelectedValue.Equals("999"))) {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else if (column.HeaderText.Equals("Mérida") && (cmbAlmacen.SelectedValue.Equals("03") || cmbAlmacen.SelectedValue.Equals("999"))) {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else if (column.HeaderText.Equals("Tuxtla") && (cmbAlmacen.SelectedValue.Equals("07") || cmbAlmacen.SelectedValue.Equals("999"))) {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else
     columnas.Add(false);
   }

   //Adding the Rows
   foreach (DataGridViewRow row in dgvArticulosRemate.Rows){
    dt.Rows.Add();
    int ColNum = -1;
    foreach (DataGridViewCell cell in row.Cells)
    {
     if (columnas[cell.ColumnIndex] == true)
     {
      ColNum++;
      dt.Rows[dt.Rows.Count - 1][ColNum] = cell.Value.ToString();
     }
    }
   }

   //Exporting to Excel
   string folderPath = "C:\\Excel\\";
   if (!Directory.Exists(folderPath))
   {
    Directory.CreateDirectory(folderPath);
   }
   using (XLWorkbook wb = new XLWorkbook())
   {
    wb.Worksheets.Add(dt, "Existencias Articulos Remate");
    wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
   }
   Process.Start(folderPath + "DataGridViewExport.xlsx");
  }

  public bool Insertar(string sql)
  {
   conexion.con.Close();
   conexion.con.Open();
   SqlCommand cmd = new SqlCommand(sql, conexion.con);
   int i = cmd.ExecuteNonQuery();
   if (i > 0)
   {
    return true;
   }
   else
   {
    return false;
   }

  }

  private void btnBuscar_Click(object sender, EventArgs e)
  {
   if (cmbAlmacen.SelectedValue.Equals("01")){
    dgvArticulosRemate.Columns["PUEBLA"].Visible = true;
    dgvArticulosRemate.Columns["MERIDA"].Visible = false;
    dgvArticulosRemate.Columns["TUXTLA"].Visible = false;
   }
   else if (cmbAlmacen.SelectedValue.Equals("03"))
   {
    dgvArticulosRemate.Columns["PUEBLA"].Visible = false;
    dgvArticulosRemate.Columns["MERIDA"].Visible = true;
    dgvArticulosRemate.Columns["TUXTLA"].Visible = false;
   }
   else if (cmbAlmacen.SelectedValue.Equals("07"))
   {
    dgvArticulosRemate.Columns["PUEBLA"].Visible = false;
    dgvArticulosRemate.Columns["MERIDA"].Visible = false;
    dgvArticulosRemate.Columns["TUXTLA"].Visible = true;
   }
   else if (cmbAlmacen.SelectedValue.Equals("999"))
   {
    dgvArticulosRemate.Columns["PUEBLA"].Visible = true;
    dgvArticulosRemate.Columns["TUXTLA"].Visible = true;
    dgvArticulosRemate.Columns["MERIDA"].Visible = true;
   }

   cargarInformacion();

  }

  private void frmExistenciasArticulosRemate_Load_1(object sender, EventArgs e)
  {
   llenarLineas();
   llenarAlmacenes();
   diseñoGrid();
  }
 }
}
