using System;
using System.Collections.Generic;
using System.Linq;

namespace BiblioRegistrar
{
    public class RCliente
    {
        public class Cliente
        {
            public string DNI { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Telefono { get; set; }
            public string Email { get; set; }
            public string Direccion { get; set; }
        }

        public static List<Cliente> listaClientes = new List<Cliente>();

        public static void RegistrarCliente()
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
            Console.Write("║                REGISTRO DE CLIENTES                   ║");
            Console.SetCursorPosition(4, 8);
            Console.Write("╚═══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            int linea = 10;
            string dni, nombre, apellido, email, direccion;
            int telefono;

            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("DNI (8 dígitos): ");
                Console.SetCursorPosition(25, linea);
                dni = Console.ReadLine().Trim();

                if (dni == "")
                {
                    MostrarError("El DNI no puede estar vacío.", linea);
                    continue;
                }
                if (!int.TryParse(dni, out _))
                {
                    MostrarError("El DNI debe ser numérico.", linea);
                    continue;
                }
                if (dni.Length != 8)
                {
                    MostrarError("Debe tener 8 dígitos.", linea);
                    continue;
                }
                if (listaClientes.Any(c => c.DNI == dni))
                {
                    MostrarError("El DNI ya existe.", linea);
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
                apellido = Console.ReadLine().Trim();

                if (apellido == "")
                {
                    MostrarError("El apellido es obligatorio.", linea);
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
                Console.SetCursorPosition(28, linea);
                string cel = Console.ReadLine().Trim();

                if (cel == "")
                {
                    MostrarError("El teléfono no puede estar vacío.", linea);
                    continue;
                }
                if (!int.TryParse(cel, out telefono))
                {
                    MostrarError("Debe ingresar solo números.", linea);
                    continue;
                }
                if (cel.Length != 9)
                {
                    MostrarError("Debe tener 9 dígitos.", linea);
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            linea++;
            while (true)
            {
                Console.SetCursorPosition(4, linea);
                Console.Write("Correo (Email): ");
                Console.SetCursorPosition(25, linea);
                email = Console.ReadLine().Trim();

                if (email == "")
                {
                    MostrarError("El email no puede estar vacío.", linea);
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
                    continue;
                }
                LimpiarError(linea);
                break;
            }

            listaClientes.Add(new Cliente
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Email = email,
                Direccion = direccion
            });

            linea += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(4, linea);
            Console.Write("Cliente registrado correctamente.");
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

            Console.Write(new string(' ', 80));

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
