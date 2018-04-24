using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal5.Modelos.Peticiones.Posiciones;
using ProyectoFinal5.Modelos.Respuestas;
using ProyectoFinal5.Droid.Support;

namespace ProyectoFinal5.Droid.DAL.Services
{
    public static class ClientePosiciones
    {
        const string Modulo = "posiciones";

        public static async Task<RespuestaApi<bool>> InsertarPosicionesViaje(
            PeticionInsertarPosicionesViaje peticion)
        {
            var nombreServicio = "insertarPosicionesViaje";

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
