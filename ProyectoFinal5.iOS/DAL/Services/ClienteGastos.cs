using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal5.Modelos.Peticiones.Gastos;
using ProyectoFinal5.Modelos.Respuestas;
using ProyectoFinal5.iOS.Support;

namespace ProyectoFinal5.iOS.DAL.Services
{
    public static class ClienteGastos
    {
        const string Modulo = "gastos";

        public static async Task<RespuestaApi<bool>> InsertarGastosViajeAsync(
            PeticionInsertarGastoViaje peticion)
        {
            var nombreServicio = "insertarGastosViaje";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonPeticion = JsonConvert.SerializeObject(peticion);

                var respuestaApi = await client.PostAsync(url, new StringContent(jsonPeticion));
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<bool>>(jsonRespuesta);
            }
        }
    }
}
