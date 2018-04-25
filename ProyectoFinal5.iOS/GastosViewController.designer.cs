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
	[Register ("GastosViewController")]
	partial class GastosViewController
	{
		[Outlet]
		UIKit.UIButton BtnGuardar { get; set; }

		[Outlet]
		UIKit.UITextField TxtAlimentos { get; set; }

		[Outlet]
		UIKit.UITextField TxtCasetas { get; set; }

		[Outlet]
		UIKit.UITextField TxtGasolina { get; set; }

		[Outlet]
		UIKit.UITextField TxtHospedaje { get; set; }

		[Outlet]
		UIKit.UITextField TxtOtros { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TxtGasolina != null) {
				TxtGasolina.Dispose ();
				TxtGasolina = null;
			}

			if (TxtCasetas != null) {
				TxtCasetas.Dispose ();
				TxtCasetas = null;
			}

			if (TxtAlimentos != null) {
				TxtAlimentos.Dispose ();
				TxtAlimentos = null;
			}

			if (TxtHospedaje != null) {
				TxtHospedaje.Dispose ();
				TxtHospedaje = null;
			}

			if (TxtOtros != null) {
				TxtOtros.Dispose ();
				TxtOtros = null;
			}

			if (BtnGuardar != null) {
				BtnGuardar.Dispose ();
				BtnGuardar = null;
			}
		}
	}
}
