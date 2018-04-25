using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using ProyectoFinal5.Droid.DAL.Services;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Gastos;

namespace ProyectoFinal5.Droid
{
    public class GastosFragment : Fragment
    {
        readonly int _idViaje;
        List<GastoViaje> _gastos;

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

        public GastosFragment(int idViaje, List<GastoViaje> gastos)
        {
            _idViaje = idViaje;
            _gastos = gastos;
        }

        public static GastosFragment NewInstance(int idViaje, List<GastoViaje> gastos)
        {
            var fragment = new GastosFragment(idViaje, gastos);
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var gastosView = inflater.Inflate(Resource.Layout.FrgGastosViaje, container, false);

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

            return gastosView;
        }

        void CargarGastos()
        {
            var gastos = _gastos;

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

                _btnGuardarGastos.Click += (sender, e) => { };
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
                _gastos = new List<GastoViaje>();

                for (int i = (int)TipoGasto.Gasolina; i < ((int)TipoGasto.Otros + 1); i++)
                {
                    switch (i)
                    {
                        case (int)TipoGasto.Gasolina:
                            if (_txtGastoGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = _idViaje,
                                    ClaveTipoGasto = TipoGasto.Gasolina,
                                    Monto = double.Parse(_txtGastoGasolina.Text)
                                });
                            break;
                        case (int)TipoGasto.Casetas:
                            if (_txtGastoCasetas.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = _idViaje,
                                    ClaveTipoGasto = TipoGasto.Casetas,
                                    Monto = double.Parse(_txtGastoCasetas.Text)
                                });
                            break;
                        case (int)TipoGasto.Alimentos:
                            if (_txtGastoAlimentos.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = _idViaje,
                                    ClaveTipoGasto = TipoGasto.Alimentos,
                                    Monto = double.Parse(_txtGastoAlimentos.Text)
                                });
                            break;
                        case (int)TipoGasto.Hospedaje:
                            if (_txtGastoHospedaje.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = _idViaje,
                                    ClaveTipoGasto = TipoGasto.Hospedaje,
                                    Monto = double.Parse(_txtGastoHospedaje.Text)
                                });
                            break;
                        case (int)TipoGasto.Otros:
                            if (_txtGastoOtros.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = _idViaje,
                                    ClaveTipoGasto = TipoGasto.Otros,
                                    Monto = double.Parse(_txtGastoOtros.Text)
                                });
                            break;
                    }
                }

                var peticion = new PeticionInsertarGastoViaje
                {
                    IdViaje = _idViaje,
                    Gastos = _gastos
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
