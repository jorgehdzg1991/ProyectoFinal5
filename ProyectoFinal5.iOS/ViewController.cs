using System;
using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.iOS.DAL.Local;
using ProyectoFinal5.iOS.DAL.Services;
using ProyectoFinal5.iOS.Models;
using ProyectoFinal5.iOS.Support;
using UIKit;

namespace ProyectoFinal5.iOS
{
    public partial class ViewController : UIViewController
    {
        UIAlertController _alerta;
        public static List<Viaje> Viajes;
        public static List<Viaje> ViajesFiltrados;
        List<Usuario> _operadores;

        public bool EsLogin { get; set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TblViajes.RegisterNibForCellReuse(CeldaListaViajes.Nib, CeldaListaViajes.Key);

            BtnFiltrar.TouchUpInside += delegate
            {
                var posicion = ((PckOperadoresModel)PckOperadores.Model).SelectedIndex;

                if (posicion == -1)
                {
                    FiltrarViajesOperador(posicion);
                }
                else
                {
                    FiltrarViajesOperador(_operadores[posicion].UsuarioId);
                }
            };
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            try
            {
                if (!EsLogin)
                {
                    var correoSesion = BaseDatosHelper.ObtenerConfiguracion(Constantes.ClaveCorreoSesion);

                    if (correoSesion == null)
                    {
                        NavegarLogin();
                    }
                }

                ObtenerOperadores();
                ObtenerViajes();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error", ex.Message);
            }
        }

        void MostrarMensaje(string titulo, string mensaje)
        {
            _alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            _alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

            PresentViewController(_alerta, true, null);
        }

        void NavegarLogin()
        {
            var controlador = Storyboard.InstantiateViewController("LoginViewController") as LoginViewController;

            PresentViewControllerAsync(controlador, true);
        }

        async void ObtenerViajes()
        {
            var respuesta = await ClienteViajes.ObtenerTodosViajesAsync();

            if (!respuesta.TieneError)
            {
                ViajesFiltrados = new List<Viaje>();

                Viajes = respuesta.Datos;
                ViajesFiltrados.AddRange(Viajes);

                MostrarViajesTabla();
            }
            else
            {
                MostrarMensaje("Error", respuesta.Mensaje);
            }
        }

        async void ObtenerOperadores()
        {
            var respuesta = await ClienteUsuarios.ObtenerOperadoresAsync();

            if (!respuesta.TieneError)
            {
                _operadores = respuesta.Datos;

                var modeloPickerOperadores = new PckOperadoresModel(_operadores);
                PckOperadores.Model = modeloPickerOperadores;
            }
            else
            {
                MostrarMensaje("Error", respuesta.Mensaje);
            }
        }

        void MostrarViajesTabla()
        {
            TblViajes.Source = null;

            var origenTabla = new TblViajesSource(ViajesFiltrados, NavigationController, Storyboard);

            TblViajes.Source = origenTabla;
            TblViajes.ReloadData();
        }

        void FiltrarViajesOperador(int idOperador)
        {
            ViajesFiltrados = new List<Viaje>();

            if (idOperador == -1)
            {
                ViajesFiltrados.AddRange(Viajes);

                MostrarViajesTabla();
            }
            else
            {
                foreach (var viaje in Viajes)
                {
                    if (viaje.OperadorId == idOperador)
                    {
                        ViajesFiltrados.Add(viaje);
                    }
                }

                MostrarViajesTabla();
            }
        }
    }


}
