using System.Collections.Generic;
using ProyectoFinal5.AccesoDatos;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.LogicaNegocio
{
    public static class GastosViajesBL
    {
        public static void InsertarGastosViaje(
            int idViaje, List<GastoViaje> gastos)
        {
            foreach (var gasto in gastos)
            {
                GastosViajesDAO.InsertarGastoViaje(idViaje, gasto);
            }
        }
    }
}
