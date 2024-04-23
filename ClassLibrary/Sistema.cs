using ClassLibrary.Enum;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography;
using System.Threading;

namespace ClassLibrary
{
    public class Sistema
    {
        /** Atributos **/
        private List<Peon> _peones = new List<Peon>();
        private List<Capataz> _capataces = new List<Capataz>();
        private List<Tarea> _tareas = new List<Tarea>();
        private List<Bovino> _bovinos = new List<Bovino>();
        private List<Ovino> _ovinos = new List<Ovino>();
        private List<Vacuna> _vacunas = new List<Vacuna>();
        private List<Potrero> _potreros = new List<Potrero>();

        /** Singleton **/
        private static Sistema _instancia;

        /** Constructor **/
        private Sistema()
        {
            PrecargarPeon();
            PrecargarCapataz();
            PrecargarTarea();
            PrecargarBovino();
        }

        /** Get; Set; **/
        public static Sistema Instancia
        {
            get { if (_instancia == null) _instancia = new Sistema(); return _instancia; }
        }

        /** Métodos para Buscar Información **/
        public Tarea ObtenerTareaPorId(int id)
        {
            Tarea tarea = null;

            int index = 0;
            while (index < _tareas.Count && tarea is null)
            {
                if (_tareas[index].Id == id) tarea = _tareas[index];

                index++;
            }

            return tarea;
        }

        /** Métodos para Listar Información **/
        public void ListarBovinos()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE BOVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_tareas.Count == 0) throw new ArgumentOutOfRangeException("Lista de Tareas Vacía. Sistema\\ListarBovinos()");

                foreach (Bovino bovino in _bovinos)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ {bovino.ToString()} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Console.ReadKey();
        }

        public void ListarTareas()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_tareas.Count == 0) throw new ArgumentOutOfRangeException("Lista de Tareas Vacía. Sistema\\ListarTareas()");

                foreach (Tarea tarea in _tareas)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ {tarea.ToString()} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Console.ReadKey();
        }

        public void ListarCapataces()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE CAPATACES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_capataces.Count == 0) throw new ArgumentOutOfRangeException("Lista de Peones Vacía. Sistema\\ListarPeones() \n");

                foreach (Capataz capataz in _capataces)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ {capataz.ToString()} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Console.ReadKey();
        }

        public void ListarPeones()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE PEONES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_peones.Count == 0) throw new ArgumentOutOfRangeException("Lista de Peones Vacía. Sistema\\ListarPeones() \n");

                foreach (Peon peon in _peones)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ {peon.ToString()} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Console.ReadKey();
        }

        /** Métodos para Agregan o Modificar Información **/
        public void AltaBovino(Bovino bovino)
        {
            if (bovino is null) throw new ArgumentNullException("Object Null AltaTarea() \n");
            bovino.Validar();
            if (_bovinos.Contains(bovino)) throw new ArgumentException("Tarea ya Existe en _tareas \n");
            _bovinos.Add(bovino);
        }

        public void PrecargarBovino()
        {
            AltaBovino(new Bovino("Caravana1", Sexo.Macho, "Angus", new DateTime(2019, 01, 15), 1500, 200, 300, false, TipoAlimentacion.Grano, 25));
            AltaBovino(new Bovino("Caravana2", Sexo.Hembra, "Hereford", new DateTime(2020, 03, 22), 1600, 220, 320, true, TipoAlimentacion.Pastura, 30));
            AltaBovino(new Bovino("Caravana3", Sexo.Macho, "Simmental", new DateTime(2021, 05, 10), 1700, 240, 340, false, TipoAlimentacion.Grano, 35));
            AltaBovino(new Bovino("Caravana4", Sexo.Hembra, "Angus", new DateTime(2022, 07, 03), 1800, 260, 360, true, TipoAlimentacion.Pastura, 40));
            AltaBovino(new Bovino("Caravana5", Sexo.Macho, "Hereford", new DateTime(2023, 09, 18), 1900, 280, 380, false, TipoAlimentacion.Grano, 45));
            AltaBovino(new Bovino("Caravana6", Sexo.Hembra, "Simmental", new DateTime(2024, 11, 25), 2000, 300, 400, true, TipoAlimentacion.Pastura, 50));
            AltaBovino(new Bovino("Caravana7", Sexo.Macho, "Angus", new DateTime(2025, 12, 10), 2100, 320, 420, false, TipoAlimentacion.Grano, 55));
            AltaBovino(new Bovino("Caravana8", Sexo.Hembra, "Hereford", new DateTime(2026, 10, 06), 2200, 340, 440, true, TipoAlimentacion.Pastura, 60));
            AltaBovino(new Bovino("Caravana9", Sexo.Macho, "Simmental", new DateTime(2027, 08, 30), 2300, 360, 460, false, TipoAlimentacion.Grano, 65));
            AltaBovino(new Bovino("Caravana10", Sexo.Hembra, "Angus", new DateTime(2028, 07, 20), 2400, 380, 480, true, TipoAlimentacion.Pastura, 70));
            AltaBovino(new Bovino("Caravana11", Sexo.Macho, "Hereford", new DateTime(2018, 02, 14), 1500, 200, 300, false, TipoAlimentacion.Grano, 75));
            AltaBovino(new Bovino("Caravana12", Sexo.Hembra, "Simmental", new DateTime(2017, 04, 03), 1600, 220, 320, true, TipoAlimentacion.Pastura, 80));
            AltaBovino(new Bovino("Caravana13", Sexo.Macho, "Angus", new DateTime(2016, 06, 27), 1700, 240, 340, false, TipoAlimentacion.Grano, 85));
            AltaBovino(new Bovino("Caravana14", Sexo.Hembra, "Hereford", new DateTime(2015, 08, 12), 1800, 260, 360, true, TipoAlimentacion.Pastura, 90));
            AltaBovino(new Bovino("Caravana15", Sexo.Macho, "Simmental", new DateTime(2014, 10, 05), 1900, 280, 380, false, TipoAlimentacion.Grano, 95));
            AltaBovino(new Bovino("Caravana16", Sexo.Hembra, "Angus", new DateTime(2013, 12, 20), 2000, 300, 400, true, TipoAlimentacion.Pastura, 100));
            AltaBovino(new Bovino("Caravana17", Sexo.Macho, "Hereford", new DateTime(2012, 07, 18), 2100, 320, 420, false, TipoAlimentacion.Grano, 105));
            AltaBovino(new Bovino("Caravana18", Sexo.Hembra, "Simmental", new DateTime(2011, 05, 30), 2200, 340, 440, true, TipoAlimentacion.Pastura, 110));
            AltaBovino(new Bovino("Caravana19", Sexo.Macho, "Angus", new DateTime(2010, 03, 25), 2300, 360, 460, false, TipoAlimentacion.Grano, 115));
            AltaBovino(new Bovino("Caravana20", Sexo.Hembra, "Hereford", new DateTime(2009, 01, 15), 2400, 380, 480, true, TipoAlimentacion.Pastura, 120));
            AltaBovino(new Bovino("Caravana21", Sexo.Macho, "Angus", new DateTime(2023, 01, 15), 1500, 200, 300, false, TipoAlimentacion.Grano, 125));
            AltaBovino(new Bovino("Caravana22", Sexo.Hembra, "Hereford", new DateTime(2020, 03, 22), 1600, 220, 320, true, TipoAlimentacion.Pastura, 130));
            AltaBovino(new Bovino("Caravana23", Sexo.Macho, "Simmental", new DateTime(2021, 05, 10), 1700, 240, 340, false, TipoAlimentacion.Grano, 135));
            AltaBovino(new Bovino("Caravana24", Sexo.Hembra, "Angus", new DateTime(2022, 07, 03), 1800, 260, 360, true, TipoAlimentacion.Pastura, 140));
            AltaBovino(new Bovino("Caravana25", Sexo.Macho, "Hereford", new DateTime(2023, 09, 18), 1900, 280, 380, false, TipoAlimentacion.Grano, 145));
            AltaBovino(new Bovino("Caravana26", Sexo.Hembra, "Simmental", new DateTime(2024, 11, 25), 2000, 300, 400, true, TipoAlimentacion.Pastura, 150));
            AltaBovino(new Bovino("Caravana27", Sexo.Macho, "Angus", new DateTime(2025, 12, 10), 2100, 320, 420, false, TipoAlimentacion.Grano, 155));
            AltaBovino(new Bovino("Caravana28", Sexo.Hembra, "Hereford", new DateTime(2026, 10, 06), 2200, 340, 440, true, TipoAlimentacion.Pastura, 160));
            AltaBovino(new Bovino("Caravana29", Sexo.Macho, "Simmental", new DateTime(2027, 08, 30), 2300, 360, 460, false, TipoAlimentacion.Grano, 165));
            AltaBovino(new Bovino("Caravana30", Sexo.Hembra, "Angus", new DateTime(2028, 07, 20), 2400, 380, 480, true, TipoAlimentacion.Pastura, 170));
        }

        public void AltaTarea(Tarea tarea)
        {
            if (tarea is null) throw new ArgumentNullException("Object Null AltaTarea() \n");
            tarea.Validar();
            if (_tareas.Contains(tarea)) throw new ArgumentException("Tarea ya Existe en _tareas \n");
            _tareas.Add(tarea);
        }

        public void PrecargarTarea()
        {
            AltaTarea(new Tarea("Preparar terreno para siembra", DateTime.Today.AddDays(1), false, DateTime.Today.AddDays(2), "Se necesita arar y fertilizar el terreno"));
            AltaTarea(new Tarea("Sembrar cultivo de maíz", DateTime.Today.AddDays(3), false, DateTime.Today.AddDays(4), "Sembrar el maíz en las parcelas asignadas"));
            AltaTarea(new Tarea("Regar cultivos", DateTime.Today.AddDays(5), false, DateTime.Today.AddDays(6), "Asegurarse de mantener una hidratación adecuada"));
            AltaTarea(new Tarea("Fertilizar cultivos", DateTime.Today.AddDays(7), false, DateTime.Today.AddDays(8), "Aplicar fertilizantes según las necesidades del suelo"));
            AltaTarea(new Tarea("Control de plagas", DateTime.Today.AddDays(9), false, DateTime.Today.AddDays(10), "Monitorear y aplicar tratamientos contra plagas"));
            AltaTarea(new Tarea("Podar árboles frutales", DateTime.Today.AddDays(11), false, DateTime.Today.AddDays(12), "Realizar poda de forma adecuada para promover el crecimiento"));
            AltaTarea(new Tarea("Cosechar cultivos", DateTime.Today.AddDays(13), false, DateTime.Today.AddDays(14), "Recolectar los cultivos en el momento óptimo"));
            AltaTarea(new Tarea("Inspección de cercas", DateTime.Today.AddDays(15), false, DateTime.Today.AddDays(16), "Revisar la integridad de las cercas del campo"));
            AltaTarea(new Tarea("Reparación de maquinaria agrícola", DateTime.Today.AddDays(17), false, DateTime.Today.AddDays(18), "Realizar mantenimiento y reparaciones según sea necesario"));
            AltaTarea(new Tarea("Control de malezas", DateTime.Today.AddDays(19), false, DateTime.Today.AddDays(20), "Eliminar malezas que puedan competir con los cultivos"));
            AltaTarea(new Tarea("Fertilizar terrenos vacíos", DateTime.Today.AddDays(21), false, DateTime.Today.AddDays(22), "Aplicar fertilizantes en áreas sin cultivos"));
            AltaTarea(new Tarea("Revisión de sistemas de riego", DateTime.Today.AddDays(23), false, DateTime.Today.AddDays(24), "Asegurarse de que los sistemas de riego estén funcionando correctamente"));
            AltaTarea(new Tarea("Control de humedad en suelo", DateTime.Today.AddDays(25), false, DateTime.Today.AddDays(26), "Monitorear niveles de humedad y ajustar riego según sea necesario"));
            AltaTarea(new Tarea("Cercar área de pastoreo", DateTime.Today.AddDays(27), false, DateTime.Today.AddDays(28), "Instalar cercas temporales para el pastoreo del ganado"));
            AltaTarea(new Tarea("Preparar suelos para próximas siembras", DateTime.Today.AddDays(29), false, DateTime.Today.AddDays(30), "Arar y acondicionar suelos para futuras siembras"));
        }

        public void AltaCapataz(Capataz capataz)
        {
            if (capataz is null) throw new ArgumentNullException("Object Null AltaCapataz(Capataz capataz) \n");
            capataz.Validar();
            if (_capataces.Contains(capataz)) throw new ArgumentException("Capataz ya Existe en Sistema\\List<Capataz> _capataces \n");
            _capataces.Add(capataz);
        }

        public void PrecargarCapataz()
        {
            AltaCapataz(new Capataz("capataz1@email.com", "password1", "Juan", new DateTime(2022, 1, 1), 10));
            AltaCapataz(new Capataz("capataz2@email.com", "password2", "María", new DateTime(2022, 1, 2), 8));
        }

        public void AltaPeon(Peon peon)
        {
            if (peon is null) throw new ArgumentNullException("Object Null AltaPeon(Peon peon) \n");
            peon.Validar();
            if (_peones.Contains(peon)) throw new ArgumentException("Peón ya Existe en Sistema\\List<Peon> _peones \n");
            _peones.Add(peon);
        }

        public void PrecargarPeon()
        {
            AltaPeon(new Peon("peon1@email.com", "password1", "Juan", new DateTime(2022, 1, 1), true));
            AltaPeon(new Peon("peon2@email.com", "password2", "María", new DateTime(2022, 1, 2), false));
            AltaPeon(new Peon("peon3@email.com", "password3", "Carlos", new DateTime(2022, 1, 3), true));
            AltaPeon(new Peon("peon4@email.com", "password4", "Ana", new DateTime(2022, 1, 4), false));
            AltaPeon(new Peon("peon5@email.com", "password5", "Pedro", new DateTime(2022, 1, 5), true));
            AltaPeon(new Peon("peon6@email.com", "password6", "Luis", new DateTime(2022, 1, 6), false));
            AltaPeon(new Peon("peon7@email.com", "password7", "Sofía", new DateTime(2022, 1, 7), true));
            AltaPeon(new Peon("peon8@email.com", "password8", "Elena", new DateTime(2022, 1, 8), false));
            AltaPeon(new Peon("peon9@email.com", "password9", "Diego", new DateTime(2022, 1, 9), true));
            AltaPeon(new Peon("peon10@email.com", "password10", "Laura", new DateTime(2022, 1, 10), false));
        }

        /** Métdos Globales **/
        public void Menu()
        {
            Console.WriteLine("╰┈➤ 1 ▶ Listado de todos los animales mostrando: i.Id de caravana ii.Raza iii.Peso actual iv.Sexo \n");
            Console.WriteLine("╰┈➤ 2 ▶ Digitar cantidad de hectáreas y un número. Listado de Potreros con área mayor a cantidad de hectáreas proporcionada y Capacidad máxima superior al número dado. \n");
            Console.WriteLine("╰┈➤ 3 ▶ Establecer el precio por kilogramo de lana de los Ovinos \n");
            Console.WriteLine("╰┈➤ 4 ▶ Alta de ganado Bovino. \n");
            Console.WriteLine("╰┈➤ 0 ▶ Salir \n");
        }

        public void Bienvenida()
        {
            Resaltar("🐄 🐑 ▁ ▂ ▄ ▅ ▆ ▇ █ ESTANCIA █ ▇ ▆ ▅ ▄ ▂ ▁ 🐑 🐄", ConsoleColor.DarkMagenta);
            Resaltar("░▒▓█ Compra y Engorde de Bovinos y Ovinos █▓▒░", ConsoleColor.DarkMagenta);
            Console.WriteLine();
            Resaltar("◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠ MENÚ ◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠", ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        public static void Resaltar(string mensaje, ConsoleColor color1)
        {
            Console.ForegroundColor = color1;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ConsoleColor.Gray;
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
