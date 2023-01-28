using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;
using System.Diagnostics;

namespace TPD_C.TPD_Compras
{
    public partial class Partidas_Faltantes : Form
    {
        public Partidas_Faltantes()
        {
            InitializeComponent();
        }
        DataView DVTarimas = new DataView();

        private void Partidas_Faltantes_Load(object sender, EventArgs e)
        {
            llenarComboTarimas();

        }

        public void llenarComboTarimas()
        {
            string llenAlmacen = "select CveTarima from Tarimas";
            conexion.conectar(true);

            SqlDataAdapter DAlmacen = new SqlDataAdapter(llenAlmacen, conexion.con);
            DataSet DsAlmacen = new DataSet();
            DAlmacen.Fill(DsAlmacen, "Tarimas");
            DVTarimas.Table = DsAlmacen.Tables["Tarimas"];
            cmbTarimas.DataSource = DVTarimas;
            cmbTarimas.DisplayMember = "CveTarima";

            conexion.cerra_conectar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();

                string filePath = openFileDialog1.FileName;

                //Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(filePath))
                {

                    IXLWorksheet workSheet = workBook.Worksheet(1);


                    DataTable dt = new DataTable();


                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {

                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();


                                i++;
                            }
                        }

                        dataGridView1.DataSource = dt;
                        estilo_grid();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Cierre el archivo antes de importarlo");
            }

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

        private void button2_Click(object sender, EventArgs e)
        {

            try
               {
                conexion.con.Open();
            string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conexion.con);
            int idTarima = Convert.ToInt32(cmd.ExecuteScalar());
            string cantRequerid;
            string articulo;
            conexion.con.Close();
            string tipo = "PI";

            conexion.con.Open();
            string query2 = "SELECT CveAlmacen FROM Tarimas where id = " + idTarima + "";
            SqlCommand cmd2 = new SqlCommand(query2, conexion.con);
            string clave = Convert.ToString(cmd2.ExecuteScalar());

            conexion.con.Close();




            int cantRequerid2 = 0;
            foreach (DataGridViewRow dv in dataGridView1.Rows)
            {

                articulo = dv.Cells["ARTÍCULO"].Value.ToString();

                if (validaRegistro(idTarima, articulo) == false)
                {


                    cantRequerid = dv.Cells["CANTIDADREQUERIDA"].Value.ToString();
                    if (articulo == "" && cantRequerid == "") {

                    }
                    else if (articulo != "" && cantRequerid != "")
                    {
                        cantRequerid2 = Convert.ToInt32(dv.Cells["CANTIDADREQUERIDA"].Value);

                        conexion.con.Open();
                        string ingresarTarima = "insert into ANDROID_SurtidoTarimaSucursal_Detalles_Importados(IdTarima,Articulo,CantidadRequerida,Recibido,TipoIngreso,CveSucursal) values (" + idTarima + ",'" + articulo + "'," + cantRequerid2 + "," + 0 + ",'" + tipo + "' ,'" + clave + "')";
                        Insertar(ingresarTarima);
                        conexion.con.Close();
                    }
                    else
                    {
                        cantRequerid2 = 0;

                        conexion.con.Open();
                        string ingresarTarima = "insert into ANDROID_SurtidoTarimaSucursal_Detalles_Importados(IdTarima,Articulo,CantidadRequerida,Recibido,TipoIngreso,CveSucursal) values (" + idTarima + ",'" + articulo + "'," + cantRequerid2 + "," + 0 + ",'" + tipo + "' ,'" + clave + "')";
                        Insertar(ingresarTarima);
                        conexion.con.Close();

                    }

                    // cantRequerid = Convert.ToInt32(dv.Cells["CANTIDAD REQUERIDA"].Value);

                    //
                    //{ 

                }
                else
                {
                    cantRequerid = dv.Cells[1].Value.ToString();
                    conexion.con.Open();
                    String cadena = "UPDATE  ANDROID_SurtidoTarimaSucursal_Detalles_Importados SET CantidadRequerida = @cantidad WHERE  idTarima= @idTarima and Articulo=@articulo";

                    conexion.conectar(true);
                    SqlCommand cmd4 = new SqlCommand(cadena, conexion.con);
                    cmd4.Parameters.AddWithValue("@cantidad", cantRequerid);
                    cmd4.Parameters.AddWithValue("@idTarima", idTarima);
                    cmd4.Parameters.AddWithValue("@articulo", articulo);

                    cmd4.ExecuteNonQuery();
                    conexion.con.Close();
                }

                //}

            }
            MessageBox.Show("La tarima " + cmbTarimas.Text + "ha quedado registrada");
            dataGridView1.DataSource = "";
        }
        catch
        {
            MessageBox.Show("Verifique que los datos en su documento sean correctos");
        }
}





    public void estilo_grid()
        {
            //ESTILO DEL GRID DE FACTURA
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns[0].HeaderText = "ARTÍCULO";
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.Columns[1].HeaderText = "CANTIDAD REQUERIDA";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView1.Columns[1].ReadOnly = true;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultarTarima();

        }


        public void consultarTarima()
        {

            conexion.con.Open();
            string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conexion.con);
            int idTarima = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.con.Close();

            conexion.conectar(true);
            SqlCommand cmdSP = new SqlCommand("consultarTarimas", conexion.con);
            cmdSP.CommandType = CommandType.StoredProcedure;
            cmdSP.Parameters.AddWithValue("@Tarima", idTarima);
            SqlDataAdapter da = new SqlDataAdapter(cmdSP);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            estilo_grid();
            conexion.cerra_conectar();

        }

        public void consultarTarimaVacia()
        {

            conexion.con.Open();
            string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conexion.con);
            int idTarima = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.con.Close();

            conexion.conectar(true);
            SqlCommand cmdSP = new SqlCommand("consultarTarimasPartidasVacias", conexion.con);
            cmdSP.CommandType = CommandType.StoredProcedure;
            cmdSP.Parameters.AddWithValue("@Tarima", idTarima);
            SqlDataAdapter da = new SqlDataAdapter(cmdSP);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            estilo_grid();
            conexion.cerra_conectar();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            conexion.con.Open();
            string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conexion.con);
            int idTarima = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.con.Close();
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            conexion.con.Open();
            String cadena = "UPDATE tpm.dbo.ANDROID_SurtidoTarimaSucursal_Detalles_Importados SET CantidadRequerida = @Cantidad WHERE  Articulo= @articulo and idTarima=@idTarima";

            conexion.conectar(true);
            SqlCommand cmdUp = new SqlCommand(cadena, conexion.con);
            cmdUp.Parameters.AddWithValue("@Cantidad", cantidad);
            cmdUp.Parameters.AddWithValue("@articulo", lblArticulo.Text);
            cmdUp.Parameters.AddWithValue("@idTarima", idTarima);

            cmdUp.ExecuteNonQuery();
            conexion.con.Close();
            consultarTarima();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar este registro?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.con.Open();
                string query = "SELECT id FROM Tarimas where CveTarima = '" + cmbTarimas.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conexion.con);
                int idTarima = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.con.Close();





                conexion.con.Open();


                String cadenaEliminar = "delete from ANDROID_SurtidoTarimaSucursal_Detalles_Importados where IdTarima = @idTarima and Articulo=@articulo";
                conexion.conectar(true);
                SqlCommand cmdE = new SqlCommand(cadenaEliminar, conexion.con);
                cmdE.Parameters.AddWithValue("@idTarima", idTarima);
                cmdE.Parameters.AddWithValue("@articulo", lblArticulo2.Text);



                cmdE.ExecuteNonQuery();
                conexion.con.Close();
                consultarTarima();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTarima.Text = cmbTarimas.Text;
            lblArticulo.Text = (dataGridView1.CurrentRow.Cells[0].Value.ToString());

            txtCantidad.Text = (dataGridView1.CurrentRow.Cells[1].Value.ToString());

            lblTarima2.Text = cmbTarimas.Text;
            lblArticulo2.Text = (dataGridView1.CurrentRow.Cells[0].Value.ToString());


        }

        private void button6_Click(object sender, EventArgs e)
        {
            consultarTarimaVacia();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
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





        public Boolean validaRegistro(int idTarima, String articuloval)
        {
            Boolean resultado = false;
            
            try
            {
                conexion.con.Open();
                foreach (DataGridViewRow dv in dataGridView1.Rows)
                {
                    
                    String valida = "select * from ANDROID_SurtidoTarimaSucursal_Detalles_Importados where IdTarima =" + idTarima + "and Articulo = '" + articuloval + "'";
                    conexion.conectar(true);
                    SqlCommand cmdValida = new SqlCommand(valida, conexion.con);
                    SqlDataReader dr = cmdValida.ExecuteReader();

                    if (dr.Read())
                    {
                        resultado = true;

                    }
                    dr.Close();
                    conexion.con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procedimiento:" + ex.ToString());
            }

            return resultado; 
        }
    }
}

