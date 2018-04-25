using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using ProyectoFinal5.Droid.DAL.Services;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Droid
{
    [Activity(Label = "Transporta App: Admin", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        TextView _lblTituloMain;
        TextView _lblFiltrarViajes;
        TextView _lblViajesHint;
        Spinner _spnOperadores;
        ListView _lsvViajes;

        List<Usuario> _operadores;
        List<Viaje> _viajes;
        List<Viaje> _filtrados;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.MainToolbar);

            toolbar.SetTitleTextColor(Colores.Icons);
            toolbar.SetBackgroundColor(Colores.DarkPrimary);

            SetSupportActionBar(toolbar);

            //SupportActionBar.SetBackgroundDrawable(new ColorDrawable(Colores.Accent));

            _lblTituloMain = FindViewById<TextView>(Resource.Id.LblTituloMain);
            _lblFiltrarViajes = FindViewById<TextView>(Resource.Id.LblFiltrarViajes);
            _lblViajesHint = FindViewById<TextView>(Resource.Id.LblViajesHint);
            _spnOperadores = FindViewById<Spinner>(Resource.Id.SpnOperadores);
            _lsvViajes = FindViewById<ListView>(Resource.Id.LsvViajes);

            _lblTituloMain.SetTextColor(Colores.Accent);
            _lblFiltrarViajes.SetTextColor(Colores.Primary);
            _lblViajesHint.SetTextColor(Colores.SecondaryText);

            await ObtenerViajes();
            await CargarOperadores();
        }

        async Task<bool> ObtenerViajes()
        {
            try
            {
                var respuesta = await ClienteViajes.ObtenerTodosViajesAsync();

                if (respuesta.TieneError)
                {
                    AlertMessage.Show(this, $"Ha ocurrido un error: {respuesta.Mensaje}", ToastLength.Long);
                    return false;
                }

                _viajes = respuesta.Datos;
                return true;
            }
            catch (Exception ex)
            {
                AlertMessage.Show(this, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
                return false;
            }
        }

        async Task<bool> CargarOperadores()
        {
            try
            {
                var respuesta = await ClienteUsuarios.ObtenerOperadoresAsync();

                if (respuesta.TieneError)
                {
                    AlertMessage.Show(this, $"Ha ocurrido un error: {respuesta.Mensaje}", ToastLength.Long);
                    return false;
                }

                _operadores = respuesta.Datos;

                if (_operadores == null || _operadores.Count == 0)
                {
                    AlertMessage.Show(this, $"Ha ocurrido un error: No hay operadores en la base de datos", ToastLength.Long);
                    return false;
                }

                var items = new List<string>
                {
                    "Todos los operadores"
                };

                items.AddRange(_operadores.Select(o => o.Nombre));

                var adaptador = new ArrayAdapter<string>(
                    this, Android.Resource.Layout.SimpleSpinnerItem, items.ToArray());

                _spnOperadores.Adapter = adaptador;

                _spnOperadores.ItemSelected += (sender, e) =>
                {
                    ActualizarListaViajes(e.Position);
                };

                return true;
            }
            catch (Exception ex)
            {
                AlertMessage.Show(this, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
                return false;
            }
        }

        void ActualizarListaViajes(int posicion)
        {
            _filtrados = new List<Viaje>();

            if (posicion == 0)
            {
                _filtrados = _viajes;
            }
            else
            {
                var operadorSeleccionado = _operadores[posicion - 1];

                _filtrados = _viajes.Where(
                    v => v.OperadorId == operadorSeleccionado.UsuarioId).ToList();
            }

            var items = _filtrados.Select(
                v => $"{v.Fecha.ToShortDateString()} {v.Origen} - {v.Destino}").ToArray();

            var adaptador = new ArrayAdapter<string>(
                this, Android.Resource.Layout.SimpleListItem1, items);

            _lsvViajes.Adapter = adaptador;

            _lsvViajes.ItemClick += (sender, e) => 
            {
                var viaje = _filtrados[e.Position];
                var intent = new Intent(this, typeof(ViajeActivity));
                intent.PutExtra("IdViaje", viaje.ViajeId);
                StartActivity(intent);
            };
        }

    }
}

