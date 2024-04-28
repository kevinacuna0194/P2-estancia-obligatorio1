using ClassLibrary;
using ClassLibrary.Enum;
using System.Linq.Expressions;

namespace ConsoleApp
{
    public class Program
    {
        private static Sistema? sistema;

        static void Main(string[] args)
        {
            sistema = Sistema.Instancia;

            string? input;
            bool codigo = true;

            while (codigo)
            {
                Console.Clear();

                Bienvenida();
                Menu();
                input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    /** Listado de todos los animales **/
                    case "1":
                        Console.Clear();

                        ListarAnimales();
                        break;
                    /** mostrar todos los potreros con área mayor a dicha cantidad de hectáreas y una capacidad máxima superior al número dado **/
                    case "2":
                        Console.Clear();

                        int hectareas = InputNumber("Ingresar Cantidad de Hectareas");
                        int numero = InputNumber("Ingresar Capacidad Máxima");
                        sistema.ListarPotrerosHectareasCapacidadMaxima(hectareas, numero);
                        break;
                    /** Establecer el precio por kilogramo de lana de los ovinos **/
                    case "3":
                        Console.Clear();

                        int PrecioPorKiloLana = InputNumber("Ingrese Precio por kilogramo de Lana de los Ovinos:");
                        sistema.PrecioPorKiloLana(PrecioPorKiloLana);
                        break;
                    /** Alta de ganado bovino. **/
                    case "4":
                        Console.Clear();

                        Sistema.Resaltar("▀▄▀▄▀▄ ALTA DE GANADO BOVINO ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                        string codigoCaravana = InputText("Ingrese Código de Caravana: ").Trim();

                        Bovino bovino = sistema.ObtenerBovinoPorCodigoCaravana(codigoCaravana);

                        if (bovino is null)
                        {
                            Sexo sexo = InputSexo();

                            string raza = InputText("Ingrese Raza: ");

                            DateTime fechaNacimiento = InputDateTime("Ingrese Fecha de nacimiento: ");

                            int costoAdquisicion = InputNumber("Ingrese Costo Adquisición: ");

                            int costoAlimentacion = InputNumber("Ingrese Costo Alimentación: ");

                            int pesoActual = InputNumber("Ingrese Peso Actual: ");

                            bool esHibrido = InputBool("¿Es Híbrido? ");

                            TipoAlimentacion tipoAlimentacion = InputTipoAlimentacion();

                            int precioPorKiloBovinoEnPie = InputNumber("Ingrese Precio Por Kilo en Pie: ");

                            sistema.AltaBovino(codigoCaravana, sexo, raza, fechaNacimiento, costoAdquisicion, costoAlimentacion, pesoActual, esHibrido, tipoAlimentacion, precioPorKiloBovinoEnPie);

                            Sistema.Exito("Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }
                        else
                        {
                            Sistema.Error("Existe un Bovino con Código de Caravana Ingresado. Presione una Tecla Para Continuar. \n");
                            Console.ReadKey();
                        }

                        break;
                    case "5":
                        Console.Clear();
                        ListarBovinos();
                        break;
                    case "6":
                        Console.Clear();
                        ListarOvinos();
                        break;
                    case "0":
                        Sistema.Exito("Cerrando Aplicación de Consola ■■■■■□□□");
                        codigo = false;
                        break;
                    default:
                        Sistema.Error("❰❰❰❰ Seleccione Una Opción Correcta. Presione una Tecla Para Continuar. ❱❱❱❱ \n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Get; Set;
        /** Get; Set; **/
        #endregion Get; Set;

        #region Métodos que Listan Información
        /** Métodos para Listar Información **/
        static void ListarPotreros()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE POTREROS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Potrero potrero in sistema.Potreros)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {potrero} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Potreros Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarVacunas()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE VACUNAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Vacuna vacuna in sistema.Vacunas)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {vacuna} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Vacunas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarAnimales()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE ANIMALES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarAnimales() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Ovino)
                    {
                        Ovino ovino = (Ovino)animal;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {ovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                    else if (animal is Bovino)
                    {
                        Bovino bovino = (Bovino)animal;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {bovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Animales Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarOvinos()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE OVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarOvinos() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Ovino)
                    {
                        Ovino ovino = (Ovino)animal;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {ovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Ovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarBovinos()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE BOVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarBovinos() \n");

                int contador = 1;

                foreach (Animal animal in sistema.Animales)
                {
                    if (animal is Bovino)
                    {
                        Bovino bovino = (Bovino)animal;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {bovino} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Bovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarTareas()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Tareas.Count == 0) throw new ArgumentOutOfRangeException("Lista de Tareas Vacía. Sistema\\ListarTareas() \n");

                int contador = 1;

                foreach (Tarea tarea in sistema.Tareas)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {tarea} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Tareas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarCapataces()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE CAPATACES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarCapataces() \n");

                int contador = 1;

                foreach (Empleado empleado in sistema.Empleados)
                {
                    if (empleado is Capataz)
                    {
                        Capataz capataz = (Capataz)empleado;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {capataz} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("Capataces Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        static void ListarPeones()
        {
            try
            {
                Sistema.Resaltar("▀▄▀▄▀▄ LISTADO DE PEONES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (sistema.Empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarPeones() \n");

                int contador = 1;

                foreach (Empleado empleado in sistema.Empleados)
                {
                    if (empleado is Peon)
                    {
                        Peon peon = (Peon)empleado;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {peon} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex)
            {
                Sistema.Error($"{ex.Message} \n");
            }

            Sistema.Exito("peones Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }
        #endregion Métodos que Listan Información

        #region Métodos Globales
        /** Métodos Globales **/
        static void SaltoDeLinea()
        {
            Console.WriteLine();
            return;
        }

        static bool InputBool(string mensaje)
        {
            bool exito = false;
            bool input = false;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} (S/N) \n", ConsoleColor.DarkBlue);
                    string inputString = Console.ReadLine().ToUpper();

                    if (inputString.Length != 1) throw new ArgumentOutOfRangeException("Cantidad de Dígitos Superior a la Esperada. Ingrese S o N. Program\\(string mensaje)");

                    switch (inputString)
                    {
                        case "S":
                            input = true;
                            exito = true;
                            break;
                        case "N":
                            input = false;
                            exito = true;
                            break;
                        default:
                            throw new ArgumentException("Opción Inválida. Program\\(string mensaje) \n");
                    }
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return input;
        }

        static DateTime InputDateTime(string mensaje)
        {
            bool exito = false;
            DateTime dateTime = DateTime.Now;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} (Day/Month/Year): \n", ConsoleColor.DarkBlue);

                    exito = DateTime.TryParse(Console.ReadLine(), out dateTime);

                    if (!exito) throw new ArgumentException("Formato de Fecha Incorrecto. Program\\InputDateTime(string mensaje)");
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return dateTime;
        }

        static TipoAlimentacion InputTipoAlimentacion()
        {
            bool exito = false;
            TipoAlimentacion tipoAlimentacion = new TipoAlimentacion();

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar("Seleccione Tipo de Alimentación: \n", ConsoleColor.DarkBlue);

                    foreach (int numero in Enum.GetValues(typeof(TipoAlimentacion)))
                    {
                        Sistema.Resaltar($"{numero} ➟ {(TipoAlimentacion)numero} \n", ConsoleColor.DarkBlue);
                    }

                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("String Vacío. Program\\InputTipoAlimentacion()");

                    bool isNumber = int.TryParse(inputString, out int number);

                    if (isNumber && Enum.IsDefined(typeof(TipoAlimentacion), number))
                    {
                        tipoAlimentacion = (TipoAlimentacion)number;
                        exito = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Opción Inválida. Program\\InputTipoAlimentacion()");
                    }
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return tipoAlimentacion;
        }

        static Sexo InputSexo()
        {
            bool exito = false;
            Sexo sexo = new Sexo();

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar("Seleccione Sexo del Animal: \n", ConsoleColor.DarkBlue);

                    foreach (int numero in Enum.GetValues(typeof(Sexo)))
                    {
                        Sistema.Resaltar($"{numero} ➟ {(Sexo)numero} \n", ConsoleColor.DarkBlue);
                    }

                    string inputString = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputString)) throw new ArgumentException("String Vacío. Program\\InputSexo()");

                    bool isNumber = int.TryParse(inputString, out int number);

                    if (isNumber && Enum.IsDefined(typeof(Sexo), number))
                    {
                        sexo = (Sexo)number;
                        exito = true;
                    }
                    else
                    {
                        SaltoDeLinea();
                        throw new ArgumentOutOfRangeException("Opción Inválida. Program\\InputSexo(string mensaje)");
                    }
                }
                catch (Exception ex)
                {
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return sexo;
        }

        static int InputNumber(string mensaje)
        {
            bool exito = false;
            int inputNumero = 0;
            bool isNumber = false;

            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} \n", ConsoleColor.DarkBlue);

                    isNumber = int.TryParse(Console.ReadLine(), out inputNumero);

                    if (!isNumber || inputNumero <= 0) throw new ArgumentOutOfRangeException("Número Incorrecto. Program\\InputText(string mensaje)");

                    exito = true;
                }
                catch (Exception ex)
                {
                    SaltoDeLinea();
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return inputNumero;
        }

        static string InputText(string mensaje)
        {
            bool exito = false;
            string? inputText = string.Empty;


            while (!exito)
            {
                try
                {
                    Sistema.Resaltar($"{mensaje} \n", ConsoleColor.DarkBlue);

                    inputText = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputText)) throw new ArgumentException("InputText Vacío. InputString(string mensaje)");

                    exito = true;
                }
                catch (Exception ex)
                {
                    Sistema.Error($"{ex.Message} \n");
                }
            }

            SaltoDeLinea();
            return inputText;
        }

        static void Menu()
        {
            Console.WriteLine("╰┈➤ 1 ▶ Listado de Todos los Animales \n".ToUpper());
            Console.WriteLine("╰┈➤ 2 ▶ Digitar cantidad de Hectáreas y un Número. Listado de Potreros con Área Mayor a Cantidad de Hectáreas Proporcionada y Capacidad Máxima Superior al Número Dado. \n".ToUpper());
            Console.WriteLine("╰┈➤ 3 ▶ Establecer el Precio por Kilogramo de Lana de los Ovinos \n".ToUpper());
            Console.WriteLine("╰┈➤ 4 ▶ Alta de Ganado Bovino. \n".ToUpper());
            Console.WriteLine("╰┈➤ 5 ▶ Listar Ganado Bovino. \n".ToUpper());
            Console.WriteLine("╰┈➤ 6 ▶ Listar Ganado Ovino. \n".ToUpper());
            Console.WriteLine("╰┈➤ 0 ▶ Salir \n".ToUpper());
        }

        static void Bienvenida()
        {
            Sistema.Resaltar("🐄 🐑 ▁ ▂ ▄ ▅ ▆ ▇ █ ESTANCIA █ ▇ ▆ ▅ ▄ ▂ ▁ 🐑 🐄", ConsoleColor.DarkMagenta);
            Sistema.Resaltar("░▒▓█ Compra y Engorde de Bovinos y Ovinos █▓▒░".ToUpper(), ConsoleColor.DarkMagenta);
            Console.WriteLine();
            Sistema.Resaltar("◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠ MENÚ ◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠◡◠", ConsoleColor.DarkCyan);
            Console.WriteLine();
        }
        #endregion Métodos Globales
    }
}
