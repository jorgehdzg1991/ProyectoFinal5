// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using ProyectoFinal5.iOS.DAL.Services;
using ProyectoFinal5.Modelos.Entidades;
using ProyectoFinal5.Modelos.Peticiones.Gastos;
using UIKit;

namespace ProyectoFinal5.iOS
{
	public partial class GastosViewController : UIViewController
    {
        UIAlertController _alerta;
        List<GastoViaje> _gastos;

		public GastosViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            _gastos = TabsViewController.DetalleViaje.Gastos;

            if (_gastos.Count > 0)
            {
                CargarGastos();
            }

            BtnGuardar.TouchUpInside += (object sender, EventArgs e) =>
            {
                GuardarGastos();
            };
		}

        void CargarGastos()
        {
            try
            {
                BtnGuardar.Hidden = true;
                TxtGasolina.Enabled = false;
                TxtCasetas.Enabled = false;
                TxtAlimentos.Enabled = false;
                TxtHospedaje.Enabled = false;
                TxtOtros.Enabled = false;

                foreach (var gasto in _gastos)
                {
                    string anterior = "";

                    switch (gasto.ClaveTipoGasto)
                    {
                        case TipoGasto.Gasolina:
                            TxtGasolina.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Casetas:
                            TxtCasetas.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Alimentos:
                            TxtAlimentos.Text = gasto.Monto.ToString();
                            break;
                        case TipoGasto.Hospedaje:
                            TxtHospedaje.Text = gasto.Monto.ToString();
                            break;
                        default:
                            TxtOtros.Text = gasto.Monto.ToString();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error", ex.Message);
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
                            if (TxtGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = TabsViewController.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Gasolina,
                                    Monto = double.Parse(TxtGasolina.Text)
                                });
                            break;
                        case (int)TipoGasto.Casetas:
                            if (TxtGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = TabsViewController.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Casetas,
                                    Monto = double.Parse(TxtCasetas.Text)
                                });
                            break;
                        case (int)TipoGasto.Alimentos:
                            if (TxtGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = TabsViewController.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Alimentos,
                                    Monto = double.Parse(TxtAlimentos.Text)
                                });
                            break;
                        case (int)TipoGasto.Hospedaje:
                            if (TxtGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = TabsViewController.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Hospedaje,
                                    Monto = double.Parse(TxtHospedaje.Text)
                                });
                            break;
                        case (int)TipoGasto.Otros:
                            if (TxtGasolina.Text.Trim() != "")
                                _gastos.Add(new GastoViaje
                                {
                                    ViajeId = TabsViewController.ViajeId,
                                    ClaveTipoGasto = TipoGasto.Otros,
                                    Monto = double.Parse(TxtOtros.Text)
                                });
                            break;
                    }
                }

                var peticion = new PeticionInsertarGastoViaje
                {
                    IdViaje = TabsViewController.ViajeId,
                    Gastos = _gastos
                };

                await ClienteGastos.InsertarGastosViajeAsync(peticion);

                CargarGastos();
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
	}
}
