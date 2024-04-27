using ClassLibrary;
using System.Linq.Expressions;

namespace ConsoleApp
{
    internal class Program
    {
        private static Sistema sistema;

        static void Main(string[] args)
        {
            sistema = Sistema.Instancia;

            string? input;
            bool codigo = true;

            while (codigo)
            {
                // Console.Clear();

                sistema.Bienvenida();
                sistema.Menu();
                input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        sistema.ListarAnimales();
                        break;
                    case "2":
                        int hectareas = sistema.InputNumber("Ingresar Cantidad de Hectareas");
                        int numero = sistema.InputNumber("Ingresar Capacidad Máxima");
                        sistema.ListarPotrerosHectareasCapacidadMaxima(hectareas, numero);
                        break;
                    case "3":
                        int PrecioPorKiloLana = sistema.InputNumber("Ingrese Precio por kilogramo de Lana de los Ovinos:");
                        sistema.PrecioPorKiloLana(PrecioPorKiloLana);
                        break;
                    case "4":
                        sistema.ListarOvinos();
                        break;
                    case "0":
                        Sistema.Exito("Cerrando Aplicación de Consola ■■■■■□□□");
                        codigo = false;
                        break;
                    default:
                        Sistema.Error("❰❰❰❰ Seleccione Una Opción Correcta ❱❱❱❱ \n");
                        break;
                }
            }
        }
    }
}
