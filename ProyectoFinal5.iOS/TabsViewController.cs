using System;
using UIKit;
using ProyectoFinal5.Modelos.Entidades;

namespace ProyectoFinal5.iOS
{
    public partial class TabsViewController : UITabBarController
    {
        public static Viaje DetalleViaje;
        public static int ViajeId;

        public TabsViewController() : base("TabsViewController", null)
        {
            
        }

        public TabsViewController(IntPtr handle) : base(handle)
        {
            
        }



    }
}

