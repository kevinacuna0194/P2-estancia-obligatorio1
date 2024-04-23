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

            string input = string.Empty;
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
                        break;
                    case "2":
                        Console.WriteLine("2");
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
