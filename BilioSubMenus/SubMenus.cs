using BiblioRegistrar;
using BiblioReportes;
using BiblioVentas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilioSubMenus
{
    public class SubMenus
    {
        public static void SubMenuRegistrar()
        {
            int sub;
            do
            {
                sub = Registrar.Registra();

                switch (sub)
                {
                    case 0:
                        RProducto.RegistrarProducto();
                        break;

                    case 1:
                        RCliente.RegistrarCliente();
                        break;

                    case 2:
                        RVendedor.RegistrarVendedor();
                        break;

                    case 3:
                        RProveedores.RegistrarProveedor();
                        break;

                }
            } while (sub != -1);

        }

        public static void SubmenuVentas()
        {
            int sub;
            do
            {
                sub = Ventas.Venta();

                switch (sub)
                {
                    case 0:
                        VBoletas.MostrarBoleta();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Seguimos trabajando...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                }
            }
            while (sub != 4);
        }

        public static void SubMenuReportes()
        {
            string[] opciones = {
            "REPORTE DE CLIENTES",
            "REPORTE DE PRODUCTOS",
            "REPORTE DE VENDEDORES",
            "REPORTE DE PROVEEDORES"
            };

            int opcion = 0;
            ConsoleKey tecla;

            while (true)
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.Yellow;

                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(5, 10 + i);

                    if (i == opcion)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write(opciones[i].PadRight(40));
                }

                Console.ResetColor();

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow)
                {
                    opcion = (opcion == 0) ? opciones.Length - 1 : opcion - 1;
                }
                else if (tecla == ConsoleKey.DownArrow)
                {
                    opcion = (opcion == opciones.Length - 1) ? 0 : opcion + 1;
                }
                else if (tecla == ConsoleKey.Enter)
                {
                    Reportes.MostrarReporte(opcion);
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    for (int y = 5; y <= 25; y++)
                    {
                        Console.SetCursorPosition(1, y);
                        Console.Write(new string(' ', 108));
                    }

                    Console.ResetColor();
                    return;
                }
            }
        }


    }
}
