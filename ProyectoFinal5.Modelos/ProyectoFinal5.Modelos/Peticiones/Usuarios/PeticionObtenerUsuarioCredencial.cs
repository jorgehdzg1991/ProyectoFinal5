namespace ProyectoFinal5.Modelos.Peticiones.Usuarios
{
    public class PeticionObtenerUsuarioCredencial
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public PeticionObtenerUsuarioCredencial(string correo, string contrasena)
        {
            Correo = correo;
            Contrasena = contrasena;
        }
    }
}
