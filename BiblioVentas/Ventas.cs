using System;
using BilioSubMenus;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioVentas
{
    public class Ventas
    {
        public static int Venta()
        {
            string[] arregloMenu = { "REGISTRA", "VENTAS", "REPORTES", "MODIFICAR", "AYUDA", "SALIR" };
            string[] opciones = { "BOLETA", "FACTURA", "GUIA REM", "PROFORMA", "VOLVER" };

            int opcion = 0;
            int alineaIzquierda = 1;
            ConsoleKey tecla;
            Console.Clear();

            ClaseInterfaz.Interfaz();

            for (int i = 0; i < arregloMenu.Length; i++)
            {
                Console.SetCursorPosition(alineaIzquierda, 3);

                if (i == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write("                 ");
                Console.SetCursorPosition(alineaIzquierda + 4, 3);
                Console.Write(arregloMenu[i]);
                Console.ResetColor();

                alineaIzquierda = alineaIzquierda + 18;
            }

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(40, 1);
                Console.WriteLine("SISTEMA PARA GESTIONAR VENTAS");
                Console.ResetColor();

                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(20, 5 + (i * 2));

                    if (i == opcion)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write($"  {opciones[i]}  ");
                    Console.ResetColor();
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.UpArrow)
                {
                    opcion--;
                    if (opcion < 0) opcion = opciones.Length - 1;
                }

                else if (tecla == ConsoleKey.DownArrow)
                {
                    opcion++;
                    if (opcion >= opciones.Length) opcion = 0;
                }

                else if (tecla == ConsoleKey.Enter)
                {
                    return opcion;
                }
            }
        }
    }
}
