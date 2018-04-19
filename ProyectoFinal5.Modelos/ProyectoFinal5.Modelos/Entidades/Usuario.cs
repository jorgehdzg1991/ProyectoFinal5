using System;

namespace ProyectoFinal5.Modelos.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public TipoUsuario ClaveTipoUsuario { get; set; }
        public bool Estatus { get; set; }

        public string DescripcionTipoGasto
        {
            get
            {
                switch (ClaveTipoUsuario)
                {
                    case TipoUsuario.Administrador:
                        return "Administrador";
                    case TipoUsuario.Operador:
                        return "Operador";
                    default:
                        throw new Exception("Tipo de usuario desconocido");
                }
            }
        }
    }
}
