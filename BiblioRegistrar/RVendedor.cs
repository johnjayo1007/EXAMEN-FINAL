using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public decimal Telefono { get; set; }
        }

        public static List<Vendedores> listaVendedores = new List<Vendedores>();

        public static void RegistrarVendedor()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE VENDEDORES ===\n");

            string codigo;
            string nombre;
            string apellido;
            int sueldo;
            int telefono;

            while (true)
            {
                Console.Write("Código: ");
                codigo = Console.ReadLine().Trim();

                if (codigo == "")
                {
                    Console.WriteLine("ERROR: El código no puede estar vacío.\n");
                    continue;
                }

                bool existe = listaVendedores.Any(p => p.Codigo == codigo);
                if (existe)
                    Console.WriteLine("ERROR: El código ya existe.\n");
                else
                    break;
            }

            Console.Write("Nombre: ");
            nombre = Console.ReadLine().Trim();
            while (true)
            {
                if (nombre == "")
                {
                    Console.WriteLine("ERROR: El nombre no puede estar vacío.\n");
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Apellidos: ");
                apellido = Console.ReadLine().Trim();

                if (apellido == "")
                {
                    Console.WriteLine("ERROR. El apellido no puede estar vacio.\n");
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Sueldo: ");
                if (int.TryParse(Console.ReadLine(), out sueldo) && sueldo >= 0)
                    break;

                Console.WriteLine("ERROR: Ingresa un número válido.\n");
            }

            while (true)
            {
                Console.Write("Teléfono: ");
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

            listaVendedores.Add(new Vendedores
            {
                Codigo = codigo,
                Nombre = nombre,
                Apellidos = apellido,
                Sueldo = sueldo,
                Telefono = telefono
            });

            Console.WriteLine("\nProducto registrado exitosamente.");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
