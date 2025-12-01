using System;
using BilioSubMenus;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilioSubMenus
{
    public class ClaseInterfaz
    {
        public static void Interfaz()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 110; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
            
                    Console.Write(" ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 1);
            Console.Write("SISTEMA PARA GESTIONAR VENTAS");
            Console.ResetColor();

            for (int i = 0; i < 110; i++)
            {
                Console.SetCursorPosition(i, 4);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.ResetColor();

                Console.SetCursorPosition(i, 29);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.ResetColor();

            }

            for (int i = 4; i < 29; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.ResetColor();

                Console.SetCursorPosition(109, i);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.ResetColor();
            }
        }

        public static int Menu()
        {
            string[] arregloMenu = { "REGISTRA", "VENTAS", "REPORTES", "MODIFICAR", "AYUDA", "SALIR" };

            int opcion = 0;
            ConsoleKey tecla;

            while (true)
            {

                Console.CursorVisible = false;

                int alineaIzquierda = 1;

                for (int i = 0; i < arregloMenu.Length; i++)
                {
                    Console.SetCursorPosition(alineaIzquierda, 3);

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

                    Console.Write("                 ");
                    Console.SetCursorPosition(alineaIzquierda + 4, 3);
                    Console.Write(arregloMenu[i]);
                    Console.ResetColor();

                    alineaIzquierda = alineaIzquierda + 18;
                }

                tecla = Console.ReadKey(true).Key;

                if (tecla == ConsoleKey.RightArrow)
                {
                    opcion++;
                    if (opcion >= arregloMenu.Length) opcion = 0;
                }

                else if (tecla == ConsoleKey.LeftArrow)
                {
                    opcion--;
                    if (opcion < 0) opcion = arregloMenu.Length - 1;
                }
                else if (tecla == ConsoleKey.Enter)
                {
                    return opcion;
                }


            }
        }
    }
}
