using ClassLibrary.Enum;

namespace ClassLibrary
{
    // Clase para los bovinos, derivada de Animal
    public class Bovino : Animal
    {
        private TipoAlimentacion _tipoAlimentacion;
        private decimal _precioPorKiloBovinoEnPie;

        // Constructor
        public Bovino(string codigoCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion, decimal costoAlimentacion, double pesoActual, bool esHibrido, TipoAlimentacion tipoAlimentacion, decimal precioPorKiloBovinoEnPie) : base(codigoCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, esHibrido)
        {
            _tipoAlimentacion = tipoAlimentacion;
            _precioPorKiloBovinoEnPie = precioPorKiloBovinoEnPie;
        }

        // Propiedades de lectura y escritura

        // Métodos
        public override bool Validar()
        {
            base.Validar();
            if (_precioPorKiloBovinoEnPie > 0) return true;

            return false;
        }

        public override string ToString()
        {
            string mensaje = base.ToString();
            mensaje += $"Tipo de Alimentación: {_tipoAlimentacion} ➟ ";
            mensaje += $"Precio por Kilo de Bovino en Pie: {_precioPorKiloBovinoEnPie}";

            return mensaje;
        }
    }
}
