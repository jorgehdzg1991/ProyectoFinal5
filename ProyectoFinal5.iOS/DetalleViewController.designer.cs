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
	[Register ("DetalleViewController")]
	partial class DetalleViewController
	{
		[Outlet]
		UIKit.UITextField TxtFechaFinal { get; set; }

		[Outlet]
		UIKit.UITextField TxtFechaInicial { get; set; }

		[Outlet]
		UIKit.UITextField TxtKilometrajeFinal { get; set; }

		[Outlet]
		UIKit.UITextField TxtKilometrajeInicial { get; set; }

		[Outlet]
		UIKit.UITextField TxtObservaciones { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtFechaInicial != null) {
				TxtFechaInicial.Dispose ();
				TxtFechaInicial = null;
			}

			if (TxtFechaFinal != null) {
				TxtFechaFinal.Dispose ();
				TxtFechaFinal = null;
			}

			if (TxtKilometrajeInicial != null) {
				TxtKilometrajeInicial.Dispose ();
				TxtKilometrajeInicial = null;
			}

			if (TxtKilometrajeFinal != null) {
				TxtKilometrajeFinal.Dispose ();
				TxtKilometrajeFinal = null;
			}

			if (TxtObservaciones != null) {
				TxtObservaciones.Dispose ();
				TxtObservaciones = null;
			}
		}
	}
}
