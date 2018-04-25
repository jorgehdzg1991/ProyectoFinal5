using System;
namespace ProyectoFinal5.iOS
{
    public struct ParametrosGlobales
    {
        public enum TipoAlerta { Alert, Sheet, AlertOption }

        public enum TipoAccion { Touch, Control };

        public enum Accion { Aceptar, Cancelar, SinRespuesta };

        public enum TipoLogin { TouchID, RegistroTouchID }
    }
}
