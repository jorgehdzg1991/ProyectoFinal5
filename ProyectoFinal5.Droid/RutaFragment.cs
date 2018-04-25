using System;
using System.Collections.Generic;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Droid
{
    public class RutaFragment : Fragment, IOnMapReadyCallback
    {
        List<PosicionViaje> _posiciones;

        SupportMapFragment _mapFragment;
        GoogleMap _mapa;

        static readonly LatLng LeonGuanajuato = new LatLng(21.1218562, -101.8060975);

        public RutaFragment(List<PosicionViaje> posiciones)
        {
            _posiciones = posiciones;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static RutaFragment NewInstance(List<PosicionViaje> posiciones)
        {
            var fragment = new RutaFragment(posiciones);
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rutaView = inflater.Inflate(Resource.Layout.FrgRutaViaje, container, false);

            _mapFragment = FragmentManager.FindFragmentByTag("MapRuta") as SupportMapFragment;

            if (_mapFragment == null)
            {
                var mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                var fragTx = FragmentManager.BeginTransaction();
                _mapFragment = SupportMapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.MapRuta, _mapFragment, "MapRuta");
                fragTx.Commit();
            }

            _mapFragment.GetMapAsync(this);

            return rutaView;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _mapa = googleMap;

            CentrarMapa();

            if (_posiciones != null && _posiciones.Count >= 2)
            {
				MarcarInicioYFinRuta();
                DibujarRuta();
            }
        }

        void CentrarMapa()
        {
            LatLng centro;
            double zoom;

            if (_posiciones != null && _posiciones.Count >= 2)
            {
                var primera = _posiciones.First();
                var ultima = _posiciones.Last();

                var displayMetrix = new DisplayMetrics();
                Activity.WindowManager.DefaultDisplay.GetMetrics(displayMetrix);

                var pixelWidth = displayMetrix.WidthPixels;

                var GLOBE_WIDTH = 256;

                var west = primera.Coordenada.Longitud;
                var east = ultima.Coordenada.Longitud;

                var angle = east - west;
                if (angle < 0)
                {
                    angle += 360;
                }

                zoom = Math.Round(Math.Log(pixelWidth * 360 / angle / GLOBE_WIDTH) / Math.Log(2));

                centro = new LatLng(primera.Coordenada.Latitud, primera.Coordenada.Longitud);
            }
            else
            {
                centro = LeonGuanajuato;
                zoom = 8.0f;
            }

            _mapa.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(centro, (float)zoom));
        }

        void MarcarInicioYFinRuta()
        {
            try
            {
                var inicio = _posiciones.First();
                var fin = _posiciones.Last();

                AgregarMarcador($"Inicio de viaje: {inicio.Fecha.ToString()}", inicio.Coordenada);
                AgregarMarcador($"Fin de viaje: {fin.Fecha.ToString()}", fin.Coordenada);
            }
            catch (Exception ex)
            {
                AlertMessage.Show(Activity, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
            }
        }

        void DibujarRuta()
        {
            try
            {
                var options = new PolylineOptions();

                var colorInt = Colores.Accent;

                options.InvokeColor(colorInt);
                options.InvokeWidth(5);
                options.Visible(true);

                foreach (var posicion in _posiciones.OrderBy(p => p.Fecha))
                {
                    var coordenada = posicion.Coordenada;

                    options.Add(new LatLng(coordenada.Latitud, coordenada.Longitud));
                }

                _mapa.AddPolyline(options);
            }
            catch (Exception ex)
            {
                AlertMessage.Show(Activity, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
            }
        }

        void AgregarMarcador(string titulo, Coordenada coordenada)
        {
            var options = new MarkerOptions();
            options.SetPosition(new LatLng(coordenada.Latitud, coordenada.Longitud));
            options.SetTitle(titulo);
            _mapa.AddMarker(options);
        }
    }
}
