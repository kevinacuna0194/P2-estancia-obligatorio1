using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Tarea : IValidar
    {
        private static int idContador = 1;
        private int _id;
        private string _descripcion;
        private DateTime _fechaPactada;
        private bool _completada;
        private DateTime _fechaCierre;
        private string _comentario;

        public Tarea(string descripcion, DateTime fechaPactada, bool completada, DateTime fechaCierre, string comentario)
        {
            _id = idContador++;
            _descripcion = descripcion;
            _fechaPactada = fechaPactada;
            _completada = completada;
            _fechaCierre = fechaCierre;
            _comentario = comentario;
        }

        public bool Validar()
        {
            if (!String.IsNullOrEmpty(_descripcion) && _fechaPactada < DateTime.Today && _fechaCierre < DateTime.Today && !String.IsNullOrEmpty(_comentario)) return true;

            return false;
        }
    }
}
