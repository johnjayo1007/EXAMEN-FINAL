using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE CLIENTES ===\n");

            string dni;
            string nombre;
            int telefono;
            string email;
            string direccion;
            string apellido;

            while (true)
            {
                Console.Write("Ingresa DNI (8 dígitos): ");
                dni = Console.ReadLine().Trim();

                if (dni == "")
                {
                    Console.WriteLine("ERROR. DNI no puede estar vacío.\n");
                    continue;
                }

                if (!int.TryParse(dni, out _))
                {
                    Console.WriteLine("ERROR: Debe ser un número.\n");
                    continue;
                }

                if (dni.Length != 8)
                {
                    Console.WriteLine("ERROR: Debe tener 8 dígitos.\n");
                    continue;
                }

                bool existe = listaClientes.Any(c => c.DNI == dni);
                if (existe)
                {
                    Console.WriteLine("ERROR: El DNI ya existe.\n");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Ingresa su Nombre: ");
                nombre = Console.ReadLine().Trim();
                if (nombre == "")
                {
                    Console.WriteLine("ERROR: El nombre no puede estar vacío.\n");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Ingresa sus Apellidos: ");
                apellido = Console.ReadLine().Trim();
                if (apellido == "")
                {
                    Console.WriteLine("ERROR: El apellido no puede estar vacio.\n");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Ingrese su teléfono: ");
                string cel = Console.ReadLine().Trim();

                if (cel == "")
                {
                    Console.WriteLine("ERROR: El teléfono no puede estar en blanco.");
                    continue;
                }

                if (!int.TryParse(cel, out telefono))
                {
                    Console.WriteLine("ERROR: Debe ingresar solo números.");
                    continue;
                }
                if (cel.Length != 9)
                {
                    Console.WriteLine("ERROR: Debe tener 9 dígitos.\n");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Ingrese su Correo(Email): ");
                email = Console.ReadLine();
                if (email == "")
                {
                    Console.WriteLine("ERROR: EL email no puede estar vacio.\n");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Ingrese su Direccion: ");
                direccion = Console.ReadLine().Trim();
                if (direccion == "")
                {
                    Console.WriteLine("ERROR: La direccion no puede estar en blanco.\n");
                    continue;
                }
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

            Console.WriteLine("\nCliente registrado correctamente.");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
