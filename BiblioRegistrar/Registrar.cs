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
            string[] opciones = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEDORES" };

            int opcion = 0;
            ConsoleKey tecla;
            Console.Clear();
            Console.CursorVisible = false;

            for (int x = 8; x <= 60; x++)
            {
                Console.SetCursorPosition(x, 1);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }

            for (int x = 8; x <= 60; x++)
            {
                Console.SetCursorPosition(x, 18);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }

            for (int y = 1; y <= 18; y++)
            {
                Console.SetCursorPosition(8, y);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }

            for (int y = 1; y <= 18; y++)
            {
                Console.SetCursorPosition(60, y);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("=== SUB - MENÚ DE REGISTRO ===");
            Console.ResetColor();

            while (true)
            {
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(15, 6 + (i * 2));

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
                    Console.Clear();
                    return opcion;
                }
                else if (tecla == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return -1;
                }
            }
        }
    }
}
