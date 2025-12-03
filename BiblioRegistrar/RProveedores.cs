using System;
using System.Collections.Generic;
using System.Linq;

namespace BiblioRegistrar
{
    public class RProveedores
    {
        public class Proveedor
        {
            public string Codigo { get; set; }
            public string Empresa { get; set; }
            public string RUC { get; set; }
            public string Representante { get; set; }
            public int Telefono { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
        }

        public static List<Proveedor> listaProveedores = new List<Proveedor>();

        public static void RegistrarProveedor()
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
            Console.Write("║               REGISTRO DE PROVEEDORES               ║");
            Console.SetCursorPosition(4, 8);
            Console.Write("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            int linea = 10;
            string codigo, empresa, ruc, representante, direccion, ciudad;
            int telefono;

            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Código: ");
                Console.SetCursorPosition(25, linea);
                codigo = Console.ReadLine().Trim();

                if (codigo == "")
                {
                    MostrarError("El código no puede estar vacío.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (!int.TryParse(codigo, out _))
                {
                    MostrarError("El código debe ser numérico.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (listaProveedores.Any(p => p.Codigo == codigo))
                {
                    MostrarError("El código ya existe.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Empresa: ");
                Console.SetCursorPosition(25, linea);
                empresa = Console.ReadLine().Trim();

                if (empresa == "")
                {
                    MostrarError("El nombre de la empresa no puede estar vacío.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("RUC (11 dígitos): ");
                Console.SetCursorPosition(25, linea);
                ruc = Console.ReadLine().Trim();

                if (ruc == "")
                {
                    MostrarError("El RUC no puede estar vacío.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (!long.TryParse(ruc, out _))
                {
                    MostrarError("El RUC debe ser numérico.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (ruc.Length != 11)
                {
                    MostrarError("El RUC debe tener 11 dígitos.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (listaProveedores.Any(p => p.RUC == ruc))
                {
                    MostrarError("El RUC ya existe.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Representante: ");
                Console.SetCursorPosition(25, linea);
                representante = Console.ReadLine().Trim();

                if (representante == "")
                {
                    MostrarError("El nombre del representante no puede estar vacío.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

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
                string input = Console.ReadLine().Trim();

                if (input == "")
                {
                    MostrarError("El teléfono no puede estar vacío.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (!int.TryParse(input, out telefono))
                {
                    MostrarError("Debe ingresar solo números.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                if (input.Length != 9)
                {
                    MostrarError("El teléfono debe tener 9 dígitos.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Dirección: ");
                Console.SetCursorPosition(25, linea);
                direccion = Console.ReadLine().Trim();

                if (direccion == "")
                {
                    MostrarError("La dirección no puede estar vacía.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Ciudad: ");
                Console.SetCursorPosition(25, linea);
                ciudad = Console.ReadLine().Trim();

                if (ciudad == "")
                {
                    MostrarError("La ciudad no puede estar vacía.", linea);

                    Console.SetCursorPosition(25, linea);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(25, linea);

                    continue;
                }
                LimpiarError(linea);
                break;
            }

            listaProveedores.Add(new Proveedor
            {
                Codigo = codigo,
                Empresa = empresa,
                RUC = ruc,
                Representante = representante,
                Telefono = telefono,
                Direccion = direccion,
                Ciudad = ciudad
            });

            linea += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(4, linea);
            Console.Write("Proveedor registrado correctamente.");
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
            Console.Write(new string(' ', 80));
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

