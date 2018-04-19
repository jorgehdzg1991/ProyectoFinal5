using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProyectoFinal5.LogicaNegocio;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Viajes;
using ProyectoFinal5.Modelos.Respuestas;

namespace ProyectoFinal5.Servicios.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/viajes")]
    public class ViajesController : ApiController
    {
        [HttpPut]
        [Route("actualizarEstatus")]
        public HttpResponseMessage ActualizarEstatusViaje(
            PeticionActualizarEstatus peticion)
        {
            var respuesta = new RespuestaApi<bool>();

            try
            {
                ViajesBL.ActualizarEstatusViaje(
                    peticion.IdViaje, peticion.Estatus, peticion.Detalle);

                respuesta.Datos = true;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }

        [HttpGet]
        [Route("obtenerViajesOperador/{idOperador}")]
        public HttpResponseMessage ObtenerViajesOperador(int idOperador)
        {
            var respuesta = new RespuestaApi<List<Viaje>>();

            try
            {
                var viajes = ViajesBL.ObtenerViajesOperador(idOperador);

                respuesta.Datos = viajes;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }

        [HttpGet]
        [Route("obtenerDetalleViaje/{idViaje}")]
        public HttpResponseMessage ObtenerDetalleViaje(int idViaje)
        {
            var respuesta = new RespuestaApi<Viaje>();

            try
            {
                var viaje = ViajesBL.ObtenerDetalleViaje(idViaje);

                respuesta.Datos = viaje;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }

        [HttpGet]
        [Route("obtenerTodosViajes")]
        public HttpResponseMessage ObtenerTodosViajes()
        {
            var respuesta = new RespuestaApi<List<Viaje>>();

            try
            {
                var viajes = ViajesBL.ObtenerTodosViajes();

                respuesta.Datos = viajes;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(respuesta.CodigoEstadoHttp, respuesta);
        }
    }
}
