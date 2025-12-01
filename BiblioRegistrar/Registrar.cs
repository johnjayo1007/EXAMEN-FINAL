using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRegistrar
{
    public class Registrar
    {
        public static int Registra()
        {
            string[] opciones = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEEDORES" };

            int opcion = 0;
            ConsoleKey tecla;

            Console.CursorVisible = false;

            while (true)
            {
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(1, 5 + i);

                    if (i == opcion)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
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
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        Console.SetCursorPosition(1, 5 + i);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("                      ");
                        Console.ResetColor();
                    }
                    return opcion;
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        Console.SetCursorPosition(1, 5 + i);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("                      ");
                        Console.ResetColor();
                    }
                    return -1;
                }
            }
        }
    }
}
