  using Newtonsoft.Json;
 using RestSharp;
 using System;
 using System.Collections.Generic;
 using System.Linq;
using System.Net;
using System.Windows.Forms;
using TPD_C.ControlVehiculo.DTOs;
 using TPD_C.GPSImport;

 namespace TPD_C.ControlVehiculo
 {
    public class APIService
    {
        public static Auth_token GetToken()
        {
            try
            {
                //Instancia al objeto que contiene los datos para obtener el token 
                LoginParams login = new LoginParams();

																System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

																//crea un cliente con la ruta de acceso
																var client = new RestClient($"https://login.mzoneweb.net/connect/token");

                //Se define el tipo de metodo que se utilizara, compo primer parametro se puede enviar una URL relativa
                var request = new RestRequest(Method.POST);

                //Se define el el tipo se pueden enviar cuantos headers sean necesarios
                request.AddHeader("content-type", "application/x-www-form-urlencoded");

																//tipo de post y body en formato x-www-form-urlencoded, se pueden enviar cuantos parametros sean encesarios
																request.AddParameter("application/x-www-form-urlencoded",
                    $"grant_type={login.Grant_type}" +
                    $"&client_id={login.Client_id}" +
                    $"&client_secret={login.Client_secret}" +
                    $"&scope={login.Scope}" +
                    $"&username={login.Username}" +
                    $"&password={login.Password}",
                    ParameterType.RequestBody);

																	/*
																	 * JUSTAMENTE EN LA LINEA DE ABAJO ES DONDE SE REALIZA LA CONSULTA DE LA API HACIA EL PROVEEDOR TELCEL Y SE GUARDAR LA RESPUESTA EN LA VARIABLE "response"
																	*/
                //Se ejecuta la configuracion previa
                IRestResponse response = client.Execute(request);

                //el resultado se mapea a el objeto de datos que almacena el token 
                Auth_token auth_Token = JsonConvert.DeserializeObject<Auth_token>(response.Content);

                //retortam el objeto de datos con el token, tiempo de validez y tipo de token
                return auth_Token;
            }
            catch (System.Exception e)
            {
													MessageBox.Show("Error (GetToken): " + e.Message);
													throw;
            }
        }

        public static List<VehicleRutes> GetRutes(DateTime startDate, DateTime endDate, string vehicleGroup)
        {
            //se creata el cliente con la ruta base, debe ser ruta absoluta
            var client = new RestClient("https://live.mzoneweb.net/mzone62.api/Trips");

            //tipo de metodo, aca se puede agregar como primer parametro ruta relativa
            var request = new RestRequest(Method.GET);

            //se envia como header el token
            request.AddHeader("Authorization", "Bearer " + GetToken().Access_token);

            //se agregan los parametros, cuantos sea nnecesarios, aca tambien se define el tipo por el  que se envian, puede ser por query o por ruta
            request.AddParameter("utcStartDate", startDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            request.AddParameter("utcEndDate", endDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            request.AddParameter("vehicleGroup_Id", vehicleGroup);

            //se ejecuta la configuracion
            IRestResponse response = client.Execute(request);

            //se mapea a un objeto de datos que contendra la respuesta
            var oJson = JsonConvert.DeserializeObject<ResponseCollection>(response.Content);

            //se retorna una lista de objeto de datos con los valores de la respuesta 
            return oJson.Value;
        }
  
  public int GetRutesByVehicle(DateTime startDate, DateTime endDate, string vehicleId)
  {
		 try{
				//se creata el cliente con la ruta base, debe ser ruta absoluta
				var client = new RestClient("https://live.mzoneweb.net/mzone62.api/Trips");

				//tipo de metodo, aca se puede agregar como primer parametro ruta relativa
				var request = new RestRequest(Method.GET);

				//se envia como header el token
				request.AddHeader("Authorization", "Bearer " + GetToken().Access_token);

				//se agregan los parametros, cuantos sea nnecesarios, aca tambien se define el tipo por el  que se envian, puede ser por query o por ruta
				request.AddParameter("utcStartDate", startDate.ToString("yyyy-MM-ddT00:00:00"));
				request.AddParameter("utcEndDate", endDate.ToString("yyyy-MM-ddT23:59:59"));
				request.AddParameter("vehicle_Id", vehicleId);

				//se ejecuta la configuracion
				IRestResponse response = client.Execute(request);

				//se mapea a un objeto de datos que contendra la respuesta
				var oJson = JsonConvert.DeserializeObject<ResponseCollection>(response.Content);

				//Se instancia la clase que se utilizara
				ImportGPS importGPS = new ImportGPS();

				//Se insertan los datos a la tabla donde se tratan
				DateTime dateStart;
				DateTime dateEnd;
				foreach (var item in oJson.Value)
				{
					//se crean variables para descontar las horas y se actualice el dia en atm
					dateStart = item.StartUtcTimestamp.AddHours(-6.0);
					dateEnd = item.EndUtcTimestamp.AddHours(-6.0);

					importGPS.Insertar(item.Vehicle_Description, item.Vehicle_Id, item.Id,
								dateStart.ToString("yyyy-MM-dd"), item.StartLocationDescription,
								dateStart.ToString("HH:mm:ss"),
								dateEnd.ToString("yyyy-MM-dd"), item.EndLocationDescription,
								dateEnd.ToString("HH:mm:ss"),
								(float)item.EndLatitude, (float)item.EndLongitude);
				}
				return oJson.Value.Count();
			}
			catch (SystemException e)
			{
				MessageBox.Show("Error (GetRutesByVehicle): " + e.Message);
				return 0;
			}

			//se retorna una lista de objeto de datos con los valores de la respuesta 
  }
 }
 }