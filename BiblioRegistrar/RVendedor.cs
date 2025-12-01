using System;
using System.Collections.Generic;
using System.Linq;

namespace BiblioRegistrar
{
    public class RVendedor
    {
        public class Vendedores
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public int Sueldo { get; set; }
            public int Telefono { get; set; }
        }

        public static List<Vendedores> listaVendedores = new List<Vendedores>();

        public static void RegistrarVendedor()
        {
            // Limpiar zona de trabajo
            for (int y = 6; y <= 28; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 108));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(4, 6);
            Console.Write("╔═══════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(4, 7);
            Console.Write("║                REGISTRO DE VENDEDORES               ║");
            Console.SetCursorPosition(4, 8);
            Console.Write("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            int linea = 10;
            string codigo, nombre, apellidos;
            int sueldo, telefono;

            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Código: ");
                Console.SetCursorPosition(25, linea);
                codigo = Console.ReadLine().Trim();

                if (codigo == "")
                {
                    MostrarError("El código no puede estar vacío.", linea);
                    continue;
                }
                if (listaVendedores.Any(v => v.Codigo == codigo))
                {
                    MostrarError("El código ya existe.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Nombre: ");
                Console.SetCursorPosition(25, linea);
                nombre = Console.ReadLine().Trim();

                if (nombre == "")
                {
                    MostrarError("El nombre no puede estar vacío.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Apellidos: ");
                Console.SetCursorPosition(25, linea);
                apellidos = Console.ReadLine().Trim();

                if (apellidos == "")
                {
                    MostrarError("El apellido no puede estar vacío.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Sueldo: ");
                Console.SetCursorPosition(25, linea);
                string inputSueldo = Console.ReadLine().Trim();
                if (!int.TryParse(inputSueldo, out sueldo) || sueldo < 0)
                {
                    MostrarError("Ingresa un número válido para sueldo.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Teléfono (9 dígitos): ");
                Console.SetCursorPosition(25, linea);
                string inputTel = Console.ReadLine().Trim();

                if (inputTel == "")
                {
                    MostrarError("El teléfono no puede estar vacío.", linea);
                    continue;
                }
                if (!int.TryParse(inputTel, out telefono))
                {
                    MostrarError("Debe ingresar solo números.", linea);
                    continue;
                }
                if (inputTel.Length != 9)
                {
                    MostrarError("El teléfono debe tener 9 dígitos.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            listaVendedores.Add(new Vendedores
            {
                Codigo = codigo,
                Nombre = nombre,
                Apellidos = apellidos,
                Sueldo = sueldo,
                Telefono = telefono
            });

            linea += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(4, linea);
            Console.Write("Vendedor registrado correctamente.");
            Console.ResetColor();

            linea++;
            Console.SetCursorPosition(4, linea);
            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadKey(true);

            for (int y = 6; y <= 28; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 108));
            }
        }

        private static void MostrarError(string mensaje, int lineaInput)
        {
            int lineaError = lineaInput + 1;
            Console.SetCursorPosition(4, lineaError);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new string(' ', 80)); // limpiar línea de error
            Console.SetCursorPosition(4, lineaError);
            Console.Write(mensaje);
            Console.ResetColor();
        }

        private static void LimpiarError(int lineaInput)
        {
            int lineaError = lineaInput + 1;
            Console.SetCursorPosition(4, lineaError);
            Console.Write(new string(' ', 80));
        }
    }
}
