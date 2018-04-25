using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Usuarios;
using ProyectoFinal5.Modelos.Respuestas;
using ProyectoFinal5.iOS.Support;

namespace ProyectoFinal5.iOS.DAL.Services
{
    public static class ClienteUsuarios
    {
        const string Modulo = "usuarios";

        public static async Task<RespuestaApi<Usuario>> ObtenerUsuarioCredencialAsync(
            PeticionObtenerUsuarioCredencial peticion)
        {
            var nombreServicio = "obtenerUsuarioCredencial";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var jsonPeticion = JsonConvert.SerializeObject(peticion);

            using (var content = new StringContent(jsonPeticion, Encoding.UTF8, "application/json"))
            {
                request.Content = content;

                var respuestaApi = await client.SendAsync(request).ConfigureAwait(false);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<RespuestaApi<Usuario>>(jsonRespuesta);
            }
        }

        public static async Task<RespuestaApi<List<Usuario>>> ObtenerOperadoresAsync()
        {
            var nombreServicio = "obtenerOperadores";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}";

            using (var client = new HttpClient())
            {
                var respuestaApi = await client.GetAsync(url);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<List<Usuario>>>(jsonRespuesta);
            }
        }
    }
}
