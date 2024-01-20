using ControlDeGasto.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;

namespace ControlDeGasto.Repository
{
    public class ApiGastosRepository : IGastosRepository
    {
        private readonly string apiUrl = "https://localhost:44339";

        public async Task Ingreso(GastoModel gasto)
        {
            var url = $"{apiUrl}/Cobros/Create";
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, gasto);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error al Ingresar el Cobro. Código de estado: {response.StatusCode}");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al egresar el gasto: {ex.Message}");
                throw new Exception("Ocurrió un error al egresar el gasto.");
            }
        }

        public async Task EgresarGastoAsync(GastoModel gasto)
        {
            var url = $"{apiUrl}/Gasto/Create";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, gasto);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error al egresar el gasto. Código de estado: {response.StatusCode}");
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al egresar el gasto: {ex.Message}");
                throw new Exception("Ocurrió un error al egresar el gasto.");
            }
            //var url = $"{apiUrl}/Gasto/Create";
            //HttpClient httpClient = new HttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync(url, gasto).Result;
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new Exception("Ocurrió un error al egresar el gasto.");
            //}
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
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var gastos = JsonConvert.DeserializeObject<GastoModel>(json);
                        return gastos;
                    }
                    else
                    {
                        throw new Exception($"Error al eliminar el gasto. Código de estado: {response.StatusCode}");
                    }
                }
            }
            //{

            //    //HttpClient httpClient = new HttpClient();
            //    //HttpResponseMessage response = httpClient.GetAsync(url).Result;

            //    //if (response.IsSuccessStatusCode)
            //    //{
            //    //    var json = await response.Content.ReadAsStringAsync();
            //    //    var gastos = JsonConvert.DeserializeObject<GastoModel>(json);
            //    //    return gastos;

            //    }
            //    else
            //    {


            //    }
            //    return null;

            //}
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el gasto: {ex.Message}");
                throw new Exception("Ocurrió un error al eliminar el gasto.");
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
