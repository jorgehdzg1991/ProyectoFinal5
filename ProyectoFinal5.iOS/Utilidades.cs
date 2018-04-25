using System;
using UIKit;
namespace ProyectoFinal5.iOS
{
    public class Utilidades
    {
        readonly UIViewController viewController;

        public Utilidades(UIViewController _viewController)
        {
            viewController = _viewController;
        }

        public void ocultarTeclado(UITextField textfield, string accion)
        {
            if (ParametrosGlobales.TipoAccion.Control.ToString().Equals(accion))
            {
                textfield.ShouldReturn += delegate (UITextField text) {
                    text.ResignFirstResponder();
                    return true;
                };
            }
            else if (ParametrosGlobales.TipoAccion.Touch.ToString().Equals(accion))
            {
                textfield.ResignFirstResponder();
            }
        }

    }
}
