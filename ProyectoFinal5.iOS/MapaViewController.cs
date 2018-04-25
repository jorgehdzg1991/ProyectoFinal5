using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using Foundation;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.iOS
{
    public partial class MapaViewController : UIViewController
    {
        List<PosicionViaje> _posiciones = TabsViewController.DetalleViaje.Posiciones;
        UIAlertController _alerta;

        public MapaViewController() : base("MapaViewController", null)
        {
        }

        public MapaViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                if (_posiciones.Count >= 2)
                {
                    var primera = _posiciones[0];
                    var ultima = _posiciones[_posiciones.Count - 1];

                    var Centrar = new CLLocationCoordinate2D(primera.Coordenada.Latitud, primera.Coordenada.Longitud);
                    var Altura = new MKCoordinateSpan(.1, .1);
                    var Region = new MKCoordinateRegion(Centrar, Altura);

                    Mapa.SetRegion(Region, true);

                    _posiciones.ForEach(x => Mapa.AddAnnotation(
                        new MKPointAnnotation()
                        {
                            Title = x.ViajeId.ToString(),
                            Coordinate = new CLLocationCoordinate2D()
                            {
                                Latitude = x.Coordenada.Latitud,
                                Longitude = x.Coordenada.Longitud
                            }
                        }));

                    var origen = new CLLocationCoordinate2D(primera.Coordenada.Latitud, primera.Coordenada.Longitud);
                    var destino = new CLLocationCoordinate2D(ultima.Coordenada.Latitud, ultima.Coordenada.Longitud);
                    var Info = new NSDictionary();
                    var OrigenDestino = new MKDirectionsRequest()
                    {
                        Source = new MKMapItem(new MKPlacemark(origen, Info)),
                        Destination = new MKMapItem(new MKPlacemark(destino, Info))
                    };
                    var Direcciones = new MKDirections(OrigenDestino);
                    Direcciones.CalculateDirections((response, error) =>
                    {
                        var ruta = response.Routes[0];
                        var Linea = new MKPolylineRenderer(ruta.Polyline)
                        {
                            LineWidth = 5.0f,
                            StrokeColor = UIColor.Orange
                        };
                        Mapa.OverlayRenderer = (mapView, overlay) => Linea;
                        Mapa.AddOverlay(ruta.Polyline, MKOverlayLevel.AboveRoads);
                    });
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MostrarMensaje("Error: ", ex.Message);
            }


        }

        void MostrarMensaje(string titulo, string mensaje)
        {
            _alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            _alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

            PresentViewController(_alerta, true, null);
        }

    }
}

