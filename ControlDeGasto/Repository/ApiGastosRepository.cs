using ControlDeGasto.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;

namespace ControlDeGasto.Repository
{
    public class ApiGastosRepository : IGastosRepository
    {
        private readonly string apiUrl = "https://localhost:44339";

        public void IngresarGasto(GastoModel gasto)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync(apiUrl + "/Gasto/Create", gasto).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrió un error al ingresar el gasto.");
            }
        }

        public void EgresarGasto(GastoModel gasto)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync(apiUrl + "/Cobros/Create", gasto).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ocurrió un error al egresar el gasto.");
            }
        }
        public async Task<IEnumerable<GastoModel>> ObtenerGastos(int mes, int anio)
        {
            var url = $"{apiUrl}/Gasto/ObtenerTodoGasto/{anio}/{mes}";
            

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response =  httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var gastos = JsonConvert.DeserializeObject<IEnumerable<GastoModel>>(json);
                    return gastos;
                   
                }
                else
                {
                    // Manejar el error aquí...
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los gastos del mes actual.");
            }

            
        }
        public async Task<DineroEnCuenta> ObtenerDineroEnCuenta()
        {
            var date= DateTime.Now;
            var url = $"{apiUrl}/Balance/Restante/{date.Year}/{date.Month}";


            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var Resultado = JsonConvert.DeserializeObject<DineroEnCuenta>(json);
                    var dineroEnCuenta = new DineroEnCuenta { CantidadRestante = Resultado.CantidadRestante };
                    return dineroEnCuenta;

                }
                else
                {
                    // Manejar el error aquí...
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los gastos del mes actual.");
            }


        }

        public async Task<GastoModel> GetGastoById(int id)
        {
            var url = $"{apiUrl}/Gasto/GetById/{id}";

            
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var gastos = JsonConvert.DeserializeObject<GastoModel>(json);
                    return gastos;

                }
                else
                {
                    // Manejar el error aquí...
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los gastos del mes actual.");
            }
            
        }

        public async Task<GastoModel> DeleteGasto(GastoModel gasto)
        {
            var id = gasto.Id;
            var url = $"{apiUrl}/Gasto/Delete/{id}";
           

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var gastos = JsonConvert.DeserializeObject<GastoModel>(json);
                    return gastos;

                }
                else
                {
                    
                    
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al Eliminar El Gasto.");
            }
           
        }




        //public async Task<List<GastoModel>> ObtenerGastosDelMesActual()
        //{
        //    HttpClient httpClient = new HttpClient();
        //    HttpResponseMessage response = httpClient.GetAsync(apiUrl + "/GetAll").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var gastos = JsonConvert.DeserializeObject<List<GastoModel>>(content);

        //        return gastos;
        //    }
        //    else
        //    {
        //        throw new Exception("Ocurrió un error al obtener los gastos del mes actual.");
        //    }
        //}
    }

}
