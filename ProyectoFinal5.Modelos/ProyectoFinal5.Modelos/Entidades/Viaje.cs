using System;
using System.Collections.Generic;

namespace ProyectoFinal5.Modelos.Entidades
{
    public class Viaje
    {
        public int ViajeId { get; set; }
        public int OperadorId { get; set; }
        public string NombreOperador { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public EstatusViaje ClaveEstatusViaje { get; set; }

        public string DescripcionEstatusViaje
        {
            get
            {
                switch (ClaveEstatusViaje)
                {
                    case EstatusViaje.Iniciado:
                        return "Iniciado";
                    case EstatusViaje.Entregado:
                        return "Entregado";
                    case EstatusViaje.Terminado:
                        return "Terminado";
                    case EstatusViaje.NoIniciado:
                        return "No iniciado";
                    default:
                        throw new Exception("Estatus de viaje desconocido");
                }
            }
        }

        public DetalleViaje Detalle { get; set; }
        public List<GastoViaje> Gastos { get; set; }
        public List<PosicionViaje> Posiciones { get; set; }
    }
}
