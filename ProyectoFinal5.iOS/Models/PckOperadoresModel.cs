using System;
using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;
using UIKit;

namespace ProyectoFinal5.iOS.Models
{
    public class PckOperadoresModel : UIPickerViewModel
    {
        List<Usuario> _operadores;

        const string TituloTodosOperadores = "Todos los operadores";

        public int SelectedIndex { get; set; }
        public Usuario SelectedItem { get { return _operadores[SelectedIndex]; } }

        public PckOperadoresModel(List<Usuario> operadores)
        {
            SelectedIndex = -1;
            _operadores = operadores;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _operadores.Count + 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (row == 0)
            {
                return TituloTodosOperadores;
            }
            else
            {
                var operador = _operadores[(int)row - 1];
                return $"{operador.UsuarioId} - {operador.Nombre}";
            }
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            SelectedIndex = (int)row - 1;
        }
    }
}
