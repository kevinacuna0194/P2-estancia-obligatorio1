using ClassLibrary.Interface;

namespace ClassLibrary
{
    public class Vacuna : IValidar
    {
        private string _nombre;
        private string _descripcion;
        private string _patogeno;

        // Constructor
        public Vacuna(string nombre, string descripcion, string patogeno)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _patogeno = patogeno;
        }

        // Métodos
        public bool Validar()
        {
            if (!String.IsNullOrEmpty(_nombre) && !String.IsNullOrEmpty(_descripcion) && !String.IsNullOrEmpty(_patogeno)) return true;
            return false;
        }

        public override string ToString()
        {
            string mensaje = String.Empty;
            mensaje = $"Nombre: ${_nombre}, ";
            mensaje += $"Descripción: ${_descripcion}, ";
            mensaje += $"patógeno: ${_patogeno}";

            return mensaje;
        }
    }
}
