using System;
using System.Collections.Generic;
using System.Linq;

namespace BiblioRegistrar
{
    public class RProducto
    {
        public class Producto
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public int Stock { get; set; }
            public decimal Precio { get; set; }
        }

        public static List<Producto> listaProductos = new List<Producto>();

        public static void RegistrarProducto()
        {
            for (int y = 6; y <= 28; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 108));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(4, 6);
            Console.Write("╔═══════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(4, 7);
            Console.Write("║               REGISTRO DE PRODUCTOS                 ║");
            Console.SetCursorPosition(4, 8);
            Console.Write("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            int linea = 10;
            string codigo, nombre, categoria;
            int stock;
            decimal precioU;

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
                if (listaProductos.Any(p => p.Codigo == codigo))
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
                if (listaProductos.Any(p => p.Nombre == nombre))
                {
                    MostrarError("El nombre ya existe.", linea);
                    continue;
                }

                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Categoría: ");
                Console.SetCursorPosition(25, linea);
                categoria = Console.ReadLine().Trim();

                if (categoria == "")
                {
                    MostrarError("La categoria no puede estar vacío.", linea);
                    continue;
                }

                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Stock: ");
                Console.SetCursorPosition(25, linea);
                string stockInput = Console.ReadLine().Trim();
                if (!int.TryParse(stockInput, out stock) || stock < 0)
                {
                    MostrarError("Ingresa un número válido para stock.", linea);
                    continue;
                }

                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Precio Unitario: ");
                Console.SetCursorPosition(25, linea);
                string precioInput = Console.ReadLine().Trim();
                if (!decimal.TryParse(precioInput, out precioU) || precioU < 0)
                {
                    MostrarError("Ingresa un precio válido.", linea);
                    continue;
                }

                LimpiarError(linea);
                break;
            }

            listaProductos.Add(new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Categoria = categoria,
                Stock = stock,
                Precio = precioU
            });

            linea += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(4, linea);
            Console.Write("Producto registrado correctamente.");
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
            Console.Write(new string(' ', 80)); // limpiar línea
            Console.SetCursorPosition(4, lineaError);
            Console.ForegroundColor = ConsoleColor.Red;
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
