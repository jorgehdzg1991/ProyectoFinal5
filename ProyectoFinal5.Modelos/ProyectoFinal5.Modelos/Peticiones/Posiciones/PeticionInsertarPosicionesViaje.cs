using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Modelos.Peticiones.Posiciones
{
    public class PeticionInsertarPosicionesViaje
    {
        public int IdViaje { get; set; }
        public List<PosicionViaje> Posiciones { get; set; }
    }
}
