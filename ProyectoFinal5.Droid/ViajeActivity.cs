
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using com.refractored;
using Java.Lang;
using ProyectoFinal5.Droid.Support;

namespace ProyectoFinal5.Droid
{
    [Activity(Label = "ViajeActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class ViajeActivity : AppCompatActivity
    {
        ViajeAdapter _adapter;
        PagerSlidingTabStrip _tabs;
        ViewPager _pager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Viaje);

            _adapter = new ViajeAdapter(SupportFragmentManager);
            _pager = FindViewById<ViewPager>(Resource.Id.pager);
            _tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);

            _pager.Adapter = _adapter;
            _tabs.SetViewPager(_pager);
            _tabs.SetBackgroundColor(Colores.Accent);
            _tabs.SetTabTextColor(Colores.Icons);
        }

        public class ViajeAdapter : Android.Support.V4.App.FragmentPagerAdapter
        {
            int tabsCount = 3;

            public ViajeAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {
            }

            public override int Count => tabsCount;

			public override ICharSequence GetPageTitleFormatted(int position)
			{
                ICharSequence cs;

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
                return ViajeFragment.NewInstance(position);
            }
        }
    }
}
