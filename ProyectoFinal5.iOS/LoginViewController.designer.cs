// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
