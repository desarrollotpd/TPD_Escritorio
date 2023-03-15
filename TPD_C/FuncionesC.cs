using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Windows.Forms;

namespace TPD_C
{
		public class infMail{
		string email { get; set; }
		string password { get; set; }
		Int16 port { get; set; }
		string host { get; set; }
		Boolean seguridad { get; set; }
		Boolean Status { get; set; }
		string Error { get; set; }


		public infMail()
		{
			conexion.con.Open();
			try
			{
				String valida = "SELECT * FROM TPM.DBO.configuracion_email WHERE id = 3";
				conexion.conectar(true);
				SqlCommand cmdValida = new SqlCommand(valida, conexion.con);
				SqlDataReader dr = cmdValida.ExecuteReader();

				if (dr.Read())
				{
					Int16 puerto = 0;
					this.email = dr.GetString(1);
					this.password = dr.GetString(2);
					Int16.TryParse(dr.GetString(3), out puerto);
					this.port = puerto;
					this.host = dr.GetString(4);
					Boolean UsaSeguridad;
					Boolean.TryParse(dr.GetString(5), out UsaSeguridad);
					this.seguridad = UsaSeguridad;
				}
				dr.Close();
				conexion.con.Close();
				this.Status = true;
				this.Error = "";
			}
			catch (Exception ex)
			{
				conexion.con.Close();
				this.Error = ex.Message;
				this.Status = false;
				//MessageBox.Show("Error en el procedimiento:" + ex.ToString());
			}

		}

		public string getEmail() {
			return email;
		}

		public string getPassword() {
		return password;
		}

		public int getPort() {
			return port;
		}

		public string getHost() {
			return host;
		}

		public Boolean getSeguridad() {
			return seguridad;
		}

		public Boolean getStatus()
		{
			return Status;
		}

		public String getError() {
			return Error;
		}
	}



}
