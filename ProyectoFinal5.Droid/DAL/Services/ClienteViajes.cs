using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Viajes;
using ProyectoFinal5.Modelos.Respuestas;
using ProyectoFinal5.Droid.Support;

namespace ProyectoFinal5.Droid.DAL.Services
{
    public static class ClienteViajes
    {
        public const string Modulo = "viajes";

        public static async Task<RespuestaApi<List<Viaje>>> ObtenerTodosViajesAsync()
        {
            var nombreServicio = "obtenerTodosViajes";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}";

            using (var client = new HttpClient())
            {
                var respuestaApi = await client.GetAsync(url);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<List<Viaje>>>(jsonRespuesta);
            }
        }

        public static async Task<RespuestaApi<List<Viaje>>> ObtenerViajesOperadorAsync(int idOperador)
        {
            var nombreServicio = "obtenerViajesOperador";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}/{idOperador}";

            using (var client = new HttpClient())
            {
                var respuestaApi = await client.GetAsync(url);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<List<Viaje>>>(jsonRespuesta);
            }
        }

        public static async Task<RespuestaApi<Viaje>> ObtenerDetalleViajeAsync(int idViaje)
        {
            var nombreServicio = "obtenerDetalleViaje";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}/{idViaje}";

            using (var client = new HttpClient())
            {
                var respuestaApi = await client.GetAsync(url);
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<Viaje>>(jsonRespuesta);
            }
        }

        public static async Task<RespuestaApi<bool>> ActualizarEstatusViajeAsync(
            PeticionActualizarEstatus peticion)
        {
            var nombreServicio = "actualizarEstatus";

            var url = $"{Constantes.DireccionServicios}/{Modulo}/{nombreServicio}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonPeticion = JsonConvert.SerializeObject(peticion);

                var respuestaApi = await client.PutAsync(url, new StringContent(jsonPeticion));
                var jsonRespuesta = await respuestaApi.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RespuestaApi<bool>>(jsonRespuesta);
            }
        }
    }
}
