
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Droid
{
    public class ViajeFragment : Fragment
    {
        int _position;
        Viaje _viaje;

        // Controles para la vista de detalle de viaje
        TextView _lblTituloDetalle;
        TextView _lblFechaInicio;
        TextView _lblFechaFin;
        TextView _lblKilometrajeInicial;
        TextView _lblKilometrajeFinal;
        TextView _lblObservaciones;
        EditText _txtFechaInicio;
        EditText _txtFechaFin;
        EditText _txtKilometrajeInicial;
        EditText _txtKilometrajeFinal;
        EditText _txtObservaciones;

        public ViajeFragment(Viaje viaje)
        {
            _viaje = viaje;
        }

        public static ViajeFragment NewInstance(int position, Viaje viaje)
        {
            var fragment = new ViajeFragment(viaje);
            var arguments = new Bundle();

            arguments.PutInt("position", position);
            fragment.Arguments = arguments;

            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _position = Arguments.GetInt("position");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view;

            switch (_position)
            {
                case 0:
                    view = inflater.Inflate(Resource.Layout.FrgDetalleViaje, container, false);
                    SetUpDetalleView(view);
                    break;
                case 1:
                    view = inflater.Inflate(Resource.Layout.FrgRutaViaje, container, false);
                    break;
                default:
                    view = inflater.Inflate(Resource.Layout.FrgGastosViaje, container, false);
                    break;
            }

            ViewCompat.SetElevation(view, 50);

            return view;
        }

        void SetUpDetalleView(View detalleView)
        {
            _lblTituloDetalle = detalleView.FindViewById<TextView>(Resource.Id.LblTituloDetalle);
            _lblFechaInicio = detalleView.FindViewById<TextView>(Resource.Id.LblFechaInicio);
            _lblFechaFin = detalleView.FindViewById<TextView>(Resource.Id.LblFechaFin);
            _lblKilometrajeInicial = detalleView.FindViewById<TextView>(Resource.Id.LblKilometrajeInicial);
            _lblKilometrajeFinal = detalleView.FindViewById<TextView>(Resource.Id.LblKilometrajeFinal);
            _lblObservaciones = detalleView.FindViewById<TextView>(Resource.Id.LblObservaciones);
            _txtFechaInicio = detalleView.FindViewById<EditText>(Resource.Id.TxtFechaInicio);
            _txtFechaFin = detalleView.FindViewById<EditText>(Resource.Id.TxtFechaFin);
            _txtKilometrajeInicial = detalleView.FindViewById<EditText>(Resource.Id.TxtKilometrajeInicial);
            _txtKilometrajeFinal = detalleView.FindViewById<EditText>(Resource.Id.TxtKilometrajeFinal);
            _txtObservaciones = detalleView.FindViewById<EditText>(Resource.Id.TxtObservaciones);

            _lblTituloDetalle.SetTextColor(Colores.Primary);
            _lblFechaInicio.SetTextColor(Colores.LightPrimary);
            _lblFechaFin.SetTextColor(Colores.LightPrimary);
            _lblKilometrajeInicial.SetTextColor(Colores.LightPrimary);
            _lblKilometrajeFinal.SetTextColor(Colores.LightPrimary);
            _lblObservaciones.SetTextColor(Colores.LightPrimary);

            var detalle = _viaje.Detalle;

            _txtFechaInicio.Text = detalle.FechaInicio.ToString();
            _txtFechaFin.Text = detalle.FechaFin.ToString();
            _txtKilometrajeInicial.Text = detalle.KilometrajeInicial.ToString();
            _txtKilometrajeFinal.Text = detalle.KilometrajeFinal.ToString();
            _txtObservaciones.Text = detalle.Observaciones;
        }
    }
}
