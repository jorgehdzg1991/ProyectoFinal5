using System;
using System.Collections.Generic;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.App;
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

            DibujarRuta();
        }

        void DibujarRuta()
        {
            try
            {
                if (_posiciones != null && _posiciones.Count >= 2)
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
            }
            catch (Exception ex)
            {
                AlertMessage.Show(Activity, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
            }
        }
    }
}
