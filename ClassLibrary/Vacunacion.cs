using ClassLibrary.Interface;

namespace ClassLibrary
{
    public class Vacunacion : IValidar
    {
        private Vacuna _tipoVacuna;
        private DateTime _fecha;
        private DateTime _vencimiento;

        public Vacunacion(Vacuna tipoVacuna, DateTime fecha, DateTime vencimiento)
        {
            _tipoVacuna = tipoVacuna;
            _fecha = fecha;
            _vencimiento = vencimiento;
        }

        public Vacuna TipoVacuna
        {
            get { return _tipoVacuna; }
            set { _tipoVacuna = value;}
        }

        public bool Validar()
        {
            if (_tipoVacuna is not null) return true;
            return false;
        }

        public override string ToString()
        {
            string mensaje = String.Empty;
            mensaje = $"Tipo de Vacuna: ${_tipoVacuna}, ";
            mensaje += $"Fecha: ${_fecha}, ";
            mensaje += $"Vencimiento: ${_vencimiento}";

            return mensaje;
        }
    }
}
