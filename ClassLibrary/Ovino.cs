using ClassLibrary.Enum;

namespace ClassLibrary
{
    // Clase para los ovinos, derivada de Animal
    public class Ovino : Animal
    {
        private double _pesoLanaEstimado;
        private decimal _precioPorKiloLana;
        private decimal _precioPorKiloOvinoEnPie;

        // Constructor clase Derivada
        public Ovino(string codigoCaravana, Sexo sexo, string raza, DateTime fechaNacimiento, decimal costoAdquisicion, decimal costoAlimentacion, double pesoActual, bool esHibrido, double pesoLanaEstimado, decimal precioPorKiloLana, decimal precioPorKiloEnPie) : base(codigoCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, esHibrido)
        {
            _pesoLanaEstimado = pesoLanaEstimado;
            _precioPorKiloLana = precioPorKiloLana;
            _precioPorKiloOvinoEnPie = precioPorKiloEnPie;
        }

        /** Get; Set; **/
        public string CodigoCaravana
        {
            get { return _codigoCaravana; }
        }

        public decimal PrecioPorKiloLana
        {
            set { _precioPorKiloLana = value; }
        }

        /** Métodos Globales **/
        public override bool Validar()
        {
            base.Validar();
            if (_pesoLanaEstimado > 0 && _precioPorKiloLana > 0 && _precioPorKiloOvinoEnPie > 0) return true;

            return false;
        }

        public override string ToString()
        {
            string mensaje = base.ToString();
            mensaje += $"\n Peso Lana Estimado: ${_pesoLanaEstimado} ➟ ";
            mensaje += $"Precio por Kilo de Lana: ${_precioPorKiloLana} ➟ ";
            mensaje += $"Precio por Kilo de Ovino en Pie: ${_precioPorKiloOvinoEnPie}";

            return mensaje;
        }

        public override bool Equals(object? obj)
        {
            Ovino ovino = obj as Ovino;
            return ovino is not null && this._codigoCaravana.Equals(ovino._codigoCaravana);
        }
    }
}
