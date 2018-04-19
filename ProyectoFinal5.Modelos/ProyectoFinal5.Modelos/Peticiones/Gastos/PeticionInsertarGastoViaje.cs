using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Modelos.Peticiones.Gastos
{
    public class PeticionInsertarGastoViaje
    {
        public int IdViaje { get; set; }
        public List<GastoViaje> Gastos { get; set; }
    }
}
