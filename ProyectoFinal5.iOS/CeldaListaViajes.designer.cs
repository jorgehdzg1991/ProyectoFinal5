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
	[Register ("CeldaListaViajes")]
	partial class CeldaListaViajes
	{
		[Outlet]
		UIKit.UILabel TxtDestino { get; set; }

		[Outlet]
		UIKit.UILabel TxtEstatusViaje { get; set; }

		[Outlet]
		UIKit.UILabel TxtFecha { get; set; }

		[Outlet]
		UIKit.UILabel TxtNombreOperador { get; set; }

		[Outlet]
		UIKit.UILabel TxtOrigen { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtNombreOperador != null) {
				TxtNombreOperador.Dispose ();
				TxtNombreOperador = null;
			}

			if (TxtOrigen != null) {
				TxtOrigen.Dispose ();
				TxtOrigen = null;
			}

			if (TxtDestino != null) {
				TxtDestino.Dispose ();
				TxtDestino = null;
			}

			if (TxtFecha != null) {
				TxtFecha.Dispose ();
				TxtFecha = null;
			}

			if (TxtEstatusViaje != null) {
				TxtEstatusViaje.Dispose ();
				TxtEstatusViaje = null;
			}
		}
	}
}
