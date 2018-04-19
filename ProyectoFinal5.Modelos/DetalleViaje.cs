using System;

namespace ProyectoFinal5.Modelos
{
    public class DetalleViaje
    {
        public int DetalleViajeId { get; set; }
        public int ViajeId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double KilometrajeInicial { get; set; }
        public double KilometrajeFinal { get; set; }
        public string Observaciones { get; set; }
    }
}
