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

        // Constructor Clase Base
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

        /** Get; Set; **/
        public string CodigoCaravana
        {
            get { return _codigoCaravana; }
        }

        /** Vacunar un Aniamal **/
        public void Vacunar(Vacuna vacuna, DateTime fecha, DateTime vencimiento)
        {
            // Crear una nueva instancia de Vacunación
            Vacunacion nuevaVacunacion = new Vacunacion(vacuna, fecha, vencimiento);

            // Agregar la nueva vacunación a la lista de vacunaciones del animal
            _vacunaciones.Add(nuevaVacunacion);
        }

        /** Métodos Globales **/
        public virtual bool Validar()
        {
            if (!String.IsNullOrEmpty(_codigoCaravana) && _codigoCaravana.Length == 8 && !String.IsNullOrEmpty(_raza) && _fechaNacimiento < DateTime.Today && _costoAdquisicion > 0 && _costoAlimentacion > 0 && _pesoActual > 0) return true;
            return false;
        }

        public override string ToString()
        {
            string mensaje;
            mensaje = $"Código Caravana: {_codigoCaravana} ➟ ";
            mensaje += $"Sexo: {_sexo} ➟ ";
            mensaje += $"Raza: {_raza} ➟ ";
            mensaje += $"Fecha de Nacimiento: {_fechaNacimiento} ➟ ";
            mensaje += $"Costo de Adquisición: {_costoAdquisicion} ➟ ";
            mensaje += $"Costo de Alimentación: {_costoAlimentacion} ➟ ";
            mensaje += $"Peso Actual: {_pesoActual} ➟ ";
            mensaje += $"¿Es Híbrido?: {_esHibrido} \n";

            if (_vacunaciones.Count > 0)
            {
                foreach (Vacunacion vacunacion in _vacunaciones)
                {
                    mensaje += $"\n ➽ {vacunacion.ToString()} \n";
                }
            }
            else
            {
                mensaje += $"\n ➽ No Hay Registros de Vacunación \n";
            }

            return mensaje;
        }
    }
}
