using ClassLibrary.Interface;

namespace ClassLibrary
{
    public class Potrero : IValidar
    {
        private static int idContador = 1;
        private int _id;
        private string _descripcion;
        private decimal _hectareas;
        private int _capacidadMaxima;
        private List<Animal> _animales = new List<Animal>();

        public Potrero(string descripcion, decimal hectareas, int capacidadMaxima, List<Animal> animales)
        {
            _id = idContador++;
            _descripcion = descripcion;
            _hectareas = hectareas;
            _capacidadMaxima = capacidadMaxima;
            _animales = animales;
        }

        public void AsignarAnimalAPotrero(Animal animal, Potrero potrero)
        {
            // Verificar si el potrero tiene capacidad para más animales
            if (potrero._animales.Count >= potrero._capacidadMaxima)
            {
                throw new InvalidOperationException("El potrero está lleno.");
            }

            // Agregar el animal al potrero y asignarle el potrero
            potrero._animales.Add(animal);
            animal._potreroAsignado = potrero;
        }

        public bool Validar()
        {
            if (!String.IsNullOrEmpty(_descripcion) && _hectareas > 0 && _capacidadMaxima > 0 && _animales.Count > 0) return true;
            return false;
        }

        public override string ToString()
        {
            string mensaje = String.Empty;
            mensaje = $"ID Potrero: ${_id}, ";
            mensaje += $"Descripción: ${_descripcion}, ";
            mensaje += $"Hectareas: ${_hectareas}";
            mensaje += $"Capacidad Máxima: ${_capacidadMaxima}";
            
            if (_animales.Count > 0)
            {
                foreach(Animal animal in _animales)
                {
                    //mensaje += $"\n {animal.CodigoCaravana}, {animal.Sexo}, {animal.Raza}, {animal.FechaNacimiento}, {animal.CostoAdquisicion}, {animal.CostoAlimentacion}, {animal.pesoActual}, {animal.EsHibrido}";
                    mensaje += animal.ToString();
                }
            }
            else
            {
                mensaje += $"No hay registros de Animales en el Potrero";
            }

            return mensaje;
        }
    }
}
