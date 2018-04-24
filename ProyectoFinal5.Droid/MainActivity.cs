using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using ProyectoFinal5.Droid.DAL.Services;
using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Droid.Support;
using System.Linq;
using System;
using Android.Content;
using Android.Support.V7.App;
using Android.Graphics.Drawables;

namespace ProyectoFinal5.Droid
{
    [Activity(Label = "Transporta App: Admin", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        Spinner _spnOperadores;
        ListView _lsvViajes;

        List<Usuario> _operadores;
        List<Viaje> _viajes;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.MainToolbar);

            toolbar.SetTitleTextColor(Colores.Icons);
            toolbar.SetBackgroundColor(Colores.Accent);

            SetSupportActionBar(toolbar);

            //SupportActionBar.SetBackgroundDrawable(new ColorDrawable(Colores.Accent));

            _spnOperadores = FindViewById<Spinner>(Resource.Id.SpnOperadores);
            _lsvViajes = FindViewById<ListView>(Resource.Id.LsvViajes);

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
            var filtrados = new List<Viaje>();

            if (posicion == 0)
            {
                filtrados = _viajes;
            }
            else
            {
                var operadorSeleccionado = _operadores[posicion - 1];

                filtrados = _viajes.Where(
                    v => v.OperadorId == operadorSeleccionado.UsuarioId).ToList();
            }

            var items = filtrados.Select(
                v => $"Origen: {v.Origen}; Destino: {v.Destino}").ToArray();

            var adaptador = new ArrayAdapter<string>(
                this, Android.Resource.Layout.SimpleListItem1, items);

            _lsvViajes.Adapter = adaptador;

            _lsvViajes.ItemClick += (sender, e) => 
            {
                var viaje = _viajes[e.Position];
                var intent = new Intent(this, typeof(ViajeActivity));
                intent.PutExtra("IdViaje", viaje.ViajeId);
                StartActivity(intent);
            };
        }

    }
}

