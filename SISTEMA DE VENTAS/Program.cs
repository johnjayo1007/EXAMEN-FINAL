using System;
using BilioSubMenus;
using BiblioRegistrar;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_VENTAS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            ClaseInterfaz.Interfaz();

            while (true)
            {
                int op = ClaseInterfaz.Menu();
                Console.SetCursorPosition(0, 29);

                switch (op)
                {
                    case 0:
                        SubMenus.SubMenuRegistrar();
                        break;
                    case 1:
                        SubMenus.SubMenuVenta();
                        break;
                    case 2:
                        SubMenus.SubMenuReportes();
                        break;

                    case 3:
                        Console.SetCursorPosition(5, 20);
                        Console.WriteLine("En proceso");
                        Console.ReadKey(true);
                        Console.Clear();
                        ClaseInterfaz.Interfaz();
                        break;

                    case 4:
                        Console.SetCursorPosition(5, 20);
                        Console.WriteLine("En Proceso");
                        Console.ReadKey(true);
                        Console.Clear();
                        ClaseInterfaz.Interfaz();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Saliendo del programa...");
                        break;
                }
                if (op == 5)
                    break;

            }
        }
    }
}
