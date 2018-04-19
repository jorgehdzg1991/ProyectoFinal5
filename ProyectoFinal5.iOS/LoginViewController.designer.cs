// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ProyectoFinal5.iOS
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UIButton BtnIniciarSesion { get; set; }


        [Outlet]
        UIKit.UITextField TxtContrasena { get; set; }


        [Outlet]
        UIKit.UITextField TxtCorreo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtnIniciarSesion != null) {
                BtnIniciarSesion.Dispose ();
                BtnIniciarSesion = null;
            }

            if (TxtContrasena != null) {
                TxtContrasena.Dispose ();
                TxtContrasena = null;
            }

            if (TxtCorreo != null) {
                TxtCorreo.Dispose ();
                TxtCorreo = null;
            }
        }
    }
}