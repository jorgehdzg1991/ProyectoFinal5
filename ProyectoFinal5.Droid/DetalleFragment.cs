using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Droid
{
    public class DetalleFragment : Fragment
    {
        DetalleViaje _detalle;

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

        public DetalleFragment(DetalleViaje detalle)
        {
            _detalle = detalle;
        }

        public static DetalleFragment NewInstance(DetalleViaje detalle)
        {
            var fragment = new DetalleFragment(detalle);
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var detalleView = inflater.Inflate(Resource.Layout.FrgDetalleViaje, container, false);

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

            _lblTituloDetalle.SetTextColor(Colores.Accent);
            _lblFechaInicio.SetTextColor(Colores.Primary);
            _lblFechaFin.SetTextColor(Colores.Primary);
            _lblKilometrajeInicial.SetTextColor(Colores.Primary);
            _lblKilometrajeFinal.SetTextColor(Colores.Primary);
            _lblObservaciones.SetTextColor(Colores.Primary);

            _txtFechaInicio.Text = _detalle.FechaInicio.ToString();
            _txtFechaFin.Text = _detalle.FechaFin.ToString();
            _txtKilometrajeInicial.Text = _detalle.KilometrajeInicial.ToString();
            _txtKilometrajeFinal.Text = _detalle.KilometrajeFinal.ToString();
            _txtObservaciones.Text = _detalle.Observaciones;

            return detalleView;
        }
    }
}
