using ClassLibrary.Enum;
using Microsoft.Win32.SafeHandles;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace ClassLibrary
{
    public class Sistema
    {
        /** Atributos **/
        private List<Empleado> _empleados = new List<Empleado>();
        private List<Animal> _animales = new List<Animal>();
        private List<Tarea> _tareas = new List<Tarea>();
        private List<Vacuna> _vacunas = new List<Vacuna>();
        private List<Potrero> _potreros = new List<Potrero>();

        /** Singleton **/
        private static Sistema? _instancia;

        /** Constructor **/
        private Sistema()
        {
            PrecargarEmpleado();
            PrecargarAnimal();
            PrecargarTarea();
            PrecargarVacuna();
            PrecargarPotrero();
            VacunarBovino();
            VacunarOvino();
        }

        #region Get; Set;
        /** Get; Set; **/
        public static Sistema Instancia
        {
            get { if (_instancia == null) _instancia = new Sistema(); return _instancia; }
        }
        #endregion Get; Set;

        #region Métodos para Buscar Información
        /** Métodos para Buscar Información **/
        public void ListarPotrerosHectareasCapacidadMaxima(double hectareas, int numero)
        {
            if (hectareas <= 0 || numero <= 0) throw new ArgumentOutOfRangeException("Parámetros incorrectos. ListarPotrerosHectareasCapacidadMaxima(double hectareas, int numero) \n");

            int contador = 1;
            List<Potrero> potreros = new List<Potrero>();

            foreach (Potrero potrero in _potreros)
            {
                if (potrero.Hectareas > hectareas && potrero.CapacidadMaxima > numero)
                {
                    potreros.Add(potrero);
                }
            }

            if(potreros.Count == 0)
            {
                Error("No Se Encontraron Registros. \n");
                return;
            }

            foreach(Potrero potrero in potreros)
            {
                Console.WriteLine($"({contador++}) {potrero} \n");
            }

            Exito("Potreros Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public Vacuna ObtenerVacunaPorNombre(string nombre)
        {
            if (nombre is null) throw new ArgumentNullException("String Vacío. ObtenerVacunaPorNombre(string nombre)");
            Vacuna vacuna = null;

            int index = 0;
            while (index < _vacunas.Count && vacuna is null)
            {
                if (_vacunas[index].Nombre == nombre) vacuna = _vacunas[index];

                index++;
            }

            return vacuna;
        }

        public Ovino ObtenerOvinoPorCodigoCaravana(string codigoCaravana)
        {
            if (string.IsNullOrEmpty(codigoCaravana)) throw new ArgumentNullException("String Vacío. ObtenerOvinoPorCodigoCaravana(string codigoCaravana)");

            Ovino ovino = null;

            for (int index = 0; index < _animales.Count; index++)
            {
                Animal animal = _animales[index];

                if (animal.CodigoCaravana == codigoCaravana && animal is Ovino)
                {
                    ovino = (Ovino)animal;
                }
            }

            return ovino;
        }

        public Bovino ObtenerBovinoPorCodigoCaravana(string codigoCaravana)
        {
            if (string.IsNullOrEmpty(codigoCaravana)) throw new ArgumentNullException("String Vacío. ObtenerBovinoPorCodigoCaravana(string codigoCaravana)");

            Bovino bovino = null;

            for (int index = 0; index < _animales.Count; index++)
            {
                Animal animal = _animales[index];

                if (animal.CodigoCaravana == codigoCaravana && animal is Bovino)
                {
                    bovino = (Bovino)animal;
                }
            }

            return bovino;
        }

        public Tarea ObtenerTareaPorId(int id)
        {
            if (id <= 0) throw new ArgumentException("ID 0. ObtenerTareaPorId(int id)");

            Tarea tarea = null;

            int index = 0;
            while (index < _tareas.Count && tarea is null)
            {
                if (_tareas[index].Id == id) tarea = _tareas[index];

                index++;
            }

            return tarea;
        }
        #endregion Métodos para Buscar Información

        #region Métodos para Listar Información
        /** Métodos para Listar Información **/
        public void ListarPotreros()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE POTREROS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Potrero potrero in _potreros)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {potrero} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error(ex.Message);
            }

            Exito("Potreros Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarVacunas()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE VACUNAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Vacuna vacuna in _vacunas)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {vacuna} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex)
            {
                Sistema.Error(ex.Message);
            }

            Exito("Vacunas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarAnimales()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE ANIMALES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                int contador = 1;

                foreach (Animal animal in _animales)
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
                Sistema.Error(ex.Message);
            }

            Exito("Animales Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarOvinos()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE OVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarOvinos() \n");

                int contador = 1;

                foreach (Animal animal in _animales)
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
                Sistema.Error(ex.Message);
            }

            Exito("Ovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarBovinos()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE BOVINOS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_animales.Count == 0) throw new ArgumentOutOfRangeException("Lista de Animales Vacía. Sistema\\ListarBovinos() \n");

                int contador = 1;

                foreach (Animal animal in _animales)
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
                Sistema.Error(ex.Message);
            }

            Exito("Bovinos Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarTareas()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE TAREAS ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_tareas.Count == 0) throw new ArgumentOutOfRangeException("Lista de Tareas Vacía. Sistema\\ListarTareas() \n");

                int contador = 1;

                foreach (Tarea tarea in _tareas)
                {
                    Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {tarea} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Exito("Tareas Listadas con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarCapataces()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE CAPATACES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarCapataces() \n");

                int contador = 1;

                foreach (Empleado empleado in _empleados)
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
                Sistema.Error(ex.Message);
            }

            Exito("Capataces Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void ListarPeones()
        {
            try
            {
                Resaltar("▀▄▀▄▀▄ LISTADO DE PEONES ▄▀▄▀▄▀ \n", ConsoleColor.DarkYellow);

                if (_empleados.Count == 0) throw new ArgumentOutOfRangeException("Lista de Empleados Vacía. Sistema\\ListarPeones() \n");

                int contador = 1;

                foreach (Empleado empleado in _empleados)
                {
                    if (empleado is Peon)
                    {
                        Peon peon = (Peon)empleado;
                        Console.WriteLine($"◢◤◢◤◢◤◢◤◢◤◢ ({contador++}) {peon} ◢◤◢◤◢◤◢◤◢◤◢ \n");
                    }
                }
            }
            catch (Exception ex) { Sistema.Error(ex.Message); }

            Exito("peones Listados con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }
        #endregion Métodos para Listar Información

        #region Métodos para Agregar o Modificar Información 
        /** Métodos para Agregan o Modificar Información **/
        public void PrecioPorKiloLana(int precioPorKiloLana)
        {
            if (precioPorKiloLana == 0) throw new ArgumentException("precioPorKiloLana = 0. Sistema\\PrecioPorKilogramoLana(int precioPorKiloLana) \n");

            foreach (Animal animal in _animales)
            {
                if (animal is Ovino)
                {
                    Ovino ovino = (Ovino)animal;
                    ovino.PrecioPorKiloLana = precioPorKiloLana;
                }
            }

            Sistema.Exito("Precio por Kilogramo de Lana de los Ovinos Modificado con Éxito. Presione una Tecla Para Continuar. \n");
            Console.ReadKey();
        }

        public void VacunarOvino()
        {
            Ovino ovino1 = ObtenerOvinoPorCodigoCaravana("Caravana1");
            Ovino ovino2 = ObtenerOvinoPorCodigoCaravana("Caravana5");
            Ovino ovino3 = ObtenerOvinoPorCodigoCaravana("Caravana10");
            Ovino ovino4 = ObtenerOvinoPorCodigoCaravana("Caravana15");
            Ovino ovino5 = ObtenerOvinoPorCodigoCaravana("Caravana20");

            if (ovino1 is null || ovino2 is null || ovino3 is null || ovino4 is null || ovino5 is null) throw new ArgumentNullException("Object Null Sistema\\VacunarOvino() \n");

            Vacuna vacuna1 = ObtenerVacunaPorNombre("Vacuna Antitetánica");
            Vacuna vacuna2 = ObtenerVacunaPorNombre("Vacuna Anticlostridial");
            Vacuna vacuna3 = ObtenerVacunaPorNombre("Vacuna Anticarbuncloso");
            Vacuna vacuna4 = ObtenerVacunaPorNombre("Vacuna Antileptospira");
            Vacuna vacuna5 = ObtenerVacunaPorNombre("Vacuna Antibrucelosis");
            Vacuna vacuna6 = ObtenerVacunaPorNombre("Vacuna Antipasteurelosis");
            Vacuna vacuna7 = ObtenerVacunaPorNombre("Vacuna Antirabia");
            Vacuna vacuna8 = ObtenerVacunaPorNombre("Vacuna Antiviral");
            Vacuna vacuna9 = ObtenerVacunaPorNombre("Vacuna Antiparasitaria");
            Vacuna vacuna10 = ObtenerVacunaPorNombre("Vacuna Anticoccidial");

            if (vacuna1 is null || vacuna2 is null || vacuna3 is null || vacuna4 is null || vacuna5 is null || vacuna6 is null || vacuna7 is null || vacuna8 is null || vacuna9 is null || vacuna10 is null) throw new ArgumentNullException("Object Null Sistema\\VacunarOvino() \n");

            ovino1.Vacunar(vacuna1, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino1.Vacunar(vacuna2, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino1.Vacunar(vacuna3, DateTime.Now, DateTime.Now.AddMonths(6));

            ovino2.Vacunar(vacuna3, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino2.Vacunar(vacuna4, DateTime.Now, DateTime.Now.AddMonths(6));

            ovino3.Vacunar(vacuna5, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino3.Vacunar(vacuna6, DateTime.Now, DateTime.Now.AddMonths(6));

            ovino4.Vacunar(vacuna7, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino4.Vacunar(vacuna8, DateTime.Now, DateTime.Now.AddMonths(6));

            ovino5.Vacunar(vacuna9, DateTime.Now, DateTime.Now.AddMonths(6));
            ovino5.Vacunar(vacuna10, DateTime.Now, DateTime.Now.AddMonths(6));
        }

        public void VacunarBovino()
        {
            Animal bovino1 = ObtenerBovinoPorCodigoCaravana("Caravana1");
            Bovino bovino2 = ObtenerBovinoPorCodigoCaravana("Caravana5");
            Bovino bovino3 = ObtenerBovinoPorCodigoCaravana("Caravana10");
            Bovino bovino4 = ObtenerBovinoPorCodigoCaravana("Caravana15");
            Bovino bovino5 = ObtenerBovinoPorCodigoCaravana("Caravana20");

            if (bovino1 is null || bovino2 is null || bovino3 is null || bovino4 is null || bovino5 is null) throw new ArgumentNullException("Object Null. Sistema\\VacunarBovino() \n");

            Vacuna vacuna1 = ObtenerVacunaPorNombre("Vacuna Antitetánica");
            Vacuna vacuna2 = ObtenerVacunaPorNombre("Vacuna Anticlostridial");
            Vacuna vacuna3 = ObtenerVacunaPorNombre("Vacuna Anticarbuncloso");
            Vacuna vacuna4 = ObtenerVacunaPorNombre("Vacuna Antileptospira");
            Vacuna vacuna5 = ObtenerVacunaPorNombre("Vacuna Antibrucelosis");
            Vacuna vacuna6 = ObtenerVacunaPorNombre("Vacuna Antipasteurelosis");
            Vacuna vacuna7 = ObtenerVacunaPorNombre("Vacuna Antirabia");
            Vacuna vacuna8 = ObtenerVacunaPorNombre("Vacuna Antiviral");
            Vacuna vacuna9 = ObtenerVacunaPorNombre("Vacuna Antiparasitaria");
            Vacuna vacuna10 = ObtenerVacunaPorNombre("Vacuna Anticoccidial");

            if (vacuna1 is null || vacuna2 is null || vacuna3 is null || vacuna4 is null || vacuna5 is null || vacuna6 is null || vacuna7 is null || vacuna8 is null || vacuna9 is null || vacuna10 is null) throw new ArgumentNullException("Object Null Sistema\\VacunarBovino() \n");

            bovino1.Vacunar(vacuna1, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino1.Vacunar(vacuna2, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino1.Vacunar(vacuna3, DateTime.Now, DateTime.Now.AddMonths(6));

            bovino2.Vacunar(vacuna3, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino2.Vacunar(vacuna4, DateTime.Now, DateTime.Now.AddMonths(6));

            bovino3.Vacunar(vacuna5, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino3.Vacunar(vacuna6, DateTime.Now, DateTime.Now.AddMonths(6));

            bovino4.Vacunar(vacuna7, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino4.Vacunar(vacuna8, DateTime.Now, DateTime.Now.AddMonths(6));

            bovino5.Vacunar(vacuna9, DateTime.Now, DateTime.Now.AddMonths(6));
            bovino5.Vacunar(vacuna10, DateTime.Now, DateTime.Now.AddMonths(6));
        }

        public void AltaPotrero(Potrero potrero)
        {
            try
            {
                if (potrero is null) throw new ArgumentNullException("Object Null Sistema\\AltaPotrero(Potrero potrero) \n");
                potrero.Validar();
                if (_potreros.Contains(potrero)) throw new ArgumentException("Potrero ya Existe en Sistema\\List<Potrero> _potreros \n");
                _potreros.Add(potrero);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        public void PrecargarPotrero()
        {
            AltaPotrero(new Potrero("Potrero 1", 20, 50));
            AltaPotrero(new Potrero("Potrero 2", 15, 40));
            AltaPotrero(new Potrero("Potrero 3", 25, 60));
            AltaPotrero(new Potrero("Potrero 4", 18, 45));
            AltaPotrero(new Potrero("Potrero 5", 22, 55));
            AltaPotrero(new Potrero("Potrero 6", 17, 42));
            AltaPotrero(new Potrero("Potrero 7", 21, 58));
            AltaPotrero(new Potrero("Potrero 8", 19, 48));
            AltaPotrero(new Potrero("Potrero 9", 23, 63));
            AltaPotrero(new Potrero("Potrero 10", 16, 38));
        }

        public void AltaVacuna(Vacuna vacuna)
        {
            try
            {
                if (vacuna is null) throw new ArgumentNullException("Object Null Sistema\\AltaVacuna(Vacuna vacuna) \n");
                vacuna.Validar();
                if (_vacunas.Contains(vacuna)) throw new ArgumentException("Vacuna ya Existe en Sistema\\List<Vacuna> _vacunas \n");
                _vacunas.Add(vacuna);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        public void PrecargarVacuna()
        {
            AltaVacuna(new Vacuna("Vacuna Antitetánica", "Protege contra el tétanos", "Clostridium tetani"));
            AltaVacuna(new Vacuna("Vacuna Anticlostridial", "Protege contra las infecciones por clostridios", "Clostridium perfringens"));
            AltaVacuna(new Vacuna("Vacuna Anticarbuncloso", "Protege contra el ántrax", "Bacillus anthracis"));
            AltaVacuna(new Vacuna("Vacuna Antileptospira", "Protege contra la leptospirosis", "Leptospira spp."));
            AltaVacuna(new Vacuna("Vacuna Antibrucelosis", "Protege contra la brucelosis", "Brucella abortus"));
            AltaVacuna(new Vacuna("Vacuna Antipasteurelosis", "Protege contra la pasteurelosis", "Pasteurella multocida"));
            AltaVacuna(new Vacuna("Vacuna Antirabia", "Protege contra la rabia", "Virus de la rabia"));
            AltaVacuna(new Vacuna("Vacuna Antiviral", "Protege contra enfermedades virales", "Diferentes virus"));
            AltaVacuna(new Vacuna("Vacuna Antiparasitaria", "Protege contra parásitos internos y externos", "Diferentes parásitos"));
            AltaVacuna(new Vacuna("Vacuna Anticoccidial", "Protege contra la coccidiosis", "Diferentes especies de coccidios"));
        }

        public void AltaAnimal(Animal animal)
        {
            if (animal is null) throw new ArgumentNullException("Object Null Sistema\\AltaAnimal(Animal animal) \n");
            animal.Validar();
            if (_animales.Contains(animal)) throw new ArgumentException("Ovino ya Existe en Sistema\\List<Animal> _animales \n");
            _animales.Add(animal);
        }

        public void PrecargarAnimal()
        {
            /** Ovinos **/
            AltaAnimal(new Ovino("Caravana1", Sexo.Macho, "Raza1", new DateTime(2019, 01, 15), 1500, 200, 30.5, false, 5.2, 15, 20));
            AltaAnimal(new Ovino("Caravana2", Sexo.Hembra, "Raza2", new DateTime(2020, 03, 22), 1600, 220, 35.2, true, 6.8, 18, 22));
            AltaAnimal(new Ovino("Caravana3", Sexo.Macho, "Raza3", new DateTime(2021, 05, 10), 1700, 240, 32.7, false, 5.9, 16, 21));
            AltaAnimal(new Ovino("Caravana4", Sexo.Hembra, "Raza4", new DateTime(2022, 07, 03), 1800, 260, 38.1, true, 7.5, 20, 25));
            AltaAnimal(new Ovino("Caravana5", Sexo.Macho, "Raza5", new DateTime(2023, 09, 18), 1900, 280, 36.8, false, 6.3, 17, 23));
            AltaAnimal(new Ovino("Caravana6", Sexo.Hembra, "Raza6", new DateTime(2024, 11, 25), 2000, 300, 42.4, true, 8.1, 22, 27));
            AltaAnimal(new Ovino("Caravana7", Sexo.Macho, "Raza7", new DateTime(2025, 12, 10), 2100, 320, 39.6, false, 7.2, 19, 24));
            AltaAnimal(new Ovino("Caravana8", Sexo.Hembra, "Raza8", new DateTime(2026, 10, 06), 2200, 340, 45.3, true, 9.3, 25, 30));
            AltaAnimal(new Ovino("Caravana9", Sexo.Macho, "Raza9", new DateTime(2027, 08, 30), 2300, 360, 43.9, false, 8.5, 23, 28));
            AltaAnimal(new Ovino("Caravana10", Sexo.Hembra, "Raza10", new DateTime(2028, 07, 20), 2400, 380, 49.7, true, 10.2, 27, 33));
            AltaAnimal(new Ovino("Caravana11", Sexo.Macho, "Raza11", new DateTime(2018, 02, 14), 1500, 200, 34.2, false, 6.1, 17, 22));
            AltaAnimal(new Ovino("Caravana12", Sexo.Hembra, "Raza12", new DateTime(2017, 04, 03), 1600, 220, 40.5, true, 7.9, 21, 26));
            AltaAnimal(new Ovino("Caravana13", Sexo.Macho, "Raza13", new DateTime(2016, 06, 27), 1700, 240, 37.8, false, 7.0, 18, 23));
            AltaAnimal(new Ovino("Caravana14", Sexo.Hembra, "Raza14", new DateTime(2015, 08, 12), 1800, 260, 44.6, true, 8.8, 24, 29));
            AltaAnimal(new Ovino("Caravana15", Sexo.Macho, "Raza15", new DateTime(2014, 10, 05), 1900, 280, 41.3, false, 7.7, 20, 25));
            AltaAnimal(new Ovino("Caravana16", Sexo.Hembra, "Raza16", new DateTime(2013, 12, 20), 2000, 300, 47.9, true, 9.6, 26, 31));
            AltaAnimal(new Ovino("Caravana17", Sexo.Macho, "Raza17", new DateTime(2012, 07, 18), 2100, 320, 45.2, false, 8.4, 22, 27));
            AltaAnimal(new Ovino("Caravana18", Sexo.Hembra, "Raza18", new DateTime(2011, 05, 30), 2200, 340, 51.8, true, 10.7, 28, 34));
            AltaAnimal(new Ovino("Caravana19", Sexo.Macho, "Raza19", new DateTime(2010, 03, 25), 2300, 360, 49.1, false, 9.2, 24, 29));
            AltaAnimal(new Ovino("Caravana20", Sexo.Hembra, "Raza20", new DateTime(2009, 01, 15), 2400, 380, 55.7, true, 11.3, 30, 35));
            AltaAnimal(new Ovino("Caravana21", Sexo.Macho, "Raza1", new DateTime(2010, 1, 1), 1500, 200, 30.5, false, 5.2, 15, 40));
            AltaAnimal(new Ovino("Caravana22", Sexo.Hembra, "Raza2", new DateTime(2011, 1, 1), 1600, 220, 35.2, true, 6.8, 18, 45));
            AltaAnimal(new Ovino("Caravana23", Sexo.Macho, "Raza3", new DateTime(2012, 1, 1), 1700, 240, 32.7, false, 5.9, 16, 50));
            AltaAnimal(new Ovino("Caravana24", Sexo.Hembra, "Raza4", new DateTime(2013, 1, 1), 1800, 260, 38.1, true, 7.5, 20, 55));
            AltaAnimal(new Ovino("Caravana25", Sexo.Macho, "Raza5", new DateTime(2014, 1, 1), 1900, 280, 36.8, false, 6.3, 17, 60));
            AltaAnimal(new Ovino("Caravana26", Sexo.Hembra, "Raza6", new DateTime(2015, 1, 1), 2000, 300, 42.4, true, 8.1, 22, 65));
            AltaAnimal(new Ovino("Caravana27", Sexo.Macho, "Raza7", new DateTime(2016, 1, 1), 2100, 320, 39.6, false, 7.2, 19, 70));
            AltaAnimal(new Ovino("Caravana28", Sexo.Hembra, "Raza8", new DateTime(2017, 1, 1), 2200, 340, 45.3, true, 9.3, 25, 75));
            AltaAnimal(new Ovino("Caravana29", Sexo.Macho, "Raza9", new DateTime(2018, 1, 1), 2300, 360, 43.9, false, 8.5, 23, 80));
            AltaAnimal(new Ovino("Caravana30", Sexo.Hembra, "Raza10", new DateTime(2019, 1, 1), 2400, 380, 49.7, true, 10.2, 27, 85));

            /** Bovinos **/
            AltaAnimal(new Bovino("Caravana1", Sexo.Macho, "Angus", new DateTime(2019, 01, 15), 1500, 200, 300, false, TipoAlimentacion.Grano, 25));
            AltaAnimal(new Bovino("Caravana2", Sexo.Hembra, "Hereford", new DateTime(2020, 03, 22), 1600, 220, 320, true, TipoAlimentacion.Pastura, 30));
            AltaAnimal(new Bovino("Caravana3", Sexo.Macho, "Simmental", new DateTime(2021, 05, 10), 1700, 240, 340, false, TipoAlimentacion.Grano, 35));
            AltaAnimal(new Bovino("Caravana4", Sexo.Hembra, "Angus", new DateTime(2022, 07, 03), 1800, 260, 360, true, TipoAlimentacion.Pastura, 40));
            AltaAnimal(new Bovino("Caravana5", Sexo.Macho, "Hereford", new DateTime(2023, 09, 18), 1900, 280, 380, false, TipoAlimentacion.Grano, 45));
            AltaAnimal(new Bovino("Caravana6", Sexo.Hembra, "Simmental", new DateTime(2024, 11, 25), 2000, 300, 400, true, TipoAlimentacion.Pastura, 50));
            AltaAnimal(new Bovino("Caravana7", Sexo.Macho, "Angus", new DateTime(2025, 12, 10), 2100, 320, 420, false, TipoAlimentacion.Grano, 55));
            AltaAnimal(new Bovino("Caravana8", Sexo.Hembra, "Hereford", new DateTime(2026, 10, 06), 2200, 340, 440, true, TipoAlimentacion.Pastura, 60));
            AltaAnimal(new Bovino("Caravana9", Sexo.Macho, "Simmental", new DateTime(2027, 08, 30), 2300, 360, 460, false, TipoAlimentacion.Grano, 65));
            AltaAnimal(new Bovino("Caravana10", Sexo.Hembra, "Angus", new DateTime(2028, 07, 20), 2400, 380, 480, true, TipoAlimentacion.Pastura, 70));
            AltaAnimal(new Bovino("Caravana11", Sexo.Macho, "Hereford", new DateTime(2018, 02, 14), 1500, 200, 300, false, TipoAlimentacion.Grano, 75));
            AltaAnimal(new Bovino("Caravana12", Sexo.Hembra, "Simmental", new DateTime(2017, 04, 03), 1600, 220, 320, true, TipoAlimentacion.Pastura, 80));
            AltaAnimal(new Bovino("Caravana13", Sexo.Macho, "Angus", new DateTime(2016, 06, 27), 1700, 240, 340, false, TipoAlimentacion.Grano, 85));
            AltaAnimal(new Bovino("Caravana14", Sexo.Hembra, "Hereford", new DateTime(2015, 08, 12), 1800, 260, 360, true, TipoAlimentacion.Pastura, 90));
            AltaAnimal(new Bovino("Caravana15", Sexo.Macho, "Simmental", new DateTime(2014, 10, 05), 1900, 280, 380, false, TipoAlimentacion.Grano, 95));
            AltaAnimal(new Bovino("Caravana16", Sexo.Hembra, "Angus", new DateTime(2013, 12, 20), 2000, 300, 400, true, TipoAlimentacion.Pastura, 100));
            AltaAnimal(new Bovino("Caravana17", Sexo.Macho, "Hereford", new DateTime(2012, 07, 18), 2100, 320, 420, false, TipoAlimentacion.Grano, 105));
            AltaAnimal(new Bovino("Caravana18", Sexo.Hembra, "Simmental", new DateTime(2011, 05, 30), 2200, 340, 440, true, TipoAlimentacion.Pastura, 110));
            AltaAnimal(new Bovino("Caravana19", Sexo.Macho, "Angus", new DateTime(2010, 03, 25), 2300, 360, 460, false, TipoAlimentacion.Grano, 115));
            AltaAnimal(new Bovino("Caravana20", Sexo.Hembra, "Hereford", new DateTime(2009, 01, 15), 2400, 380, 480, true, TipoAlimentacion.Pastura, 120));
            AltaAnimal(new Bovino("Caravana21", Sexo.Macho, "Angus", new DateTime(2023, 01, 15), 1500, 200, 300, false, TipoAlimentacion.Grano, 125));
            AltaAnimal(new Bovino("Caravana22", Sexo.Hembra, "Hereford", new DateTime(2020, 03, 22), 1600, 220, 320, true, TipoAlimentacion.Pastura, 130));
            AltaAnimal(new Bovino("Caravana23", Sexo.Macho, "Simmental", new DateTime(2021, 05, 10), 1700, 240, 340, false, TipoAlimentacion.Grano, 135));
            AltaAnimal(new Bovino("Caravana24", Sexo.Hembra, "Angus", new DateTime(2022, 07, 03), 1800, 260, 360, true, TipoAlimentacion.Pastura, 140));
            AltaAnimal(new Bovino("Caravana25", Sexo.Macho, "Hereford", new DateTime(2023, 09, 18), 1900, 280, 380, false, TipoAlimentacion.Grano, 145));
            AltaAnimal(new Bovino("Caravana26", Sexo.Hembra, "Simmental", new DateTime(2024, 11, 25), 2000, 300, 400, true, TipoAlimentacion.Pastura, 150));
            AltaAnimal(new Bovino("Caravana27", Sexo.Macho, "Angus", new DateTime(2025, 12, 10), 2100, 320, 420, false, TipoAlimentacion.Grano, 155));
            AltaAnimal(new Bovino("Caravana28", Sexo.Hembra, "Hereford", new DateTime(2026, 10, 06), 2200, 340, 440, true, TipoAlimentacion.Pastura, 160));
            AltaAnimal(new Bovino("Caravana29", Sexo.Macho, "Simmental", new DateTime(2027, 08, 30), 2300, 360, 460, false, TipoAlimentacion.Grano, 165));
            AltaAnimal(new Bovino("Caravana30", Sexo.Hembra, "Angus", new DateTime(2028, 07, 20), 2400, 380, 480, true, TipoAlimentacion.Pastura, 170));
        }

        public void AltaTarea(Tarea tarea)
        {
            try
            {
                if (tarea is null) throw new ArgumentNullException("Object Null AltaTarea() \n");
                tarea.Validar();
                if (_tareas.Contains(tarea)) throw new ArgumentException("Tarea ya Existe en _tareas \n");
                _tareas.Add(tarea);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
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

        public void AltaEmpleado(Empleado empleado)
        {
            try
            {
                if (empleado is null) throw new ArgumentNullException("Object Null AltaEmpleado(Empleado empleado) \n");
                empleado.Validar();
                if (_empleados.Contains(empleado)) throw new ArgumentException("Capataz ya Existe en Sistema\\List<Empleado> _empleados \n");
                _empleados.Add(empleado);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        public void PrecargarEmpleado()
        {
            /** Peones **/
            AltaEmpleado(new Peon("peon1@email.com", "password1", "Juan", new DateTime(2022, 1, 1), true));
            AltaEmpleado(new Peon("peon2@email.com", "password2", "María", new DateTime(2022, 1, 2), false));
            AltaEmpleado(new Peon("peon3@email.com", "password3", "Carlos", new DateTime(2022, 1, 3), true));
            AltaEmpleado(new Peon("peon4@email.com", "password4", "Ana", new DateTime(2022, 1, 4), false));
            AltaEmpleado(new Peon("peon5@email.com", "password5", "Pedro", new DateTime(2022, 1, 5), true));
            AltaEmpleado(new Peon("peon6@email.com", "password6", "Luis", new DateTime(2022, 1, 6), false));
            AltaEmpleado(new Peon("peon7@email.com", "password7", "Sofía", new DateTime(2022, 1, 7), true));
            AltaEmpleado(new Peon("peon8@email.com", "password8", "Elena", new DateTime(2022, 1, 8), false));
            AltaEmpleado(new Peon("peon9@email.com", "password9", "Diego", new DateTime(2022, 1, 9), true));
            AltaEmpleado(new Peon("peon10@email.com", "password10", "Laura", new DateTime(2022, 1, 10), false));

            /** Capataces **/
            AltaEmpleado(new Capataz("capataz1@email.com", "password1", "Juan", new DateTime(2022, 1, 1), 10));
            AltaEmpleado(new Capataz("capataz2@email.com", "password2", "María", new DateTime(2022, 1, 2), 8));
        }
        #endregion #region Métodos para Agregar o Modificar Información 

        #region Métodos Globales
        /** Métodos Globales **/
        public int InputNumber(string mensaje)
        {
            bool exito = false;
            int inputNumero = 0;

            while (!exito)
            {
                try
                {
                    Resaltar(mensaje + "\n", ConsoleColor.DarkBlue);

                    exito = int.TryParse(Console.ReadLine(), out inputNumero);

                    Console.WriteLine();

                    if (!exito) throw new ArgumentOutOfRangeException("Número Incorrecto. InputText(string mensaje) \n");
                }
                catch (Exception e)
                {
                    Error(e.Message + "\n");
                }
            }

            return inputNumero;
        }

        public string InputText(string mensaje)
        {
            bool exito = false;
            string? inputText = string.Empty;

            try
            {
                while (!exito)
                {
                    Resaltar(mensaje + "\n", ConsoleColor.DarkBlue);

                    inputText = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputText)) throw new ArgumentException("InputText Vacío. InputString(string mensaje) \n");
                }
            }
            catch (Exception e)
            {
                Error(e.Message + "\n");
            }

            return inputText;
        }

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
        #endregion Métodos Globales
    }
}
