using System;
using System.Collections.Generic;
using ProyectoFinal5.AccesoDatos;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.LogicaNegocio
{
    public static class ViajesBL
    {
        public static void ActualizarEstatusViaje(
            int idViaje, EstatusViaje estatus, DetalleViaje detalles)
        {
            ViajesDAO.ActualizarEstatusViaje(idViaje, estatus);

            if (estatus == EstatusViaje.Terminado && detalles != null)
            {
                DetallesViajesDAO.InsertarDetallesViaje(idViaje, detalles);
            }
        }

        public static List<Viaje> ObtenerViajesOperador(int idOperador)
        {
            return ViajesDAO.ObtenerViajesOperador(idOperador);
        }

        public static Viaje ObtenerDetalleViaje(int idViaje)
        {
            return ViajesDAO.ObtenerDetalleViaje(idViaje);
        }

        public static List<Viaje> ObtenerTodosViajes()
        {
            return ViajesDAO.ObtenerTodosViajes();
        }
    }
}
