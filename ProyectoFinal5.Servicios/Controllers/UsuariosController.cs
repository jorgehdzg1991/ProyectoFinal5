using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProyectoFinal5.LogicaNegocio;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Usuarios;
using ProyectoFinal5.Modelos.Respuestas;

namespace ProyectoFinal5.Servicios.Controllers
{
    [RoutePrefix("api/v1/usuarios")]
    [EnableCors("*", "*", "*")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("obtenerUsuarioCredencial")]
        public HttpResponseMessage ObtenerUsuarioCredencial(
            PeticionObtenerUsuarioCredencial peticion)
        {
            var respuesta = new RespuestaApi<Usuario>();

            try
            {
                var usuario = UsuariosBL.ObtenerUsuarioPorCredencial(
                    peticion.Correo, peticion.Contrasena);

                respuesta.Datos = usuario;
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(
                respuesta.CodigoEstadoHttp, respuesta);
        }

        [HttpGet]
        [Route("obtenerOperadores")]
        public HttpResponseMessage ObtenerOperadores()
        {
            var respuesta = new RespuestaApi<List<Usuario>>();

            try
            {
                respuesta.Datos = UsuariosBL.ObtenerOperadores();
            }
            catch (Exception ex)
            {
                respuesta.ManejarExepcion(ex);
            }

            return Request.CreateResponse(
                respuesta.CodigoEstadoHttp, respuesta);
        }
    }
}
