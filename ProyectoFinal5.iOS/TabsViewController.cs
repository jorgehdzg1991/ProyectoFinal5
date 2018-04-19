using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using Foundation;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.iOS.DAL.Local;
using ProyectoFinal5.iOS.DAL.Services;
using ProyectoFinal5.iOS.Models;
using ProyectoFinal5.iOS.Support;

namespace ProyectoFinal5.iOS
{
    public partial class TabsViewController : UITabBarController
    {
        UIAlertController _alerta;
        public static Viaje DetalleViaje;


        public int ViajeId
        {
            get;
            set;
        }

        public TabsViewController() : base("TabsViewController", null)
        {
            
        }

        public TabsViewController(IntPtr handle) : base(handle)
        {
            
        }

        async void ObtenerViajes()
        {
            var respuesta = await ClienteViajes.ObtenerDetalleViajeAsync(ViajeId);

            if (!respuesta.TieneError)
            {
                DetalleViaje = respuesta.Datos;
            }
            else
            {
                MostrarMensaje("Error", respuesta.Mensaje);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ObtenerViajes();
        }

        void MostrarMensaje(string titulo, string mensaje)
        {
            _alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            _alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

            PresentViewController(_alerta, true, null);
        }

    }
}

