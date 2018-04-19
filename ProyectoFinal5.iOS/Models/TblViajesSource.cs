using System;
using System.Collections.Generic;
using Foundation;
using ProyectoFinal5.Modelos.Entidades;
using UIKit;

namespace ProyectoFinal5.iOS.Models
{
    public class TblViajesSource : UITableViewSource
    {
        List<Viaje> _viajes;
        UINavigationController _navigationController;
        UIStoryboard _storyboard;

        public TblViajesSource(List<Viaje> viajes, UINavigationController navigationController, UIStoryboard storyboard)
        {
            _viajes = viajes;
            _navigationController = navigationController;
            _storyboard = storyboard;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var celda = (CeldaListaViajes)tableView.DequeueReusableCell("CeldaListaViajes", indexPath);
            var viaje = _viajes[indexPath.Row];

            celda.ActualizarCelda(viaje);

            return celda;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _viajes.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var posicion = indexPath.Row;
            var viaje = ViewController.ViajesFiltrados[posicion];

            var controlador = _storyboard.InstantiateViewController("tabsViewController") as TabsViewController;

            controlador.ViajeId = viaje.ViajeId;
            _navigationController.PushViewController(controlador,true);

        }

    }
}
