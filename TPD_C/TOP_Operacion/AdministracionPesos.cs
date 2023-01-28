 using ClosedXML.Excel;
 using System;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Data;
 using System.Data.SqlClient;
 using System.Diagnostics;
 using System.Drawing;
 using System.IO;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.Windows.Forms;

 namespace TPD_C.TOP_Operacion
 {
    public partial class AdministracionPesos : Form
    {
        public AdministracionPesos()
        {
            InitializeComponent();
        }
        DataView dvTarimas = new DataView();
        DataView dvRuta = new DataView(); 

        private void AdministracionPesos_Load(object sender, EventArgs e)
        {
            rbOEntrega.Checked = true;

            llenarTarimas();
            lblPesoR.Visible = false;
            diseñoGrid();
        }

        public void cargarInformacionEntrega()
        {
            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("SP_DatosEntregas_Rutas", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Entrega", Convert.ToInt32(txtEntrega.Text));
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.Read())
            {
                lblCodigo2.Text = "";
                lblCliente2.Text = "";
                lblPeso2.Text = "";
                lblPesoR.Text = "";
                lblTotal2.Text = "";

                lblCodigo2.Text = registro[1].ToString();
                lblCliente2.Text = registro[2].ToString();
                lblPesoR.Text = registro[3].ToString();
                lblPeso2.Text= registro[4].ToString();
                 lblTotal2.Text = registro[5].ToString();

            }

           
            conexion.cerra_conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvOrdenesEntrega.DataSource = "";
;            cargarInformacionEntrega();
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        public void agregar()
        {

            dgvOrdenesEntrega.DataSource = "";
            int n = dgvOrdenesEntrega.Rows.Add();

            dgvOrdenesEntrega.Rows[n].Cells[0].Value = txtEntrega.Text;
            dgvOrdenesEntrega.Rows[n].Cells[1].Value = lblCodigo2.Text;
            dgvOrdenesEntrega.Rows[n].Cells[2].Value = lblCliente2.Text;
            dgvOrdenesEntrega.Rows[n].Cells[3].Value = lblPesoR.Text;
            dgvOrdenesEntrega.Rows[n].Cells[4].Value = lblPeso2.Text;
            dgvOrdenesEntrega.Rows[n].Cells[5].Value = lblTotal2.Text;

            int ultimaFila = dgvOrdenesEntrega.Rows.Count;

            foreach (DataGridViewRow fila in dgvOrdenesEntrega.Rows)
            {
                if (fila.Index < ultimaFila - 1)
                {
                 
                }
            }
        }

        public void Sumas()
        {
            if ( dgvOrdenesEntrega.Rows.Count >0)
            {

                double suma = 0;
                double total = 0;
                int totalPiezas = 0;
                int ultimaFila = dgvOrdenesEntrega.Rows.Count;
                int col = dgvOrdenesEntrega.CurrentCell.ColumnIndex;


                //Sumar el Peso Total
                foreach (DataGridViewRow fila in dgvOrdenesEntrega.Rows)
                {
                    // if (fila.Index <ultimaFila-1)
                    suma += Convert.ToDouble(fila.Cells[5].Value);
                }

                //DataGridViewRow rowTotalPeso = dgvOrdenesEntrega.Rows[dgvOrdenesEntrega.Rows.Count - 1];
                lblpesoTotal.Text = suma.ToString();

                foreach (DataGridViewRow fila in dgvOrdenesEntrega.Rows)
                {
                    //if (fila.Index < ultimaFila - 1)

                    total += Convert.ToDouble(fila.Cells[6].Value);
                }
                //DataGridViewRow rowTotal = dgvOrdenesEntrega.Rows[dgvOrdenesEntrega.Rows.Count - 1];
                totales.Text = total.ToString();

                foreach (DataGridViewRow fila in dgvOrdenesEntrega.Rows)
                {
                    // if (fila.Index < ultimaFila - 1)

                    totalPiezas += Convert.ToInt32(fila.Cells[4].Value);
                }
                //DataGridViewRow rowTotalPiezas = dgvOrdenesEntrega.Rows[dgvOrdenesEntrega.Rows.Count - 1];
                lblPiezasTotales.Text = totalPiezas.ToString();

            }
            else
            {
                MessageBox.Show("La tarima está vacía");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregar();
            Sumas();
            txtEntrega.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dv in dgvOrdenesEntrega.Rows) { 
            int entrega = Convert.ToInt32(dv.Cells[0].Value);
            string  codigoCliente = dv.Cells[1].Value.ToString();
                string nombreCliente = dv.Cells[2].Value.ToString();
                int piezas = Convert.ToInt32(dv.Cells[3].Value);
                double peso = Convert.ToDouble(dv.Cells[4].Value);
                double total = Convert.ToDouble(dv.Cells[5].Value);


                conexion.con.Open();
            string ingresarEntregas = "insert into TPD_TotalesEntregas(entrega,CodigoCliente,ClienteNombre,piezasTotales,peso,totalsinIva) values (" + entrega + ",'" + codigoCliente + "','" + nombreCliente + "'," + piezas + "," + peso + " ," + total + ")";
            Insertar(ingresarEntregas);
            conexion.con.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
          
        }

        private void rbOEntrega_CheckedChanged(object sender, EventArgs e)
        {
            txtOentrega.Enabled = true;
            cmbTarimas.Enabled = false;

        }

        private void rbTarima_CheckedChanged(object sender, EventArgs e)
        {
            txtOentrega.Text = "0";
            txtOentrega.Enabled = false;
            cmbTarimas.Enabled = true;

        }

        public void llenarTarimas()
        {
            string llenaTarimas = "select id,CveTarima from Tarimas";
            conexion.conectar(true);

            SqlDataAdapter DAlmacen = new SqlDataAdapter(llenaTarimas, conexion.con);

            DataSet DsAlmacen = new DataSet();

            DAlmacen.Fill(DsAlmacen, "Tarimas");

            dvTarimas.Table = DsAlmacen.Tables["Tarimas"];
            cmbTarimas.DataSource = dvTarimas;
            cmbTarimas.DisplayMember = "CveTarima";
            cmbTarimas.ValueMember = "id";

            conexion.cerra_conectar();
        }

        public void llenarRutas(int Tarima, int Orden)
        {
          string llenaRutas = "SELECT ' CUALQUIERA' AS Ruta, '999' idRuta ";
          llenaRutas += " UNION ";
          //llenaRutas += " SELECT DISTINCT T1.U_BXP_Ruta Ruta, T1.U_BXP_Ruta idRuta ";
          //llenaRutas += " FROM Operacion_Orden T0 ";
          //llenaRutas += " INNER JOIN SBO_TPD.dbo.OCRD T1 ON T0.CardCode COLLATE Modern_Spanish_CI_AS = T1.CardCode ";
          llenaRutas += " SELECT DISTINCT T0.TrnspName Ruta, T0.TrnspCode idRuta ";
          llenaRutas += " FROM Operacion_Orden T0";
          llenaRutas += " INNER JOIN Operacion_Entrega T1 ON T0.DocEntry = T1.DocNum";
          llenaRutas += " LEFT JOIN SBO_TPD.dbo.RDN1 T2 ON T1.DocEntry = T2.BaseRef";

          if (Tarima > 0)
           llenaRutas += " WHERE T0.IdTarima = " + Tarima;
          else if (Orden > 0)
           llenaRutas += " WHERE T1.DocEntry = " + Orden;

          llenaRutas += " AND T2.DocEntry IS NULL";
          llenaRutas += " ORDER BY Ruta";

            conexion.conectar(true);

            SqlDataAdapter DRuta = new SqlDataAdapter(llenaRutas, conexion.con);

            DataSet DsRuta = new DataSet();

            DRuta.Fill(DsRuta, "tbRutas");

            dvRuta.Table = DsRuta.Tables["tbRutas"];
            
            cmbRutas.DataSource = dvRuta;
            cmbRutas.DisplayMember = "Ruta";
            cmbRutas.ValueMember = "idRuta";
            cmbRutas.SelectedIndex = 0;

            conexion.cerra_conectar();
        }
  
        public void cargarInformacion()
        {
            conexion.con.Open();
            string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query, conexion.con);
            int idTarima = Convert.ToInt32(cmd2.ExecuteScalar());
            conexion.con.Close();

            conexion.con.Open();
            string tipoTarima = "select id_Departamento from Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd3 = new SqlCommand(tipoTarima, conexion.con);
            string tipo = Convert.ToString(cmd3.ExecuteScalar());
            conexion.con.Close();

            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("[SP_Inf_Entregas_Tarimas_Rutas]", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            int ordenEntrega = Convert.ToInt32(txtOentrega.Text);

            if (rbOEntrega.Checked == true)
            {
                cmd.Parameters.AddWithValue("@IdTarima", 0);
                cmd.Parameters.AddWithValue("@NumEntrega", ordenEntrega);
                cmd.Parameters.AddWithValue("@idDepartament", tipo);
            }
            else if (rbTarima.Checked == true)
            {
                cmd.Parameters.AddWithValue("@IdTarima", idTarima);
                cmd.Parameters.AddWithValue("@NumEntrega", 0);
                cmd.Parameters.AddWithValue("@idDepartament", tipo);
            }
            cmd.Parameters.AddWithValue("@Ruta", cmbRutas.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvOrdenesEntrega.DataSource = dt;
            conexion.cerra_conectar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           cargarInformacion();
           Sumas();
        }

        public void diseñoGrid()
        {
            dgvOrdenesEntrega.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dgvOrdenesEntrega.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvOrdenesEntrega.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvOrdenesEntrega.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
           
           
            
            dgvOrdenesEntrega.Columns["OrdenEntrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["OrdenEntrega"].ReadOnly = true;


            dgvOrdenesEntrega.Columns["Factura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["Factura"].ReadOnly = true;


            dgvOrdenesEntrega.Columns["CodigoCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["CodigoCliente"].ReadOnly = true;
           
            
            dgvOrdenesEntrega.Columns["ClienteNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["ClienteNombre"].ReadOnly = true;
            
            
            dgvOrdenesEntrega.Columns["Piezastotales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["Piezastotales"].ReadOnly = true;

            dgvOrdenesEntrega.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["Peso"].ReadOnly = true;

            dgvOrdenesEntrega.Columns["TotalsinIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["TotalsinIVA"].ReadOnly = true;
            dgvOrdenesEntrega.Columns["TotalsinIVA"].DefaultCellStyle.Format = "$ ###,###,##0.#0";


            dgvOrdenesEntrega.Columns["Ruta2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvOrdenesEntrega.Columns["Ruta2"].ReadOnly = true;


            dgvOrdenesEntrega.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvOrdenesEntrega.Rows.RemoveAt(dgvOrdenesEntrega.CurrentRow.Index);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dgvOrdenesEntrega.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dgvOrdenesEntrega.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
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
                wb.Worksheets.Add(dt, "Partidas Faltantes");
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
            conexion.con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sumas();
        }

  private void txtOentrega_TextChanged(object sender, EventArgs e)
  {
   int OrdenToFind = 0;
   int.TryParse(txtOentrega.Text, out OrdenToFind);
   if (OrdenToFind > 0)
    llenarRutas(0, OrdenToFind);
  }

  private void cmbTarimas_SelectedIndexChanged(object sender, EventArgs e)
  {
   int TarimaToFind = 0;
   int.TryParse(cmbTarimas.SelectedValue.ToString(), out TarimaToFind);
   if (TarimaToFind > 0)
    llenarRutas(TarimaToFind, 0);
  }
 }
 }
