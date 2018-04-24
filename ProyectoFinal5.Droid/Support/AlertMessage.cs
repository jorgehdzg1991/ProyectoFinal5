using System;
using Android.App;
using Android.Widget;

namespace ProyectoFinal5.Droid.Support
{
    public static class AlertMessage
    {
        public static void Show(Activity context, string message, ToastLength length)
        {
            Toast.MakeText(context, message, length).Show();
        }
    }
}
