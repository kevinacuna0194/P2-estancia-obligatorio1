using System.Threading;

namespace ClassLibrary
{
    // Clase para el Peon, derivada de Animal
    public class Peon : Empleado
    {
        private bool _residenteEstancia;
        private List<Tarea> _tareasAsignadas = new List<Tarea>();

        // Constructor
        public Peon(string email, string password, string nombre, DateTime fechaIngreso, bool residenteEstancia) : base(email, password, nombre, fechaIngreso)
        {
            _residenteEstancia = residenteEstancia;
        }

        /** Get; Set; **/
        public List<Tarea> TareasAsignadas
        {
            get { return _tareasAsignadas; }
            set { _tareasAsignadas = value; }
        }

        /** Métodos Que Agregan o Modifican Información **/
        // Método para asignar tarea al peón
        public void AsignarTarea(Tarea tarea)
        {
            _tareasAsignadas.Add(tarea);
        }

        /** Métodos Globales **/
        public override bool Validar()
        {
            return base.Validar();
        }

        public override string ToString()
        {
            string mensaje = base.ToString();
            mensaje += $"¿Es Residente de la Estancia?: {_residenteEstancia}";

            if (_tareasAsignadas.Count > 0)
            {
                foreach (Tarea tarea in _tareasAsignadas)
                {
                    mensaje += tarea.ToString();
                }
            }

            return mensaje;
        }

        public override bool Equals(object? obj)
        {
            Peon peon = obj as Peon;
            return peon is not null && this._nombre.Equals(peon._nombre) && this._email.Equals(peon._email);
        }
    }
}
