using System.Collections.Generic;
using ProyectoFinal5.AccesoDatos;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Soporte.Utilerias;

namespace ProyectoFinal5.LogicaNegocio
{
    public static class UsuariosBL
    {
        public static Usuario ObtenerUsuarioPorCredencial(
            string correo, string contrasena)
        {
            var contrasenaEncriptadaMD5 = Criptografia.CrearMD5(contrasena);

            return UsuariosDAO.ObtenerUsuarioCredenciales(
                correo, contrasenaEncriptadaMD5);
        }

        public static List<Usuario> ObtenerOperadores()
        {
            return UsuariosDAO.ObtenerOperadores();
        }
    }
}
