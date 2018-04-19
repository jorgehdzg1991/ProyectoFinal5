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
	[Register ("MapaViewController")]
	partial class MapaViewController
	{
		[Outlet]
		MapKit.MKMapView Mapa { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Mapa != null) {
				Mapa.Dispose ();
				Mapa = null;
			}
		}
	}
}
