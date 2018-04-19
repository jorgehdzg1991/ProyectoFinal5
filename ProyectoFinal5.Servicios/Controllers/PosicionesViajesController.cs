using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProyectoFinal5.LogicaNegocio;
using ProyectoFinal5.Modelos.Peticiones.Posiciones;
using ProyectoFinal5.Modelos.Respuestas;

namespace ProyectoFinal5.Servicios.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/posiciones")]
    public class PosicionesViajesController : ApiController
    {
        [HttpPost]
        [Route("insertarPosicionesViaje")]
        public HttpResponseMessage InsertarPosicionesViaje(
            PeticionInsertarPosicionesViaje peticion)
        {
            var respuesta = new RespuestaApi<bool>();

            try
            {
                PosicionesViajesBL.InsertarPosicionesViaje(
                    peticion.IdViaje, peticion.Posiciones);
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }
    }
}
