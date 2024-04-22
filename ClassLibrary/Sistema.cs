using System.Security.Cryptography;

namespace ClassLibrary
{
    public class Sistema
    {
        private List<Capataz> _capataces = new List<Capataz>();
        private List<Peon> _peones = new List<Peon>();
        private List<Ovino> _ovinos = new List<Ovino>();
        private List<Bovino> _bovinos = new List<Bovino>();
        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get { if (_instancia == null) _instancia = new Sistema(); return _instancia; }
        }

        public static void Exito(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Error.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.Gray;
        }
    }
}
