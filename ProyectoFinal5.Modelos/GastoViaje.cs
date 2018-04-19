using System;

namespace ProyectoFinal5.Modelos
{
    public class GastoViaje
    {
        public int GastoViajeId { get; set; }
        public int ViajeId { get; set; }
        public TipoGasto ClaveTipoGasto { get; set; }
        public double Monto { get; set; }

        public string DescripcionTipoGasto
        {
            get
            {
                switch (ClaveTipoGasto)
                {
                    case TipoGasto.Gasolina:
                        return "Gasolina";
                    case TipoGasto.Casetas:
                        return "Casetas";
                    case TipoGasto.Alimentos:
                        return "Alimentos";
                    case TipoGasto.Hospedaje:
                        return "Hospedaje";
                    case TipoGasto.Otros:
                        return "Otros";
                    default:
                        throw new Exception("Tipo de gasto desconocido");
                }
            }
        }
    }
}
