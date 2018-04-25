using System;
using System.Collections.Generic;
using ProyectoFinal5.Modelos.Entidades;
using UIKit;

namespace ProyectoFinal5.iOS.Models
{
    public class PckOperadoresModel : UIPickerViewModel
    {
        List<Usuario> _operadores;
        private UITextField personTxt;

        const string TituloTodosOperadores = "Todos los operadores";

        public int SelectedIndex { get; set; }
        public Usuario SelectedItem { get { return _operadores[SelectedIndex]; } }

        public EventHandler ValueChanged;
        public string SelectedValue;

        public PckOperadoresModel(){}

        public PckOperadoresModel(List<Usuario> operadores)
        {
            this._operadores = operadores;
        }

        public PckOperadoresModel(UITextField textfield, List<Usuario> operadores)
        {
            this.personTxt = textfield;
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

            var operador = "";
            if(row == 0)
                operador = _operadores[(int) row].Nombre;
            else
                operador = _operadores[(int)row - 1].Nombre;

            SelectedValue = operador.ToString();  
            ValueChanged ? .Invoke(null, null); 
        }
    }
}
