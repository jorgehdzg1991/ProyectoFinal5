using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Modelos.Peticiones.Viajes
{
    public class PeticionActualizarEstatus
    {
        public int IdViaje { get; set; }
        public EstatusViaje Estatus { get; set; }
        public DetalleViaje Detalle { get; set; }
    }
}
