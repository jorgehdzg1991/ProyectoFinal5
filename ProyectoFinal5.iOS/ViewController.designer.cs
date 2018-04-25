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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnFiltrar { get; set; }

		[Outlet]
		UIKit.UIPickerView PckOperadores { get; set; }

		[Outlet]
		UIKit.UITableView TblViajes { get; set; }

		[Outlet]
		UIKit.UITextField txtOperador { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtOperador != null) {
				txtOperador.Dispose ();
				txtOperador = null;
			}

			if (BtnFiltrar != null) {
				BtnFiltrar.Dispose ();
				BtnFiltrar = null;
			}

			if (PckOperadores != null) {
				PckOperadores.Dispose ();
				PckOperadores = null;
			}

			if (TblViajes != null) {
				TblViajes.Dispose ();
				TblViajes = null;
			}
		}
	}
}
