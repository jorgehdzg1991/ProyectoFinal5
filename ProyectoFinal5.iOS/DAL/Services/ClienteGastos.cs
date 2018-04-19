using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal5.Modelos.Peticiones.Gastos;
using ProyectoFinal5.Modelos.Respuestas;
using ProyectoFinal5.iOS.Support;
using System.Text;

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

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var jsonPeticion = JsonConvert.SerializeObject(peticion);

            using (var content = new StringContent(jsonPeticion, Encoding.UTF8, "application/json"))
            {
                request.Content = content;

                var respuestaApi = await client.SendAsync(request).ConfigureAwait(false);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<RespuestaApi<bool>>(jsonRespuesta);
            }
        }
    }
}
