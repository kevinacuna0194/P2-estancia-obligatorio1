using ClassLibrary.Enum;
using ClassLibrary.Interface;
using System.ComponentModel.Design;

namespace ClassLibrary
{
    // Clase base para todos los animales
    public abstract class Animal : IValidar
    {
        protected string _codigoCaravana;
        protected Sexo _sexo;
        protected string _raza;
        protected DateTime _fechaNacimiento;
        protected decimal _costoAdquisicion;
        protected decimal _costoAlimentacion;
        protected double _pesoActual;
        protected bool _esHibrido;
        protected List<Vacunacion> _vacunaciones = new List<Vacunacion>();
        internal Potrero _potreroAsignado { get; set; } // Potrero al que está asignado el animal

        // Constructor
        protected Animal(string codigoCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion, decimal costoAlimentacion, double pesoActual, bool esHibrido)
        {
            _codigoCaravana = codigoCaravana;
            _sexo = sexo;
            _raza = raza;
            _fechaNacimiento = fechaNacimiento;
            _costoAdquisicion = costoAdquisicion;
            _costoAlimentacion = costoAlimentacion;
            _pesoActual = pesoActual;
            _esHibrido = esHibrido;
        }

        /** Propiedades de lectura y escrituta **/

        /** Vacunar un Aniamal **/
        /* public void Vacunar(Vacuna vacuna, DateTime fecha)
        {
            if ((DateTime.Now - _fechaNacimiento).TotalDays < 90)
            {
                throw new InvalidOperationException("El animal no puede ser vacunado antes de los 3 meses de edad.");
            }

            _vacunaciones.Add();
        } */

        public virtual bool Validar()
        {
            if (!String.IsNullOrEmpty(_codigoCaravana) && _codigoCaravana.Length == 8 && !String.IsNullOrEmpty(_raza) && _fechaNacimiento < DateTime.Today && _costoAdquisicion > 0 && _costoAlimentacion > 0 && _pesoActual > 0) return true;
            return false;
        }

        public override string ToString()
        {
            string mensaje = String.Empty;
            mensaje = $"Código Caravana: {_codigoCaravana} ➟ ";
            mensaje += $"Sexo: {_sexo} ➟ ";
            mensaje += $"Raza: {_raza} ➟ ";
            mensaje += $"Fecha de Nacimiento: {_fechaNacimiento} ➟ ";
            mensaje += $"Costo de Adquisición: {_costoAdquisicion} ➟ ";
            mensaje += $"Costo de Alimentación: {_costoAlimentacion} ➟ ";
            mensaje += $"Peso Actual: {_pesoActual} ➟ ";
            mensaje += $"¿Es Híbrido?: {_esHibrido} ➟ ";

            if (_vacunaciones.Count > 0)
            {
                foreach (Vacunacion vacunacion in _vacunaciones)
                {
                    mensaje += $"\n -> {vacunacion.TipoVacuna} ➟ {vacunacion.Fecha} ➟ {vacunacion.Vencimiento}";
                }
            }
            else
            {
                mensaje += $"\n -> No Hay Registros de Vacunacion ➟ ";
            }

            return mensaje;
        }
    }
}
