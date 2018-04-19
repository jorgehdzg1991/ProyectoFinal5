using System.Configuration;

namespace ProyectoFinal5.Soporte.Configuracion
{
    public static class BaseDatos
    {
        public static readonly string NombreBaseDatos = "ProyectoFinal5";

        public static readonly string CadenaConexion = 
            ConfigurationManager.ConnectionStrings[NombreBaseDatos].ToString();
    }
}
