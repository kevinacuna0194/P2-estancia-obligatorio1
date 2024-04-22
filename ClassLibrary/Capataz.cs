using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Capataz : Empleado
    {
        private int _cantidadPersonasACargo;

        /** Constructor **/
        public Capataz(string email, string password, string nombre, DateTime fechaIngreso, int cantidadPersonasACargo) : base(email, password, nombre, fechaIngreso)
        {
            _cantidadPersonasACargo = cantidadPersonasACargo;
        }

        // Propiedades de lectura y escritura

        // Métodos
        public override bool Validar()
        {
            base.Validar();
            if (_cantidadPersonasACargo > 0) return true;

            return false;
        }

        public override string ToString()
        {
            string mensaje = base.ToString();
            mensaje += $"Cantidad de Personas a Cargo: ${_cantidadPersonasACargo}";

            return mensaje;
        }
    }
}
