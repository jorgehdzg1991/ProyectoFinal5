using System;

using Foundation;
using ProyectoFinal5.Modelos.Entidades;
using UIKit;

namespace ProyectoFinal5.iOS
{
    public partial class CeldaListaViajes : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CeldaListaViajes");
        public static readonly UINib Nib;

        static CeldaListaViajes()
        {
            Nib = UINib.FromName("CeldaListaViajes", NSBundle.MainBundle);
        }

        protected CeldaListaViajes(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void ActualizarCelda(Viaje viaje)
        {
            //ContentView.SetNeedsLayout();
            //ContentView.LayoutIfNeeded();

            TxtNombreOperador.Text = viaje.NombreOperador;
            TxtOrigen.Text = $"Destino: {viaje.Origen}";
            TxtDestino.Text = $"Origen: {viaje.Destino}";
            TxtFecha.Text = $"Fecha: {viaje.Fecha.ToString()}";
            TxtEstatusViaje.Text = $"Estatus de viaje: {viaje.DescripcionEstatusViaje}";
        }
    }
}
