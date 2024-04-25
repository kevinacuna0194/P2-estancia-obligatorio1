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
                        sistema.ListarBovinos();
                        sistema.ListarOvinos();
                        break;
                    case "2":
                        int hectareas = sistema.InputNumber("Ingresar Cantidad de Hectareas");
                        int numero = sistema.InputNumber("Ingresar Número");
                        sistema.ListarPotrerosHectareasCapacidadMaxima(hectareas, numero);
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
