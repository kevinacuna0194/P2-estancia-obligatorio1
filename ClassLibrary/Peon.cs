namespace ClassLibrary
{
    // Clase para el Peon, derivada de Animal
    public class Peon : Empleado
    {
        private bool _residenteEstancia;
        private List<Tarea> _tareasAsignadas = new List<Tarea>();

        // Constructor
        public Peon(string email, string password, string nombre, DateTime fechaIngreso, bool residenteEstancia, List<Tarea> tareasAsignadas) : base(email, password, nombre, fechaIngreso)
        {
            _residenteEstancia = residenteEstancia;
            _tareasAsignadas = tareasAsignadas;
        }

        // Propiedades de lectura y escritura

        // Métodos
        public override bool Validar()
        {
            return base.Validar();
        }

        public override string ToString()
        {
            string mensaje = base.ToString();
            mensaje += $"¿Es Residente de la Estancia?: ${_residenteEstancia}, ";
            mensaje += $"tareas Asignadas: ${_tareasAsignadas}";

            return mensaje;
        }
    }
}
