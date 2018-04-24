
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

namespace ProyectoFinal5.Droid
{
    public class ViajeFragment : Fragment
    {
        int _position;

        public static ViajeFragment NewInstance(int position)
        {
            var fragment = new ViajeFragment();
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
    }
}
