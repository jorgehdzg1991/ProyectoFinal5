using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using ProyectoFinal5.Droid.DAL.Services;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Gastos;

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

        // Controles para la vista de gastos de viaje
        TextView _lblTituloGastos;
        TextView _lblGastoGasolina;
        TextView _lblGastoCasetas;
        TextView _lblGastoAlimentos;
        TextView _lblGastoHospedaje;
        TextView _lblGastoOtros;
        EditText _txtGastoGasolina;
        EditText _txtGastoCasetas;
        EditText _txtGastoAlimentos;
        EditText _txtGastoHospedaje;
        EditText _txtGastoOtros;
        Button _btnGuardarGastos;

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
                    SetUpGastosView(view);
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

            _lblTituloDetalle.SetTextColor(Colores.Accent);
            _lblFechaInicio.SetTextColor(Colores.Primary);
            _lblFechaFin.SetTextColor(Colores.Primary);
            _lblKilometrajeInicial.SetTextColor(Colores.Primary);
            _lblKilometrajeFinal.SetTextColor(Colores.Primary);
            _lblObservaciones.SetTextColor(Colores.Primary);

            var detalle = _viaje.Detalle;

            _txtFechaInicio.Text = detalle.FechaInicio.ToString();
            _txtFechaFin.Text = detalle.FechaFin.ToString();
            _txtKilometrajeInicial.Text = detalle.KilometrajeInicial.ToString();
            _txtKilometrajeFinal.Text = detalle.KilometrajeFinal.ToString();
            _txtObservaciones.Text = detalle.Observaciones;
        }

        void SetUpGastosView(View gastosView)
        {
            _lblTituloGastos = gastosView.FindViewById<TextView>(Resource.Id.LblTituloGastos);
            _lblGastoGasolina = gastosView.FindViewById<TextView>(Resource.Id.LblGastoGasolina);
            _lblGastoCasetas = gastosView.FindViewById<TextView>(Resource.Id.LblGastoCasetas);
            _lblGastoAlimentos = gastosView.FindViewById<TextView>(Resource.Id.LblGastoAlimentos);
            _lblGastoHospedaje = gastosView.FindViewById<TextView>(Resource.Id.LblGastoHospedaje);
            _lblGastoOtros = gastosView.FindViewById<TextView>(Resource.Id.LblGastoOtros);
            _txtGastoGasolina = gastosView.FindViewById<EditText>(Resource.Id.TxtGastoGasolina);
            _txtGastoCasetas = gastosView.FindViewById<EditText>(Resource.Id.TxtGastoCasetas);
            _txtGastoAlimentos = gastosView.FindViewById<EditText>(Resource.Id.TxtGastoAlimentos);
            _txtGastoHospedaje = gastosView.FindViewById<EditText>(Resource.Id.TxtGastoHospedaje);
            _txtGastoOtros = gastosView.FindViewById<EditText>(Resource.Id.TxtGastoOtros);
            _btnGuardarGastos = gastosView.FindViewById<Button>(Resource.Id.BtnGuardarGastos);

            _lblTituloGastos.SetTextColor(Colores.Accent);
            _lblGastoGasolina.SetTextColor(Colores.Primary);
            _lblGastoCasetas.SetTextColor(Colores.Primary);
            _lblGastoAlimentos.SetTextColor(Colores.Primary);
            _lblGastoHospedaje.SetTextColor(Colores.Primary);
            _lblGastoOtros.SetTextColor(Colores.Primary);
            _btnGuardarGastos.SetBackgroundColor(Colores.Accent);
            _btnGuardarGastos.SetTextColor(Colores.Icons);

            CargarGastos();
        }

        void CargarGastos()
        {
            var gastos = _viaje.Gastos;

            if (gastos != null && gastos.Count > 0)
            {
                _txtGastoGasolina.Enabled = false;
                _txtGastoCasetas.Enabled = false;
                _txtGastoAlimentos.Enabled = false;
                _txtGastoHospedaje.Enabled = false;
                _txtGastoOtros.Enabled = false;
                _btnGuardarGastos.Visibility = ViewStates.Gone;

                foreach (var gasto in gastos)
                {
                    switch (gasto.ClaveTipoGasto)
                    {
                        case TipoGasto.Gasolina:
                            _txtGastoGasolina.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Casetas:
                            _txtGastoCasetas.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Alimentos:
                            _txtGastoAlimentos.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Hospedaje:
                            _txtGastoHospedaje.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Otros:
                            _txtGastoOtros.Text = gasto.Monto.ToString();
                            break;
                    }
                }

                _btnGuardarGastos.Click += (sender, e) => {};
            }
            else
            {
                _txtGastoGasolina.Enabled = true;
                _txtGastoCasetas.Enabled = true;
                _txtGastoAlimentos.Enabled = true;
                _txtGastoHospedaje.Enabled = true;
                _txtGastoOtros.Enabled = true;
                _btnGuardarGastos.Visibility = ViewStates.Visible;

                _btnGuardarGastos.Click += (sender, e) =>
                {
                    GuardarGastos();
                };
            }
        }

        async void GuardarGastos()
        {
            try
            {
                _viaje.Gastos = new List<GastoViaje>();

                for (int i = (int)TipoGasto.Gasolina; i < ((int)TipoGasto.Otros + 1); i++)
                {
                    switch (i)
                    {
                        case (int)TipoGasto.Gasolina:
                            if (_txtGastoGasolina.Text.Trim() != "")
                                _viaje.Gastos.Add(new GastoViaje
                                {
                                ViajeId = _viaje.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Gasolina,
                                    Monto = double.Parse(_txtGastoGasolina.Text)
                                });
                            break;
                        case (int)TipoGasto.Casetas:
                            if (_txtGastoCasetas.Text.Trim() != "")
                                _viaje.Gastos.Add(new GastoViaje
                                {
                                    ViajeId = _viaje.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Casetas,
                                    Monto = double.Parse(_txtGastoCasetas.Text)
                                });
                            break;
                        case (int)TipoGasto.Alimentos:
                            if (_txtGastoAlimentos.Text.Trim() != "")
                                _viaje.Gastos.Add(new GastoViaje
                                {
                                    ViajeId = _viaje.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Alimentos,
                                    Monto = double.Parse(_txtGastoAlimentos.Text)
                                });
                            break;
                        case (int)TipoGasto.Hospedaje:
                            if (_txtGastoHospedaje.Text.Trim() != "")
                                _viaje.Gastos.Add(new GastoViaje
                                {
                                    ViajeId = _viaje.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Hospedaje,
                                    Monto = double.Parse(_txtGastoHospedaje.Text)
                                });
                            break;
                        case (int)TipoGasto.Otros:
                            if (_txtGastoOtros.Text.Trim() != "")
                                _viaje.Gastos.Add(new GastoViaje
                                {
                                    ViajeId = _viaje.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Otros,
                                    Monto = double.Parse(_txtGastoOtros.Text)
                                });
                            break;
                    }
                }

                var peticion = new PeticionInsertarGastoViaje
                {
                    IdViaje = _viaje.ViajeId,
                    Gastos = _viaje.Gastos
                };

                await ClienteGastos.InsertarGastosViajeAsync(peticion);

                CargarGastos();
            }
            catch (Exception ex)
            {
                AlertMessage.Show(Activity, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
            }
        }
    }
}
