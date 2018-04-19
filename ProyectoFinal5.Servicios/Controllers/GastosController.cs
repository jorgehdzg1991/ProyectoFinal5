using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProyectoFinal5.LogicaNegocio;
using ProyectoFinal5.Modelos.Peticiones.Gastos;
using ProyectoFinal5.Modelos.Respuestas;

namespace ProyectoFinal5.Servicios.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/gastos")]
    public class GastosController : ApiController
    {
        [HttpPost]
        [Route("insertarGastosViaje")]
        public HttpResponseMessage InsertarGastosViaje(
            PeticionInsertarGastoViaje peticion)
        {
            var respuesta = new RespuestaApi<bool>();

            try
            {
                GastosViajesBL.InsertarGastosViaje(
                    peticion.IdViaje, peticion.Gastos);

                respuesta.Datos = true;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }
    }
}
