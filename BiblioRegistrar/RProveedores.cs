using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRegistrar
{
    public class RProveedores
    {
        public class Proveedores
        {
            public string Codigo { get; set; }
            public string Empresa { get; set; }
            public string RUC { get; set; }
            public string Representante { get; set; }
            public int Telefono { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }

        }

        public static List<Proveedores> listaProveedores = new List<Proveedores>();

        public static void RegistrarProveedor()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE PROVEEDORES ===\n");

            string codigo;
            while (true)
            {
                Console.Write("Ingresa Codigo del Proveedor: ");
                codigo = Console.ReadLine().Trim();

                if (codigo == "")
                {
                    Console.WriteLine("ERROR. Codigo no puede estar vacío.\n");
                    continue;
                }

                if (!int.TryParse(codigo, out _))
                {
                    Console.WriteLine("ERROR: Debe ser un número.\n");
                    continue;
                }

                bool existe = listaProveedores.Any(c => c.Codigo == codigo);
                if (existe)
                {
                    Console.WriteLine("ERROR: El Codigo ya existe.\n");
                    continue;
                }

                break;
            }

            string nombre;
            while (true)
            {
                Console.Write("Ingresa su Nombre de la Empresa Proveedora: ");
                nombre = Console.ReadLine().Trim();
                if (nombre == "")
                {
                    Console.WriteLine("ERROR: El nombre no puede estar vacío.\n");
                    continue;
                }
                break;
            }

            string ruc;
            while (true)
            {
                Console.Write("Ingresa su Numero de Ruc: ");
                ruc = Console.ReadLine().Trim();
                if (ruc == "")
                {
                    Console.WriteLine("ERROR: El RUC no puede estar vacio.\n");
                    continue;
                }
                if (!int.TryParse(ruc, out _))
                {
                    Console.WriteLine("ERROR: Debe ser un número.\n");
                    continue;
                }
                if (ruc.Length != 11)
                {
                    Console.WriteLine("ERROR: Debe tener 8 dígitos.\n");
                    continue;
                }
                bool existe = listaProveedores.Any(c => c.RUC == ruc);
                if (existe)
                {
                    Console.WriteLine("ERROR: El DNI ya existe.\n");
                    continue;
                }
                break;
            }

            string representante;
            while (true)
            {
                Console.Write("Ingrese el Nombre del Representante: ");
                representante = Console.ReadLine().Trim();
                if (representante == "")
                {
                    Console.WriteLine("ERROR:El nombre no puede estar vacio.\n");
                    continue;
                }
                break;
            }

            int telefono;
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

            string direccion;
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

            string ciudad;
            while (true)
            {
                Console.WriteLine("Ingrese su Ciudad: ");
                ciudad = Console.ReadLine();
                if (ciudad == "")
                {
                    Console.WriteLine("ERROR: La ciudad no puede estar vacio.\n");
                    continue;
                }
                break;
            }

            listaProveedores.Add(new Proveedores
            {
                Codigo = codigo,
                Empresa = nombre,
                RUC = ruc,
                Representante = representante,
                Telefono = telefono,
                Direccion = direccion,
                Ciudad = ciudad

            });

            Console.WriteLine("\nProveedor registrado correctamente.");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
