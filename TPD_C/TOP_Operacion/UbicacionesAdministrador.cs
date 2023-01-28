using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPD_C.TOP_Operacion
{
    public partial class UbicacionesAdministrador : Form
    {
        public UbicacionesAdministrador()
        {
            InitializeComponent();
        }

        DataView DVCliente = new DataView();
        DataView DVUbicacion = new DataView();
        DataView DVUbicacion2 = new DataView();
        DataView DVAlmacen = new DataView();
        DataView DVAlmacenAdmon = new DataView();
        DataView DVAlmacenU = new DataView();

        private void UbicacionesAdministrador_Load(object sender, EventArgs e)
        {

            CargarUbicaciones();
            estilo_grid_comentarios();
            llenarAlmacenes();
            llenarAlmacenesAdministrar();
            cargarUbicaciones();
            cargarUbicacionesSecundarias();
            cargarUbicacionTercera();



            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Guardar";
            btngrid.HeaderText = "Guardar";
            btngrid.Text = "Guardar";
            btngrid.UseColumnTextForButtonValue = true;
            dgvUbicaciones.Columns.Add(btngrid);
        }
  public void CargarUbicaciones()
  {
            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("SP_ConsultaUbicaciones", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUbicaciones.DataSource = dt;
            conexion.cerra_conectar();
        }

        public void estilo_grid_comentarios()
        {
            //ESTILO DEL GRID DE FACTURA
            dgvUbicaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite;
            dgvUbicaciones.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvUbicaciones.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvUbicaciones.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvUbicaciones.AllowUserToAddRows = false;

            dgvUbicaciones.Columns["Almacen"].HeaderText = "Almacén";
            dgvUbicaciones.Columns["Almacen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["Almacen"].ReadOnly = true;

            dgvUbicaciones.Columns["Asignacion1"].HeaderText = "Asignacion 1";
            dgvUbicaciones.Columns["Asignacion1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["Asignacion1"].ReadOnly = true;

            dgvUbicaciones.Columns["Asignacion2"].HeaderText = "Asignacion 2";
            dgvUbicaciones.Columns["Asignacion2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["Asignacion2"].ReadOnly = true;


            dgvUbicaciones.Columns["Ubicacion"].HeaderText = "Descripción";
            dgvUbicaciones.Columns["Ubicacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["Ubicacion"].ReadOnly = true;

            dgvUbicaciones.Columns["OrdenVenta"].HeaderText = "Orden de venta";
            dgvUbicaciones.Columns["OrdenVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["OrdenVenta"].ReadOnly = true;

            dgvUbicaciones.Columns["Entrega"].HeaderText = "Orden de Entrega";
            dgvUbicaciones.Columns["Entrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvUbicaciones.Columns["Entrega"].ReadOnly = true;

            dgvUbicaciones.Columns["Estatus"].HeaderText = "Estatus";
            dgvUbicaciones.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;




            dgvUbicaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void cargarUbicaciones()
        {

            string VLlenaClientes = "select Ubicacion from ANDROID_UbicacionesSurtido";
            conexion.conectar(true);

            SqlDataAdapter DACliente = new SqlDataAdapter(VLlenaClientes, conexion.con);

            DataSet DSCliente = new DataSet();

            DACliente.Fill(DSCliente, "Ubicaciones");

            DVCliente.Table = DSCliente.Tables["Ubicaciones"];
            cmbPrincipal.DataSource = DVCliente;
            cmbPrincipal.DisplayMember = "Ubicacion";
            conexion.cerra_conectar();
        }


        public void llenarAlmacenes()
        {

            string llenAlmacen = "select WhsCode,WhsName from SBO_TPD.dbo.OWHS where WhsCode in ('01','03','07')";
            conexion.conectar(true);

            SqlDataAdapter DAlmacen = new SqlDataAdapter(llenAlmacen, conexion.con);

            DataSet DsAlmacen = new DataSet();

            DAlmacen.Fill(DsAlmacen, "Almacenes");

            DVAlmacen.Table = DsAlmacen.Tables["Almacenes"];
            cmbAlmacenGuardar.DataSource = DVAlmacen;
            cmbAlmacenGuardar.DisplayMember = "WhsName";

            conexion.cerra_conectar();
        }

        public void llenarAlmacenesAdministrar()
        {

            string llenAlmacen = "select WhsCode,WhsName from SBO_TPD.dbo.OWHS where WhsCode in ('01','03','07')";
            conexion.conectar(true);

            SqlDataAdapter DAlmacen = new SqlDataAdapter(llenAlmacen, conexion.con);

            DataSet DsAlmacenAdmin = new DataSet();

            DAlmacen.Fill(DsAlmacenAdmin, "Almacenes");

            DVAlmacenAdmon.Table = DsAlmacenAdmin.Tables["Almacenes"];
            cmbAlmacenAdministrar.DataSource = DVAlmacenAdmon;
            cmbAlmacenAdministrar.DisplayMember = "WhsName";

            conexion.cerra_conectar();
        }
        public void IngresarUbicacion()
        {


            conexion.con.Open();

            String cadena = "INSERT into ANDROID_UbicacionesSurtido (Almacen,Ubicacion,OrdenVenta,Entrega,Estatus,Asignacion4,idFinal) values (@almacen, @ubicacion,@OV,@OE,@ESTATUS,@Division,@idFinal)";
            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand(cadena, conexion.con);

            if (cmbAlmacenGuardar.Text.Equals("PUEBLA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "01");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "03");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                cmd.Parameters.AddWithValue("@almacen", "07");



            cmd.Parameters.AddWithValue("@ubicacion", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@OV", 0);
            cmd.Parameters.AddWithValue("@OE", 0);
            cmd.Parameters.AddWithValue("@ESTATUS", "INACTIVO");
            cmd.Parameters.AddWithValue("@Division", "");
            cmd.Parameters.AddWithValue("@idFinal", "");



            cmd.ExecuteNonQuery();

            txtDescripcion.Clear();






        }

        public Boolean validaRegistro(String ubicacion, String almacen)
        {
            Boolean resultado = false;


            try
            {
                conexion.con.Open();


                String valida = "select * from ANDROID_UbicacionesSurtido t1 left join SBO_TPD.dbo.OWHS  t2 on t2.WhsCode COLLATE Modern_Spanish_CI_AI  = t1.Almacen WHERE t1.Ubicacion ='" + txtDescripcion.Text + "' and  t2.WhsName = '" + cmbAlmacenGuardar.Text + "'";
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
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procedimiento:" + ex.ToString());
            }

            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Equals("") == false)
            {


                if (validaRegistro(txtDescripcion.Text, cmbAlmacenGuardar.Text) == false)
                {
                    IngresarUbicacion();
                    CargarUbicaciones();

                }
                else
                {
                    MessageBox.Show("Ya existe una ubicación con la misma descripción, ingrese una diferente");
                }

            }
            cargarUbicaciones();
            cargarUbicacionesSecundarias();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aux = "";
            string almacen = (dgvUbicaciones.CurrentRow.Cells["Almacen"].Value.ToString());
            string variable = cmbTercera.Text;


            int aux2 = Convert.ToInt32(nudParticiones.Value);
            int i = 1;

            while (i <= aux2 || aux2 == 0)
            {


                if (i == 1 || aux2 == 0)
                {


                    String cadena2 = "UPDATE ANDROID_UbicacionesSurtido SET Asignacion4 = @Division,Asignacion1 = @asignacion1,Asignacion2 = @asignacion2,Nivel =@Orden,idFinal=@idFinal WHERE Ubicacion=@Ubicacion and almacen=@almacen";

                    conexion.conectar(true);
                    SqlCommand cmd2 = new SqlCommand(cadena2, conexion.con);
                   
                    if (aux2 == 0)
                    {
                        cmd2.Parameters.AddWithValue("@Division", "");

                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@Division", "a");
                    }


                    if (aux2 == 0)
                    {
                        cmd2.Parameters.AddWithValue("@Ubicacion", cmbPrincipal.Text);

                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@Ubicacion", variable);
                    }

                  



                    if (almacen.Equals("PUEBLA"))
                    {
                        cmd2.Parameters.AddWithValue("@almacen", "01");
                    }
                    else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                    {
                        cmd2.Parameters.AddWithValue("@almacen", "03");
                    }
                    else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                        cmd2.Parameters.AddWithValue("@almacen", "07");



                    cmd2.Parameters.AddWithValue("@asignacion1", cmbPrincipal.Text);

                    string asignacion2 = cmbSecundario.Text;

                    string asignacion3 = cmbTercera.Text;


                    if (asignacion2.Equals("--Sin Asignación--"))
                    {
                        cmd2.Parameters.AddWithValue("@asignacion2", "");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@asignacion2", cmbSecundario.Text);

                    }
                    
                  

                    cmd2.Parameters.AddWithValue("@orden", 4);


                    string asignacion1 = cmbPrincipal.Text;

                   
                    string ubicacionFinal;

                    if (aux2 == 00)
                    {
                        if (asignacion3.Equals("--Sin Asignación--") && asignacion2.Equals("--Sin Asignación--"))
                        {
                            ubicacionFinal = asignacion1;
                        }
                        else if (asignacion2.Equals("--Sin Asignación--"))
                        {
                            ubicacionFinal = asignacion1 + '_' + asignacion3 ;
                        }
                        else if (asignacion3.Equals("--Sin Asignación--"))
                        {
                            ubicacionFinal = asignacion1 + '_' + asignacion2 ;
                        }
                        else
                        {
                            ubicacionFinal = asignacion1 + '_' + asignacion2 + '_' + asignacion3 ;
                         
                        }

                        cmd2.Parameters.AddWithValue("@idFinal", ubicacionFinal);
                        aux2 = 1;
                    }
                    else if (aux2 > 0)
                    {
                    if (asignacion3.Equals("--Sin Asignación--") && asignacion2.Equals("--Sin Asignación--"))
                    {
                        ubicacionFinal = asignacion1 + 'a';
                    }
                    else if (asignacion2.Equals("--Sin Asignación--"))
                        {
                        ubicacionFinal = asignacion1 + '_' + asignacion3 + 'a';
                    }
                    else if (asignacion3.Equals("--Sin Asignación--"))
                    {
                        ubicacionFinal = asignacion1 + '_' + asignacion2 + 'a';
                    }
                    else
                    {
                        ubicacionFinal = asignacion1 + '_' + asignacion2 + '_' + asignacion3 + 'a';
                    }
                        cmd2.Parameters.AddWithValue("@idFinal", ubicacionFinal);
                    }
                    //cmd2.Parameters.AddWithValue("@idFinal", ubicacionFinal);


                    cmd2.ExecuteNonQuery();
                    conexion.con.Close();
                    i++;
                    //CargarUbicaciones();
                }
                else
                {

                    
                    conexion.con.Open();

                    String cadena = "INSERT into ANDROID_UbicacionesSurtido (Almacen,Ubicacion,OrdenVenta,Entrega,Estatus,Asignacion4,Nivel,Asignacion1,Asignacion2,idFinal) values (@almacen, @ubicacion,@OV,@OE,@ESTATUS,@Division,@orden,@asignacion1,@asignacion2,@idFinal)";
                    conexion.conectar(true);
                    SqlCommand cmd = new SqlCommand(cadena, conexion.con);


                    if (almacen.Equals("PUEBLA"))
                    {
                        cmd.Parameters.AddWithValue("@almacen", "01");
                    }
                    else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                    {
                        cmd.Parameters.AddWithValue("@almacen", "03");
                    }
                    else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                        { 
                        cmd.Parameters.AddWithValue("@almacen", "07");
                    }


                    if (cmbTercera.Text.Equals("--Sin Asignación--"))
                    {
                        cmd.Parameters.AddWithValue("@ubicacion", cmbSecundario.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ubicacion", cmbTercera.Text);
                    }


                  

                    cmd.Parameters.AddWithValue("@OV", 0);
                    cmd.Parameters.AddWithValue("@OE", 0);
                    cmd.Parameters.AddWithValue("@ESTATUS", "INACTIVO");
                    cmd.Parameters.AddWithValue("@asignacion1", cmbPrincipal.Text);
                    cmd.Parameters.AddWithValue("@asignacion2", cmbSecundario.Text);

                    cmd.Parameters.AddWithValue("@orden", 4);

                    if (i == 0)
                    {
                        cmd.Parameters.AddWithValue("@Division", "");
                    }

                    else if (i == 2)
                    {
                        cmd.Parameters.AddWithValue("@Division", "b");
                        aux = "b";
                    }
                    else if (i == 3)
                    {
                        cmd.Parameters.AddWithValue("@Division", "c");
                        aux = "c";
                    }
                    else if (i == 4)
                    {
                        cmd.Parameters.AddWithValue("@Division", "d");
                        aux = "d";
                    }
                    else if (i == 5)
                    {
                        cmd.Parameters.AddWithValue("@Division", "e");
                        aux = "e";
                    }
                    else if (i == 6)
                    {
                        cmd.Parameters.AddWithValue("@Division", "f");
                        aux = "f";
                    }
                    else if (i == 7)
                    {
                        cmd.Parameters.AddWithValue("@Division", "g");
                        aux = "g";
                    }
                    else if (i == 8)
                    {
                        cmd.Parameters.AddWithValue("@Division", "h");
                        aux = "h";
                    }
                    else if (i == 9)
                    {
                        cmd.Parameters.AddWithValue("@Division", "i");
                        aux = "i";
                    }
                    else if (i == 10)
                    {
                        cmd.Parameters.AddWithValue("@Division", "j");
                        aux = "j";
                    }
                    else if (i == 11)
                    {
                        cmd.Parameters.AddWithValue("@Division", "k");
                        aux = "k";
                    }
                    else if (i == 12)
                    {
                        cmd.Parameters.AddWithValue("@Division", "l");
                        aux = "l";
                    }
                    else if (i == 13)
                    {
                        cmd.Parameters.AddWithValue("@Division", "m");
                        aux = "m";
                    }
                    else if (i == 14)
                    {
                        cmd.Parameters.AddWithValue("@Division", "n");
                        aux = "n";
                    }
                    else if (i == 15)
                    {
                        cmd.Parameters.AddWithValue("@Division", "o");
                        aux = "o";
                    }
                    else if (i == 16)
                    {
                        cmd.Parameters.AddWithValue("@Division", "p");
                        aux = "p";
                    }
                    else if (i == 17)
                    {
                        cmd.Parameters.AddWithValue("@Division", "q");
                        aux = "q";
                    }
                    else if (i == 18)
                    {
                        cmd.Parameters.AddWithValue("@Division", "r");
                        aux = "r";
                    }
                    else if (i == 19)
                    {
                        cmd.Parameters.AddWithValue("@Division", "s");
                        aux = "s";
                    }
                    else if (i == 20)
                    {
                        cmd.Parameters.AddWithValue("@Division", "t");
                        aux = "t";
                    }
                    else if (i == 21)
                    {
                        cmd.Parameters.AddWithValue("@Division", "u");
                        aux = "u";
                    }
                    else if (i == 22)
                    {
                        cmd.Parameters.AddWithValue("@Division", "v");
                        aux = "v";
                    }
                    else if (i == 23)
                    {
                        cmd.Parameters.AddWithValue("@Division", "w");
                        aux = "w";
                    }
                    else if (i == 24)
                    {
                        cmd.Parameters.AddWithValue("@Division", "x");
                        aux = "x";
                    }
                    else if (i == 25)
                    {
                        cmd.Parameters.AddWithValue("@Division", "y");
                        aux = "y";
                    }
                    else if (i == 26)
                    {
                        cmd.Parameters.AddWithValue("@Division", "z");

                        aux = "z";
                    }



                    string asignacion1 = cmbPrincipal.Text;
                    string asignacion2 = cmbSecundario.Text;

                    string asignacion3 = cmbTercera.Text;
                    string ubicacionFinal;


                    if (asignacion3.Equals("--Sin Asignación--") && asignacion2.Equals("--Sin Asignación--"))
                    {
                        ubicacionFinal = asignacion1 + aux;
                    }
                    else if (asignacion2.Equals("--Sin Asignación--"))
                    {
                        ubicacionFinal = asignacion1 + '_' + asignacion3 + aux;
                    }
                    else if (asignacion3.Equals("--Sin Asignación--"))
                    {
                        ubicacionFinal = asignacion1 + '_' + asignacion2 + aux;
                    }
                    else
                    {
                        ubicacionFinal = asignacion1 + '_' + asignacion2 + '_' + asignacion3 + aux;
                    }






                    cmd.Parameters.AddWithValue("@idFinal", ubicacionFinal);

                    cmd.ExecuteNonQuery();
                    conexion.con.Close();

                    i++;

                }
            }

            CargarUbicaciones();
        }

        public void limpiaaRegistro()
        {
            conexion.con.Open();

            string variable = lblUbicacion.Text;

            String cadenaEliminar = "delete from ANDROID_UbicacionesSurtido where Ubicacion = @Ubicacion";
            conexion.conectar(true);
            SqlCommand cmdE = new SqlCommand(cadenaEliminar, conexion.con);
            cmdE.Parameters.AddWithValue("@Ubicacion", variable);
            cmdE.ExecuteNonQuery();
            conexion.con.Close();



        }

        private void dgvUbicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUbicaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblUbicacion.Text = (dgvUbicaciones.CurrentRow.Cells["Ubicacion"].Value.ToString());
            lblEliminar.Text = dgvUbicaciones.CurrentRow.Cells["Ubicacion"].Value.ToString();
            lblElim.Text = (dgvUbicaciones.CurrentRow.Cells["division"].Value.ToString());

            if (e.ColumnIndex == dgvUbicaciones.Columns["Guardar"].Index && e.RowIndex >= 0)
            {
                string almacen = dgvUbicaciones.CurrentRow.Cells["Almacen"].Value.ToString();
                string estatus = dgvUbicaciones.CurrentRow.Cells["Estatus"].Value.ToString();
                string ubicacion = (dgvUbicaciones.CurrentRow.Cells["Ubicacion"].Value.ToString());
                string division = (dgvUbicaciones.CurrentRow.Cells["division"].Value.ToString());
                MessageBox.Show(estatus);

                String cadena2 = "UPDATE ANDROID_UbicacionesSurtido SET Estatus = @Estatus WHERE Ubicacion=@Ubicacion and almacen=@almacen and Asignacion4 =@Division";

                conexion.conectar(true);
                SqlCommand cmd2 = new SqlCommand(cadena2, conexion.con);
                cmd2.Parameters.AddWithValue("@Estatus", estatus);
                cmd2.Parameters.AddWithValue("@Ubicacion", ubicacion);

                if (almacen.Equals("PUEBLA"))
                {
                    cmd2.Parameters.AddWithValue("@almacen", "01");
                }
                else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                {
                    cmd2.Parameters.AddWithValue("@almacen", "03");
                }
                else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                    cmd2.Parameters.AddWithValue("@almacen", "07");


                cmd2.Parameters.AddWithValue("@Division", division);


                cmd2.ExecuteNonQuery();
                conexion.con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string almacen = dgvUbicaciones.CurrentRow.Cells["Almacen"].Value.ToString();
            lblEliminar.Text = dgvUbicaciones.CurrentRow.Cells["Ubicacion"].Value.ToString();
            lblElim.Text = (dgvUbicaciones.CurrentRow.Cells["division"].Value.ToString());


            if (MessageBox.Show("¿Realmente desea eliminar este registro?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.con.Open();

                String cadenaEliminar = "delete from ANDROID_UbicacionesSurtido where Ubicacion = @Ubicacion and Almacen=@almacen and Asignacion4=@Division";
                conexion.conectar(true);
                SqlCommand cmdE = new SqlCommand(cadenaEliminar, conexion.con);
                cmdE.Parameters.AddWithValue("@Ubicacion", lblEliminar.Text);
                cmdE.Parameters.AddWithValue("@Division", lblElim.Text);

                if (almacen.Equals("PUEBLA"))
                {
                    cmdE.Parameters.AddWithValue("@almacen", "01");
                }
                else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                {
                    cmdE.Parameters.AddWithValue("@almacen", "03");
                }
                else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                    cmdE.Parameters.AddWithValue("@almacen", "07");

                cmdE.ExecuteNonQuery();
                conexion.con.Close();
            }
            CargarUbicaciones();
            lblEliminar.Text = "-";
            lblElim.Text = "-";
        }

        public void cargarUbicacionesSecundarias()
        {

            string VLlenaClientes = "select Ubicacion from ANDROID_UbicacionesSurtido where Nivel > 1 or Nivel is null";
            conexion.conectar(true);

            SqlDataAdapter DACliente = new SqlDataAdapter(VLlenaClientes, conexion.con);

            DataSet DSCliente2 = new DataSet();

            DACliente.Fill(DSCliente2, "Ubicaciones");

            DVUbicacion.Table = DSCliente2.Tables["Ubicaciones"];

            DataRow fila = DVUbicacion.Table.NewRow();
            fila["Ubicacion"] = "--Sin Asignación--";
            DVUbicacion.Table.Rows.Add(fila);


            cmbSecundario.DataSource = DVUbicacion;


            cmbSecundario.DisplayMember = "Ubicacion";
            conexion.cerra_conectar();
        }

        public void cargarUbicacionTercera()
        {

            string VLlenaClientes = "select Ubicacion from ANDROID_UbicacionesSurtido where Nivel >2 or Nivel is null";
            conexion.conectar(true);

            SqlDataAdapter DACliente = new SqlDataAdapter(VLlenaClientes, conexion.con);

            DataSet DSCliente2 = new DataSet();

            DACliente.Fill(DSCliente2, "Ubicaciones");

            DVUbicacion2.Table = DSCliente2.Tables["Ubicaciones"];

            DataRow fila = DVUbicacion2.Table.NewRow();
            fila["Ubicacion"] = "--Sin Asignación--";
            DVUbicacion2.Table.Rows.Add(fila);



            cmbTercera.DataSource = DVUbicacion2;
            cmbTercera.DisplayMember = "Ubicacion";
            conexion.cerra_conectar();
        }

        //Actualiza la ubicación de la mesa en el nivel 1 
        public void ActualizarUbicacion1()
        {


            string almacen = cmbAlmacenAdministrar.Text;
            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("SP_Asignacion1", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@orden", 1);
            if (almacen.Equals("PUEBLA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "01");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "03");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                cmd.Parameters.AddWithValue("@almacen", "07");
            cmd.Parameters.AddWithValue("@ubicacion", cmbPrincipal.Text);
            cmd.ExecuteNonQuery();


            conexion.con.Close();
        }


        public void ActualizarUbicacion2()
        {

            string ubicacion = cmbPrincipal.Text;
            string almacen = cmbAlmacenAdministrar.Text;
            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("SP_Asignacion2", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@orden", 2);
            if (almacen.Equals("PUEBLA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "01");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "03");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                cmd.Parameters.AddWithValue("@almacen", "07");
            cmd.Parameters.AddWithValue("@ubicacion", cmbSecundario.Text);
            cmd.Parameters.AddWithValue("@asignacion1", cmbPrincipal.Text);
            cmd.ExecuteNonQuery();


            conexion.con.Close();
        }

        public void ActualizarUbicacion3()
        {


            string almacen = cmbAlmacenAdministrar.Text;


            conexion.conectar(true);
            SqlCommand cmd = new SqlCommand("SP_Asignacion3", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;


            if (almacen.Equals("PUEBLA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "01");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
            {
                cmd.Parameters.AddWithValue("@almacen", "03");
            }
            else if (cmbAlmacenGuardar.Text.Equals("MÉRIDA"))
                cmd.Parameters.AddWithValue("@almacen", "07");

            cmd.Parameters.AddWithValue("@ubicacion", cmbTercera.Text);
            cmd.Parameters.AddWithValue("@orden", 3);
            cmd.Parameters.AddWithValue("@asignacion1", cmbPrincipal.Text);
            cmd.Parameters.AddWithValue("@asignacion2", cmbSecundario.Text);
            cmd.ExecuteNonQuery();


            conexion.con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarUbicacion1();
            cargarUbicacionesSecundarias();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActualizarUbicacion2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ActualizarUbicacion3();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 32 || (e.KeyChar) > 57 && (e.KeyChar) < 65 || (e.KeyChar) > 90 && (e.KeyChar) < 97 || (e.KeyChar) > 122)
            {
                e.Handled = true;
            }
        }

        private void nudParticiones_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbSecundario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
