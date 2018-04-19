using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using ProyectoFinal5.Soporte.Configuracion;
using ProyectoFinal5.Modelos.Entidades;
using System.Collections.Generic;

namespace ProyectoFinal5.AccesoDatos
{
    public static class UsuariosDAO
    {
        public static Usuario ObtenerUsuarioCredenciales(
            string correo, string contrasena)
        {
            using (var conexion = new MySqlConnection(BaseDatos.CadenaConexion))
            {
                var parametros = new DynamicParameters();

                parametros.Add("p_Correo", correo, DbType.String);
                parametros.Add("p_Contrasena", contrasena, DbType.String);

                return conexion
                    .Query<Usuario>(
                        ProcedimientosAlmacenados.ObtenerUsuarioPorCredenciales,
                        parametros,
                        commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public static List<Usuario> ObtenerOperadores()
        {
            using (var conexion = new MySqlConnection(BaseDatos.CadenaConexion))
            {
                return conexion
                    .Query<Usuario>(
                        ProcedimientosAlmacenados.ObtenerOperadores,
                        commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
