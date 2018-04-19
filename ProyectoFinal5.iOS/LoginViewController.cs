using System;
using ProyectoFinal5.iOS.DAL.Local;
using ProyectoFinal5.iOS.DAL.Services;
using ProyectoFinal5.Modelos.Peticiones.Usuarios;
using UIKit;
using ProyectoFinal5.iOS.Support;

namespace ProyectoFinal5.iOS
{
    public partial class LoginViewController : UIViewController
    {
        UIAlertController _alerta;

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public LoginViewController() : base("LoginViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BtnIniciarSesion.TouchUpInside += async delegate
            {
                try
                {
                    var correo = TxtCorreo.Text;
                    var contrasena = TxtContrasena.Text;

                    var peticion = new PeticionObtenerUsuarioCredencial(correo, contrasena);

                    var respuesta = await ClienteUsuarios.ObtenerUsuarioCredencialAsync(peticion);

                    if (respuesta.TieneError)
                    {
                        MostrarMensaje("Error", respuesta.Mensaje);
                        return;
                    }

                    var usuario = respuesta.Datos;

                    GuardarCorreoSesion(usuario.Correo);

                    NavegarMainViewController();
                }
                catch (Exception ex)
                {
                    var mensaje = "Ha ocurrido un error en la aplicación.\n\nMensaje del error:\n";

                    MostrarMensaje("Error", mensaje + ex.Message);
                }
            };
        }

        void MostrarMensaje(string titulo, string mensaje)
        {
            _alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            _alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

            PresentViewController(_alerta, true, null);
        }

        void GuardarCorreoSesion(string correo)
        {
            BaseDatosHelper.InsertarConfiguracion(new Models.Configuracion
            {
                Clave = Constantes.ClaveCorreoSesion,
                Valor = correo
            });
        }

        void NavegarMainViewController()
        {
            var controlador = Storyboard.InstantiateViewController("MainViewController") as ViewController;

            controlador.EsLogin = true;

            PresentViewControllerAsync(controlador, true);
        }
    }
}

