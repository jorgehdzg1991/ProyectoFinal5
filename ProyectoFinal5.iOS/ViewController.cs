using System;
using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.iOS.DAL.Local;
using ProyectoFinal5.iOS.DAL.Services;
using ProyectoFinal5.iOS.Models;
using ProyectoFinal5.iOS.Support;
using UIKit;
using CoreGraphics;

namespace ProyectoFinal5.iOS
{
    public partial class ViewController : UIViewController
    {
        UIAlertController _alerta;
        public static List<Viaje> Viajes;
        public static List<Viaje> ViajesFiltrados;
        List<Usuario> _operadores;

        string _seleccionado;

        public bool EsLogin { get; set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            txtOperador.Placeholder = "Selecciona un Operardor";

            TblViajes.RegisterNibForCellReuse(CeldaListaViajes.Nib, CeldaListaViajes.Key);

            //txtOperador.InputView = pickerView;

            /*BtnFiltrar.TouchUpInside += delegate
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
            */


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

                //txtOperador.AddObserver

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
            NavigationController.PushViewController(controlador, true);
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

                SetupPicker();

                /*
                pickerView = new UIPickerView();
                var modeloPickerOperadores = new PckOperadoresModel(txtOperador, _operadores);
                //PckOperadores.Model = modeloPickerOperadores;
                pickerView.Model = modeloPickerOperadores;
                */
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

        void FiltrarViajesOperador(int posicion)
        {
            ViajesFiltrados = new List<Viaje>();

            if (posicion == -1)
            {
                ViajesFiltrados.AddRange(Viajes);

                MostrarViajesTabla();
            }
            else
            {
                if (_operadores[posicion] != null)
                {
                    var idOperador = _operadores[posicion].UsuarioId;

                    foreach (var viaje in Viajes)
                    {
                        if (viaje.OperadorId == idOperador)
                        {
                            ViajesFiltrados.Add(viaje);
                        }
                    }

                    MostrarViajesTabla();
                }
                else
                {
                    MostrarMensaje("Error", "Operador desconocido");
                }
            }
        }


        private void SetupPicker()
        {
            var model = new PckOperadoresModel(_operadores);

            model.ValueChanged += (sender, e) =>
            {
                _seleccionado = model.SelectedValue;
            };

            UIPickerView picker = new UIPickerView();
            picker.ShowSelectionIndicator = true;
            picker.Model = model;


            UIToolbar toolbar = new UIToolbar();
            toolbar.BarStyle = UIBarStyle.Default;
            toolbar.Translucent = true;
            var labelTitulo = new UILabel(new CGRect(x: 0, y: 50, width: 150, height: 20))
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.Gray.ColorWithAlpha(0.5f),
                TextAlignment = UITextAlignment.Center,
                Text = " Lista Operadores "
            };

            var tituloCajaTexto = new UIBarButtonItem(labelTitulo);
            var cancelarBoton = new UIBarButtonItem("Cancelar", UIBarButtonItemStyle.Done, (s, e) => { txtOperador.ResignFirstResponder(); });
            var espacioEntreBoton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null, null);

            UIBarButtonItem hechoBoton = new UIBarButtonItem("Hecho", UIBarButtonItemStyle.Done,
            (s, e) => {
                txtOperador.Text = _seleccionado;
                txtOperador.ResignFirstResponder();
            });

            toolbar.SetItems(new UIBarButtonItem[] { cancelarBoton, espacioEntreBoton, tituloCajaTexto, espacioEntreBoton, hechoBoton }, true);

            toolbar.TranslatesAutoresizingMaskIntoConstraints = false;
            picker.TranslatesAutoresizingMaskIntoConstraints = false;

            toolbar.SizeToFit();

            txtOperador.InputView = picker;

            txtOperador.InputAccessoryView = toolbar;


            hechoBoton.Clicked += delegate
            {
                int posicion;

                if (_seleccionado == PckOperadoresModel.TituloTodosOperadores)
                {
                    posicion = -1;
                }
                else
                {
                    posicion = _operadores.FindIndex(o => o.Nombre == _seleccionado);
                }

                //var posicion = ((PckOperadoresModel)PckOperadores.Model).SelectedIndex;

                FiltrarViajesOperador(posicion);
            };

        }

    }//Fin class

}//Fin namespace
