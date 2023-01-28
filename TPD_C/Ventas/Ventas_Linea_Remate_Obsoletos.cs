using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using System.Diagnostics;

namespace TPD_C.Ventas
{
 public partial class Ventas_Linea_Remate_Obsoletos : Form
 {
  public Ventas_Linea_Remate_Obsoletos()
  {
   InitializeComponent();
  }

  DataView dvAgentes = new DataView();
  DataView dvAlmacen = new DataView();
  DataTable Totales = new DataTable();
  DataTable Detalles = new DataTable();

  public void llenarAgentes()
  {
   string llenaAgentes = "SELECT 999 SlpCode, ' TODOS' SlpName, 0 GroupCode UNION SELECT DISTINCT T0.SlpCode,SlpName,T1.GroupCode FROM SBO_TPD.dbo.OSLP t0 INNER JOIN TPM.dbo.DEPCOBR T1 ON T0.SlpCode = T1.SlpCode WHERE (U_ESTATUS = 'ACTIVO' OR U_ESTATUS = 'INACTIVOCC') ORDER BY SlpName";
   conexion.conectar(false);

   SqlDataAdapter DAAgentes = new SqlDataAdapter(llenaAgentes, conexion.con);

   DataSet DsAgentes = new DataSet();

   DAAgentes.Fill(DsAgentes, "Agentes");
   dvAgentes.Table = DsAgentes.Tables["Agentes"];
   cboAgente.DataSource = dvAgentes;
   cboAgente.DisplayMember = "SlpName";
   cboAgente.ValueMember = "SlpCode";

   conexion.cerra_conectar();
  }

  public void llenarAlmacenes()
  {
   string llenaAlmacenes = "SELECT '99' CveAlmacen, 'TODOS' Almacen UNION SELECT GroupCode CveAlmacen, UPPER(GroupName) Almacen FROM SBO_TPD.dbo.OCRG WHERE GroupType = 'C'";
   conexion.conectar(true);

   SqlDataAdapter DAlmacen = new SqlDataAdapter(llenaAlmacenes, conexion.con);

   DataSet DsAlmacen = new DataSet();

   DAlmacen.Fill(DsAlmacen, "Almacen");

   dvAlmacen.Table = DsAlmacen.Tables["Almacen"];
   cmbAlmacen.DataSource = dvAlmacen;
   cmbAlmacen.DisplayMember = "Almacen";
   cmbAlmacen.ValueMember = "CveAlmacen";

   conexion.cerra_conectar();
  }

  private void Ventas_Linea_Remate_Obsoletos_Load(object sender, EventArgs e)
  {
   llenarAgentes();
   llenarAlmacenes();
  }

  public void diseñoGridTotales()
  {
   dgvTotales.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
   dgvTotales.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
   dgvTotales.DefaultCellStyle.BackColor = Color.AliceBlue;
   dgvTotales.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

   dgvTotales.Columns["CveAgente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
   dgvTotales.Columns["CveAgente"].ReadOnly = true;
   dgvTotales.Columns["CveAgente"].Width = 110;
   dgvTotales.Columns["CveAgente"].Visible = false;

   dgvTotales.Columns["Agente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
   dgvTotales.Columns["Agente"].ReadOnly = true;
   dgvTotales.Columns["Agente"].Width = 240;

   dgvTotales.Columns["CveSuc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
   dgvTotales.Columns["CveSuc"].ReadOnly = true;
   dgvTotales.Columns["CveSuc"].Width = 30;
   dgvTotales.Columns["CveSuc"].Visible = false;

   dgvTotales.Columns["Sucursal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
   dgvTotales.Columns["Sucursal"].ReadOnly = true;
   dgvTotales.Columns["Sucursal"].Width = 70;

   dgvTotales.Columns["VtaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
   dgvTotales.Columns["VtaTotal"].ReadOnly = true;
   dgvTotales.Columns["VtaTotal"].Width = 70;
   dgvTotales.Columns["VtaTotal"].DefaultCellStyle.Format = "$ ###,##0.00";

   dgvTotales.Columns["MontoDevuelto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
   dgvTotales.Columns["MontoDevuelto"].ReadOnly = true;
   dgvTotales.Columns["MontoDevuelto"].Width = 70;
   dgvTotales.Columns["MontoDevuelto"].DefaultCellStyle.Format = "$ ###,##0.00";

   dgvTotales.Columns["VtasNetas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
   dgvTotales.Columns["VtasNetas"].ReadOnly = true;
   dgvTotales.Columns["VtasNetas"].Width = 70;
   dgvTotales.Columns["VtasNetas"].DefaultCellStyle.Format = "$ ###,##0.00";

   dgvTotales.Columns["Pzas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
   dgvTotales.Columns["Pzas"].ReadOnly = true;
   dgvTotales.Columns["Pzas"].Width = 50;
   dgvTotales.Columns["Pzas"].DefaultCellStyle.Format = "###,##0";

   dgvTotales.Columns["PzasDev"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
   dgvTotales.Columns["PzasDev"].ReadOnly = true;
   dgvTotales.Columns["PzasDev"].Width = 50;
   dgvTotales.Columns["PzasDev"].DefaultCellStyle.Format = "###,##0";

   dgvTotales.Columns["PzasNetas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
   dgvTotales.Columns["PzasNetas"].ReadOnly = true;
   dgvTotales.Columns["PzasNetas"].Width = 50;
   dgvTotales.Columns["PzasNetas"].DefaultCellStyle.Format = "###,##0";

   dgvTotales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
  }

  public void diseñoGridDetalles()
  {
   dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
   dgvDetalles.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
   dgvDetalles.DefaultCellStyle.BackColor = Color.AliceBlue;
   dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

   try {
    dgvDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dgvDetalles.Columns[0].ReadOnly = true;
    dgvDetalles.Columns[0].Width = 110;
    dgvDetalles.Columns[0].Visible = false;


            
    dgvDetalles.Columns["Articulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dgvDetalles.Columns["Articulo"].ReadOnly = true;
    dgvDetalles.Columns["Articulo"].Width = 110;

    dgvDetalles.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dgvDetalles.Columns["Descripcion"].ReadOnly = true;
    dgvDetalles.Columns["Descripcion"].Width = 340;

    dgvDetalles.Columns["Sublinea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    dgvDetalles.Columns["Sublinea"].ReadOnly = true;
    dgvDetalles.Columns["Sublinea"].Width = 110;
              
     

    dgvDetalles.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    dgvDetalles.Columns[5].ReadOnly = true;
    dgvDetalles.Columns[5].Width = 70;
    dgvDetalles.Columns[5].DefaultCellStyle.Format = "$ ###,##0.00";

    dgvDetalles.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    dgvDetalles.Columns[6].ReadOnly = true;
    dgvDetalles.Columns[6].Width = 70;
    dgvDetalles.Columns[6].DefaultCellStyle.Format = "$ ###,##0.00";

                dgvDetalles.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetalles.Columns[7].ReadOnly = true;
                dgvDetalles.Columns[7].Width = 70;
                dgvDetalles.Columns[7].DefaultCellStyle.Format = "$ ###,##0.00";

                dgvDetalles.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
    dgvDetalles.Columns[8].ReadOnly = true;
    dgvDetalles.Columns[8].Width = 50;
    dgvDetalles.Columns[8].DefaultCellStyle.Format = "###,##0";

    dgvDetalles.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
    dgvDetalles.Columns[9].ReadOnly = true;
    dgvDetalles.Columns[9].Width = 50;
    dgvDetalles.Columns[9].DefaultCellStyle.Format = "###,##0";

    dgvDetalles.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
    dgvDetalles.Columns[10].ReadOnly = true;
    dgvDetalles.Columns[10].Width = 50;
    dgvDetalles.Columns[10].DefaultCellStyle.Format = "###,##0";

                
    

                //dgvDetalles.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //dgvDetalles.Columns[11].ReadOnly = true;
                //dgvDetalles.Columns[11].Width = 110;
                //dgvDetalles.Columns[11].Visible = false;



                //dgvDetalles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
   }
   catch (SystemException ex)
   {

   }
  }

  private void btnBuscar_Click(object sender, EventArgs e)
  {
   cargarInformacion();
  }

  public void cargarInformacion()
  {
   conexion.conectar(true);
   SqlCommand cmd = new SqlCommand("SP_RpteVentasLineasRemate_Obsoletos", conexion.con);
   cmd.CommandType = CommandType.StoredProcedure;

   cmd.Parameters.AddWithValue("@Sucursal", Convert.ToString(cmbAlmacen.SelectedValue));
   cmd.Parameters.AddWithValue("@Agente", Convert.ToString(cboAgente.SelectedValue));
   cmd.Parameters.AddWithValue("@FechaIni", Convert.ToString(dtpfecha_ini.Value.ToString("yyyy-MM-dd")));
   cmd.Parameters.AddWithValue("@FechaFin", Convert.ToString(dtpfecha_fin.Value.ToString("yyyy-MM-dd")));

   DataTable dt = new DataTable();
   DataSet DsVtasLinea = new DataSet();

   dt.TableName = "VentasLinea";
   DsVtasLinea.Tables.Add(dt);
   
   SqlDataAdapter da = new SqlDataAdapter(cmd);
   da.Fill(DsVtasLinea, "Ventas");

   DsVtasLinea.Tables[1].TableName = "Totales";
   DsVtasLinea.Tables[2].TableName = "Detalles";

   Totales = DsVtasLinea.Tables["Totales"];
   Detalles = DsVtasLinea.Tables["Detalles"];

   dgvTotales.DataSource = Totales;
   dgvDetalles.DataSource = Detalles;

   diseñoGridDetalles();
   diseñoGridTotales();
   conexion.cerra_conectar();

   int iAgente = -1;
   int.TryParse(dgvTotales.Rows[0].Cells[0].Value.ToString(), out iAgente);
   DataView filtro = new DataView(Detalles, "CveAgente = " + iAgente, "", DataViewRowState.CurrentRows);
   dgvDetalles.DataSource = filtro;
  }

  private void dgvTotales_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
   try
   {
    int iAgente = -1;
     int.TryParse(dgvTotales.Rows[e.RowIndex].Cells[0].Value.ToString(), out iAgente);
    if (iAgente > 0){
     if (iAgente == 999)
     {
      DataView filtro = new DataView(Detalles, "CveAgente <> 999", "", DataViewRowState.CurrentRows);
      dgvDetalles.DataSource = filtro;
     }
     else if (iAgente < 999) { 
      DataView filtro = new DataView();
      filtro = new DataView(Detalles, "CveAgente = " + iAgente, "",DataViewRowState.CurrentRows);
      dgvDetalles.DataSource = filtro;
     }
    }
   }
   catch (SystemException err)
   {

   }
  }

  private void button6_Click(object sender, EventArgs e)
  {
   DataTable dt = new DataTable();

   List<Boolean> columnas = new List<bool>();

   if (dgvTotales.Rows.Count <= 0)
    return;

   //Adding the Columns
   foreach (DataGridViewColumn column in dgvTotales.Columns)
   {
    if (column.ToolTipText != "no")
    {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else
     columnas.Add(false);
   }

   //Adding the Rows
   foreach (DataGridViewRow row in dgvTotales.Rows)
   {
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

   try
   {
    //Exporting to Excel
    string folderPath = "C:\\Excel\\";
    if (!Directory.Exists(folderPath))
    {
     Directory.CreateDirectory(folderPath);
    }
    using (XLWorkbook wb = new XLWorkbook())
    {
     wb.Worksheets.Add(dt, "Totales ventas Linea Remate");
     wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
    }
    Process.Start(folderPath + "DataGridViewExport.xlsx");
   }
   catch(SystemException ex)
   {
    MessageBox.Show(ex.Message, "Se presentó un error al importar información");
   }
  }

  private void btnDetallesToXls_Click(object sender, EventArgs e)
  {
   DataTable dt = new DataTable();

   List<Boolean> columnas = new List<bool>();

   if (dgvDetalles.Rows.Count <= 0)
    return;

   //Adding the Columns
   foreach (DataGridViewColumn column in dgvDetalles.Columns)
   {
    if (column.ToolTipText != "no")
    {
     dt.Columns.Add(column.HeaderText, column.ValueType);
     columnas.Add(true);
    }
    else
     columnas.Add(false);
   }

   //Adding the Rows
   foreach (DataGridViewRow row in dgvDetalles.Rows)
   {
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

   try
   {
    //Exporting to Excel
    string folderPath = "C:\\Excel\\";
    if (!Directory.Exists(folderPath))
    {
     Directory.CreateDirectory(folderPath);
    }
    using (XLWorkbook wb = new XLWorkbook())
    {
     wb.Worksheets.Add(dt, "Detalles Ventas Linea Remate");
     wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
    }
    Process.Start(folderPath + "DataGridViewExport.xlsx");
   }
   catch (SystemException ex)
   {
    MessageBox.Show(ex.Message, "Se presentó un error al importar información");
   }

  }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
