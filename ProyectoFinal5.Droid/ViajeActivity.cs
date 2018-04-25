using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using com.refractored;
using ProyectoFinal5.Droid.DAL.Services;
using ProyectoFinal5.Droid.Support;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.Droid
{
    [Activity(Label = "ViajeActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ViajeActivity : AppCompatActivity
    {
        Viaje _viaje;
        ViajeAdapter _adapter;
        PagerSlidingTabStrip _tabs;
        ViewPager _pager;
        Button _btnRegresarInicio;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Viaje);

            _btnRegresarInicio = FindViewById<Button>(Resource.Id.BtnRegresarInicio);
            _pager = FindViewById<ViewPager>(Resource.Id.pager);
            _tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);

            _tabs.SetBackgroundColor(Colores.DarkPrimary);
            _tabs.SetTabTextColor(Colores.Icons);
            _btnRegresarInicio.Visibility = Android.Views.ViewStates.Gone;
            _btnRegresarInicio.SetBackgroundColor(Colores.LightPrimary);
            _btnRegresarInicio.SetTextColor(Colores.PrimaryText);

            var idViaje = Intent.GetIntExtra("IdViaje", -1);

            if (idViaje == -1)
            {
                AlertMessage.Show(this, "Ha ocurrido un error: No se seleccionó un viaje", ToastLength.Long);
                RegresarInicio();
                return;
            }

            await ObtenerDetalleViajeSeleccionado(idViaje);

            _adapter = new ViajeAdapter(SupportFragmentManager, _viaje);

            _pager.Adapter = _adapter;
            _tabs.SetViewPager(_pager);

            _btnRegresarInicio.Click += (sender, e) =>
            {
                RegresarInicio();
            };
        }

        void RegresarInicio()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        async Task<bool> ObtenerDetalleViajeSeleccionado(int idViaje)
        {
            try
            {
                var respuesta = await ClienteViajes.ObtenerDetalleViajeAsync(idViaje);

                if (respuesta.TieneError)
                {
                    AlertMessage.Show(
                        this, $"Ha ocurrido un error: {respuesta.Mensaje}", ToastLength.Long);
                    return false;
                }

                _viaje = respuesta.Datos;

                return true;
            }
            catch (System.Exception ex)
            {
                AlertMessage.Show(
                    this, $"Ha ocurrido un error: {ex.Message}", ToastLength.Long);
                return false;
            }
        }

        public class ViajeAdapter : Android.Support.V4.App.FragmentPagerAdapter
        {
            int tabsCount = 3;
            Viaje _viaje;

            public ViajeAdapter(Android.Support.V4.App.FragmentManager fm, Viaje viaje) : base(fm)
            {
                _viaje = viaje;
            }

            public override int Count => tabsCount;

			public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
			{
                Java.Lang.ICharSequence cs;

                switch (position)
                {
                    case 0:
                        cs = new Java.Lang.String("Detalle");
                        break;
                    case 1:
                        cs = new Java.Lang.String("Ruta");
                        break;
                    default:
                        cs = new Java.Lang.String("Gastos");
                        break;
                }

                return cs;
			}

			public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                switch (position)
                {
                    case 0:
                        return DetalleFragment.NewInstance(_viaje.Detalle);
                    case 1:
                        return RutaFragment.NewInstance(_viaje.Posiciones);
                    default:
                        return GastosFragment.NewInstance(_viaje.ViajeId, _viaje.Gastos);
                }
            }
        }
    }
}
